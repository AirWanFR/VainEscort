using System;
using System.IO;
using System.Windows.Forms;
using VainEscort.BLL;

namespace Projet_VainEscort
{
    // C'EST CETTE LIGNE QUI EST CRUCIALE : " : Form "
    public partial class FicCatalogue : Form
    {
        private CatalogueManager _manager = new CatalogueManager();

        public FicCatalogue()
        {
            InitializeComponent();
        }

        private async void FicCatalogue_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;

            try
            {
                // Initialisation du WebView2
                await webBrowserCatalogue.EnsureCoreWebView2Async(null);

                ChargerCatalogueHTML();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'initialisation du navigateur : " + ex.Message);
            }
        }

        private void ChargerCatalogueHTML()
        {
            try
            {
                string contenuHTML = _manager.GenererCatalogueHTML();

                if (webBrowserCatalogue.CoreWebView2 != null)
                {
                    webBrowserCatalogue.NavigateToString(contenuHTML);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la génération du catalogue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Il faut lier cet événement dans ton designer
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerCatalogueHTML();
        }

        // Il faut lier cet événement dans ton designer
        private void btnExporterHTML_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Fichier HTML (*.html)|*.html";
                sfd.FileName = $"Catalogue_VainEscort_{DateTime.Now:yyyyMMdd}.html";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string contenuHTML = _manager.GenererCatalogueHTML();
                        File.WriteAllText(sfd.FileName, contenuHTML, System.Text.Encoding.UTF8);
                        MessageBox.Show("Le catalogue HTML a été exporté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'exportation : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}