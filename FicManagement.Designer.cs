using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Projet_VainEscort
{
    partial class FicManagement
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicManagement));
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            tabControl1 = new TabControl();
            tpCA = new TabPage();
            chartTurnover = new Chart();
            btnCA = new Button();
            dgvTurnover = new DataGridView();
            tpRent = new TabPage();
            btnPdfRenta = new Button();
            dgvProfitability = new DataGridView();
            tpClientsAttitres = new TabPage();
            btnGenererPdfAttitres = new Button();
            dgvClientsAttitres = new DataGridView();
            tabControl1.SuspendLayout();
            tpCA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTurnover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTurnover).BeginInit();
            tpRent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfitability).BeginInit();
            tpClientsAttitres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientsAttitres).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpCA);
            tabControl1.Controls.Add(tpRent);
            tabControl1.Controls.Add(tpClientsAttitres);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tpCA
            // 
            tpCA.Controls.Add(chartTurnover);
            tpCA.Controls.Add(btnCA);
            tpCA.Controls.Add(dgvTurnover);
            tpCA.ForeColor = SystemColors.ActiveCaptionText;
            tpCA.Location = new Point(4, 29);
            tpCA.Name = "tpCA";
            tpCA.Padding = new Padding(3);
            tpCA.Size = new Size(768, 393);
            tpCA.TabIndex = 0;
            tpCA.Text = "Chiffre d'Affaires";
            tpCA.UseVisualStyleBackColor = true;
            // 
            // chartTurnover
            // 
            chartArea1.Name = "ChartArea1";
            chartTurnover.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTurnover.Legends.Add(legend1);
            chartTurnover.Location = new Point(383, 6);
            chartTurnover.Name = "chartTurnover";
            chartTurnover.Size = new Size(379, 332);
            chartTurnover.TabIndex = 2;
            chartTurnover.Text = "chartTurnover";
            chartTurnover.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnCA
            // 
            btnCA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCA.ForeColor = SystemColors.ActiveCaptionText;
            btnCA.Location = new Point(637, 344);
            btnCA.Name = "btnCA";
            btnCA.Size = new Size(125, 43);
            btnCA.TabIndex = 1;
            btnCA.Text = "Générer PDF";
            btnCA.UseVisualStyleBackColor = true;
            // 
            // dgvTurnover
            // 
            dgvTurnover.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnover.Location = new Point(6, 6);
            dgvTurnover.Name = "dgvTurnover";
            dgvTurnover.ReadOnly = true;
            dgvTurnover.RowHeadersWidth = 51;
            dgvTurnover.Size = new Size(371, 381);
            dgvTurnover.TabIndex = 0;
            // 
            // tpRent
            // 
            tpRent.Controls.Add(btnPdfRenta);
            tpRent.Controls.Add(dgvProfitability);
            tpRent.Location = new Point(4, 29);
            tpRent.Name = "tpRent";
            tpRent.Padding = new Padding(3);
            tpRent.Size = new Size(768, 393);
            tpRent.TabIndex = 1;
            tpRent.Text = "Rentabilité";
            tpRent.UseVisualStyleBackColor = true;
            // 
            // btnPdfRenta
            // 
            btnPdfRenta.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPdfRenta.Location = new Point(565, 333);
            btnPdfRenta.Name = "btnPdfRenta";
            btnPdfRenta.Size = new Size(128, 54);
            btnPdfRenta.TabIndex = 1;
            btnPdfRenta.Text = "Généré PDF";
            btnPdfRenta.UseVisualStyleBackColor = true;
            // 
            // dgvProfitability
            // 
            dgvProfitability.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfitability.Location = new Point(3, 9);
            dgvProfitability.Name = "dgvProfitability";
            dgvProfitability.ReadOnly = true;
            dgvProfitability.RowHeadersWidth = 51;
            dgvProfitability.Size = new Size(540, 378);
            dgvProfitability.TabIndex = 0;
            // 
            // tpClientsAttitres
            // 
            tpClientsAttitres.BackColor = SystemColors.GradientInactiveCaption;
            tpClientsAttitres.Controls.Add(btnGenererPdfAttitres);
            tpClientsAttitres.Controls.Add(dgvClientsAttitres);
            tpClientsAttitres.Location = new Point(4, 29);
            tpClientsAttitres.Name = "tpClientsAttitres";
            tpClientsAttitres.Size = new Size(768, 393);
            tpClientsAttitres.TabIndex = 2;
            tpClientsAttitres.Text = "Clients Attitrés";
            // 
            // btnGenererPdfAttitres
            // 
            btnGenererPdfAttitres.Location = new Point(6, 342);
            btnGenererPdfAttitres.Name = "btnGenererPdfAttitres";
            btnGenererPdfAttitres.Size = new Size(200, 40);
            btnGenererPdfAttitres.TabIndex = 1;
            btnGenererPdfAttitres.Text = "Générer PDF";
            btnGenererPdfAttitres.UseVisualStyleBackColor = true;
            // 
            // dgvClientsAttitres
            // 
            dgvClientsAttitres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientsAttitres.Location = new Point(6, 6);
            dgvClientsAttitres.Name = "dgvClientsAttitres";
            dgvClientsAttitres.ReadOnly = true;
            dgvClientsAttitres.RowHeadersWidth = 51;
            dgvClientsAttitres.Size = new Size(756, 330);
            dgvClientsAttitres.TabIndex = 0;
            // 
            // FicManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FicManagement";
            Text = "VainEscort - Management";
            Load += FicManagement_Load;
            tabControl1.ResumeLayout(false);
            tpCA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartTurnover).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTurnover).EndInit();
            tpRent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProfitability).EndInit();
            tpClientsAttitres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientsAttitres).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCA;
        private System.Windows.Forms.TabPage tpRent;
        private System.Windows.Forms.TabPage tpClientsAttitres;
        private System.Windows.Forms.DataGridView dgvTurnover;
        private System.Windows.Forms.DataGridView dgvProfitability;
        private System.Windows.Forms.DataGridView dgvClientsAttitres;
        private System.Windows.Forms.Button btnGenererPdfAttitres;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnover;
        private System.Windows.Forms.Button btnCA;
        private System.Windows.Forms.Button btnPdfRenta;
    }
}