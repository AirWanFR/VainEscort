namespace Projet_VainEscort
{
    partial class FicCatalogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicCatalogue));
            btnActualiser = new Button();
            btnExporterHTML = new Button();
            panel1 = new Panel();
            webBrowserCatalogue = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webBrowserCatalogue).BeginInit();
            SuspendLayout();
            // 
            // btnActualiser
            // 
            btnActualiser.Location = new Point(14, 3);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(94, 29);
            btnActualiser.TabIndex = 0;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = true;
            btnActualiser.Click += btnActualiser_Click;
            // 
            // btnExporterHTML
            // 
            btnExporterHTML.Location = new Point(114, 3);
            btnExporterHTML.Name = "btnExporterHTML";
            btnExporterHTML.Size = new Size(154, 29);
            btnExporterHTML.TabIndex = 1;
            btnExporterHTML.Text = "Exporter HTML";
            btnExporterHTML.UseVisualStyleBackColor = true;
            btnExporterHTML.Click += btnExporterHTML_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActualiser);
            panel1.Controls.Add(btnExporterHTML);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 37);
            panel1.TabIndex = 2;
            // 
            // webBrowserCatalogue
            // 
            webBrowserCatalogue.AllowExternalDrop = true;
            webBrowserCatalogue.CreationProperties = null;
            webBrowserCatalogue.DefaultBackgroundColor = Color.White;
            webBrowserCatalogue.Dock = DockStyle.Fill;
            webBrowserCatalogue.Location = new Point(0, 37);
            webBrowserCatalogue.Name = "webBrowserCatalogue";
            webBrowserCatalogue.Size = new Size(800, 413);
            webBrowserCatalogue.TabIndex = 3;
            webBrowserCatalogue.ZoomFactor = 1D;
            // 
            // FicCatalogue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(webBrowserCatalogue);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FicCatalogue";
            Text = "VainEscort - Catalogue";
            Load += FicCatalogue_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webBrowserCatalogue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnActualiser;
        private Button btnExporterHTML;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webBrowserCatalogue;
    }
}