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
            // Liaison des événements de boutons
            btnGenererPdfAttitres.Click -= btnGenererPdfAttitres_Click;
            btnGenererPdfAttitres.Click += btnGenererPdfAttitres_Click;

            btnCA.Click -= btnCA_Click;
            btnCA.Click += btnCA_Click;

            // Liaison du nouveau bouton pour le PDF de rentabilité des employés
            if (btnPdfRenta != null)
            {
                btnPdfRenta.Click -= btnPdfRenta_Click;
                btnPdfRenta.Click += btnPdfRenta_Click;
            }

            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                // 1. Onglet Chiffre d'Affaires
                DataTable dtCA = _manager.ChargerCA();
                if (dgvTurnover != null) dgvTurnover.DataSource = dtCA;
                MettreAJourGraphiqueCA(dtCA);

                // 2. Onglet Rentabilité
                if (dgvProfitability != null)
                {
                    dgvProfitability.DataSource = _manager.ChargerRentabilite();
                    ColoriserRentabilite();
                }

                // 3. Onglet Clients Attitrés
                if (dgvClientsAttitres != null)
                {
                    dgvClientsAttitres.DataSource = _manager.ChargerClientsAttitres();

                    // FORCE L'INVERSION DE L'AFFICHAGE DANS LA GRILLE WINFORMS
                    if (dgvClientsAttitres.Columns.Contains("Client") && dgvClientsAttitres.Columns.Contains("Employe"))
                    {
                        dgvClientsAttitres.Columns["Client"].DisplayIndex = 0;
                        dgvClientsAttitres.Columns["Employe"].DisplayIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MettreAJourGraphiqueCA(DataTable dt)
        {
            if (chartTurnover == null) return;

            chartTurnover.Series.Clear();
            chartTurnover.Titles.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                chartTurnover.Titles.Add("Aucune donnée disponible");
                return;
            }

            // Titre principal
            Title titre = chartTurnover.Titles.Add("Performances Chiffre d'Affaires");
            titre.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);

            Series series = chartTurnover.Series.Add("Performances CA");
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;
            series.Color = System.Drawing.Color.Purple;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;

            // Configuration adaptative de la zone de dessin
            if (chartTurnover.ChartAreas.Count > 0)
            {
                ChartArea aire = chartTurnover.ChartAreas[0];

                // CRITICAL : On laisse WinForms gérer l'espace automatiquement en fonction de la taille du contrôle
                aire.Position.Auto = true;
                aire.InnerPlotPosition.Auto = true;

                // Rendre les grilles plus discrètes lors de l'étirement
                aire.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
                aire.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);

                // Force les labels des axes à s'adapter (réduction/inclinaison auto si manque de place)
                aire.AxisX.LabelStyle.IsEndLabelVisible = true;
            }

            // Remplissage des données
            foreach (DataRow row in dt.Rows)
            {
                if (row["Mois"] != DBNull.Value && row["ChiffreAffaires"] != DBNull.Value)
                {
                    string mois = row["Mois"].ToString() ?? "";
                    if (double.TryParse(row["ChiffreAffaires"].ToString(), out double ca))
                    {
                        series.Points.AddXY(mois, ca);
                    }
                }
            }
        }

        private void ColoriserRentabilite()
        {
            if (dgvProfitability == null || dgvProfitability.Rows.Count == 0 || !dgvProfitability.Columns.Contains("TotalGenere")) return;

            double maxRevenu = 0;
            foreach (DataGridViewRow row in dgvProfitability.Rows)
            {
                if (row.Cells["TotalGenere"].Value != null && double.TryParse(row.Cells["TotalGenere"].Value.ToString(), out double val))
                {
                    if (val > maxRevenu) maxRevenu = val;
                }
            }

            if (maxRevenu <= 0) return;

            foreach (DataGridViewRow row in dgvProfitability.Rows)
            {
                if (row.Cells["TotalGenere"].Value != null && double.TryParse(row.Cells["TotalGenere"].Value.ToString(), out double val))
                {
                    double ratio = val / maxRevenu;
                    if (ratio >= 0.7) row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    else if (ratio >= 0.4) row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    else row.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                }
            }
        }

        private void btnGenererPdfAttitres_Click(object? sender, EventArgs e)
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
                    MessageBox.Show("Le document des clients attitrés a été généré !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la génération du PDF : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCA_Click(object? sender, EventArgs e)
        {
            if (dgvTurnover == null || dgvTurnover.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée de chiffre d'affaires à exporter.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Chiffre_Affaires_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GenererPdfChiffreAffaires(sfd.FileName);
                    MessageBox.Show("Le rapport du Chiffre d'Affaires a été généré !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la génération du PDF CA : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- ACTION BOUTON : PDF PERFORMANCES EMPLOYES (Nouveau !) ---
        private void btnPdfRenta_Click(object? sender, EventArgs e)
        {
            if (dgvProfitability == null || dgvProfitability.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée de rentabilité à exporter.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Performances_Employes_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GenererPdfRentabilite(sfd.FileName);
                    MessageBox.Show("Le rapport des performances employés a été généré !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la génération du PDF Performances : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenererPdfClientsAttitresDirect(string cheminFichier)
        {
            if (dgvClientsAttitres == null) return;

            iText.Document doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 40f, 40f);
            iTextPdf.PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            iText.BaseColor couleurViolet = new iText.BaseColor(128, 0, 128);
            iText.BaseColor couleurBleu = new iText.BaseColor(26, 54, 93);
            iText.BaseColor couleurGris = new iText.BaseColor(240, 240, 240);

            iText.Font policeTitre = iText.FontFactory.GetFont("Helvetica", 24, iText.Font.BOLD, couleurViolet);
            iText.Font policeNormal = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.NORMAL, iText.BaseColor.BLACK);
            iText.Font policeEnteteTab = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.WHITE);

            iTextPdf.PdfPTable tableHeader = new iTextPdf.PdfPTable(2) { WidthPercentage = 100 };
            iTextPdf.PdfPCell cellLeft = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER };
            cellLeft.AddElement(new iText.Paragraph("VAINESCORT S.A.", policeTitre));
            cellLeft.AddElement(new iText.Paragraph("Rue Sohet 14\n4000 Liège - Belgique", policeNormal));
            tableHeader.AddCell(cellLeft);

            iTextPdf.PdfPCell cellRight = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            iText.Paragraph infosDoc = new iText.Paragraph { Alignment = iText.Element.ALIGN_RIGHT };
            infosDoc.Add(new iText.Chunk("DOCUMENT INTERNE\n", iText.FontFactory.GetFont("Helvetica", 14, iText.Font.BOLD, couleurBleu)));
            infosDoc.Add(new iText.Chunk($"Date : {DateTime.Now:dd/MM/yyyy}\n", policeNormal));
            infosDoc.Add(new iText.Chunk("Registre des Clients Attitrés", iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurViolet)));
            tableHeader.AddCell(cellRight);
            doc.Add(tableHeader);

            doc.Add(new iText.Paragraph("\n"));

            iTextPdf.PdfPTable table = new iTextPdf.PdfPTable(4) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 25f, 25f, 20f, 30f });

            string[] entetes = { "Client", "Employé(e) associé(e)", "Téléphone Client", "Email Client" };
            foreach (string t in entetes)
            {
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(t, policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });
            }

            bool ligneGrise = false;
            foreach (DataGridViewRow row in dgvClientsAttitres.Rows)
            {
                if (row.IsNewRow) continue;
                iText.BaseColor bgColor = ligneGrise ? couleurGris : iText.BaseColor.WHITE;

                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(row.Cells["Client"]?.Value?.ToString() ?? "", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(row.Cells["Employe"]?.Value?.ToString() ?? "", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(row.Cells["TelephoneClient"]?.Value?.ToString() ?? "", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(row.Cells["EmailClient"]?.Value?.ToString() ?? "", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });

                ligneGrise = !ligneGrise;
            }

            doc.Add(table);
            doc.Close();
        }

        private void GenererPdfChiffreAffaires(string cheminFichier)
        {
            if (dgvTurnover == null) return;

            iText.Document doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 40f, 40f);
            iTextPdf.PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            iText.BaseColor couleurViolet = new iText.BaseColor(128, 0, 128);
            iText.BaseColor couleurBleu = new iText.BaseColor(26, 54, 93);
            iText.BaseColor couleurGris = new iText.BaseColor(240, 240, 240);

            iText.Font policeTitre = iText.FontFactory.GetFont("Helvetica", 24, iText.Font.BOLD, couleurViolet);
            iText.Font policeNormal = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.NORMAL, iText.BaseColor.BLACK);
            iText.Font policeEnteteTab = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.WHITE);

            iTextPdf.PdfPTable tableHeader = new iTextPdf.PdfPTable(2) { WidthPercentage = 100 };
            iTextPdf.PdfPCell cellLeft = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER };
            cellLeft.AddElement(new iText.Paragraph("VAINESCORT S.A.", policeTitre));
            cellLeft.AddElement(new iText.Paragraph("Analyse des performances financières.", iText.FontFactory.GetFont("Helvetica", 10, iText.Font.ITALIC)));
            tableHeader.AddCell(cellLeft);

            iTextPdf.PdfPCell cellRight = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            iText.Paragraph infosDoc = new iText.Paragraph { Alignment = iText.Element.ALIGN_RIGHT };
            infosDoc.Add(new iText.Chunk("RAPPORT FINANCIER\n", iText.FontFactory.GetFont("Helvetica", 14, iText.Font.BOLD, couleurBleu)));
            infosDoc.Add(new iText.Chunk($"Émis le : {DateTime.Now:dd/MM/yyyy}\n", policeNormal));
            tableHeader.AddCell(cellRight);
            doc.Add(tableHeader);

            doc.Add(new iText.Paragraph("\n\n"));

            iTextPdf.PdfPTable table = new iTextPdf.PdfPTable(2) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 50f, 50f });

            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Période (Mois)", policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });
            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Chiffre d'Affaires réalisé", policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });

            bool ligneGrise = false;
            double totalGeneral = 0;

            foreach (DataGridViewRow row in dgvTurnover.Rows)
            {
                if (row.IsNewRow) continue;
                iText.BaseColor bgColor = ligneGrise ? couleurGris : iText.BaseColor.WHITE;

                string mois = row.Cells["Mois"]?.Value?.ToString() ?? "";
                string caRaw = row.Cells["ChiffreAffaires"]?.Value?.ToString() ?? "0";

                double.TryParse(caRaw, out double caValue);
                totalGeneral += caValue;

                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(mois, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase($"{caValue:N2} €", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });

                ligneGrise = !ligneGrise;
            }

            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("TOTAL GÉNÉRAL", policeEnteteTab)) { BackgroundColor = couleurViolet, Padding = 8f });
            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase($"{totalGeneral:N2} €", policeEnteteTab)) { BackgroundColor = couleurViolet, Padding = 8f });

            doc.Add(table);
            doc.Close();
        }

        // --- CODE DE GÉNÉRATION : PDF PERFORMANCES RENTABILITÉ EMPLOYES (Nouveau !) ---
        private void GenererPdfRentabilite(string cheminFichier)
        {
            if (dgvProfitability == null) return;

            iText.Document doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 40f, 40f);
            iTextPdf.PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            iText.BaseColor couleurViolet = new iText.BaseColor(128, 0, 128);
            iText.BaseColor couleurBleu = new iText.BaseColor(26, 54, 93);
            iText.BaseColor couleurGris = new iText.BaseColor(240, 240, 240);

            iText.Font policeTitre = iText.FontFactory.GetFont("Helvetica", 24, iText.Font.BOLD, couleurViolet);
            iText.Font policeNormal = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.NORMAL, iText.BaseColor.BLACK);
            iText.Font policeEnteteTab = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.WHITE);

            iTextPdf.PdfPTable tableHeader = new iTextPdf.PdfPTable(2) { WidthPercentage = 100 };
            iTextPdf.PdfPCell cellLeft = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER };
            cellLeft.AddElement(new iText.Paragraph("VAINESCORT S.A.", policeTitre));
            cellLeft.AddElement(new iText.Paragraph("Suivi des prestations et rentabilité de l'équipe.", iText.FontFactory.GetFont("Helvetica", 10, iText.Font.ITALIC)));
            tableHeader.AddCell(cellLeft);

            iTextPdf.PdfPCell cellRight = new iTextPdf.PdfPCell { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            iText.Paragraph infosDoc = new iText.Paragraph { Alignment = iText.Element.ALIGN_RIGHT };
            infosDoc.Add(new iText.Chunk("BILAN DES PERFORMANCES\n", iText.FontFactory.GetFont("Helvetica", 14, iText.Font.BOLD, couleurBleu)));
            infosDoc.Add(new iText.Chunk($"Généré le : {DateTime.Now:dd/MM/yyyy}\n", policeNormal));
            tableHeader.AddCell(cellRight);
            doc.Add(tableHeader);

            doc.Add(new iText.Paragraph("\n\n"));

            iTextPdf.PdfPTable table = new iTextPdf.PdfPTable(3) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 40f, 30f, 30f });

            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Employé(e)", policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });
            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Heures Prestées", policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });
            table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Chiffre Généré", policeEnteteTab)) { BackgroundColor = couleurBleu, Padding = 8f });

            bool ligneGrise = false;

            foreach (DataGridViewRow row in dgvProfitability.Rows)
            {
                if (row.IsNewRow) continue;
                iText.BaseColor bgColor = ligneGrise ? couleurGris : iText.BaseColor.WHITE;

                string employe = row.Cells["Employe"]?.Value?.ToString() ?? "";
                string heures = row.Cells["HeuresPrestees"]?.Value?.ToString() ?? "0";
                string totalGenereRaw = row.Cells["TotalGenere"]?.Value?.ToString() ?? "0";

                double.TryParse(totalGenereRaw, out double totalGenereVal);

                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(employe, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase(heures, policeNormal)) { BackgroundColor = bgColor, Padding = 6f });
                table.AddCell(new iTextPdf.PdfPCell(new iText.Phrase($"{totalGenereVal:N2} €", policeNormal)) { BackgroundColor = bgColor, Padding = 6f });

                ligneGrise = !ligneGrise;
            }

            doc.Add(table);
            doc.Close();
        }

        private void ActiverDoubleBuffer(DataGridView dgv)
        {
            if (dgv == null) return;
            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, dgv, new object[] { true });
        }
    }
}