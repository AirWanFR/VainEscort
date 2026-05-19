namespace Projet_VainEscort
{
    partial class FicEmployes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicEmployes));
            dgvEmployes = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            chkActif = new CheckBox();
            txtTelephone = new TextBox();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            btnSuppr = new Button();
            btnModif = new Button();
            btnAjouter = new Button();
            txtNom = new TextBox();
            lNom = new Label();
            txtPrenom = new TextBox();
            lPrenom = new Label();
            btnQuitter = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmployes
            // 
            dgvEmployes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployes.Location = new Point(12, 49);
            dgvEmployes.Name = "dgvEmployes";
            dgvEmployes.RowHeadersWidth = 51;
            dgvEmployes.Size = new Size(407, 374);
            dgvEmployes.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(chkActif);
            panel1.Controls.Add(txtTelephone);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnSuppr);
            panel1.Controls.Add(btnModif);
            panel1.Controls.Add(btnAjouter);
            panel1.Controls.Add(txtNom);
            panel1.Controls.Add(lNom);
            panel1.Controls.Add(txtPrenom);
            panel1.Controls.Add(lPrenom);
            panel1.Location = new Point(425, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(363, 200);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(302, 79);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 12;
            label3.Text = "Actif";
            // 
            // chkActif
            // 
            chkActif.AutoSize = true;
            chkActif.Location = new Point(314, 112);
            chkActif.Name = "chkActif";
            chkActif.Size = new Size(18, 17);
            chkActif.TabIndex = 11;
            chkActif.UseVisualStyleBackColor = true;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(166, 102);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(125, 27);
            txtTelephone.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 79);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 9;
            label1.Text = "Téléphone";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(19, 102);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(141, 27);
            txtEmail.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 79);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 7;
            label2.Text = "Email";
            // 
            // btnSuppr
            // 
            btnSuppr.Location = new Point(226, 158);
            btnSuppr.Name = "btnSuppr";
            btnSuppr.Size = new Size(94, 39);
            btnSuppr.TabIndex = 6;
            btnSuppr.Text = "Supprimer";
            btnSuppr.UseVisualStyleBackColor = true;
            btnSuppr.Click += btnSupprimer_Click;
            // 
            // btnModif
            // 
            btnModif.Location = new Point(126, 158);
            btnModif.Name = "btnModif";
            btnModif.Size = new Size(94, 39);
            btnModif.TabIndex = 5;
            btnModif.Text = "Modifier";
            btnModif.UseVisualStyleBackColor = true;
            btnModif.Click += btnModifier_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(26, 158);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 39);
            btnAjouter.TabIndex = 4;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(166, 33);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(154, 27);
            txtNom.TabIndex = 3;
            // 
            // lNom
            // 
            lNom.AutoSize = true;
            lNom.Location = new Point(206, 10);
            lNom.Name = "lNom";
            lNom.Size = new Size(42, 20);
            lNom.TabIndex = 2;
            lNom.Text = "Nom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(35, 33);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(125, 27);
            txtPrenom.TabIndex = 1;
            // 
            // lPrenom
            // 
            lPrenom.AutoSize = true;
            lPrenom.Location = new Point(64, 10);
            lPrenom.Name = "lPrenom";
            lPrenom.Size = new Size(60, 20);
            lPrenom.TabIndex = 0;
            lPrenom.Text = "Prénom";
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(694, 384);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 39);
            btnQuitter.TabIndex = 14;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // FicEmployes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnQuitter);
            Controls.Add(panel1);
            Controls.Add(dgvEmployes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FicEmployes";
            Text = "VainEscort - Employés";
            ((System.ComponentModel.ISupportInitialize)dgvEmployes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmployes;
        private Panel panel1;
        private Button btnAjouter;
        private TextBox txtNom;
        private Label lNom;
        private TextBox txtPrenom;
        private Label lPrenom;
        private Button btnSuppr;
        private Button btnModif;
        private Button btnQuitter;
        private TextBox txtTelephone;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private CheckBox chkActif;
        private Label label3;
    }
}