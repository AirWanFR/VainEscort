using System;
using System.Windows.Forms;
using VainEscort.BLL; // Référence à ta couche métier

namespace Projet_VainEscort
{
    public partial class Home : Form
    {
        // On instancie la BLL pour pouvoir lui "demander" des infos
        private DashboardManager _dashboardBLL = new DashboardManager();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            RafraichirDashboard();
            VerifierStatutConnexion();
        }

        private void RafraichirDashboard()
        {
            if (_dashboardBLL.EstConnecte())
            {
                // Tableau 1 : Prestations
                dgvPrestations.DataSource = _dashboardBLL.ObtenirApercuPrestations();

                // Tableau 2 : Employés (le tableau du milieu)
                dgvEmployes.DataSource = _dashboardBLL.ObtenirListeEmployes();

                // Tableau 3 : Clients (le tableau de droite)
                dgvClients.DataSource = _dashboardBLL.ObtenirListeClients();

                lblStatsFactures.Text = $"Factures en attente : {_dashboardBLL.CompterPrestationsNonFacturees()}";
            }
        }

        // --- Navigation vers les autres fichiers (PL) ---
        private void menuPrestations_Click(object sender, EventArgs e)
        {
            FicPresta f = new FicPresta();
            f.ShowDialog(); // Ouvre la fenêtre d'encodage
            RafraichirDashboard(); // Met à jour l'accueil après l'encodage
        }

        private void menuFacturation_Click(object sender, EventArgs e)
        {
            FicFacturation f = new FicFacturation();
            f.ShowDialog(); // Ouvre la fenêtre des factures non traitées
            RafraichirDashboard(); // Met à jour l'accueil après la facturation


        }

        private void menuQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNouvellePrestation_Click(object sender, EventArgs e)
        {
            // On ouvre la fenêtre FicPresta que tu as créée
            FicPresta formulairePrestation = new FicPresta();

            // ShowDialog bloque l'accueil tant que le formulaire n'est pas fermé
            formulairePrestation.ShowDialog();

            // Une fois fermé, on rafraîchit les données du dashboard
            RafraichirDashboard();
        }



        private void VerifierStatutConnexion()
        {
            tsslStatus.Text = "Vérification de la connexion...";
            ssConnexion.Refresh();

            tsslStatus.ForeColor = System.Drawing.Color.Orange;
            if (_dashboardBLL.EstConnecte())
            {
                tsslStatus.Text = "Connecté à SQL Server Express";
                tsslStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                tsslStatus.Text = "Erreur : Déconnecté de la base de données";
                tsslStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void menuPrestation_Click(object sender, EventArgs e)
        {
            // On ouvre la fenêtre FicPresta que tu as créée
            FicPresta formulairePrestation = new FicPresta();

            // ShowDialog bloque l'accueil tant que le formulaire n'est pas fermé
            formulairePrestation.ShowDialog();

            // Une fois fermé, on rafraîchit les données du dashboard
            RafraichirDashboard();
        }

        private void menuEmployes_Click(object sender, EventArgs e)
        {
            FicEmployes ficEmployes = new FicEmployes();

            ficEmployes.ShowDialog(); // Ouvre la fenêtre de gestion des employés

            RafraichirDashboard(); // Met à jour l'accueil après la gestion des employés
        }

        private void menuClient_Click(object sender, EventArgs e)
        {
            FicClients ficClients = new FicClients();

            ficClients.ShowDialog(); // Ouvre la fenêtre de gestion des clients

            RafraichirDashboard();
        }

        private void menuManagement_Click(object sender, EventArgs e)
        {
            FicManagement ficPerfCA = new FicManagement();

            ficPerfCA.Show();

            RafraichirDashboard();
        }

        private void catalogueHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FicCatalogue catalogue = new FicCatalogue();

            catalogue.Show();

            RafraichirDashboard();
        }
    }
}