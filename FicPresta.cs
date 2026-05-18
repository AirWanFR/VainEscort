using System;
using System.Data;
using System.Windows.Forms;
using VainEscort.BLL;

namespace Projet_VainEscort
{
    public partial class FicPresta : Form
    {
        private PrestaManager _manager = new PrestaManager();
        private int _idSelectionne = -1;

        public FicPresta()
        {
            InitializeComponent();
        }

        private void FicPresta_Load(object sender, EventArgs e)
        {
            RafraichirTout();
        }

        private void RafraichirTout()
        {
            try
            {
                DataTable dtEmp = _manager.ChargerEmployes();
                DataTable dtCli = _manager.ChargerClients();
                DataTable dtType = _manager.ChargerTypes();

                // Lier les structures d'affichage avant les sources d'information (évite les freezes)
                cmbEmployes.DisplayMember = "Affichage";
                cmbEmployes.ValueMember = "ID_Employe";
                cmbEmployes.DataSource = dtEmp;

                cmbClients.DisplayMember = "Affichage";
                cmbClients.ValueMember = "ID_Client";
                cmbClients.DataSource = dtCli;

                cmbTypes.DisplayMember = "Libelle";
                cmbTypes.ValueMember = "ID_Type";
                cmbTypes.DataSource = dtType;

                cmbEmployes.SelectedIndex = -1;
                cmbClients.SelectedIndex = -1;
                cmbTypes.SelectedIndex = -1;

                // Affichage de l'historique dans la grille du bas
                dgvPresta.DataSource = _manager.ChargerHistorique();

                // Masquage propre des colonnes techniques
                if (dgvPresta.Columns["ID_Prestation"] != null) dgvPresta.Columns["ID_Prestation"].Visible = false;
                if (dgvPresta.Columns["Client_ID_Hidden"] != null) dgvPresta.Columns["Client_ID_Hidden"].Visible = false;
                if (dgvPresta.Columns["Employe_ID_Hidden"] != null) dgvPresta.Columns["Employe_ID_Hidden"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cmbEmployes.SelectedValue == null || cmbClients.SelectedValue == null || cmbTypes.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client, un employé et un type de prestation.");
                return;
            }

            if (_manager.Ajouter((int)cmbEmployes.SelectedValue, (int)cmbClients.SelectedValue,
                (int)cmbTypes.SelectedValue, dtpDate.Value, numHeures.Value))
            {
                RafraichirTout();
                MessageBox.Show("Prestation ajoutée !");
            }
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_idSelectionne == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une ligne dans le tableau du bas.");
                return;
            }

            if (cmbEmployes.SelectedValue == null || cmbClients.SelectedValue == null || cmbTypes.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client, un employé et un type de prestation.");
                return;
            }

            if (_manager.Modifier(_idSelectionne, (int)cmbEmployes.SelectedValue, (int)cmbClients.SelectedValue,
                (int)cmbTypes.SelectedValue, dtpDate.Value, numHeures.Value))
            {
                RafraichirTout();
                _idSelectionne = -1;
                MessageBox.Show("Prestation modifiée avec succès !");
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification.");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_idSelectionne == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une ligne dans le tableau du bas.");
                return;
            }

            if (MessageBox.Show("Voulez-vous vraiment supprimer cette prestation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            if (_manager.Supprimer(_idSelectionne))
            {
                RafraichirTout();
                _idSelectionne = -1;
                MessageBox.Show("Prestation supprimée !");
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression.");
            }
        }

        private void dgvPresta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvPresta.Rows[e.RowIndex];

                    // Récupération sécurisée de l'ID
                    if (row.Cells["ID_Prestation"].Value != DBNull.Value)
                        _idSelectionne = Convert.ToInt32(row.Cells["ID_Prestation"].Value);
                    else
                        _idSelectionne = -1;

                    // Clients / Employés : vérifier les DBNull avant d'assigner SelectedValue
                    if (row.Cells["Client_ID_Hidden"].Value != DBNull.Value)
                        cmbClients.SelectedValue = Convert.ToInt32(row.Cells["Client_ID_Hidden"].Value);
                    else
                        cmbClients.SelectedIndex = -1;

                    if (row.Cells["Employe_ID_Hidden"].Value != DBNull.Value)
                        cmbEmployes.SelectedValue = Convert.ToInt32(row.Cells["Employe_ID_Hidden"].Value);
                    else
                        cmbEmployes.SelectedIndex = -1;

                    // Type : préférer SelectedValue si disponible, sinon retomber sur le libellé
                    if (row.Cells["ID_Type"] != null && row.Cells["ID_Type"].Value != DBNull.Value)
                        cmbTypes.SelectedValue = Convert.ToInt32(row.Cells["ID_Type"].Value);
                    else if (row.Cells["Type"] != null && row.Cells["Type"].Value != DBNull.Value)
                        cmbTypes.SelectedIndex = cmbTypes.FindStringExact(row.Cells["Type"].Value.ToString());
                    else
                        cmbTypes.SelectedIndex = -1;

                    // Date et durée avec garde-fous
                    if (row.Cells["DatePrestation"].Value != DBNull.Value)
                        dtpDate.Value = Convert.ToDateTime(row.Cells["DatePrestation"].Value);

                    if (row.Cells["DureeHeures"].Value != DBNull.Value)
                        numHeures.Value = Convert.ToDecimal(row.Cells["DureeHeures"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection : " + ex.Message);
                }
            }
        }
    }
}