
namespace KafeAdisyon.Forms
{
    partial class MenuForm
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
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.pbKategori = new System.Windows.Forms.PictureBox();
            this.btnKategoriKaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstKategori = new System.Windows.Forms.ListBox();
            this.nFiyat = new System.Windows.Forms.NumericUpDown();
            this.pbUrun = new System.Windows.Forms.PictureBox();
            this.btnUrunKaydet = new System.Windows.Forms.Button();
            this.lstUrunler = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUrun)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(106, 57);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(125, 27);
            this.txtKategoriAdi.TabIndex = 0;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(545, 62);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(164, 27);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // pbKategori
            // 
            this.pbKategori.Location = new System.Drawing.Point(34, 90);
            this.pbKategori.Name = "pbKategori";
            this.pbKategori.Size = new System.Drawing.Size(197, 169);
            this.pbKategori.TabIndex = 2;
            this.pbKategori.TabStop = false;
            this.pbKategori.Click += new System.EventHandler(this.pbKategori_Click);
            // 
            // btnKategoriKaydet
            // 
            this.btnKategoriKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKategoriKaydet.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKategoriKaydet.Location = new System.Drawing.Point(34, 265);
            this.btnKategoriKaydet.Name = "btnKategoriKaydet";
            this.btnKategoriKaydet.Size = new System.Drawing.Size(197, 116);
            this.btnKategoriKaydet.TabIndex = 3;
            this.btnKategoriKaydet.Text = "Kategori Kaydet";
            this.btnKategoriKaydet.UseVisualStyleBackColor = false;
            this.btnKategoriKaydet.Click += new System.EventHandler(this.btnKategoriKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori:";
            // 
            // lstKategori
            // 
            this.lstKategori.FormattingEnabled = true;
            this.lstKategori.ItemHeight = 20;
            this.lstKategori.Location = new System.Drawing.Point(237, 57);
            this.lstKategori.Name = "lstKategori";
            this.lstKategori.Size = new System.Drawing.Size(227, 324);
            this.lstKategori.TabIndex = 5;
            this.lstKategori.SelectedIndexChanged += new System.EventHandler(this.lstKategori_SelectedIndexChanged);
            // 
            // nFiyat
            // 
            this.nFiyat.DecimalPlaces = 2;
            this.nFiyat.Location = new System.Drawing.Point(545, 93);
            this.nFiyat.Name = "nFiyat";
            this.nFiyat.Size = new System.Drawing.Size(163, 27);
            this.nFiyat.TabIndex = 6;
            // 
            // pbUrun
            // 
            this.pbUrun.Location = new System.Drawing.Point(499, 126);
            this.pbUrun.Name = "pbUrun";
            this.pbUrun.Size = new System.Drawing.Size(210, 133);
            this.pbUrun.TabIndex = 7;
            this.pbUrun.TabStop = false;
            this.pbUrun.Click += new System.EventHandler(this.pbUrun_Click);
            // 
            // btnUrunKaydet
            // 
            this.btnUrunKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUrunKaydet.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUrunKaydet.Location = new System.Drawing.Point(499, 265);
            this.btnUrunKaydet.Name = "btnUrunKaydet";
            this.btnUrunKaydet.Size = new System.Drawing.Size(209, 121);
            this.btnUrunKaydet.TabIndex = 8;
            this.btnUrunKaydet.Text = "Ürün Kaydet";
            this.btnUrunKaydet.UseVisualStyleBackColor = false;
            this.btnUrunKaydet.Click += new System.EventHandler(this.btnUrunKaydet_Click);
            // 
            // lstUrunler
            // 
            this.lstUrunler.FormattingEnabled = true;
            this.lstUrunler.ItemHeight = 20;
            this.lstUrunler.Location = new System.Drawing.Point(714, 62);
            this.lstUrunler.Name = "lstUrunler";
            this.lstUrunler.Size = new System.Drawing.Size(205, 324);
            this.lstUrunler.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(490, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ürün:";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(974, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstUrunler);
            this.Controls.Add(this.btnUrunKaydet);
            this.Controls.Add(this.pbUrun);
            this.Controls.Add(this.nFiyat);
            this.Controls.Add(this.lstKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKategoriKaydet);
            this.Controls.Add(this.pbKategori);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.txtKategoriAdi);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUrun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.PictureBox pbKategori;
        private System.Windows.Forms.Button btnKategoriKaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstKategori;
        private System.Windows.Forms.NumericUpDown nFiyat;
        private System.Windows.Forms.PictureBox pbUrun;
        private System.Windows.Forms.Button btnUrunKaydet;
        private System.Windows.Forms.ListBox lstUrunler;
        private System.Windows.Forms.Label label2;
    }
}