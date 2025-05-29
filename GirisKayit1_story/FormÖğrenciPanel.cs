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
            this.Hide();
            // 1. Ayarlar ekranı aç
            FormAyarlar ayarFormu = new FormAyarlar(kullaniciID);
            ayarFormu.ShowDialog();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            // 2. Ayar yapıldıktan sonra tekrar ekranı aç
            FormTekrar tekrarFormu = new FormTekrar(kullaniciID);
            tekrarFormu.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormWordle wordle = new FormWordle(kullaniciID);
            wordle.ShowDialog();
            this.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLLM LLM = new FormLLM(kullaniciID);
            LLM.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAnaliz analiz = new FormAnaliz(kullaniciID);
            analiz.ShowDialog();
            this.Show();
        }

        private void btnTarih_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormTarihcs tarih = new FormTarihcs();
            tarih.ShowDialog();
            this.Show();
        }
    }
}
