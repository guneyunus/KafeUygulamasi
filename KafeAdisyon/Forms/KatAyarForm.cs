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
using KafeAdisyon.Data;
using KafeAdisyon.Data.Models;

namespace KafeAdisyon.Forms
{
    public partial class KatAyarForm : Form
    {
        public KatAyarForm()
        {
            InitializeComponent();
        }
        
        private KatRepository _repository;
        private KafeBilgiRepository _kafeBilgiRepository = new KafeBilgiRepository();
        private void KatAyarForm_Load(object sender, EventArgs e)
        {
            _repository = new KatRepository ()
            {
               
            };
            lstKatlar.DataSource = _repository.GetAll().OrderBy(x => x.Sira).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kat yeniKat = new Kat()
            {
                Ad = txtKatAdi.Text,
                Kod = txtKod.Text,
                Sira = int.Parse(txtSira.Text)
            };
            int adet = int.Parse(txtAdet.Text);

            for (int i = 0; i < adet; i++)
            {
                Masa yeniMasa = new Masa()
                {
                    Sira = i + 1,
                    Ad = $"{yeniKat.Kod}/Masa {i + 1}"
                };
                yeniKat.Masalar.Add(yeniMasa);
            }

            yeniKat.KafeBilgiId = _kafeBilgiRepository.GetById(1).Id;
            _repository.Add(yeniKat);
            _repository._dbContext.SaveChanges();
            lstKatlar.DataSource = null;
            lstKatlar.DataSource = _repository.GetAll().OrderBy(x => x.Sira).ToList();
        }
    }
}
