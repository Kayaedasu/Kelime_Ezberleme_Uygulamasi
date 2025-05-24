using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormAyarlar : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";
        private int kullaniciID;

        public FormAyarlar(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "SELECT GunlukKelimeSayisi FROM KullaniciAyar WHERE KullaniciID = @kullaniciID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                object sonuc = cmd.ExecuteScalar();
                int sayi = (sonuc != null && sonuc != DBNull.Value) ? Convert.ToInt32(sonuc) : 10;


                nudKelimeSayisi.Value = sayi;
                lblMevcut.Text = $"Mevcut değer: {sayi}";
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string kontrolSorgu = "SELECT COUNT(*) FROM KullaniciAyar WHERE KullaniciID = @kullaniciID";
                SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, baglanti);
                cmdKontrol.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                int varMi = (int)cmdKontrol.ExecuteScalar();

                string sql;
                if (varMi == 0)
                {
                    sql = "INSERT INTO KullaniciAyar (KullaniciID, GunlukKelimeSayisi) VALUES (@kullaniciID, @sayi)";
                }
                else
                {
                    sql = "UPDATE KullaniciAyar SET GunlukKelimeSayisi = @sayi WHERE KullaniciID = @kullaniciID";
                }

                SqlCommand cmd = new SqlCommand(sql, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@sayi", (int)nudKelimeSayisi.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Ayar kaydedildi.");
                lblMevcut.Text = $"Mevcut değer: {(int)nudKelimeSayisi.Value}";
            }
        }
    }
}

