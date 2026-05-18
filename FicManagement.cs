using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VainEscort.BLL;

// Alias stricts pour éviter les conflits avec System.Drawing
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

namespace Projet_VainEscort
{
    public partial class FicManagement : Form
    {
        private ManagementManager _manager;

        public FicManagement()
        {
            InitializeComponent();
            _manager = new ManagementManager();

            // Activation anti-scintillement pour les grilles
            if (dgvTurnover != null) ActiverDoubleBuffer(dgvTurnover);
            if (dgvProfitability != null) ActiverDoubleBuffer(dgvProfitability);
            if (dgvClientsAttitres != null) ActiverDoubleBuffer(dgvClientsAttitres);
        }

        private void FicManagement_Load(object sender, EventArgs e)
        {
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                // 1. Chiffre d'Affaires
                var dtCA = _manager.ChargerCA();
                if (dgvTurnover != null) dgvTurnover.DataSource = dtCA;

                // Graphique en mode Courbe (Spline)
                if (chartTurnover != null)
                {
                    chartTurnover.Series.Clear();
                    Series series = chartTurnover.Series.Add("CA Mensuel");

                    // Changement en courbe lissée (Spline)
                    series.ChartType = SeriesChartType.Spline;
                    series.BorderWidth = 3; // Ligne plus épaisse
                    series.MarkerStyle = MarkerStyle.Circle; // Ajoute des points sur la courbe
                    series.MarkerSize = 8;
                    series.IsValueShownAsLabel = true;

                    foreach (DataRow row in dtCA.Rows)
                    {
                        if (row["Mois"] != DBNull.Value && row["ChiffreAffaires"] != DBNull.Value)
                        {
                            string mois = row["Mois"].ToString();
                            double ca = Convert.ToDouble(row["ChiffreAffaires"]);
                            series.Points.AddXY(mois, ca);
                        }
                    }
                }

                // 2. Rentabilité avec Couleurs
                if (dgvProfitability != null)
                {
                    dgvProfitability.DataSource = _manager.ChargerRentabilite();
                    ColoriserRentabilite(); // Application des couleurs
                }

                // 3. Clients Attitrés
                if (dgvClientsAttitres != null) dgvClientsAttitres.DataSource = _manager.ChargerClientsAttitres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ajoute des couleurs dans le tableau de rentabilité pour repérer les meilleurs
        private void ColoriserRentabilite()
        {
            if (dgvProfitability.Rows.Count == 0 || !dgvProfitability.Columns.Contains("TotalGenere")) return;

            // 1. Trouver le revenu maximum pour créer une échelle
            double maxRevenu = 0;
            foreach (DataGridViewRow row in dgvProfitability.Rows)
            {
                if (row.Cells["TotalGenere"].Value != null && row.Cells["TotalGenere"].Value != DBNull.Value)
                {
                    double val = Convert.ToDouble(row.Cells["TotalGenere"].Value);
                    if (val > maxRevenu) maxRevenu = val;
                }
            }

            if (maxRevenu == 0) return;

            // 2. Colorier chaque ligne selon son score
            foreach (DataGridViewRow row in dgvProfitability.Rows)
            {
                if (row.Cells["TotalGenere"].Value != null && row.Cells["TotalGenere"].Value != DBNull.Value)
                {
                    double val = Convert.ToDouble(row.Cells["TotalGenere"].Value);
                    double ratio = val / maxRevenu; // Score de 0.0 à 1.0

                    // Application du code couleur (Vert pour les tops, Jaune moyen, Rouge faible)
                    if (ratio >= 0.7)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    else if (ratio >= 0.4)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                }
            }
        }

        // Action sur le bouton de génération du document PDF
        private void btnGenererPdfAttitres_Click(object sender, EventArgs e)
        {
            if (dgvClientsAttitres == null || dgvClientsAttitres.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée de clients attitrés à exporter.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Clients_Attitres_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GenererPdfClientsAttitresDirect(sfd.FileName);
                    MessageBox.Show("Le document des clients attitrés a été généré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la génération du PDF : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Logique de génération du PDF (Sécurisée avec Alias)
        private void GenererPdfClientsAttitresDirect(string cheminFichier)
        {
            iText.Document doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 40f, 40f);
            iTextPdf.PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            // --- CHARTE GRAPHIQUE ---
            iText.BaseColor couleurViolet = new iText.BaseColor(128, 0, 128);
            iText.BaseColor couleurBleu = new iText.BaseColor(26, 54, 93);
            iText.BaseColor couleurJaune = new iText.BaseColor(255, 215, 0);
            iText.BaseColor couleurGris = new iText.BaseColor(240, 240, 240);

            iText.Font policeTitre = iText.FontFactory.GetFont("Helvetica", 24, iText.Font.BOLD, couleurViolet);
            iText.Font policeNormal = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.NORMAL, iText.BaseColor.BLACK);
            iText.Font policeEnteteTab = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.WHITE);

            // --- EN-TÊTE ---
            iTextPdf.PdfPTable tableHeader = new iTextPdf.PdfPTable(2);
            tableHeader.WidthPercentage = 100;

            iTextPdf.PdfPCell cellLeft = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER };

            cellLeft.AddElement(new iText.Paragraph("VAINESCORT S.A.", policeTitre));
            cellLeft.AddElement(new iText.Paragraph("L'excellence à vos côtés.", iText.FontFactory.GetFont("Helvetica", 10, iText.Font.ITALIC, couleurBleu)));
            cellLeft.AddElement(new iText.Paragraph("Rue Sohet 14\n4000 Liège - Belgique", policeNormal));
            tableHeader.AddCell(cellLeft);

            iTextPdf.PdfPCell cellRight = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            iText.Paragraph infosDoc = new iText.Paragraph { Alignment = iText.Element.ALIGN_RIGHT };
            infosDoc.Add(new iText.Chunk("DOCUMENT INTERNE\n", iText.FontFactory.GetFont("Helvetica", 14, iText.Font.BOLD, couleurBleu)));
            infosDoc.Add(new iText.Chunk($"Date : {DateTime.Now:dd/MM/yyyy}\n", policeNormal));
            infosDoc.Add(new iText.Chunk("Registre des Clients Attitrés", iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurViolet)));
            cellRight.AddElement(infosDoc);
            tableHeader.AddCell(cellRight);

