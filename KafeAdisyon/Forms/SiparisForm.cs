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


       
        private Kategori _seciliKategori;
        Urun _seciliUrun;

        private KategoriRepository _kategoriRepository;
        private SiparisRepository _siparisRepository;
        private SiparisDetay _siparisDetay;
        private MasaRepository _masaRepository;
        private void SiparisForm_Load(object sender, EventArgs e)
        {
            _kategoriRepository = new KategoriRepository() { };
            _siparisRepository = new SiparisRepository() { };
            



            List<Kategori> kategoriler = _kategoriRepository.GetAll(x => x.Urunler.Count > 0);
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

            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            throw new NotImplementedException();
        }

        private void KategoriBtn_Click(object sender, EventArgs e)
        {
            Button seciliButton = sender as Button;

            _seciliKategori = seciliButton.Tag as Kategori;
            List<Urun> urunler = _seciliKategori.Urunler.ToList();
            flpUrunler.Controls.Clear();
            foreach (Urun urun in urunler)
            {
                Button btn = new Button()
                {
                    Text = urun.Ad,
                    Size = new Size(220, 150),
                    BackgroundImage = Image.FromStream(new MemoryStream(urun.Fotograf)),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    ForeColor = Color.White,
                    Font = new Font(FontFamily.GenericMonospace, 20, FontStyle.Regular),
                    Tag = urun
                };
                //btn.Click += BtnUrun_Click; ;
                flpUrunler.Controls.Add(btn);
            }
        }

        //private void BtnUrun_Click(object sender, EventArgs e)
        //{
        //    Button seciliButton = (Button)sender;
        //    _seciliUrun = seciliButton.Tag as Urun;
        //    SeciliMasa.DoluMU = true;
        //    bool varMi = false;
        //    Siparis seciliSiparis = new Siparis();
        //    SiparisDetay siparisDetay = new SiparisDetay();

        //    foreach (Siparis item in MasaninSiparisleri)
        //    {
        //        if ( == _seciliUrun.Id)
        //        {
        //            seciliSiparis = item;
        //            varMi = true;
        //            break;
        //        }
        //    }

        //    if (varMi)
        //    {
        //        seciliSiparis.SiparisDetaylar().;
        //        _siparisRepository.Update();
        //    }
        //    else
        //    {
        //        Siparis yeniSiparis = new Siparis()
        //        {
        //            Adet = 1,
        //            Urun = _seciliUrun,
        //            Fiyat = _seciliUrun.Fiyat,
        //            Masa = SeciliMasa
        //        };
        //        _siparisRepository.Add(yeniSiparis);
        //    }

        //    MasaninSiparisleri = _siparisRepository.GetAll(x =>
        //        x.Masa.Id == SeciliMasa.Id && x.Masa.MasaDurumu == MasaDurumlar.Dolu);
        //    ListeyiDoldur();
        //}
    }
}
