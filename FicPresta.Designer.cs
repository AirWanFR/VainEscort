namespace Projet_VainEscort
{
    partial class FicPresta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicPresta));
            panel1 = new Panel();
            lblHeure = new Label();
            lblDate = new Label();
            numHeures = new NumericUpDown();
            dtpDate = new DateTimePicker();
            cmbTypes = new ComboBox();
            lblType = new Label();
            cmbEmployes = new ComboBox();
            label2 = new Label();
            cmbClients = new ComboBox();
            label1 = new Label();
            btnSuppr = new Button();
            btnModif = new Button();
            btnAjouter = new Button();
            dgvPresta = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHeures).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPresta).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeure);
            panel1.Controls.Add(lblDate);
            panel1.Controls.Add(numHeures);
            panel1.Controls.Add(dtpDate);
            panel1.Controls.Add(cmbTypes);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(cmbEmployes);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbClients);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSuppr);
            panel1.Controls.Add(btnModif);
            panel1.Controls.Add(btnAjouter);
            panel1.Location = new Point(12, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 200);
            panel1.TabIndex = 5;
            panel1.UseWaitCursor = true;
            // 
            // lblHeure
            // 
            lblHeure.AutoSize = true;
            lblHeure.Location = new Point(650, 9);
            lblHeure.Name = "lblHeure";
            lblHeure.RightToLeft = RightToLeft.Yes;
            lblHeure.Size = new Size(123, 20);
            lblHeure.TabIndex = 17;
            lblHeure.Text = "Nombre d'heures";
            lblHeure.UseWaitCursor = true;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(481, 10);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 15;
            lblDate.Text = "Date";
            lblDate.UseWaitCursor = true;
            // 
            // numHeures
            // 
            numHeures.Location = new Point(653, 32);
            numHeures.Name = "numHeures";
            numHeures.Size = new Size(120, 27);
            numHeures.TabIndex = 14;
            numHeures.UseWaitCursor = true;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(481, 33);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(166, 27);
            dtpDate.TabIndex = 13;
            dtpDate.UseWaitCursor = true;
            // 
            // cmbTypes
            // 
            cmbTypes.FormattingEnabled = true;
            cmbTypes.Location = new Point(324, 32);
            cmbTypes.Name = "cmbTypes";
            cmbTypes.Size = new Size(151, 28);
            cmbTypes.TabIndex = 12;
            cmbTypes.UseWaitCursor = true;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(324, 9);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 20);
            lblType.TabIndex = 11;
            lblType.Text = "Type";
            lblType.UseWaitCursor = true;
            // 
            // cmbEmployes
            // 
            cmbEmployes.FormattingEnabled = true;
            cmbEmployes.Location = new Point(169, 32);
            cmbEmployes.Name = "cmbEmployes";
            cmbEmployes.Size = new Size(151, 28);
            cmbEmployes.TabIndex = 10;
            cmbEmployes.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(169, 9);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 9;
            label2.Text = "Employé(e) Attitré(e)";
            label2.UseWaitCursor = true;
            // 
            // cmbClients
            // 
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(14, 32);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(151, 28);
            cmbClients.TabIndex = 8;
            cmbClients.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 7;
            label1.Text = "Client";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseWaitCursor = true;
            // 
            // btnSuppr
            // 
            btnSuppr.Location = new Point(460, 140);
            btnSuppr.Name = "btnSuppr";
            btnSuppr.Size = new Size(94, 39);
            btnSuppr.TabIndex = 6;
            btnSuppr.Text = "Supprimer";
            btnSuppr.UseVisualStyleBackColor = true;
            btnSuppr.UseWaitCursor = true;
            btnSuppr.Click += btnSupprimer_Click;
            // 
            // btnModif
            // 
            btnModif.Location = new Point(360, 140);
            btnModif.Name = "btnModif";
            btnModif.Size = new Size(94, 39);
            btnModif.TabIndex = 5;
            btnModif.Text = "Modifier";
            btnModif.UseVisualStyleBackColor = true;
            btnModif.UseWaitCursor = true;
            btnModif.Click += btnModifier_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(260, 140);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 39);
            btnAjouter.TabIndex = 4;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.UseWaitCursor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // dgvPresta
            // 
            dgvPresta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPresta.Location = new Point(12, 255);
            dgvPresta.Name = "dgvPresta";
            dgvPresta.RowHeadersWidth = 51;
            dgvPresta.Size = new Size(776, 157);
            dgvPresta.TabIndex = 4;
            dgvPresta.UseWaitCursor = true;
            dgvPresta.CellContentClick += dgvPresta_CellClick;
            // 
            // FicPresta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvPresta);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FicPresta";
            Text = "VainEscort - Prestation";
            Load += FicPresta_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHeures).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPresta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbEmployes;
        private Label label2;
        private ComboBox cmbClients;
        private Label label1;
        private Button btnSuppr;
        private Button btnModif;
        private Button btnAjouter;
        private DataGridView dgvPresta;
        private ComboBox cmbTypes;
        private Label lblType;
        private DateTimePicker dtpDate;
        private Label lblDate;
        private NumericUpDown numHeures;
        private Label lblHeure;
    }
}