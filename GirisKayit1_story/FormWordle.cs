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

        public FormWordle(int KullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = KullaniciID;
            this.Load += FormWordle_Load;
        }

        private void FormWordle_Load(object sender, EventArgs e)
        {
            kelimeListesi = GetirOgrenilmisKelimeler();
            if (kelimeListesi.Count == 0)
            {
                MessageBox.Show("Veritabanında öğrenilmiş kelime bulunamadı!");
                this.Close();
                return;
            }

            YeniKelimeyiBaslat();
        }

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

        private async void btnTahminEt_Click(object sender, EventArgs e)
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

            char[] gizliDizi = gizliKelime.ToCharArray();
            bool[] harfKullanildi = new bool[gizliKelime.Length];

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

            if (tahmin == gizliKelime)
            {
                lblDurum.Text = $"Tebrikler! Doğru tahmin ettiniz: {gizliKelime.ToUpper()}";
                btnTahminEt.Enabled = false;
                txtTahmin.Enabled = false;

                await Task.Delay(1500); // 1.5 saniye bekle, kullanıcı yeşil sonucu görsün
                YeniKelimeyiBaslat();
                return;
            }

            aktifSatir++;
            lblDurum.Text = $"Tahmin hakkınız: {tahminHakki - aktifSatir}";

            if (aktifSatir >= tahminHakki)
            {
                lblDurum.Text = $"Tahmin hakkınız bitti! Doğru kelime: {gizliKelime.ToUpper()}";
                btnTahminEt.Enabled = false;
                txtTahmin.Enabled = false;

                await Task.Delay(1500); // yanlışsa da biraz görsün
                YeniKelimeyiBaslat();
            }

            txtTahmin.Clear();
            txtTahmin.Focus();
        }


        private void YeniKelimeyiBaslat()
        {
            if (kelimeListesi.Count > 0)
            {
                gizliKelime = kelimeListesi[0];
                kelimeListesi.RemoveAt(0);

                aktifSatir = 0;
                lblDurum.Text = $"Yeni Kelime! Tahmin hakkınız: {tahminHakki}";
                this.Text = "Wordle Oyunu - " + gizliKelime.Length + " Harfli Kelime";

                // Önceki kutuları temizle
                foreach (var satir in lblHarfSatirlari)
                {
                    foreach (var lbl in satir)
                    {
                        this.Controls.Remove(lbl);
                        lbl.Dispose();
                    }
                }
                lblHarfSatirlari.Clear();

                DinamikLabelOlustur();

                txtTahmin.Clear();
                txtTahmin.MaxLength = gizliKelime.Length;
                btnTahminEt.Enabled = true;
                txtTahmin.Enabled = true;
            }
            else
            {
                lblDurum.Text = "Tüm kelimeleri bildiniz!";
                MessageBox.Show("Tüm kelimeleri başarıyla tahmin ettiniz!");
                btnTahminEt.Enabled = false;
                txtTahmin.Enabled = false;
            }
        }

        private List<string> GetirOgrenilmisKelimeler()
        {
            List<string> kelimeler = new List<string>();
            string connectionString = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";

            TimeSpan[] tekrarAraliklari = new TimeSpan[]
            {
        TimeSpan.Zero,
        TimeSpan.FromDays(1),
        TimeSpan.FromDays(7),
        TimeSpan.FromDays(30),
        TimeSpan.FromDays(90),
        TimeSpan.FromDays(180),
        TimeSpan.FromDays(365)
            };

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                string query = @"
            SELECT KTG.KelimeID, W.IngKelime, KTG.Tarih
            FROM KelimeTekrarGecmisi KTG
            JOIN Kelimeler W ON KTG.KelimeID = W.KelimeID
            WHERE KTG.KullaniciID = @kullaniciID AND KTG.DogruMu = 1
            ORDER BY KTG.KelimeID, KTG.Tarih";

                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                Dictionary<int, List<DateTime>> kelimeDogruZamanlari = new Dictionary<int, List<DateTime>>();
                Dictionary<int, string> kelimeIngilizce = new Dictionary<int, string>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int kelimeID = reader.GetInt32(0);
                        string ing = reader.GetString(1).ToLower();
                        DateTime tarih = reader.GetDateTime(2);

                        if (!kelimeDogruZamanlari.ContainsKey(kelimeID))
                        {
                            kelimeDogruZamanlari[kelimeID] = new List<DateTime>();
                            kelimeIngilizce[kelimeID] = ing;
                        }

                        kelimeDogruZamanlari[kelimeID].Add(tarih);
                    }
                }

                foreach (var pair in kelimeDogruZamanlari)
                {
                    List<DateTime> dogruTarihler = pair.Value.OrderBy(x => x).ToList();
                    if (dogruTarihler.Count < 6) continue;

                    DateTime ilkTarih = dogruTarihler[0];
                    bool hepsiVar = true;

                    for (int i = 1; i <= 5; i++)
                    {
                        DateTime hedefTarih = ilkTarih + tekrarAraliklari[i];
                        bool uygunVar = dogruTarihler.Any(dt => dt >= hedefTarih);
                        if (!uygunVar)
                        {
                            hepsiVar = false;
                            break;
                        }
                    }

                    if (hepsiVar)
                        kelimeler.Add(kelimeIngilizce[pair.Key]);
                }
            }

            return kelimeler;
        }


    }
}
