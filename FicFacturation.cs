using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using VainEscort.BLL;

// Usings iTextSharp stricts pour éviter les conflits de types
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

namespace Projet_VainEscort
{
    public partial class FicFacturation : Form
    {
        private FacturationManager _manager = new FacturationManager();

        public FicFacturation()
        {
            InitializeComponent();
            ActiverDoubleBuffer(dgvFacturation);
        }

        private void FicFacturation_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            dgvFacturation.UseWaitCursor = false;

            ConfigurerTableau();
            RafraichirGrid();
        }

        private void ConfigurerTableau()
        {
            dgvFacturation.Columns.Clear();

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Selection";
            checkColumn.HeaderText = "Choisir";
            checkColumn.Width = 60;
            dgvFacturation.Columns.Add(checkColumn);

            dgvFacturation.AllowUserToAddRows = false;
            dgvFacturation.AllowUserToDeleteRows = false;
            dgvFacturation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Événements pour la réactivité immédiate et la mise à jour du texte du bouton
            dgvFacturation.CurrentCellDirtyStateChanged += dgvFacturation_CurrentCellDirtyStateChanged;
            dgvFacturation.CellValueChanged += dgvFacturation_CellValueChanged;
        }

        private void RafraichirGrid()
        {
            DataTable dt = _manager.ChargerPrestationsEnAttente();
            dgvFacturation.DataSource = dt;

            if (dgvFacturation.Columns["ID_Prestation"] != null)
                dgvFacturation.Columns["ID_Prestation"].Visible = false;

            foreach (DataGridViewColumn col in dgvFacturation.Columns)
            {
                if (col.Name != "Selection") col.ReadOnly = true;
            }

            MettreAJourTexteBouton();
        }

