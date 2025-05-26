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
    public partial class FormTarihcs : Form
    {
        public FormTarihcs()
        {
            InitializeComponent();
        }
      
       private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnTarih_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şu anki sistem tarihi: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        private void FormTarihcs_Load(object sender, EventArgs e)
        {
            
        }
    }
}
