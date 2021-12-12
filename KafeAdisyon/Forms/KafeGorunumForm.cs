using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KafeAdisyon.Business;
using KafeAdisyon.Data.Models;

namespace KafeAdisyon.Forms
{
    public partial class KafeGorunumForm : Form
    {
        public KafeGorunumForm()
        {
            InitializeComponent();
        }

        private KatRepository _katRepository;
        private SiparisRepository _siparisRepository;
        private MasaRepository _masaRepository;
        private Kat _seciliKat;
        Color seciliKatColor = Color.Coral, defaultKatColor = Color.CornflowerBlue;
        private void KafeGorunumForm_Load(object sender, EventArgs e)
        {
            _katRepository = new KatRepository() {};
            _masaRepository = new MasaRepository();
            _siparisRepository = new SiparisRepository() {};
            List<Kat> katlar = _katRepository
                .Get().ToList();
            
            for (int i = 0; i < katlar.Count; i++)
            {
                Kat kat = katlar[i];
                Button btn = new Button()
                {
                    Text = kat.Ad,
                    Size = new Size(140, 95),
                    BackColor = defaultKatColor,
                    Tag = kat
                };
                btn.Click += Btn_Click; ;
                flpKatlar.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button seciliButton = sender as Button;

            _seciliKat = seciliButton.Tag as Kat;
            List<Masa> masalar = _masaRepository.Get().Where(x=>x.KatId == _seciliKat.Id).OrderBy(x=>x.Id).ToList();
            flpMasalar.Controls.Clear();
            foreach (Masa masa in masalar)
            {
                Button btn = new Button()
                {
                    Text = masa.Ad,
                    Size = new Size(140, 95),
                    BackColor = defaultKatColor,
                    Tag = masa
                };
                btn.Click += Btn_Click1; ;
                flpMasalar.Controls.Add(btn);
            }

            foreach (Button button in flpKatlar.Controls)
            {
                button.BackColor = defaultKatColor;
                if (button.Text == seciliButton.Text)
                    button.BackColor = seciliKatColor;
            }

            MasaRenklendir();
        }

        private void MasaRenklendir()
        {
            var mevcutSiparisler = _siparisRepository.Get().ToList();
            foreach (Button button in flpMasalar.Controls)
            {
                var btn = button.Tag as Masa;
                button.BackColor = defaultKatColor;
                //if (mevcutSiparisler.Any(x => x.Masa.Ad.Equals(button.Text)))
                //{
                //    button.BackColor = seciliKatColor;
                //}
                foreach (var sip in mevcutSiparisler)
                {
                    if (sip.MasaId ==btn.Id)
                    {
                        button.BackColor = seciliKatColor;
                    }
                }
            }
        }

        private SiparisForm _frmSiparis;
        private void Btn_Click1(object sender, EventArgs e)
        {
            Button seciliButton = sender as Button;
            if (_frmSiparis == null || _frmSiparis.IsDisposed)
            {
                _frmSiparis = new SiparisForm();
            }
            //_frmSiparis.MdiParent = this.MdiParent;
            _frmSiparis.WindowState = FormWindowState.Maximized;
            _frmSiparis.SeciliMasa = seciliButton.Tag as Masa;
            _frmSiparis.MasaninSiparisleri = _siparisRepository
                .GetAll(x =>x.MasaId == _frmSiparis.SeciliMasa.Id);
            
            DialogResult result = _frmSiparis.ShowDialog();
            if (result == DialogResult.OK)
            {
                seciliButton.BackColor = seciliKatColor;//siparis kaydettiyse
            }
            else if (result == DialogResult.Abort)//masayı kapadiysa
            {
                //var masaninSiparisleri = _siparisRepository
                //    .GetAll(x =>
                //        x.Masa.Id == _frmSiparis.SeciliMasa.Id && x.Masa.DoluMU ==true);
                //MessageBox.Show($"Masa kapatıldı: {masaninSiparisleri.Sum(x=>x.SiparisDetaylar.Sum(x=>x.Fiyat)):c2} Tutar Tahsil edildi.");
                //foreach (var siparis in masaninSiparisleri)
                //{
                //    siparis.Masa.DoluMU = false;
                //}
                //_siparisRepository._dbContext.SaveChanges();
                seciliButton.BackColor = defaultKatColor;

            }
            MasaRenklendir();
        }
    }
}
