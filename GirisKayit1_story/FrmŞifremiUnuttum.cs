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
    public partial class FrmŞifremiUnuttum : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";

        public FrmŞifremiUnuttum()
        {
            InitializeComponent();
        }

        private void FrmŞifremiUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void btnSifreGüncel_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Şifreler uyuşmuyor!");
                return;
            }

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
                {
                    baglanti.Open();

                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanici WHERE Email = @email";
                    SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, baglanti);
                    cmdKontrol.Parameters.AddWithValue("@email", email);
                    int kullaniciSayisi = (int)cmdKontrol.ExecuteScalar();

                    if (kullaniciSayisi == 0)
                    {
                        MessageBox.Show("Bu email adresine ait kullanıcı bulunamadı.");
                        return;
                    }

                    string sifreHash = HashHelper.Sha256Hash(yeniSifre);

                    string guncelleSorgu = "UPDATE Kullanici SET SifreHash = @sifreHash WHERE Email = @email";
                    SqlCommand cmdGuncelle = new SqlCommand(guncelleSorgu, baglanti);
                    cmdGuncelle.Parameters.AddWithValue("@sifreHash", sifreHash);
                    cmdGuncelle.Parameters.AddWithValue("@email", email);
                    cmdGuncelle.ExecuteNonQuery();

                    MessageBox.Show("Şifreniz başarıyla güncellendi.");
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

