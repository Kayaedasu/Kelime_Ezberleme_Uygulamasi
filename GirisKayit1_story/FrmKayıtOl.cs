using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GirisKayit1_story
{
    public partial class FrmKayıtOl : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";

        public FrmKayıtOl()
        {
            InitializeComponent();
        }

        private void FrmKayıtOl_Load(object sender, EventArgs e)
        {

        }

        private void btnKayıtOl_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAd.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;
            // Rol seçimi
            string rol = "";
            if (chkOgretmen.Checked)
            {
                rol = "Ogretmen";
            }
            else if (chkOgrenci.Checked)
            {
                rol = "Ogrenci";
            }

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(sifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return;
            }

            string sifreHash = HashHelper.Sha256Hash(sifre);

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
                {
                    baglanti.Open();

                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanici WHERE KullaniciAdi = @kadi OR Email = @email";
                    SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, baglanti);
                    cmdKontrol.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmdKontrol.Parameters.AddWithValue("@email", email);

                    int mevcut = (int)cmdKontrol.ExecuteScalar();

                    if (mevcut > 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı veya email zaten kayıtlı.");
                        return;
                    }

                    string ekleSorgu = "INSERT INTO Kullanici (KullaniciAdi, Email, SifreHash, Rol) VALUES (@kadi, @email, @sifreHash, @rol)";
                    SqlCommand cmdEkle = new SqlCommand(ekleSorgu, baglanti);
                    cmdEkle.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmdEkle.Parameters.AddWithValue("@email", email);
                    cmdEkle.Parameters.AddWithValue("@sifrehash", sifreHash);
                    cmdEkle.Parameters.AddWithValue("@rol", rol);

                    cmdEkle.ExecuteNonQuery();

                    MessageBox.Show("Kayıt başarılı! Giriş yapabilirsiniz.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}
