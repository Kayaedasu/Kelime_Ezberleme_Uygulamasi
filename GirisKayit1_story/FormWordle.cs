using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormWordle : Form
    {
        private string gizliKelime;
        private int tahminHakki = 6;
        private int aktifSatir = 0;
        private int kullaniciID;

        private List<List<Label>> lblHarfSatirlari = new List<List<Label>>();
        private List<string> kelimeListesi = new List<string>();
        private void FormWordle_Load(object sender, EventArgs e)
        {
            kelimeListesi = GetirOgrenilmisKelimeler(); // Veritabanından kelimeleri al
            if (kelimeListesi.Count == 0)
            {
                MessageBox.Show("Veritabanında öğrenilmiş kelime bulunamadı!");
                this.Close();
                return;
            }

            // İlk kelimeyi seç
            gizliKelime = kelimeListesi[0];
            kelimeListesi.RemoveAt(0); // İlk kelimeyi listeden çıkar
            lblDurum.Text = $"Tahmin hakkınız: {tahminHakki}";
        }

        public FormWordle(int KullaniciID)
        {
            InitializeComponent();

            // Form yüklenme olayını bağla
            this.Load += FormWordle_Load;  // Yüklenme olayını burada bağlıyoruz

            this.kullaniciID = KullaniciID;

            // Öğrenilmiş kelimeleri veritabanından al
            kelimeListesi = GetirOgrenilmisKelimeler();
            if (kelimeListesi.Count == 0)
            {
                MessageBox.Show("Veritabanında öğrenilmiş kelime bulunamadı!");
                this.Hide();  // Formu kapat
                return;
            }

            // İlk kelimeyi seç ve başlat
            gizliKelime = kelimeListesi[0];
            kelimeListesi.RemoveAt(0); // İlk kelimeyi listeden çıkar
            lblDurum.Text = $"Tahmin hakkınız: {tahminHakki}";
            this.Text = "Wordle Oyunu - " + gizliKelime.Length + " Harfli Kelime";

            // Dinamik label oluştur
            DinamikLabelOlustur();
            txtTahmin.MaxLength = gizliKelime.Length; // Kullanıcıdan alınacak kelime uzunluğu
        }

        // Dinamik olarak satırlar ve hücreler oluşturuluyor
        private void DinamikLabelOlustur()
        {
            int baslangicX = 20;
            int baslangicY = 20;
            int kutuBoyutu = 40;
            int bosluk = 5;

            for (int i = 0; i < tahminHakki; i++)
            {
                List<Label> lblSatir = new List<Label>();
                for (int j = 0; j < gizliKelime.Length; j++)
                {
                    Label lbl = new Label();
                    lbl.Width = kutuBoyutu;
                    lbl.Height = kutuBoyutu;
                    lbl.Location = new Point(baslangicX + j * (kutuBoyutu + bosluk), baslangicY + i * (kutuBoyutu + bosluk));
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Arial", 18, FontStyle.Bold);
                    lbl.BackColor = Color.LightGray;
                    this.Controls.Add(lbl);
                    lblSatir.Add(lbl);
                }
                lblHarfSatirlari.Add(lblSatir);
            }
        }

        // Kullanıcının tahminini kontrol etme
        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            if (aktifSatir >= tahminHakki)
            {
                MessageBox.Show("Tahmin hakkınız kalmadı.");
                return;
            }

            string tahmin = txtTahmin.Text.Trim().ToLower();

            if (tahmin.Length != gizliKelime.Length)
            {
                MessageBox.Show($"Lütfen {gizliKelime.Length} harfli bir kelime giriniz.");
                return;
            }

            // Harflerin durumunu bulmak için:
            char[] gizliDizi = gizliKelime.ToCharArray();
            bool[] harfKullanildi = new bool[gizliKelime.Length];

            // Öncelikle yeşil harfleri işaretle (doğru yer)
            for (int i = 0; i < gizliKelime.Length; i++)
            {
                if (tahmin[i] == gizliKelime[i])
                {
                    lblHarfSatirlari[aktifSatir][i].BackColor = Color.Green;
                    harfKullanildi[i] = true;
                }
                else
                {
                    lblHarfSatirlari[aktifSatir][i].BackColor = Color.LightGray;
                }
                lblHarfSatirlari[aktifSatir][i].Text = tahmin[i].ToString().ToUpper();
            }

            // Sarı harfler (yanlış yerde olan harfler)
            for (int i = 0; i < gizliKelime.Length; i++)
            {
                if (lblHarfSatirlari[aktifSatir][i].BackColor == Color.Green)
                    continue;

                bool sarildi = false;
                for (int j = 0; j < gizliKelime.Length; j++)
                {
                    if (!harfKullanildi[j] && tahmin[i] == gizliKelime[j])
                    {
                        lblHarfSatirlari[aktifSatir][i].BackColor = Color.Goldenrod;
                        harfKullanildi[j] = true;
                        sarildi = true;
                        break;
                    }
                }
                if (!sarildi)
                {
                    lblHarfSatirlari[aktifSatir][i].BackColor = Color.Gray;
                }
            }

            // Eğer doğru kelime tahmin edilmişse:
            if (tahmin == gizliKelime)
            {
                lblDurum.Text = $"Tebrikler! Doğru tahmin ettiniz: {gizliKelime.ToUpper()}";
                kelimeListesi.Remove(gizliKelime); // Doğru kelimeyi listeden çıkar
                btnTahminEt.Enabled = false;
                txtTahmin.Enabled = false;

                // Yeni kelimeyi al ve baştan başlat
                if (kelimeListesi.Count > 0)
                {
                    gizliKelime = kelimeListesi[0];  // Yeni kelimeyi al
                    kelimeListesi.RemoveAt(0);  // Yeni kelimeyi listeden çıkar

                    aktifSatir = 0;  // Yeni kelimeyle tahmin haklarını sıfırla
                    lblDurum.Text = $"Yeni Kelime! Tahmin hakkınız: {tahminHakki}";

                    // TextBox'ları sıfırla
                    foreach (var satir in lblHarfSatirlari)
                    {
                        foreach (var lbl in satir)
                        {
                            lbl.Text = "";
                            lbl.BackColor = Color.LightGray;
                        }
                    }

                    // Yeni kelimeyi ekle
                    txtTahmin.Clear();
                    btnTahminEt.Enabled = true;
                    txtTahmin.Enabled = true;
                }
                else
                {
                    lblDurum.Text = "Tüm kelimeleri bildiniz!";
                    MessageBox.Show("Tüm kelimeleri bildiniz!");
                    // Oyun sonlandır
                    btnTahminEt.Enabled = false;
                    txtTahmin.Enabled = false;
                }
            }
            else
            {
                aktifSatir++;
                lblDurum.Text = $"Tahmin hakkınız: {tahminHakki - aktifSatir}";
            }

            if (aktifSatir >= tahminHakki)
            {
                lblDurum.Text = $"Tahmin hakkınız bitti! Doğru kelime: {gizliKelime.ToUpper()}";
                btnTahminEt.Enabled = false;
                txtTahmin.Enabled = false;
            }

            txtTahmin.Clear();
            txtTahmin.Focus();
        }


        // Veritabanından kelimeleri al
        private List<string> GetirOgrenilmisKelimeler()
        {
            List<string> kelimeler = new List<string>();
            string connectionString = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Öğrenilmiş kelimeleri WordProgress tablosundan al, burada 6 tekrar tamamlananlar filtreleniyor
                string query = @"
                    SELECT W.IngKelime
                    FROM WordProgress WP
                    JOIN Kelimeler W ON WP.KelimeID = W.KelimeID
                    WHERE WP.TekrarSayisi >= 6";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        kelimeler.Add(reader["IngKelime"].ToString().ToLower());
                    }
                }
            }

            return kelimeler;
        }
    }
}
