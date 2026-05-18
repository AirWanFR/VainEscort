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
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ssConnexion.SuspendLayout();
            pnlAffichage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, gestionToolStripMenuItem, documentsToolStripMenuItem, webToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1093, 28);
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
            catalogueHTMLToolStripMenuItem.Size = new Size(224, 26);
            catalogueHTMLToolStripMenuItem.Text = "Catalogue HTML";
            catalogueHTMLToolStripMenuItem.Click += catalogueHTMLToolStripMenuItem_Click;
            // 
            // dgvPrestations
            // 
            dgvPrestations.AllowUserToAddRows = false;
            dgvPrestations.AllowUserToDeleteRows = false;
            dgvPrestations.BackgroundColor = SystemColors.Window;
            dgvPrestations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestations.Location = new Point(0, 27);
            dgvPrestations.Name = "dgvPrestations";
            dgvPrestations.ReadOnly = true;
            dgvPrestations.RowHeadersWidth = 51;
            dgvPrestations.Size = new Size(510, 399);
            dgvPrestations.TabIndex = 1;
            // 
            // dgvEmployes
            // 
            dgvEmployes.AllowUserToAddRows = false;
            dgvEmployes.AllowUserToDeleteRows = false;
            dgvEmployes.BackgroundColor = SystemColors.Window;
            dgvEmployes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployes.Location = new Point(516, 266);
            dgvEmployes.Name = "dgvEmployes";
            dgvEmployes.ReadOnly = true;
            dgvEmployes.RowHeadersWidth = 51;
            dgvEmployes.Size = new Size(529, 160);
            dgvEmployes.TabIndex = 2;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.BackgroundColor = SystemColors.Window;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(516, 27);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(529, 213);
            dgvClients.TabIndex = 3;
            // 
            // btnNouvellePrestation
            // 
            btnNouvellePrestation.Anchor = AnchorStyles.Left;
            btnNouvellePrestation.Location = new Point(12, 466);
            btnNouvellePrestation.Name = "btnNouvellePrestation";
            btnNouvellePrestation.Size = new Size(276, 39);
            btnNouvellePrestation.TabIndex = 4;
            btnNouvellePrestation.Text = "Nouvelle Prestation";
            btnNouvellePrestation.UseVisualStyleBackColor = true;
            btnNouvellePrestation.Click += btnNouvellePrestation_Click;
            // 
            // ssConnexion
            // 
            ssConnexion.ImageScalingSize = new Size(20, 20);
            ssConnexion.Items.AddRange(new ToolStripItem[] { tsslStatus });
            ssConnexion.Location = new Point(0, 510);
            ssConnexion.Name = "ssConnexion";
            ssConnexion.RenderMode = ToolStripRenderMode.Professional;
            ssConnexion.Size = new Size(1093, 26);
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
            lblStatsFactures.Location = new Point(882, 485);
            lblStatsFactures.Name = "lblStatsFactures";
            lblStatsFactures.Size = new Size(182, 20);
            lblStatsFactures.TabIndex = 6;
            lblStatsFactures.Text = "Aucune Facture en Attente";
            // 
            // lblEmployes
            // 
            lblEmployes.AutoSize = true;
            lblEmployes.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployes.Location = new Point(516, 243);
            lblEmployes.Name = "lblEmployes";
            lblEmployes.Size = new Size(78, 20);
            lblEmployes.TabIndex = 7;
            lblEmployes.Text = "Employés";
            // 
            // lblClients
            // 
            lblClients.AutoSize = true;
            lblClients.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClients.Location = new Point(516, 4);
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
            pnlAffichage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pnlAffichage.Controls.Add(lblPresta);
            pnlAffichage.Controls.Add(lblEmployes);
            pnlAffichage.Controls.Add(lblClients);
            pnlAffichage.Controls.Add(dgvClients);
            pnlAffichage.Controls.Add(dgvEmployes);
            pnlAffichage.Controls.Add(dgvPrestations);
            pnlAffichage.Location = new Point(12, 31);
            pnlAffichage.Name = "pnlAffichage";
            pnlAffichage.Size = new Size(1069, 429);
            pnlAffichage.TabIndex = 10;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 536);
            Controls.Add(pnlAffichage);
            Controls.Add(lblStatsFactures);
            Controls.Add(ssConnexion);
            Controls.Add(btnNouvellePrestation);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "VainEscort - Accueil";
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
    }
}
