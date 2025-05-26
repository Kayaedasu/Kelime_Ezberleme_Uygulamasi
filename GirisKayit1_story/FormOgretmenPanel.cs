using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormOgretmenPanel : Form
    {
        private int kullaniciID;
        public FormOgretmenPanel(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKelimeEkle kelimeEkle = new FrmKelimeEkle(kullaniciID);
            kelimeEkle.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormOgrenciSec secimFormu = new FormOgrenciSec();
            secimFormu.ShowDialog();
            this.Show();
        }
    }
}
