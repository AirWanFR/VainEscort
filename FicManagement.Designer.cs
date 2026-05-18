namespace Projet_VainEscort
{
    // CORRECTION : On renomme la classe pour qu'elle corresponde exactement au fichier principal
    partial class FicManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCA = new System.Windows.Forms.TabPage();
            this.chartTurnover = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTurnover = new System.Windows.Forms.DataGridView();
            this.tpRent = new System.Windows.Forms.TabPage();
            this.dgvProfitability = new System.Windows.Forms.DataGridView();
            this.tpClientsAttitres = new System.Windows.Forms.TabPage();
            this.btnGenererPdfAttitres = new System.Windows.Forms.Button();
            this.dgvClientsAttitres = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpCA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnover)).BeginInit();
            this.tpRent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitability)).BeginInit();
            this.tpClientsAttitres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsAttitres)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCA);
            this.tabControl1.Controls.Add(this.tpRent);
            this.tabControl1.Controls.Add(this.tpClientsAttitres);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCA
            // 
            this.tpCA.Controls.Add(this.chartTurnover);
            this.tpCA.Controls.Add(this.dgvTurnover);
            this.tpCA.Location = new System.Drawing.Point(4, 29);
            this.tpCA.Name = "tpCA";
            this.tpCA.Padding = new System.Windows.Forms.Padding(3);
            this.tpCA.Size = new System.Drawing.Size(768, 393);
            this.tpCA.TabIndex = 0;
            this.tpCA.Text = "Chiffre d\'Affaires";
            this.tpCA.UseVisualStyleBackColor = true;
            // 
            // chartTurnover
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTurnover.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTurnover.Legends.Add(legend1);
            this.chartTurnover.Location = new System.Drawing.Point(383, 6);
            this.chartTurnover.Name = "chartTurnover";
            this.chartTurnover.Size = new System.Drawing.Size(379, 381);
            this.chartTurnover.TabIndex = 1;
            this.chartTurnover.Text = "chart1";
            // 
            // dgvTurnover
            // 
            this.dgvTurnover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnover.Location = new System.Drawing.Point(6, 6);
            this.dgvTurnover.Name = "dgvTurnover";
            this.dgvTurnover.RowHeadersWidth = 51;
            this.dgvTurnover.Size = new System.Drawing.Size(371, 381);
            this.dgvTurnover.TabIndex = 0;
            // 
            // tpRent
            // 
            this.tpRent.Controls.Add(this.dgvProfitability);
            this.tpRent.Location = new System.Drawing.Point(4, 29);
            this.tpRent.Name = "tpRent";
            this.tpRent.Padding = new System.Windows.Forms.Padding(3);
            this.tpRent.Size = new System.Drawing.Size(768, 393);
            this.tpRent.TabIndex = 1;
            this.tpRent.Text = "Rentabilité";
            this.tpRent.UseVisualStyleBackColor = true;
            // 
            // dgvProfitability
            // 
            this.dgvProfitability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfitability.Location = new System.Drawing.Point(6, 6);
            this.dgvProfitability.Name = "dgvProfitability";
            this.dgvProfitability.RowHeadersWidth = 51;
            this.dgvProfitability.Size = new System.Drawing.Size(756, 381);
            this.dgvProfitability.TabIndex = 0;
            // 
            // tpClientsAttitres
            // 
            this.tpClientsAttitres.Controls.Add(this.btnGenererPdfAttitres);
            this.tpClientsAttitres.Controls.Add(this.dgvClientsAttitres);
            this.tpClientsAttitres.Location = new System.Drawing.Point(4, 29);
            this.tpClientsAttitres.Name = "tpClientsAttitres";
            this.tpClientsAttitres.Size = new System.Drawing.Size(768, 393);
            this.tpClientsAttitres.TabIndex = 2;
            this.tpClientsAttitres.Text = "Clients Attitrés";
            this.tpClientsAttitres.UseVisualStyleBackColor = true;
            // 
            // btnGenererPdfAttitres
            // 
            this.btnGenererPdfAttitres.Location = new System.Drawing.Point(6, 342);
            this.btnGenererPdfAttitres.Name = "btnGenererPdfAttitres";
            this.btnGenererPdfAttitres.Size = new System.Drawing.Size(200, 40);
            this.btnGenererPdfAttitres.TabIndex = 1;
            this.btnGenererPdfAttitres.Text = "Générer PDF";
            this.btnGenererPdfAttitres.UseVisualStyleBackColor = true;
            this.btnGenererPdfAttitres.Click += new System.EventHandler(this.btnGenererPdfAttitres_Click);
            // 
            // dgvClientsAttitres
            // 
            this.dgvClientsAttitres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientsAttitres.Location = new System.Drawing.Point(6, 6);
            this.dgvClientsAttitres.Name = "dgvClientsAttitres";
            this.dgvClientsAttitres.RowHeadersWidth = 51;
            this.dgvClientsAttitres.Size = new System.Drawing.Size(756, 330);
            this.dgvClientsAttitres.TabIndex = 0;
            // 
            // FicManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            // CORRECTION : Le nom de la fenêtre et l'événement de chargement
            this.Name = "FicManagement";
            this.Text = "VainEscort - Management";
            this.Load += new System.EventHandler(this.FicManagement_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnover)).EndInit();
            this.tpRent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitability)).EndInit();
            this.tpClientsAttitres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsAttitres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCA;
        private System.Windows.Forms.TabPage tpRent;
        private System.Windows.Forms.TabPage tpClientsAttitres;
        private System.Windows.Forms.DataGridView dgvTurnover;
        private System.Windows.Forms.DataGridView dgvProfitability;
        private System.Windows.Forms.DataGridView dgvClientsAttitres;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnover;
        private System.Windows.Forms.Button btnGenererPdfAttitres;
    }
}