            doc.Add(tableHeader);

            // Séparation esthétique
            iText.pdf.draw.LineSeparator ligneSep = new iText.pdf.draw.LineSeparator(2f, 100f, couleurJaune, iText.Element.ALIGN_CENTER, -15f);
            doc.Add(new iText.Chunk(ligneSep));
            doc.Add(new iText.Paragraph("\n\n"));

            // --- TABLEAU DES DONNÉES ---
            iTextPdf.PdfPTable table = new iTextPdf.PdfPTable(4) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 25f, 25f, 20f, 30f });

            // INVERSION DES COLONNES ICI : "Client Attitré" en premier, puis "Employé(e)"
            string[] entetes = { "Client Attitré", "Employé(e)", "Téléphone", "Email" };
            foreach (string t in entetes)
            {
                iTextPdf.PdfPCell cellHeader = new iTextPdf.PdfPCell(new iText.Phrase(t, policeEnteteTab))
                {
                    BackgroundColor = couleurBleu,
                    Padding = 8f,
                    HorizontalAlignment = iText.Element.ALIGN_LEFT
                };
                table.AddCell(cellHeader);
            }

            bool ligneGrise = false;

            foreach (DataGridViewRow row in dgvClientsAttitres.Rows)
            {
                if (row.IsNewRow) continue;

                iText.BaseColor bgColor = ligneGrise ? couleurGris : iText.BaseColor.WHITE;

                string employeStr = row.Cells["Employe"]?.Value?.ToString() ?? "";
                string clientStr = row.Cells["Client"]?.Value?.ToString() ?? "";
                string telStr = row.Cells["TelephoneClient"]?.Value?.ToString() ?? "";
                string emailStr = row.Cells["EmailClient"]?.Value?.ToString() ?? "";

                // INVERSION DES DONNÉES ICI (Le Client est affiché avant l'Employé)
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(clientStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(employeStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(telStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(emailStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });

                ligneGrise = !ligneGrise;
            }

            doc.Add(table);
            doc.Close();
        }

        private void ActiverDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }
    }
}