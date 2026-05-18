namespace Projet_VainEscort
{
    partial class FicFacturation
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
            dgvFacturation = new DataGridView();
            btnGenererFactures = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturation).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturation
            // 
            dgvFacturation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturation.Location = new Point(12, 12);
            dgvFacturation.Name = "dgvFacturation";
            dgvFacturation.RowHeadersWidth = 51;
            dgvFacturation.Size = new Size(403, 282);
            dgvFacturation.TabIndex = 0;
            // 
            // btnGenererFactures
            // 
            btnGenererFactures.Anchor = AnchorStyles.Bottom;
            btnGenererFactures.Location = new Point(111, 322);
            btnGenererFactures.Name = "btnGenererFactures";
            btnGenererFactures.Size = new Size(202, 29);
            btnGenererFactures.TabIndex = 1;
            btnGenererFactures.Text = "Générer toutes les factures";
            btnGenererFactures.UseVisualStyleBackColor = true;
            btnGenererFactures.Click += btnGenererFactures_Click;
            // 
            // FicFacturation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 450);
            Controls.Add(btnGenererFactures);
            Controls.Add(dgvFacturation);
            Name = "FicFacturation";
            Text = "VainEscort - Facturation";
            Load += FicFacturation_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFacturation;
        private Button btnGenererFactures;
    }
}