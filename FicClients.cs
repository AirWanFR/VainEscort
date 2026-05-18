using System;
using System.Data;
using System.Windows.Forms;
using VainEscort.BLL;

namespace Projet_VainEscort
{
    public partial class FicClients : Form
    {
        private ClientBLL _manager = new ClientBLL();
        private int _idSelectionne = -1;

        public FicClients()
        {
            InitializeComponent();
            ActiverDoubleBuffer(dgvClients);
        }

        private void FicClients_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            dgvClients.UseWaitCursor = false;

            RafraichirTout();

            // Liaison manuelle sécurisée de l'événement clic de la grille
            dgvClients.CellClick += dgvClients_CellClick;
        }

        private void RafraichirTout()
        {
            try
            {
                // 1. Charger la ComboBox des employés (Configuration avant DataSource pour éviter les boucles)
                cmbEmployes.DisplayMember = "NomComplet";
                cmbEmployes.ValueMember = "ID_Employe";
                cmbEmployes.DataSource = _manager.ChargerEmployes();
                cmbEmployes.SelectedIndex = -1;

                // 2. Charger le tableau à gauche
                dgvClients.DataSource = _manager.ChargerClients();

                // Masquer les colonnes techniques
                if (dgvClients.Columns["ID_Client"] != null) dgvClients.Columns["ID_Client"].Visible = false;
                if (dgvClients.Columns["Employe_ID_Hidden"] != null) dgvClients.Columns["Employe_ID_Hidden"].Visible = false;

                // Nettoyer les champs de saisie
                txtPrenom.Clear();
                txtNom.Clear();
                _idSelectionne = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void dgvClients_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClients.Rows[e.RowIndex];

                // Récupération de l'ID du client sélectionné
                _idSelectionne = Convert.ToInt32(row.Cells["ID_Client"].Value);

                // Remplissage des TextBox à droite
                txtPrenom.Text = row.Cells["Prenom"].Value?.ToString() ?? "";
                txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";

                // Sélection de l'employé attitré dans la ComboBox via sa valeur cachée
                if (row.Cells["Employe_ID_Hidden"].Value != DBNull.Value)
                {
                    cmbEmployes.SelectedValue = Convert.ToInt32(row.Cells["Employe_ID_Hidden"].Value);
                }
                else
                {
                    cmbEmployes.SelectedIndex = -1;
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtNom.Text) || cmbEmployes.SelectedValue == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs et assigner un employé.");
                return;
            }

            if (_manager.Ajouter(txtPrenom.Text.Trim(), txtNom.Text.Trim(), (int)cmbEmployes.SelectedValue))
            {
                RafraichirTout();
                MessageBox.Show("Client ajouté avec succès !");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_idSelectionne == -1)
            {
                MessageBox.Show("Veuillez sélectionner un client dans le tableau de gauche.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtNom.Text) || cmbEmployes.SelectedValue == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (_manager.Modifier(_idSelectionne, txtPrenom.Text.Trim(), txtNom.Text.Trim(), (int)cmbEmployes.SelectedValue))
            {
                RafraichirTout();
                MessageBox.Show("Informations client modifiées !");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_idSelectionne == -1)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.");
                return;
            }

            if (MessageBox.Show("Supprimer définitivement ce client ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_manager.Supprimer(_idSelectionne))
                {
                    RafraichirTout();
                    MessageBox.Show("Client supprimé.");
                }
            }
        }

        private void ActiverDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }
    }
}