
namespace KafeAdisyon.Forms
{
    partial class KafeGorunumForm
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
            this.flpKatlar = new System.Windows.Forms.FlowLayoutPanel();
            this.flpMasalar = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpKatlar
            // 
            this.flpKatlar.Location = new System.Drawing.Point(13, 13);
            this.flpKatlar.Name = "flpKatlar";
            this.flpKatlar.Size = new System.Drawing.Size(1329, 163);
            this.flpKatlar.TabIndex = 0;
            // 
            // flpMasalar
            // 
            this.flpMasalar.Location = new System.Drawing.Point(13, 183);
            this.flpMasalar.Name = "flpMasalar";
            this.flpMasalar.Size = new System.Drawing.Size(1329, 553);
            this.flpMasalar.TabIndex = 1;
            // 
            // KafeGorunumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 748);
            this.Controls.Add(this.flpMasalar);
            this.Controls.Add(this.flpKatlar);
            this.Name = "KafeGorunumForm";
            this.Text = "KafeGorunumForm";
            this.Load += new System.EventHandler(this.KafeGorunumForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpKatlar;
        private System.Windows.Forms.FlowLayoutPanel flpMasalar;
    }
}