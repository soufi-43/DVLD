namespace DVLD
{
    partial class frmListActiveLicences
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
            this.dgvListActiveLicenses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListActiveLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListActiveLicenses
            // 
            this.dgvListActiveLicenses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListActiveLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListActiveLicenses.Location = new System.Drawing.Point(24, 46);
            this.dgvListActiveLicenses.Name = "dgvListActiveLicenses";
            this.dgvListActiveLicenses.Size = new System.Drawing.Size(755, 253);
            this.dgvListActiveLicenses.TabIndex = 0;
            // 
            // frmListActiveLicences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvListActiveLicenses);
            this.Name = "frmListActiveLicences";
            this.Text = "frmListActiveLicences";
            this.Load += new System.EventHandler(this.frmListActiveLicences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListActiveLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListActiveLicenses;
    }
}