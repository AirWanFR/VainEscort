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
        private bool _estEnChargement = false;

        public FicPresta()
        {
            InitializeComponent();
        }

        private void FicPresta_Load(object sender, EventArgs e)
        {
            // On désabonne puis on abonne pour être sûr de ne pas créer l'événement en double
            cmbClients.SelectedIndexChanged -= cmbClients_SelectedIndexChanged;
            cmbClients.SelectedIndexChanged += cmbClients_SelectedIndexChanged;

            RafraichirTout();
        }

        private void RafraichirTout()
        {
            try
            {
                _estEnChargement = true;

                // 1. Coupe radicalement la roue bleue au niveau global de l'application
                Application.UseWaitCursor = false;
                this.UseWaitCursor = false;
                this.Cursor = Cursors.Default;

                DataTable dtEmp = _manager.ChargerEmployes();
                DataTable dtCli = _manager.ChargerClients();
                DataTable dtType = _manager.ChargerTypes();

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

                dgvPresta.DataSource = _manager.ChargerHistorique();

                if (dgvPresta.Columns["ID_Prestation"] != null) dgvPresta.Columns["ID_Prestation"].Visible = false;
                if (dgvPresta.Columns["Client_ID_Hidden"] != null) dgvPresta.Columns["Client_ID_Hidden"].Visible = false;
                if (dgvPresta.Columns["Employe_ID_Hidden"] != null) dgvPresta.Columns["Employe_ID_Hidden"].Visible = false;
                if (dgvPresta.Columns["ID_Type"] != null) dgvPresta.Columns["ID_Type"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message, "Erreur système", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _estEnChargement = false;
            }
        }

        // L'auto-sélection du client corrigée
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_estEnChargement || cmbClients.SelectedIndex == -1) return;

            try
            {
                // Vérification propre et sécurisée de l'objet sélectionné
                if (cmbClients.SelectedItem is DataRowView rowView)
                {
                    if (rowView.Row.Table.Columns.Contains("EstAttitreA") && rowView["EstAttitreA"] != DBNull.Value)
                    {
                        cmbEmployes.SelectedValue = Convert.ToInt32(rowView["EstAttitreA"]);
                    }
                    else
                    {
                        cmbEmployes.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Fini le catch silencieux, on affiche le problème si la base a un souci !
                MessageBox.Show("Impossible de lier l'employé : " + ex.Message, "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_idSelectionne == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une ligne dans le tableau du bas.");
                return;
            }

            if (MessageBox.Show("Voulez-vous vraiment supprimer cette prestation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_manager.Supprimer(_idSelectionne))
                {
                    RafraichirTout();
                    _idSelectionne = -1;
                    MessageBox.Show("Prestation supprimée !");
                }
            }
        }

        private void dgvPresta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    _estEnChargement = true;
                    DataGridViewRow row = dgvPresta.Rows[e.RowIndex];

                    if (row.Cells["ID_Prestation"].Value != DBNull.Value)
                        _idSelectionne = Convert.ToInt32(row.Cells["ID_Prestation"].Value);
                    else
                        _idSelectionne = -1;

                    if (row.Cells["Client_ID_Hidden"].Value != DBNull.Value)
                        cmbClients.SelectedValue = Convert.ToInt32(row.Cells["Client_ID_Hidden"].Value);
                    else
                        cmbClients.SelectedIndex = -1;

                    if (row.Cells["Employe_ID_Hidden"].Value != DBNull.Value)
                        cmbEmployes.SelectedValue = Convert.ToInt32(row.Cells["Employe_ID_Hidden"].Value);
                    else
                        cmbEmployes.SelectedIndex = -1;

                    // CORRECTION DU CRASH (Le problème de la roue bleue venait d'ici)
                    if (dgvPresta.Columns.Contains("ID_Type") && row.Cells["ID_Type"].Value != DBNull.Value)
                        cmbTypes.SelectedValue = Convert.ToInt32(row.Cells["ID_Type"].Value);
                    else if (dgvPresta.Columns.Contains("Type") && row.Cells["Type"].Value != DBNull.Value)
                        cmbTypes.SelectedIndex = cmbTypes.FindStringExact(row.Cells["Type"].Value.ToString());
                    else
                        cmbTypes.SelectedIndex = -1;

                    if (row.Cells["DatePrestation"].Value != DBNull.Value)
                        dtpDate.Value = Convert.ToDateTime(row.Cells["DatePrestation"].Value);

                    if (row.Cells["DureeHeures"].Value != DBNull.Value)
                        numHeures.Value = Convert.ToDecimal(row.Cells["DureeHeures"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection : " + ex.Message, "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _estEnChargement = false;
                }
            }
        }
    }
}