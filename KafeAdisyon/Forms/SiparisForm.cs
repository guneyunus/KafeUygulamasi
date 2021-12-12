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
            _kategoriRepository = new KategoriRepository() { };
            _siparisRepository = new SiparisRepository() { };
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

            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            lstSiparisler.Columns.Clear();
            lstSiparisler.Items.Clear();
            lstSiparisler.View = View.Details;
            lstSiparisler.Columns.Add("Adet");
            lstSiparisler.Columns.Add("Ürün");
            lstSiparisler.Columns.Add("Ara Toplam");
            decimal toplam = 0;
            foreach (Siparis item in MasaninSiparisleri)
            {
                var boolQuery = _siparisDetayRepository.Get(x => x.SiparisId == item.Id).Any();
                if (boolQuery)
                {

                    var siparis = _siparisRepository.Get(x => x.Id == item.Id);
                    var siparisDetayi = _siparisDetayRepository.Get(x => x.SiparisId == item.Id).ToList();
                    var urun = siparisDetayi.Select(x => x.Urun).ToString();
                    ListViewItem viewItem = new ListViewItem(siparisDetayi.Select(x => x.Adet).ToString());
                    viewItem.SubItems.Add(siparisDetayi.Select(x => x.Urun.Ad).ToString());
                    viewItem.SubItems.Add($"{siparisDetayi.Select(x => x.AraToplam):c2}");
                    lstSiparisler.Items.Add(viewItem);
                    var aratoplamsal = siparisDetayi.Select(x => x.AraToplam).Sum();
                    toplam += aratoplamsal;
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
                if (item.Id == _seciliUrun.Id)
                {
                    seciliSiparis = item;
                    varMi = true;
                    break;
                }
            }

            if (varMi)
            {
                var SiparisDetay = _siparisDetayRepository.GetAll().Where(x => x.SiparisId == seciliSiparis.Id).ToList();
                siparisDetay.Adet++;
                _siparisDetayRepository.Update(siparisDetay);

            }
            else
            {
                Siparis yeniSiparis = new Siparis()
                {
                    SiparisTarihi = DateTime.Now,
                    Masa = SeciliMasa,
                    MasaId = SeciliMasa.Id
                };
                SiparisDetay yeniSiparisDetay = new SiparisDetay()
                {
                    UrunID = _seciliUrun.Id,
                    SiparisId = yeniSiparis.Id,
                    Adet = 1,
                    Fiyat = _seciliUrun.Fiyat,
                };
                yeniSiparisDetay.AraToplam = yeniSiparisDetay.Adet * yeniSiparisDetay.Fiyat;

                _siparisRepository.Add(yeniSiparis);
                _siparisDetayRepository.Add(yeniSiparisDetay);

            }

            MasaninSiparisleri = _siparisRepository.GetAll(x =>
                x.Masa.Id == SeciliMasa.Id && x.Masa.DoluMU == true);
            ListeyiDoldur();
        }
    }
}
