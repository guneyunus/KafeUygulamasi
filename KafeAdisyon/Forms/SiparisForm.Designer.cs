
namespace KafeAdisyon.Forms
{
    partial class SiparisForm
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
            this.flpKategoriler = new System.Windows.Forms.FlowLayoutPanel();
            this.flpUrunler = new System.Windows.Forms.FlowLayoutPanel();
            this.lblToplam = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.lstSiparisler = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // flpKategoriler
            // 
            this.flpKategoriler.Location = new System.Drawing.Point(13, 13);
            this.flpKategoriler.Name = "flpKategoriler";
            this.flpKategoriler.Size = new System.Drawing.Size(1024, 219);
            this.flpKategoriler.TabIndex = 0;
            // 
            // flpUrunler
            // 
            this.flpUrunler.Location = new System.Drawing.Point(12, 238);
            this.flpUrunler.Name = "flpUrunler";
            this.flpUrunler.Size = new System.Drawing.Size(1025, 497);
            this.flpUrunler.TabIndex = 1;
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Location = new System.Drawing.Point(1189, 554);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(50, 20);
            this.lblToplam.TabIndex = 3;
            this.lblToplam.Text = "label1";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(1043, 591);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(338, 60);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            // 
            // btnKapat
            // 
            this.btnKapat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnKapat.Location = new System.Drawing.Point(1043, 657);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(338, 60);
            this.btnKapat.TabIndex = 5;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            // 
            // lstSiparisler
            // 
            this.lstSiparisler.HideSelection = false;
            this.lstSiparisler.Location = new System.Drawing.Point(1044, 13);
            this.lstSiparisler.Name = "lstSiparisler";
            this.lstSiparisler.Size = new System.Drawing.Size(337, 523);
            this.lstSiparisler.TabIndex = 6;
            this.lstSiparisler.UseCompatibleStateImageBehavior = false;
            // 
            // SiparisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 747);
            this.Controls.Add(this.lstSiparisler);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.flpUrunler);
            this.Controls.Add(this.flpKategoriler);
            this.Name = "SiparisForm";
            this.Text = "SiparisForm";
            this.Load += new System.EventHandler(this.SiparisForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpKategoriler;
        private System.Windows.Forms.FlowLayoutPanel flpUrunler;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.ListView lstSiparisler;
    }
}