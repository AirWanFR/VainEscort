namespace Projet_VainEscort
{
    partial class FicClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicClients));
            pnlBouton = new Panel();
            txtEmail = new TextBox();
            lEmail = new Label();
            txtTelephone = new TextBox();
            lTel = new Label();
            cmbEmployes = new ComboBox();
            label1 = new Label();
            btnSupprimer = new Button();
            btnModifier = new Button();
            btnAjouter = new Button();
            txtNom = new TextBox();
            lNom = new Label();
            txtPrenom = new TextBox();
            lPrenom = new Label();
            dgvClients = new DataGridView();
            btnQuitter = new Button();
            pnlBouton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // pnlBouton
            // 
            pnlBouton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBouton.Controls.Add(txtEmail);
            pnlBouton.Controls.Add(lEmail);
            pnlBouton.Controls.Add(txtTelephone);
            pnlBouton.Controls.Add(lTel);
            pnlBouton.Controls.Add(cmbEmployes);
            pnlBouton.Controls.Add(label1);
            pnlBouton.Controls.Add(btnSupprimer);
            pnlBouton.Controls.Add(btnModifier);
            pnlBouton.Controls.Add(btnAjouter);
            pnlBouton.Controls.Add(txtNom);
            pnlBouton.Controls.Add(lNom);
            pnlBouton.Controls.Add(txtPrenom);
            pnlBouton.Controls.Add(lPrenom);
            pnlBouton.Location = new Point(542, 38);
            pnlBouton.Name = "pnlBouton";
            pnlBouton.Size = new Size(423, 200);
            pnlBouton.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(214, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 12;
            // 
            // lEmail
            // 
            lEmail.AutoSize = true;
            lEmail.Location = new Point(214, 75);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(46, 20);
            lEmail.TabIndex = 11;
            lEmail.Text = "Email";
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(83, 98);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(125, 27);
            txtTelephone.TabIndex = 10;
            // 
            // lTel
            // 
            lTel.AutoSize = true;
            lTel.Location = new Point(83, 75);
            lTel.Name = "lTel";
            lTel.Size = new Size(78, 20);
            lTel.TabIndex = 9;
            lTel.Text = "Téléphone";
            // 
            // cmbEmployes
            // 
            cmbEmployes.FormattingEnabled = true;
            cmbEmployes.Location = new Point(266, 36);
            cmbEmployes.Name = "cmbEmployes";
            cmbEmployes.Size = new Size(151, 28);
            cmbEmployes.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 13);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 7;
            label1.Text = "Employé(e) Attitré(e)";
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(223, 140);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 39);
            btnSupprimer.TabIndex = 6;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(123, 140);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(94, 39);
            btnModifier.TabIndex = 5;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(23, 140);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 39);
            btnAjouter.TabIndex = 4;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(135, 36);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(125, 27);
            txtNom.TabIndex = 3;
            // 
            // lNom
            // 
            lNom.AutoSize = true;
            lNom.Location = new Point(135, 13);
            lNom.Name = "lNom";
            lNom.Size = new Size(42, 20);
            lNom.TabIndex = 2;
            lNom.Text = "Nom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(4, 36);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(125, 27);
            txtPrenom.TabIndex = 1;
            // 
            // lPrenom
            // 
            lPrenom.AutoSize = true;
            lPrenom.Location = new Point(4, 13);
            lPrenom.Name = "lPrenom";
            lPrenom.Size = new Size(60, 20);
            lPrenom.TabIndex = 0;
            lPrenom.Text = "Prénom";
            // 
            // dgvClients
            // 
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(12, 38);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(524, 374);
            dgvClients.TabIndex = 2;
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(871, 373);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 39);
            btnQuitter.TabIndex = 13;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // FicClients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(977, 450);
            ControlBox = false;
            Controls.Add(btnQuitter);
            Controls.Add(pnlBouton);
            Controls.Add(dgvClients);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FicClients";
            Text = "VainEscort - Gestion Clients";
            Load += FicClients_Load;
            pnlBouton.ResumeLayout(false);
            pnlBouton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBouton;
        private ComboBox cmbEmployes;
        private Label label1;
        private Button btnSupprimer;
        private Button btnModifier;
        private Button btnAjouter;
        private TextBox txtNom;
        private Label lNom;
        private TextBox txtPrenom;
        private Label lPrenom;
        private DataGridView dgvClients;
        private TextBox txtEmail;
        private Label lEmail;
        private TextBox txtTelephone;
        private Label lTel;
        private Button btnQuitter;
    }
}