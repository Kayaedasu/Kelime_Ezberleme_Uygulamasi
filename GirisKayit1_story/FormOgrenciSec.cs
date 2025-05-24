using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormOgrenciSec : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";
        private int kullaniciID;
        public FormOgrenciSec()
        {
            InitializeComponent();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            if (dgvOgrenciler.SelectedRows.Count > 0)
            {
                int secilenID = Convert.ToInt32(dgvOgrenciler.SelectedRows[0].Cells["KullaniciID"].Value);
                FormAnaliz analiz = new FormAnaliz(secilenID);
                analiz.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci seçin.");
            }
        }

        private void FormOgrenciSec_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(baglantiCumlesi))
            {
                conn.Open();
                string sorgu = "SELECT KullaniciID, KullaniciAdi FROM Kullanici WHERE Rol = 'Ogrenci'";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOgrenciler.DataSource = dt;
            }
        }
    }
}
