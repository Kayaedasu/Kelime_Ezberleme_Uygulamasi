using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GirisKayit1_story
{
    public partial class FormTekrar : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";
        private int kullaniciID;
        private int aktifKelimeID;
        private int hedefDogruSayisi = 6;
        private int gecerliDogruSayisi = 0;
        private int gecerliYanlisSayisi = 0;
        private int ardIsikDogruSayisi = 0;
        private int gosterilenKelimeSayisi = 0;

        private int gunlukKelimeSayisi;
        private List<int> kelimeIDListesi = new List<int>();
        private int kelimeIndex = 0;

        private TimeSpan[] tekrarAraliklari = new TimeSpan[]
        {
            TimeSpan.Zero,
            TimeSpan.FromDays(1),
            TimeSpan.FromDays(7),
            TimeSpan.FromDays(30),
            TimeSpan.FromDays(90),
            TimeSpan.FromDays(180),
            TimeSpan.FromDays(365)
        };

        public FormTekrar(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void FormTekrar_Load(object sender, EventArgs e)
        {
            gunlukKelimeSayisi = GunlukKelimeSayisiGetir(kullaniciID);
        }

        private int GunlukKelimeSayisiGetir(int kullaniciID)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT GunlukKelimeSayisi FROM KullaniciAyar WHERE KullaniciID = @kullaniciID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                object sonuc = cmd.ExecuteScalar();
                return sonuc != null ? Convert.ToInt32(sonuc) : 10;
            }
        }

        private void KelimeListesiHazirla()
        {
            kelimeIDListesi.Clear();
            kelimeIndex = 0;

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string zorluk = GetirZorlukSeviyesi();
                DateTime bugun = DateTime.Today;
                List<int> tekrarEdilecekler = new List<int>();

                // 1️⃣ Tüm geçmişte doğru bilinen kelimeleri al
                string dogrularSorgu = @"
            SELECT KelimeID, MIN(Tarih) AS IlkDogruTarihi
            FROM KelimeTekrarGecmisi
            WHERE KullaniciID = @kullaniciID AND DogruMu = 1
            GROUP BY KelimeID";

                SqlCommand cmd = new SqlCommand(dogrularSorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int kelimeID = dr.GetInt32(0);
                    DateTime ilkTarih = dr.GetDateTime(1);

                    // Her aralık için kontrol et
                    for (int i = 1; i < tekrarAraliklari.Length; i++)
                    {
                        DateTime hedefTarih = ilkTarih.Date + tekrarAraliklari[i];
                        if (hedefTarih == bugun)
                        {
                            tekrarEdilecekler.Add(kelimeID);
                            break;
                        }
                    }
                }
                dr.Close();

                // 🔽 Eğer sayı fazla ise kırp
                if (tekrarEdilecekler.Count > gunlukKelimeSayisi)
                    tekrarEdilecekler = tekrarEdilecekler.Take(gunlukKelimeSayisi).ToList();

                kelimeIDListesi.AddRange(tekrarEdilecekler);

                int kalan = gunlukKelimeSayisi - kelimeIDListesi.Count;

                // 2️⃣ RASTGELE kelimeler (daha önce doğru bilinenler HARİÇ)
                if (kalan > 0)
                {
                    string rastgeleSorgu = $@"
                SELECT TOP (@kalan) KelimeID 
                FROM Kelimeler
                WHERE ZorlukSeviyesi = @zorluk
                  AND KelimeID NOT IN (
                      SELECT KelimeID 
                      FROM KelimeTekrarDurumu 
                      WHERE KullaniciID = @kullaniciID AND BilinenSoru = 1
                  )
                  AND KelimeID NOT IN ({string.Join(",", tekrarEdilecekler.DefaultIfEmpty(-1))})
                ORDER BY NEWID()";

                    SqlCommand cmd2 = new SqlCommand(rastgeleSorgu, baglanti);
                    cmd2.Parameters.AddWithValue("@kalan", kalan);
                    cmd2.Parameters.AddWithValue("@zorluk", zorluk);
                    cmd2.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                        kelimeIDListesi.Add(dr2.GetInt32(0));
                    dr2.Close();
                }
            }
        }



        private void KelimeGetir()
        {
            if (kelimeIndex >= kelimeIDListesi.Count)
            {
                MessageBox.Show("Günlük kelime hakkınız tamamlandı!");
                this.Close();
                return;
            }

            aktifKelimeID = kelimeIDListesi[kelimeIndex];
            kelimeIndex++;

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT IngKelime, TrKelime, ResimYolu FROM Kelimeler WHERE KelimeID = @kelimeID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kelimeID", aktifKelimeID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblIngKelime.Text = dr.GetString(0);
                    string resimDosyasi = dr.GetString(2);
                    string resimYolu = Path.Combine(Application.StartupPath, "Resimler", resimDosyasi);
                    pbResim.ImageLocation = File.Exists(resimYolu) ? resimYolu : null;

                    CümleleriGoster();
                    txtCevap.Clear();
                    BilinenSoruSayisiniGoster();
                    SonucGuncelle();
                }
                dr.Close();
            }
        }

        private void CümleleriGoster()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT Cumle FROM OrnekCumleler WHERE KelimeID = @kelimeID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                SqlDataReader dr = cmd.ExecuteReader();

                lstCumleler.Items.Clear();
                while (dr.Read())
                    lstCumleler.Items.Add(dr.GetString(0));
                dr.Close();
            }
        }

        private string GetirZorlukSeviyesi()
        {
            if (rbKolay.Checked) return "Kolay";
            if (rbOrta.Checked) return "Orta";
            if (rbZor.Checked) return "Zor";
            return "Kolay";
        }

        private void BilinenSoruSayisiniGoster()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT DogruSayisi, YanlisSayisi FROM KelimeTekrarDurumu WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gecerliDogruSayisi = dr.GetInt32(0);
                    gecerliYanlisSayisi = dr.GetInt32(1);
                }
                dr.Close();
            }

            txtDogru.Text = gecerliDogruSayisi.ToString();
            txtYanlıs.Text = gecerliYanlisSayisi.ToString();
        }

        private void SonucGuncelle()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT DogruSayisi, YanlisSayisi FROM KelimeTekrarDurumu WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDogru.Text = dr.GetInt32(0).ToString();
                    txtYanlıs.Text = dr.GetInt32(1).ToString();
                }
                dr.Close();
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (!rbKolay.Checked && !rbOrta.Checked && !rbZor.Checked)
            {
                MessageBox.Show("Lütfen bir zorluk seviyesi seçin.");
                return;
            }

            KelimeListesiHazirla();
            KelimeGetir();
        }

        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            string kullaniciCevabi = txtCevap.Text.Trim();
            if (string.IsNullOrEmpty(kullaniciCevabi))
            {
                MessageBox.Show("Lütfen cevap girin.");
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string kontrolVarMi = "SELECT COUNT(*) FROM KelimeTekrarDurumu WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                SqlCommand cmdKontrol = new SqlCommand(kontrolVarMi, baglanti);
                cmdKontrol.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmdKontrol.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                int kayitVarMi = (int)cmdKontrol.ExecuteScalar();

                if (kayitVarMi == 0)
                {
                    string insert = @"INSERT INTO KelimeTekrarDurumu (KullaniciID, KelimeID, DogruSayisi, YanlisSayisi, SonTekrarTarihi, BilinenSoru, TekrarSayisi)
                                      VALUES (@kullaniciID, @kelimeID, 0, 0, GETDATE(), 0, 0)";
                    SqlCommand cmdInsert = new SqlCommand(insert, baglanti);
                    cmdInsert.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdInsert.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdInsert.ExecuteNonQuery();
                }

                string dogruSorgu = "SELECT TrKelime FROM Kelimeler WHERE KelimeID = @kelimeID";
                SqlCommand cmdDogru = new SqlCommand(dogruSorgu, baglanti);
                cmdDogru.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                string dogruCevap = (string)cmdDogru.ExecuteScalar();

                bool dogruMu = string.Equals(kullaniciCevabi, dogruCevap, StringComparison.OrdinalIgnoreCase);

                string gecmisKayit = @"INSERT INTO KelimeTekrarGecmisi (KullaniciID, KelimeID, DogruMu, Tarih)
                                       VALUES (@kullaniciID, @kelimeID, @dogruMu, GETDATE())";
                SqlCommand cmdKayit = new SqlCommand(gecmisKayit, baglanti);
                cmdKayit.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmdKayit.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                cmdKayit.Parameters.AddWithValue("@dogruMu", dogruMu);
                cmdKayit.ExecuteNonQuery();

                if (dogruMu)
                {
                    gecerliDogruSayisi++;
                    string guncelle = @"UPDATE KelimeTekrarDurumu
                                        SET DogruSayisi = @dogruSayisi, YanlisSayisi = 0, SonTekrarTarihi = GETDATE()
                                        WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                    SqlCommand cmdGuncelle = new SqlCommand(guncelle, baglanti);
                    cmdGuncelle.Parameters.AddWithValue("@dogruSayisi", gecerliDogruSayisi);
                    cmdGuncelle.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdGuncelle.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdGuncelle.ExecuteNonQuery();

                    if (ZamanlaraGoreDogruKontrolEt(aktifKelimeID))
                    {
                        string bilinen = @"UPDATE KelimeTekrarDurumu 
                                           SET BilinenSoru = 1 
                                           WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                        SqlCommand cmdBilinen = new SqlCommand(bilinen, baglanti);
                        cmdBilinen.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                        cmdBilinen.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                        cmdBilinen.ExecuteNonQuery();
                        MessageBox.Show("Tebrikler! Bu kelime zaman aralıklı olarak 6 kez doğru bilindi.");
                    }
                    else
                    {
                        MessageBox.Show("Doğru! Bu kelimeyi çalışmaya devam et.");
                    }
                }
                else
                {
                    gecerliYanlisSayisi++;
                    string yanlis = @"UPDATE KelimeTekrarDurumu
                                      SET YanlisSayisi = @yanlisSayisi, DogruSayisi = 0, TekrarSayisi = 0, SonTekrarTarihi = GETDATE()
                                      WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                    SqlCommand cmdYanlis = new SqlCommand(yanlis, baglanti);
                    cmdYanlis.Parameters.AddWithValue("@yanlisSayisi", gecerliYanlisSayisi);
                    cmdYanlis.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdYanlis.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdYanlis.ExecuteNonQuery();
                    gecerliDogruSayisi = 0;
                    MessageBox.Show("Yanlış cevap! Süreç sıfırlandı.");
                }

                txtDogru.Text = gecerliDogruSayisi.ToString();
                txtYanlıs.Text = gecerliYanlisSayisi.ToString();
                KelimeGetir();
            }
        }
        private void txtDogru_TextChanged(object sender, EventArgs e)
        {
           }

        private bool ZamanlaraGoreDogruKontrolEt(int kelimeID)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = @"SELECT Tarih FROM KelimeTekrarGecmisi 
                                 WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID AND DogruMu = 1
                                 ORDER BY Tarih ASC";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@kelimeID", kelimeID);

                List<DateTime> dogruTarihler = new List<DateTime>();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        dogruTarihler.Add(dr.GetDateTime(0));
                }

                if (dogruTarihler.Count < 6)
                    return false;

                DateTime ilkTarih = dogruTarihler[0];
                for (int i = 1; i <= 5; i++)
                {
                    DateTime hedefTarih = ilkTarih + tekrarAraliklari[i];
                    bool uygunVar = dogruTarihler.Any(dt => dt >= hedefTarih);
                    if (!uygunVar) return false;
                }

                return true;
            }
        }
    }
}
