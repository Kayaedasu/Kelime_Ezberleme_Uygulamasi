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
    public partial class FrmGiris : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";


        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string KullaniciAdi = txtKullaniciAd.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(KullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!");
                return;
            }

            string sifreHash = HashHelper.Sha256Hash(sifre);

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
                {
                    baglanti.Open();
                    string sorgu = "SELECT KullaniciID,Rol FROM Kullanici WHERE KullaniciAdi = @kadi AND SifreHash = @sifrehash";

                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    cmd.Parameters.AddWithValue("@kadi", KullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifrehash", sifreHash);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int kullaniciID = dr.GetInt32(0);
                        string rol = dr.GetString(1);

                        MessageBox.Show("Giriş başarılı!");
                        this.Hide();

                        if (rol == "Ogrenci")
                        {
                            FormÖğrenciPanel panel = new FormÖğrenciPanel(kullaniciID);
                            panel.ShowDialog();
                        }

                        else if (rol == "Ogretmen")
                        {
                            FormOgretmenPanel panel = new FormOgretmenPanel(kullaniciID);
                            panel.ShowDialog();
                        }

                        this.Show(); // Ana iş formu kapandığında tekrar göster
                    }

                    
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void lnkSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmŞifremiUnuttum sifreFormu = new FrmŞifremiUnuttum();
            sifreFormu.ShowDialog(); // modal olarak aç
        }
    }
}
