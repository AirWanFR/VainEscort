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

            txtPrenom.Clear();
            txtNom.Clear();
            _id = -1;
        }

        private void Dgv_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _id = Convert.ToInt32(dgvEmployes.Rows[e.RowIndex].Cells["ID_Employe"].Value);
                txtPrenom.Text = dgvEmployes.Rows[e.RowIndex].Cells["Prenom"].Value?.ToString();
                txtNom.Text = dgvEmployes.Rows[e.RowIndex].Cells["Nom"].Value?.ToString();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPrenom.Text) && _manager.Ajouter(txtPrenom.Text, txtNom.Text))
                Rafraichir();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_id != -1 && _manager.Modifier(_id, txtPrenom.Text, txtNom.Text))
                Rafraichir();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_id != -1 && _manager.Supprimer(_id))
                Rafraichir();
        }
    }
}