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
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private KafeBilgi kafeBilgi;
        private KafeBilgiRepository _kafeBilgiRepository;
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            _kafeBilgiRepository = new KafeBilgiRepository()
            {

            };
            if (_kafeBilgiRepository.Get(x=>x.Id == 1).Any() == false)//any
            {
                kafeBilgi= new KafeBilgi()
                {
                    Ad = "deneme",


                };
                _kafeBilgiRepository.Add(kafeBilgi);
                _kafeBilgiRepository._dbContext.SaveChanges();
            }
            else
            {
                kafeBilgi = _kafeBilgiRepository.Get(x => x.Id == 1) as KafeBilgi;
                
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        private MenuForm frmMenu;
        private void menüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMenu == null || frmMenu.IsDisposed)
            {
                frmMenu = new MenuForm();
            }
            frmMenu.MdiParent = this;
            frmMenu.WindowState = FormWindowState.Maximized;
            frmMenu.Show();
        }
        private KatAyarForm frmKatAyar;
        private void katMasaAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKatAyar == null || frmKatAyar.IsDisposed)
            {
                frmKatAyar = new KatAyarForm();
            }
            frmKatAyar.MdiParent = this;
            frmKatAyar.WindowState = FormWindowState.Maximized;
            frmKatAyar.Show();
        }
        private KafeGorunumForm frmKafeGorunum;
        private void siparişEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKafeGorunum == null || frmKafeGorunum.IsDisposed)
            {
                frmKafeGorunum = new KafeGorunumForm();
            }
            frmKafeGorunum.MdiParent = this;
            frmKafeGorunum.WindowState = FormWindowState.Maximized;
            frmKafeGorunum.Show();
        }
    }
}
