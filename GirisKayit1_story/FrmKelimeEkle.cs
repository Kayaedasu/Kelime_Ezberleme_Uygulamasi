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
using System.IO;

namespace GirisKayit1_story
{
    public partial class FrmKelimeEkle : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";
        public FrmKelimeEkle(int kullaniciID)
        {
            InitializeComponent();
          
        }

        private void btnResimSec_Click(object sender, EventArgs e)

        {

            try
            {
                // Projenin kök dizinini alıyoruz (bin klasöründen 2 seviye yukarı)
                string projeKokDizini = Directory.GetParent(Application.StartupPath).Parent.FullName;
                string resimKlasoru = Path.Combine(projeKokDizini, "Resimler");
                MessageBox.Show("Resimler klasörü: " + resimKlasoru);

                // Eğer Resimler klasörü yoksa oluştur
                if (!Directory.Exists(resimKlasoru))
                {
                    Directory.CreateDirectory(resimKlasoru);
                }

                OpenFileDialog dosyaSec = new OpenFileDialog();
                dosyaSec.Title = "Bir görsel seçin";
                dosyaSec.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                dosyaSec.InitialDirectory = resimKlasoru;

                if (dosyaSec.ShowDialog() == DialogResult.OK)
                {
                    string secilenDosyaYolu = dosyaSec.FileName;
                    string dosyaAdi = Path.GetFileName(secilenDosyaYolu);
                    string hedefYol = Path.Combine(resimKlasoru, dosyaAdi);

                    // Eğer seçilen dosya Resimler klasöründe değilse kopyala
                    if (!File.Exists(hedefYol))
                    {
                        File.Copy(secilenDosyaYolu, hedefYol);
                    }

                    // Sadece dosya adını kaydediyoruz (veritabanı için)
                    txtResimYolu.Text = dosyaAdi;

                    // Resmi göster (tam yol)
                    pictureBox1.ImageLocation = hedefYol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim seçerken hata oluştu: " + ex.Message);
            }
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ingKelime = txtIngKelime.Text.Trim();
            string trKelime = txtTrKelime.Text.Trim();
            string resimAdi = txtResimYolu.Text.Trim(); // sadece dosya adı
            string zorlukSeviyesi = cmbZorluk.SelectedItem?.ToString();
            string kategori = txtKategori.Text.Trim();
            string[] cumleler = txtCumleler.Lines;

            if (string.IsNullOrEmpty(ingKelime) || string.IsNullOrEmpty(trKelime))
            {
                MessageBox.Show("İngilizce ve Türkçe kelime boş bırakılamaz.");
                return;
            }

            if (cumleler.Length == 0)
            {
                MessageBox.Show("En az bir örnek cümle giriniz.");
                return;
            }

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
                {
                    baglanti.Open();

                    // Kelimenin var olup olmadığını kontrol et (İngilizce kelime ile)
                    string kontrolSorgu = "SELECT KelimeID FROM Kelimeler WHERE IngKelime = @ing";
                    SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, baglanti);
                    cmdKontrol.Parameters.AddWithValue("@ing", ingKelime);
                    object sonuc = cmdKontrol.ExecuteScalar();

                    int kelimeId;

                    if (sonuc != null)
                    {
                        kelimeId = Convert.ToInt32(sonuc);

                        // Sadece örnek cümleleri ekle
                        string sorguCumle = "INSERT INTO OrnekCumleler (KelimeID, Cumle) VALUES (@kelimeId, @cumle)";
                        foreach (string cumle in cumleler)
                        {
                            if (!string.IsNullOrWhiteSpace(cumle))
                            {
                                SqlCommand cmdCumle = new SqlCommand(sorguCumle, baglanti);
                                cmdCumle.Parameters.AddWithValue("@kelimeId", kelimeId);
                                cmdCumle.Parameters.AddWithValue("@cumle", cumle.Trim());
                                cmdCumle.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Kelime zaten var, sadece örnek cümleler eklendi.");
                    }
                    else
                    {
                        // Kelime yoksa tüm bilgileriyle ekle
                        string sorguKelime = @"
                INSERT INTO Kelimeler (IngKelime, TrKelime, ResimYolu, Kategori, ZorlukSeviyesi)
                OUTPUT INSERTED.KelimeID
                VALUES (@ing, @tr, @resim, @kategori, @zorluk)";

                        SqlCommand cmdKelime = new SqlCommand(sorguKelime, baglanti);
                        cmdKelime.Parameters.AddWithValue("@ing", ingKelime);
                        cmdKelime.Parameters.AddWithValue("@tr", trKelime);
                        cmdKelime.Parameters.AddWithValue("@resim", resimAdi);
                        cmdKelime.Parameters.AddWithValue("@kategori", kategori);
                        cmdKelime.Parameters.AddWithValue("@zorluk", zorlukSeviyesi);

                        kelimeId = (int)cmdKelime.ExecuteScalar();

                        // Örnek cümleleri ekle
                        string sorguCumle = "INSERT INTO OrnekCumleler (KelimeID, Cumle) VALUES (@kelimeId, @cumle)";
                        foreach (string cumle in cumleler)
                        {
                            if (!string.IsNullOrWhiteSpace(cumle))
                            {
                                SqlCommand cmdCumle = new SqlCommand(sorguCumle, baglanti);
                                cmdCumle.Parameters.AddWithValue("@kelimeId", kelimeId);
                                cmdCumle.Parameters.AddWithValue("@cumle", cumle.Trim());
                                cmdCumle.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Yeni kelime ve örnek cümleler başarıyla kaydedildi.");
                    }

                    Temizle();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void Temizle()
        {
            txtIngKelime.Clear();
            txtTrKelime.Clear();
            txtResimYolu.Clear();
            txtCumleler.Clear();
            pctSüs.Image = null;
            txtKategori.Clear();
            cmbZorluk.SelectedIndex = -1;

        }

        private void FrmKelimeEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
    