        // Force la validation immédiate du clic sur la CheckBox
        private void dgvFacturation_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvFacturation.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvFacturation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Se déclenche dès qu'une case change d'état grâce au CommitEdit ci-dessus
        private void dgvFacturation_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFacturation.Columns["Selection"]?.Index)
            {
                MettreAJourTexteBouton();
            }
        }

        // Calcule le nombre de lignes cochées et renomme le bouton dynamiquement
        private void MettreAJourTexteBouton()
        {
            int nbCoches = 0;
            foreach (DataGridViewRow row in dgvFacturation.Rows)
            {
                if (row.Cells["Selection"].Value != null && Convert.ToBoolean(row.Cells["Selection"].Value) == true)
                {
                    nbCoches++;
                }
            }

            if (nbCoches == 0)
            {
                btnGenererFactures.Text = "Générer toutes les factures";
            }
            else
            {
                btnGenererFactures.Text = $"Générer les ({nbCoches}) factures";
            }
        }

        private void btnGenererFactures_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<DataGridViewRow>> prestationsParClient = new Dictionary<string, List<DataGridViewRow>>();
            int totalLignesCochees = 0;

            // 1. On compte combien de lignes sont cochées
            foreach (DataGridViewRow row in dgvFacturation.Rows)
            {
                if (row.Cells["Selection"].Value != null && Convert.ToBoolean(row.Cells["Selection"].Value) == true)
                {
                    totalLignesCochees++;
                }
            }

            // RÈGLE LOGIQUE : Si AUCUNE case n'est cochée, on prend TOUTES les lignes du tableau
            bool toutFacturer = (totalLignesCochees == 0);

            foreach (DataGridViewRow row in dgvFacturation.Rows)
            {
                // On prend la ligne si l'utilisateur l'a cochée OU si rien n'était coché du tout
                if (toutFacturer || (row.Cells["Selection"].Value != null && Convert.ToBoolean(row.Cells["Selection"].Value) == true))
                {
                    string nomClient = row.Cells["Client"].Value?.ToString() ?? "Client_Inconnu";

                    if (!prestationsParClient.ContainsKey(nomClient))
                    {
                        prestationsParClient[nomClient] = new List<DataGridViewRow>();
                    }

                    prestationsParClient[nomClient].Add(row);
                }
            }

            // Sécurité si le tableau est complètement vide de base
            if (prestationsParClient.Count == 0)
            {
                MessageBox.Show("Il n'y a aucune prestation en attente de facturation.", "Tableau vide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmation dynamique
            string messageConfirmation = toutFacturer ? "Voulez-vous générer TOUTES les factures ?" : $"Voulez-vous générer les factures pour les {prestationsParClient.Count} client(s) sélectionné(s) ?";
            if (MessageBox.Show(messageConfirmation, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 2. Sélection du dossier de stockage des PDFs
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Sélectionnez le dossier où enregistrer les factures PDF :";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    int facturesGenerees = 0;
                    string dateStr = DateTime.Now.ToString("yyyyMMdd");
                    string numFactureUnique = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

                    foreach (var kvp in prestationsParClient)
                    {
                        string nomClient = kvp.Key;
                        List<DataGridViewRow> lignesClient = kvp.Value;

                        string nomFichierSecurise = nomClient.Replace(" ", "_");
                        string cheminFichier = Path.Combine(fbd.SelectedPath, $"Facture_{nomFichierSecurise}_{dateStr}_{numFactureUnique}.pdf");

                        try
                        {
                            GenererDocumentPDFIndividuel(nomClient, lignesClient, cheminFichier, numFactureUnique);

                            foreach (DataGridViewRow row in lignesClient)
                            {
                                if (row.Cells["ID_Prestation"].Value != null)
                                {
                                    int idPresta = Convert.ToInt32(row.Cells["ID_Prestation"].Value);
                                    _manager.ValiderLigneFacture(idPresta);
                                }
                            }

                            facturesGenerees++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur lors de la génération pour {nomClient} : {ex.Message}", "Erreur Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"{facturesGenerees} facture(s) nominative(s) générée(s) avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RafraichirGrid();
                }
            }
        }

        private void GenererDocumentPDFIndividuel(string nomClient, List<DataGridViewRow> lignes, string cheminFichier, string numFactureUnique)
        {
            // Marges aérées (Gauche, Droite, Haut, Bas)
            iText.Document doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 40f, 40f);
            iTextPdf.PdfWriter writer = iTextPdf.PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));

            doc.Open();

            // --- CHARTE GRAPHIQUE ---
            iText.BaseColor couleurViolet = new iText.BaseColor(128, 0, 128);   // Couleur 1
            iText.BaseColor couleurBleu = new iText.BaseColor(26, 54, 93);      // Couleur 2 (Bleu foncé)
            iText.BaseColor couleurJaune = new iText.BaseColor(255, 215, 0);    // Couleur 3 (Accents)
            iText.BaseColor couleurGris = new iText.BaseColor(240, 240, 240);   // Pour les lignes de tableau alternées

            iText.Font policeTitre = iText.FontFactory.GetFont("Helvetica", 26, iText.Font.BOLD, couleurViolet);
            iText.Font policeSousTitre = iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurBleu);
            iText.Font policeNormal = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.NORMAL, iText.BaseColor.BLACK);
            iText.Font policeGras = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.BLACK);
            iText.Font policeEnteteTab = iText.FontFactory.GetFont("Helvetica", 10, iText.Font.BOLD, iText.BaseColor.WHITE);

            // --- LOGO ET EN-TÊTE ---
            iTextPdf.PdfPTable tableHeader = new iTextPdf.PdfPTable(2);
            tableHeader.WidthPercentage = 100;
            tableHeader.SetWidths(new float[] { 50f, 50f });

            // Cellule de Gauche (Logo + Nom de l'entreprise)
            iTextPdf.PdfPCell cellLeft = new iTextPdf.PdfPCell();
            cellLeft.Border = iText.Rectangle.NO_BORDER;

            // [INTÉGRATION DU LOGO] : Décommente et modifie le chemin si tu as l'image en local :
            
            string cheminLogo = @"C:\Users\Erwan\Source\Repos\Projet_VainEscort\logo_vainescort_rounded.png";
            if (File.Exists(cheminLogo))
            {
                iText.Image imgLogo = iText.Image.GetInstance(cheminLogo);
                imgLogo.ScaleToFit(100f, 100f); 
                cellLeft.AddElement(imgLogo);
            }
            

            cellLeft.AddElement(new iText.Paragraph("VAINESCORT S.A.", policeTitre));
            cellLeft.AddElement(new iText.Paragraph("L'excellence à vos côtés.", iText.FontFactory.GetFont("Helvetica", 10, iText.Font.ITALIC, couleurBleu)));
            cellLeft.AddElement(new iText.Paragraph("Rue Sohet 14\n4000 Liège - Belgique\nTVA : BE 0123.456.789", policeNormal));
            tableHeader.AddCell(cellLeft);

            // Cellule de Droite (Infos Facture & Client)
            iTextPdf.PdfPCell cellRight = new iTextPdf.PdfPCell();
            cellRight.Border = iText.Rectangle.NO_BORDER;
            cellRight.HorizontalAlignment = iText.Element.ALIGN_RIGHT;

            iText.Paragraph infosDoc = new iText.Paragraph();
            infosDoc.Alignment = iText.Element.ALIGN_RIGHT;
            infosDoc.Add(new iText.Chunk("FACTURE\n", iText.FontFactory.GetFont("Helvetica", 18, iText.Font.BOLD, couleurBleu)));
            infosDoc.Add(new iText.Chunk($"Date : {DateTime.Now:dd/MM/yyyy}\n", policeNormal));
            infosDoc.Add(new iText.Chunk($"N° Facture : FAC-{DateTime.Now:yyyyMMdd}-{numFactureUnique}\n\n", policeNormal));

            infosDoc.Add(new iText.Chunk("Facturé à :\n", policeSousTitre));
            infosDoc.Add(new iText.Chunk(nomClient.ToUpper(), iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurViolet)));
            cellRight.AddElement(infosDoc);

            tableHeader.AddCell(cellRight);
            doc.Add(tableHeader);

            // Ligne de séparation esthétique (Jaune)
            iText.pdf.draw.LineSeparator ligneSep = new iText.pdf.draw.LineSeparator(2f, 100f, couleurJaune, iText.Element.ALIGN_CENTER, -15f);
            doc.Add(new iText.Chunk(ligneSep));
            doc.Add(new iText.Paragraph("\n\n")); // Espace

            // --- TABLEAU DES PRESTATIONS ---
            // Ajout de la colonne "Heures" (5 colonnes au total)
            iTextPdf.PdfPTable table = new iTextPdf.PdfPTable(5);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 15f, 25f, 35f, 10f, 15f });

            // Entêtes du tableau
            string[] entetes = { "Date", "Employé", "Prestation", "Durée (h)", "Total HT" };
            foreach (string t in entetes)
            {
                iTextPdf.PdfPCell cellHeader = new iTextPdf.PdfPCell(new iText.Phrase(t, policeEnteteTab));
                cellHeader.BackgroundColor = couleurBleu; // Le bleu de ta charte
                cellHeader.Padding = 8f;
                cellHeader.HorizontalAlignment = (t == "Total HT" || t == "Durée (h)") ? iText.Element.ALIGN_RIGHT : iText.Element.ALIGN_LEFT;
                table.AddCell(cellHeader);
            }

            decimal totalHT = 0;
            bool ligneGrise = false; // Pour faire un tableau à bandes alternées

            foreach (DataGridViewRow row in lignes)
            {
                string dateStr = row.Cells["DatePrestation"].Value != null ? Convert.ToDateTime(row.Cells["DatePrestation"].Value).ToString("dd/MM/yyyy") : "";
                string employeStr = row.Cells["Employé"].Value?.ToString() ?? "";
                string typeStr = row.Cells["Type"].Value?.ToString() ?? "";
                string dureeStr = row.Cells["DureeHeures"].Value?.ToString() ?? "0";
                decimal montantRow = row.Cells["MontantApaye"].Value != null ? Convert.ToDecimal(row.Cells["MontantApaye"].Value) : 0m;

                totalHT += montantRow;

                iText.BaseColor bgColor = ligneGrise ? couleurGris : iText.BaseColor.WHITE;

                // Création des cellules
                iTextPdf.PdfPCell cellDate = new iTextPdf.PdfPCell(new iText.Phrase(dateStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f, BorderColor = iText.BaseColor.LIGHT_GRAY };
                iTextPdf.PdfPCell cellEmp = new iTextPdf.PdfPCell(new iText.Phrase(employeStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f, BorderColor = iText.BaseColor.LIGHT_GRAY };
                iTextPdf.PdfPCell cellType = new iTextPdf.PdfPCell(new iText.Phrase(typeStr, policeNormal)) { BackgroundColor = bgColor, Padding = 6f, BorderColor = iText.BaseColor.LIGHT_GRAY };

                iTextPdf.PdfPCell cellHeure = new iTextPdf.PdfPCell(new iText.Phrase(dureeStr, policeNormal))
                {
                    BackgroundColor = bgColor,
                    Padding = 6f,
                    BorderColor = iText.BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = iText.Element.ALIGN_RIGHT
                };

                iTextPdf.PdfPCell cellMontant = new iTextPdf.PdfPCell(new iText.Phrase($"{montantRow:0.00} €", policeNormal))
                {
                    BackgroundColor = bgColor,
                    Padding = 6f,
                    BorderColor = iText.BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = iText.Element.ALIGN_RIGHT
                };

                table.AddCell(cellDate);
                table.AddCell(cellEmp);
                table.AddCell(cellType);
                table.AddCell(cellHeure);
                table.AddCell(cellMontant);

                ligneGrise = !ligneGrise; // Inverse la couleur pour la ligne suivante
            }

            doc.Add(table);

            // --- CALCULS DES TOTAUX ---
            decimal tva = totalHT * 0.21m; // 21% pour la Belgique
            decimal totalTTC = totalHT + tva;

            iTextPdf.PdfPTable tableTotaux = new iTextPdf.PdfPTable(2);
            tableTotaux.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
            tableTotaux.WidthPercentage = 40;
            tableTotaux.SetWidths(new float[] { 60f, 40f });
            tableTotaux.SpacingBefore = 10f;

            // Ligne Sous-Total HT
            tableTotaux.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("Sous-total HT :", policeNormal)) { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT });
            tableTotaux.AddCell(new iTextPdf.PdfPCell(new iText.Phrase($"{totalHT:0.00} €", policeNormal)) { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT });

            // Ligne TVA
            tableTotaux.AddCell(new iTextPdf.PdfPCell(new iText.Phrase("TVA (21%) :", policeNormal)) { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT });
            tableTotaux.AddCell(new iTextPdf.PdfPCell(new iText.Phrase($"{tva:0.00} €", policeNormal)) { Border = iText.Rectangle.NO_BORDER, HorizontalAlignment = iText.Element.ALIGN_RIGHT });

            // Ligne Total TTC (Gras et Violet)
            iTextPdf.PdfPCell cellLabelTotal = new iTextPdf.PdfPCell(new iText.Phrase("Total TTC :", iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurViolet)));
            cellLabelTotal.Border = iText.Rectangle.TOP_BORDER;
            cellLabelTotal.BorderWidthTop = 2f;
            cellLabelTotal.BorderColorTop = couleurBleu;
            cellLabelTotal.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
            cellLabelTotal.PaddingTop = 5f;

            iTextPdf.PdfPCell cellValeurTotal = new iTextPdf.PdfPCell(new iText.Phrase($"{totalTTC:0.00} €", iText.FontFactory.GetFont("Helvetica", 12, iText.Font.BOLD, couleurViolet)));
            cellValeurTotal.Border = iText.Rectangle.TOP_BORDER;
            cellValeurTotal.BorderWidthTop = 2f;
            cellValeurTotal.BorderColorTop = couleurBleu;
            cellValeurTotal.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
            cellValeurTotal.PaddingTop = 5f;

            tableTotaux.AddCell(cellLabelTotal);
            tableTotaux.AddCell(cellValeurTotal);

            doc.Add(tableTotaux);

            // --- BAS DE PAGE (FOOTER) ---
            iText.Paragraph footer = new iText.Paragraph();
            footer.SpacingBefore = 50f;
            footer.Alignment = iText.Element.ALIGN_CENTER;

            footer.Add(new iText.Chunk("Conditions de paiement : Paiement attendu dans les 15 jours suivant la date de facturation.\n", iText.FontFactory.GetFont("Helvetica", 9, iText.Font.BOLD, couleurBleu)));
            footer.Add(new iText.Chunk("En cas de retard, des pénalités pourront être appliquées.\nMerci de votre confiance.", iText.FontFactory.GetFont("Helvetica", 8, iText.Font.NORMAL, iText.BaseColor.GRAY)));

            doc.Add(footer);

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