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
            var kategoriler = _kategoriRepository.Get(new[]{"Urunler"}).ToList();
            
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
            //MasaninSiparisleri = _siparisRepository.GetAll();
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

                List<SiparisDetay> listSiparisMasa = _siparisDetayRepository.GetAll(x => x.SiparisId == item.Id);
                
                foreach (var sipDet in listSiparisMasa)
                {
                    if (sipDet.UrunID == _seciliUrun.Id)
                    {
                        seciliSiparis = item;
                        varMi = true;
                        break;
                    }
                }break;
                
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
                    GetSiparisId = new Random().Next(1,999)
                };


                SiparisDetay yeniSiparisDetay = new SiparisDetay()
                {
                    UrunID = _seciliUrun.Id,
                    Adet = 1,
                    Fiyat = _seciliUrun.Fiyat,
                    
                };
                yeniSiparisDetay.AraToplam = yeniSiparisDetay.Adet * yeniSiparisDetay.Fiyat;

                

                //_siparisRepository.Add(yeniSiparis);//fixed
                _siparisRepository._dbContext.Add(yeniSiparis);
                _siparisRepository._dbContext.SaveChanges();//SiparisID olusucak
               

                var YeniSiparisDetayId = _siparisRepository.Get(x => x.GetSiparisId == yeniSiparis.GetSiparisId).ToList();
                yeniSiparisDetay.SiparisId = YeniSiparisDetayId[0].Id;//ıd buldurucu


                yeniSiparis.SiparisDetaylar.Add(yeniSiparisDetay);
                _siparisRepository._dbContext.Update(yeniSiparis);


                _siparisDetayRepository.Add(yeniSiparisDetay);
                
                
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
            var masaninSiparisleri = _masaRepository.Get(x => x.Id == SeciliMasa.Id).First();
            masaninSiparisleri.Siparisler.Clear();
            _masaRepository._dbContext.Update(masaninSiparisleri);

            foreach (Siparis item in MasaninSiparisleri)
            {

                List<SiparisDetay> listSiparisMasa = _siparisDetayRepository.GetAll(x => x.SiparisId == item.Id);

                if (listSiparisMasa.Count > 0)
                {
                    foreach (var sipDet in listSiparisMasa)
                    {

                        _siparisDetayRepository._dbContext.Remove(sipDet);
                    }
                }

               

            }

            foreach (Siparis item in MasaninSiparisleri)
            {
                
                _siparisRepository._dbContext.Remove(item);

            }

            _masaRepository._dbContext.SaveChanges();
            _siparisDetayRepository._dbContext.SaveChanges();
            _siparisRepository._dbContext.SaveChanges();


            //var masaninSiparisleri = _siparisRepository
            //    .GetAll(x =>
            //        x.Masa.Id == _frmSiparis.SeciliMasa.Id && x.Masa.DoluMU ==true);
            //MessageBox.Show($"Masa kapatıldı: {masaninSiparisleri.Sum(x=>x.SiparisDetaylar.Sum(x=>x.Fiyat)):c2} Tutar Tahsil edildi.");
            //foreach (var siparis in masaninSiparisleri)
            //{
            //    siparis.Masa.DoluMU = false;
            //}
            //_siparisRepository._dbContext.SaveChanges();



            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
