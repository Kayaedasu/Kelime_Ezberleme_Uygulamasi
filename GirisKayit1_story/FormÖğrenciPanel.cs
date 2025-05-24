using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormÖğrenciPanel : Form
    {
        private int kullaniciID;
        public FormÖğrenciPanel(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Ayarlar ekranı aç
            FormAyarlar ayarFormu = new FormAyarlar(kullaniciID);
            ayarFormu.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 2. Ayar yapıldıktan sonra tekrar ekranı aç
            FormTekrar tekrarFormu = new FormTekrar(kullaniciID);
            tekrarFormu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormWordle wordle = new FormWordle(kullaniciID);
            wordle.ShowDialog();

        }
    }
}
