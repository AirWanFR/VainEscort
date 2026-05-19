namespace Projet_VainEscort
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            menuQuitter = new ToolStripMenuItem();
            gestionToolStripMenuItem = new ToolStripMenuItem();
            menuEmployes = new ToolStripMenuItem();
            menuClient = new ToolStripMenuItem();
            menuPrestation = new ToolStripMenuItem();
            documentsToolStripMenuItem = new ToolStripMenuItem();
            menuFacturation = new ToolStripMenuItem();
            menuManagement = new ToolStripMenuItem();
            webToolStripMenuItem = new ToolStripMenuItem();
            catalogueHTMLToolStripMenuItem = new ToolStripMenuItem();
            dgvPrestations = new DataGridView();
            dgvEmployes = new DataGridView();
            dgvClients = new DataGridView();
            btnNouvellePrestation = new Button();
            ssConnexion = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            lblStatsFactures = new Label();
            lblEmployes = new Label();
            lblClients = new Label();
            lblPresta = new Label();
            pnlAffichage = new Panel();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ssConnexion.SuspendLayout();
            pnlAffichage.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Violet;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, gestionToolStripMenuItem, documentsToolStripMenuItem, webToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1902, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuQuitter });
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new Size(66, 24);
            fichierToolStripMenuItem.Text = "Fichier";
            // 
            // menuQuitter
            // 
            menuQuitter.Name = "menuQuitter";
            menuQuitter.Size = new Size(138, 26);
            menuQuitter.Text = "Quitter";
            menuQuitter.Click += menuQuitter_Click;
            // 
            // gestionToolStripMenuItem
            // 
            gestionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuEmployes, menuClient, menuPrestation });
            gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            gestionToolStripMenuItem.Size = new Size(73, 24);
            gestionToolStripMenuItem.Text = "Gestion";
            // 
            // menuEmployes
            // 
            menuEmployes.Name = "menuEmployes";
            menuEmployes.Size = new Size(174, 26);
            menuEmployes.Text = "Employé(e)s";
            menuEmployes.Click += menuEmployes_Click;
            // 
            // menuClient
            // 
            menuClient.Name = "menuClient";
            menuClient.Size = new Size(174, 26);
            menuClient.Text = "Clients";
            menuClient.Click += menuClient_Click;
            // 
            // menuPrestation
            // 
            menuPrestation.Name = "menuPrestation";
            menuPrestation.Size = new Size(174, 26);
            menuPrestation.Text = "Presations";
            menuPrestation.Click += menuPrestation_Click;
            // 
            // documentsToolStripMenuItem
            // 
            documentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuFacturation, menuManagement });
            documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            documentsToolStripMenuItem.Size = new Size(98, 24);
            documentsToolStripMenuItem.Text = "Documents";
            // 
            // menuFacturation
            // 
            menuFacturation.Name = "menuFacturation";
            menuFacturation.Size = new Size(180, 26);
            menuFacturation.Text = "Facturations";
            menuFacturation.Click += menuFacturation_Click;
            // 
            // menuManagement
            // 
            menuManagement.Name = "menuManagement";
            menuManagement.Size = new Size(180, 26);
            menuManagement.Text = "Management";
            menuManagement.Click += menuManagement_Click;
            // 
            // webToolStripMenuItem
            // 
            webToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { catalogueHTMLToolStripMenuItem });
            webToolStripMenuItem.Name = "webToolStripMenuItem";
            webToolStripMenuItem.Size = new Size(53, 24);
            webToolStripMenuItem.Text = "Web";
            // 
            // catalogueHTMLToolStripMenuItem
            // 
            catalogueHTMLToolStripMenuItem.Name = "catalogueHTMLToolStripMenuItem";
            catalogueHTMLToolStripMenuItem.Size = new Size(203, 26);
            catalogueHTMLToolStripMenuItem.Text = "Catalogue HTML";
            catalogueHTMLToolStripMenuItem.Click += catalogueHTMLToolStripMenuItem_Click;
            // 
            // dgvPrestations
            // 
            dgvPrestations.AllowUserToAddRows = false;
            dgvPrestations.AllowUserToDeleteRows = false;
            dgvPrestations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestations.BackgroundColor = SystemColors.MenuHighlight;
            dgvPrestations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestations.Location = new Point(12, 27);
            dgvPrestations.Name = "dgvPrestations";
            dgvPrestations.ReadOnly = true;
            dgvPrestations.RowHeadersWidth = 51;
            dgvPrestations.Size = new Size(916, 876);
            dgvPrestations.TabIndex = 1;
            // 
            // dgvEmployes
            // 
            dgvEmployes.AllowUserToAddRows = false;
            dgvEmployes.AllowUserToDeleteRows = false;
            dgvEmployes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployes.BackgroundColor = SystemColors.MenuHighlight;
            dgvEmployes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployes.Location = new Point(962, 491);
            dgvEmployes.Name = "dgvEmployes";
            dgvEmployes.ReadOnly = true;
            dgvEmployes.RowHeadersWidth = 51;
            dgvEmployes.Size = new Size(928, 409);
            dgvEmployes.TabIndex = 2;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = SystemColors.MenuHighlight;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(962, 27);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(928, 425);
            dgvClients.TabIndex = 3;
            // 
            // btnNouvellePrestation
            // 
            btnNouvellePrestation.Anchor = AnchorStyles.Left;
            btnNouvellePrestation.BackColor = SystemColors.ButtonFace;
            btnNouvellePrestation.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNouvellePrestation.ForeColor = Color.Black;
            btnNouvellePrestation.Location = new Point(12, 3);
            btnNouvellePrestation.Name = "btnNouvellePrestation";
            btnNouvellePrestation.Size = new Size(285, 51);
            btnNouvellePrestation.TabIndex = 4;
            btnNouvellePrestation.Text = "Nouvelle Prestation";
            btnNouvellePrestation.UseVisualStyleBackColor = false;
            btnNouvellePrestation.Click += btnNouvellePrestation_Click;
            // 
            // ssConnexion
            // 
            ssConnexion.BackColor = Color.Violet;
            ssConnexion.ImageScalingSize = new Size(20, 20);
            ssConnexion.Items.AddRange(new ToolStripItem[] { tsslStatus });
            ssConnexion.Location = new Point(0, 1007);
            ssConnexion.Name = "ssConnexion";
            ssConnexion.RenderMode = ToolStripRenderMode.Professional;
            ssConnexion.Size = new Size(1902, 26);
            ssConnexion.TabIndex = 5;
            ssConnexion.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(85, 20);
            tsslStatus.Text = "En attente...";
            // 
            // lblStatsFactures
            // 
            lblStatsFactures.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblStatsFactures.AutoSize = true;
            lblStatsFactures.Font = new Font("Segoe UI", 12F);
            lblStatsFactures.Location = new Point(1649, 12);
            lblStatsFactures.Name = "lblStatsFactures";
            lblStatsFactures.Size = new Size(241, 28);
            lblStatsFactures.TabIndex = 6;
            lblStatsFactures.Text = "Aucune Facture en Attente";
            // 
            // lblEmployes
            // 
            lblEmployes.AutoSize = true;
            lblEmployes.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployes.Location = new Point(962, 468);
            lblEmployes.Name = "lblEmployes";
            lblEmployes.Size = new Size(78, 20);
            lblEmployes.TabIndex = 7;
            lblEmployes.Text = "Employés";
            // 
            // lblClients
            // 
            lblClients.AutoSize = true;
            lblClients.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClients.Location = new Point(962, 4);
            lblClients.Name = "lblClients";
            lblClients.Size = new Size(61, 20);
            lblClients.TabIndex = 8;
            lblClients.Text = "Clients";
            // 
            // lblPresta
            // 
            lblPresta.AutoSize = true;
            lblPresta.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPresta.Location = new Point(3, 4);
            lblPresta.Name = "lblPresta";
            lblPresta.Size = new Size(94, 20);
            lblPresta.TabIndex = 9;
            lblPresta.Text = "Préstations";
            // 
            // pnlAffichage
            // 
            pnlAffichage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAffichage.BackColor = Color.Plum;
            pnlAffichage.Controls.Add(lblPresta);
            pnlAffichage.Controls.Add(lblEmployes);
            pnlAffichage.Controls.Add(lblClients);
            pnlAffichage.Controls.Add(dgvClients);
            pnlAffichage.Controls.Add(dgvEmployes);
            pnlAffichage.Controls.Add(dgvPrestations);
            pnlAffichage.Location = new Point(0, 28);
            pnlAffichage.Name = "pnlAffichage";
            pnlAffichage.Size = new Size(1902, 910);
            pnlAffichage.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Plum;
            panel1.Controls.Add(btnNouvellePrestation);
            panel1.Controls.Add(lblStatsFactures);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 944);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 63);
            panel1.TabIndex = 11;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Violet;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(pnlAffichage);
            Controls.Add(ssConnexion);
            Controls.Add(menuStrip1);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "VainEscort - Accueil";
            WindowState = FormWindowState.Maximized;
            Load += Home_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestations).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ssConnexion.ResumeLayout(false);
            ssConnexion.PerformLayout();
            pnlAffichage.ResumeLayout(false);
            pnlAffichage.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem documentsToolStripMenuItem;
        private ToolStripMenuItem webToolStripMenuItem;
        private DataGridView dgvPrestations;
        private ToolStripMenuItem menuQuitter;
        private ToolStripMenuItem menuEmployes;
        private ToolStripMenuItem menuClient;
        private ToolStripMenuItem menuPrestation;
        private ToolStripMenuItem menuFacturation;
        private ToolStripMenuItem menuManagement;
        private ToolStripMenuItem catalogueHTMLToolStripMenuItem;
        private DataGridView dgvEmployes;
        private DataGridView dgvClients;
        private Button btnNouvellePrestation;
        private StatusStrip ssConnexion;
        private Label lblStatsFactures;
        private ToolStripStatusLabel tsslStatus;
        private Label lblEmployes;
        private Label lblClients;
        private Label lblPresta;
        private Panel pnlAffichage;
        private Panel panel1;
    }
}
