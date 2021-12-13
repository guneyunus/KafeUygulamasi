using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KafeAdisyon.Business;
using KafeAdisyon.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace KafeAdisyon.Forms
{
    public partial class SiparisForm : Form
    {
        public SiparisForm()
        {
            InitializeComponent();
        }
        public Masa SeciliMasa { get; set; }
        public List<Siparis> MasaninSiparisleri { get; set; }
        private SiparisDetay _siparisDetay;
        private Kategori _seciliKategori;
        Urun _seciliUrun;

        private KategoriRepository _kategoriRepository;
        private SiparisRepository _siparisRepository;
        private MasaRepository _masaRepository;
        private SiparisDetayRepository _siparisDetayRepository;
        private UrunRepository _urunRepository;


        private void SiparisForm_Load(object sender, EventArgs e)
        {
            _kategoriRepository = new KategoriRepository();
            _siparisRepository = new SiparisRepository();
            _siparisDetayRepository = new SiparisDetayRepository();
            _masaRepository = new MasaRepository();
            _urunRepository = new UrunRepository();
            var kategoriler = _kategoriRepository.Get(new[] { "Urunler" }).ToList();

            flpKategoriler.Controls.Clear();
            foreach (Kategori kategori in kategoriler)
            {
                Button btn = new Button()
                {
                    Text = kategori.Ad,
                    Size = new Size(220, 150),
                    BackgroundImage = Image.FromStream(new MemoryStream(kategori.Fotograf)),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    ForeColor = Color.White,
                    Font = new Font(FontFamily.GenericMonospace, 20, FontStyle.Regular),
                    Tag = kategori
                };
                btn.Click += KategoriBtn_Click; ;
                flpKategoriler.Controls.Add(btn);
            }
            lstSiparisler.FullRowSelect = true;


            MasaninSiparisleri = _siparisRepository.Get(x => x.MasaId == SeciliMasa.Id).ToList();
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            lstSiparisler.Columns.Clear();
            lstSiparisler.Items.Clear();
            lstSiparisler.View = View.Details;
            lstSiparisler.Columns.Add("Adet");
            lstSiparisler.Columns.Add("Ürün");
            lstSiparisler.Columns.Add("Fiyat");
            decimal toplam = 0;
            foreach (Siparis item in MasaninSiparisleri)
            {
               
                var boolQuery = _siparisDetayRepository.Get(x => x.SiparisId == item.Id).Any();
               
                if (boolQuery)
                {
                    
                    var siparis = _siparisRepository.Get(x => x.Id == item.Id).ToList();//dbden gerekli siparis kaydına ulaşıldı
                    //gelen siparişin 0.indeksinde gelen kaydı görücez siparis[0]

                    var deneme = siparis[0];

                    var siparisDetayi = _siparisDetayRepository.Get(x => x.SiparisId == item.Id).ToList();

                    var urunAdiRep = _urunRepository.Get(x => x.Id == siparisDetayi[0].UrunID).First();

                    var urunAdi = urunAdiRep.Ad;

                    var urunFiyati = urunAdiRep.Fiyat;

                    var urunAdeti = siparisDetayi[0].Adet.ToString();

                    var araToplam = siparisDetayi[0].AraToplam;



                    ListViewItem viewItem = new ListViewItem(urunAdeti);
                    viewItem.SubItems.Add(urunAdi);
                    viewItem.SubItems.Add($"{urunFiyati:c2}");
                    lstSiparisler.Items.Add(viewItem);

                    toplam += araToplam;
                }

            }

            lstSiparisler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            lblToplam.Text = $"{toplam:c2}";
        }

        private void KategoriBtn_Click(object sender, EventArgs e)
        {
            Button seciliButton = sender as Button;

            _seciliKategori = seciliButton.Tag as Kategori;
            List<Urun> urunler = _urunRepository.Get(x => x.KategoriId == _seciliKategori.Id).ToList();
            flpUrunler.Controls.Clear();
            foreach (Urun urun in urunler)
            {
                Button btn = new Button()
                {
                    Text = urun.Ad,
                    Size = new Size(220, 150),
                    //BackgroundImage = Image.FromStream(new MemoryStream(urun.Fotograf)),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    ForeColor = Color.White,
                    Font = new Font(FontFamily.GenericMonospace, 20, FontStyle.Regular),
                    Tag = urun
                };
                btn.Click += BtnUrun_Click; ;
                flpUrunler.Controls.Add(btn);
            }
        }

        private void BtnUrun_Click(object sender, EventArgs e)
        {
            Button seciliButton = (Button)sender;
            _seciliUrun = seciliButton.Tag as Urun;
            SeciliMasa.DoluMU = true;
            bool varMi = false;
            Siparis seciliSiparis = new Siparis();
            SiparisDetay siparisDetay = new SiparisDetay();

            foreach (Siparis item in MasaninSiparisleri)
            {

                //List<SiparisDetay> listSiparisMasa = _siparisDetayRepository.Get(x => x.SiparisId == item.Id).ToList();
                List<SiparisDetay> listSiparisMasa = _siparisDetayRepository.GetAll(x=>x.SiparisId == item.Id);
                //group by eklenicek


                foreach (var sipDet in listSiparisMasa)
                {
                    if (sipDet.UrunID == _seciliUrun.Id)
                    {
                        seciliSiparis = item;
                        varMi = true;
                        break;
                    }
                }
                break;

            }

            if (varMi)
            {
                var siparisDetayi = _siparisDetayRepository.Get(x => x.SiparisId == seciliSiparis.Id).First();
                siparisDetayi.Adet++;
                siparisDetayi.AraToplam = siparisDetayi.Adet * siparisDetayi.Fiyat;
                siparisDetayi.UrunID = _seciliUrun.Id;
                _siparisDetayRepository._dbContext.Update(siparisDetayi);
                _siparisDetayRepository._dbContext.SaveChanges();

            }
            else
            {
                Siparis yeniSiparis = new Siparis()
                {
                    SiparisTarihi = DateTime.Now,
                    MasaId = SeciliMasa.Id,
                    GetSiparisId = new Random().Next(1, 999)
                };


                SiparisDetay yeniSiparisDetay = new SiparisDetay()
                {
                    UrunID = _seciliUrun.Id,
                    Adet = 1,
                    Fiyat = _seciliUrun.Fiyat,

                };
                yeniSiparisDetay.AraToplam = yeniSiparisDetay.Adet * yeniSiparisDetay.Fiyat;



                yeniSiparis.SiparisDetaylar.Add(yeniSiparisDetay);
                _siparisRepository._dbContext.Add(yeniSiparis);
                
                _siparisRepository._dbContext.SaveChanges();//SiparisID olusucak
                

                var YeniSiparisDetayId = _siparisRepository.Get(x => x.GetSiparisId == yeniSiparis.GetSiparisId).ToList();
                yeniSiparisDetay.SiparisId = YeniSiparisDetayId[0].Id;//ıd buldurucu


                //yeniSiparis.SiparisDetaylar.Add(yeniSiparisDetay);
                _siparisRepository._dbContext.Update(yeniSiparis);
                _siparisDetayRepository._dbContext.Update(yeniSiparisDetay);

                _siparisDetayRepository._dbContext.SaveChanges();
                _siparisRepository._dbContext.SaveChanges();

                _masaRepository._dbContext.Update(SeciliMasa);
                _masaRepository._dbContext.SaveChanges();
            }


            MasaninSiparisleri = _siparisRepository.Get(x => x.MasaId == SeciliMasa.Id).ToList();
            ListeyiDoldur();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            printDocument1.Print();
            


            var masaninSiparisleri = _masaRepository.Get(x => x.Id == SeciliMasa.Id).First();
            SeciliMasa.DoluMU = false;

            foreach (var siparis in MasaninSiparisleri)
            {
                var sipRepo = _siparisRepository.Get(x => x.MasaId == siparis.MasaId).First();
                
                _siparisRepository._dbContext.Remove(sipRepo);
                _siparisRepository._dbContext.SaveChanges();

            }

            masaninSiparisleri.Siparisler.Clear();
            _masaRepository._dbContext.Update(masaninSiparisleri);
            _masaRepository._dbContext.SaveChanges();

            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            decimal ToplamTutar = 0;
            Font font = new Font("Arial", 14);
            SolidBrush firca = new SolidBrush(Color.Black);
            Pen kalem = new Pen(Color.Black);
            e.Graphics.DrawString($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}", font, firca, 50, 25);
            font = new Font("Arial", 20, FontStyle.Bold);
            e.Graphics.DrawString($"Satış Raporu", font, firca, 290, 75);
            e.Graphics.DrawLine(kalem, 50, 70, 780, 70);
            e.Graphics.DrawLine(kalem, 50, 110, 780, 110);
            e.Graphics.DrawLine(kalem, 50, 70, 50, 110);
            e.Graphics.DrawLine(kalem, 780, 70, 780, 110);

            font = new Font("Arial", 14, FontStyle.Bold);

            e.Graphics.DrawString("ÜRÜN ADI", font, firca, 280, 140);
            e.Graphics.DrawString("ADETİ", font, firca, 420, 140);
            e.Graphics.DrawString("FİYATI", font, firca, 550, 140);
            e.Graphics.DrawString("ARA TOPLAM", font, firca, 680, 140);

            int i = 0;
            int y = 170;
            font = new Font("Arial", 14);
            
            foreach (var siparis in MasaninSiparisleri)
            {
                var subItem = _siparisDetayRepository.Get(x => x.SiparisId == siparis.Id).ToList();
                
                foreach (var item in subItem)
                {
                    
                    var urun = _siparisDetayRepository.Get(x => x.Id == item.Id).First();
                    var urunadı = _urunRepository.Get(x => x.Id == item.UrunID).First();

                    e.Graphics.DrawString(urunadı.Ad,font,firca,280,y);
                    e.Graphics.DrawString(urun.Adet.ToString(),font,firca,420,y);
                    e.Graphics.DrawString($"{urun.Fiyat:c2}",font,firca,550,y);
                    e.Graphics.DrawString($"{urun.AraToplam:c2}", font,firca,680,y);
                    ToplamTutar += urun.AraToplam;
                    y = y + 40; 
                    i = i + 1;
                }
            }
           e.Graphics.DrawString($"{ToplamTutar:c2}",font,firca,550,y+40);
           

        }
    }
}
