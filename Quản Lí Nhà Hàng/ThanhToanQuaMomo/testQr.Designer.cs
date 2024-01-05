namespace Quản_Lí_Nhà_Hàng.ThanhToanQuaMomo
{
    partial class testQr
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
            this.ptbQr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQr)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbQr
            // 
            this.ptbQr.Location = new System.Drawing.Point(226, 126);
            this.ptbQr.Name = "ptbQr";
            this.ptbQr.Size = new System.Drawing.Size(247, 212);
            this.ptbQr.TabIndex = 0;
            this.ptbQr.TabStop = false;
            // 
            // testQr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ptbQr);
            this.Name = "testQr";
            this.Text = "testQr";
            this.Load += new System.EventHandler(this.testQr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbQr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbQr;
    }
}