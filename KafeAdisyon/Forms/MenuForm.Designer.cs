
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
            this.txtUrunAdi.Location = new System.Drawing.Point(526, 42);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(163, 27);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // pbKategori
            // 
            this.pbKategori.Location = new System.Drawing.Point(106, 91);
            this.pbKategori.Name = "pbKategori";
            this.pbKategori.Size = new System.Drawing.Size(125, 145);
            this.pbKategori.TabIndex = 2;
            this.pbKategori.TabStop = false;
            this.pbKategori.Click += new System.EventHandler(this.pbKategori_Click);
            // 
            // btnKategoriKaydet
            // 
            this.btnKategoriKaydet.Location = new System.Drawing.Point(106, 265);
            this.btnKategoriKaydet.Name = "btnKategoriKaydet";
            this.btnKategoriKaydet.Size = new System.Drawing.Size(125, 79);
            this.btnKategoriKaydet.TabIndex = 3;
            this.btnKategoriKaydet.Text = "Kategori Kaydet";
            this.btnKategoriKaydet.UseVisualStyleBackColor = true;
            this.btnKategoriKaydet.Click += new System.EventHandler(this.btnKategoriKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori";
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
            this.nFiyat.Location = new System.Drawing.Point(526, 91);
            this.nFiyat.Name = "nFiyat";
            this.nFiyat.Size = new System.Drawing.Size(163, 27);
            this.nFiyat.TabIndex = 6;
            // 
            // pbUrun
            // 
            this.pbUrun.Location = new System.Drawing.Point(526, 133);
            this.pbUrun.Name = "pbUrun";
            this.pbUrun.Size = new System.Drawing.Size(163, 153);
            this.pbUrun.TabIndex = 7;
            this.pbUrun.TabStop = false;
            this.pbUrun.Click += new System.EventHandler(this.pbUrun_Click);
            // 
            // btnUrunKaydet
            // 
            this.btnUrunKaydet.Location = new System.Drawing.Point(526, 292);
            this.btnUrunKaydet.Name = "btnUrunKaydet";
            this.btnUrunKaydet.Size = new System.Drawing.Size(163, 83);
            this.btnUrunKaydet.TabIndex = 8;
            this.btnUrunKaydet.Text = "Urun Kaydet";
            this.btnUrunKaydet.UseVisualStyleBackColor = true;
            this.btnUrunKaydet.Click += new System.EventHandler(this.btnUrunKaydet_Click);
            // 
            // lstUrunler
            // 
            this.lstUrunler.FormattingEnabled = true;
            this.lstUrunler.ItemHeight = 20;
            this.lstUrunler.Location = new System.Drawing.Point(695, 42);
            this.lstUrunler.Name = "lstUrunler";
            this.lstUrunler.Size = new System.Drawing.Size(205, 344);
            this.lstUrunler.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ürün";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 450);
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