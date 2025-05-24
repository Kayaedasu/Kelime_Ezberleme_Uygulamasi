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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris kayitFormu = new FrmGiris();
            kayitFormu.ShowDialog(); // modal olarak aç
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKayıtOl kayitFormu = new FrmKayıtOl();
            kayitFormu.ShowDialog(); // modal olarak aç
        }
    }
}
