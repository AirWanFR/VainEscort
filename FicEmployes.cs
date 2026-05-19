using System;
using System.Windows.Forms;
using VainEscort.BLL;

namespace Projet_VainEscort
{
    public partial class FicEmployes : Form
    {
        private EmployeManager _manager = new EmployeManager();
        private int _id = -1;

        public FicEmployes()
        {
            InitializeComponent();
            this.Load += (s, e) => Rafraichir();
            dgvEmployes.CellClick += Dgv_Click;
        }

        private void Rafraichir()
        {
            dgvEmployes.DataSource = _manager.GetAll();
            if (dgvEmployes.Columns["ID_Employe"] != null)
                dgvEmployes.Columns["ID_Employe"].Visible = false;

            // Nettoyage complet
            txtPrenom.Clear();
            txtNom.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            chkActif.Checked = true; // Par défaut, un nouvel employé est actif
            _id = -1;
        }

        private void Dgv_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployes.Rows[e.RowIndex];

                _id = Convert.ToInt32(row.Cells["ID_Employe"].Value);
                txtPrenom.Text = row.Cells["Prenom"].Value?.ToString() ?? "";
                txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
                txtTelephone.Text = row.Cells["Telephone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // Récupération et application de l'état d'activité (Convertit le bit de la base en booléen)
                if (row.Cells["Actif"].Value != DBNull.Value)
                    chkActif.Checked = Convert.ToBoolean(row.Cells["Actif"].Value);
                else
                    chkActif.Checked = false;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez remplir au moins le prénom et le nom.");
                return;
            }

            // Un nouvel employé est inséré actif (1) d'office
            if (_manager.Ajouter(txtPrenom.Text.Trim(), txtNom.Text.Trim(), txtTelephone.Text.Trim(), txtEmail.Text.Trim()))
                Rafraichir();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_id == -1)
            {
                MessageBox.Show("Veuillez sélectionner un employé dans le tableau.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le prénom et le nom ne peuvent pas être vides.");
                return;
            }

            // CORRECTION : On passe l'état de chkActif.Checked (true/false) à la BLL
            if (_manager.Modifier(_id, txtPrenom.Text.Trim(), txtNom.Text.Trim(), txtTelephone.Text.Trim(), txtEmail.Text.Trim(), chkActif.Checked))
                Rafraichir();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_id == -1)
            {
                MessageBox.Show("Veuillez sélectionner un employé à supprimer.");
                return;
            }

            if (MessageBox.Show("Supprimer définitivement cet employé ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_manager.Supprimer(_id))
                    Rafraichir();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}