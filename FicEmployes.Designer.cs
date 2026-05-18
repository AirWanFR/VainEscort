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
            dgvEmployes = new DataGridView();
            panel1 = new Panel();
            btnSuppr = new Button();
            btnModif = new Button();
            btnAjouter = new Button();
            txtNom = new TextBox();
            lNom = new Label();
            txtPrenom = new TextBox();
            lPrenom = new Label();
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
            // btnSuppr
            // 
            btnSuppr.Location = new Point(223, 108);
            btnSuppr.Name = "btnSuppr";
            btnSuppr.Size = new Size(94, 39);
            btnSuppr.TabIndex = 6;
            btnSuppr.Text = "Supprimer";
            btnSuppr.UseVisualStyleBackColor = true;
            btnSuppr.Click += btnSupprimer_Click;
            // 
            // btnModif
            // 
            btnModif.Location = new Point(123, 108);
            btnModif.Name = "btnModif";
            btnModif.Size = new Size(94, 39);
            btnModif.TabIndex = 5;
            btnModif.Text = "Modifier";
            btnModif.UseVisualStyleBackColor = true;
            btnModif.Click += btnModifier_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(23, 108);
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
            txtNom.Size = new Size(125, 27);
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
            // FicEmployes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvEmployes);
            Name = "FicEmployes";
            Text = "FicEmployes";
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
    }
}