using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private TimeSpan[] tekrarAraliklari = new TimeSpan[]
{
    TimeSpan.Zero,               // 1. tekrar: hemen
    TimeSpan.FromDays(1),        // 2. tekrar: 1 gün sonra
    TimeSpan.FromDays(7),        // 3. tekrar: 1 hafta sonra
    TimeSpan.FromDays(30),       // 4. tekrar: 1 ay sonra
    TimeSpan.FromDays(90),       // 5. tekrar: 3 ay sonra
    TimeSpan.FromDays(180),      // 6. tekrar: 6 ay sonra
    TimeSpan.FromDays(365)       // bitirme: 1 yıl sonra
};



        public FormTekrar(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void FormTekrar_Load(object sender, EventArgs e)
        {
            KelimeGetir();
            BilinenSoruSayisiniGoster();
            SonucGuncelle();
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
                return sonuc != null ? Convert.ToInt32(sonuc) : 10; // varsayılan 10
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
                {
                    lstCumleler.Items.Add(dr.GetString(0));
                }

                dr.Close();
            }
        }


        private void KelimeGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                gosterilenKelimeSayisi++;

                int limit = GunlukKelimeSayisiGetir(kullaniciID);
                if (gosterilenKelimeSayisi >= limit)
                {
                    MessageBox.Show("Bugünkü çalışma tamamlandı!");
                    // 🔽 Quiz sonrası analiz formunu göster
                    FormAnaliz analizFormu = new FormAnaliz(kullaniciID);
                    analizFormu.ShowDialog();
                }

                string sorgu = $@"
            SELECT TOP ({limit}) k.KelimeID, k.IngKelime, k.TrKelime, k.ResimYolu
            FROM Kelimeler k
            LEFT JOIN KelimeTekrarDurumu kt ON kt.KelimeID = k.KelimeID AND kt.KullaniciID = @kullaniciID
            WHERE ISNULL(kt.DogruSayisi, 0) < @hedefDogruSayisi AND (kt.BilinenSoru = 0 OR kt.BilinenSoru IS NULL)
            ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@hedefDogruSayisi", hedefDogruSayisi);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    aktifKelimeID = dr.GetInt32(0);
                    lblIngKelime.Text = dr.GetString(1);
                    string trKelime = dr.GetString(2);

                    string resimDosyasi = dr.GetString(3);
                    string resimYolu = Path.Combine(Application.StartupPath, "Resimler", resimDosyasi);
                    pbResim.ImageLocation = File.Exists(resimYolu) ? resimYolu : null;

                    CümleleriGoster();
                    txtCevap.Clear();
                    BilinenSoruSayisiniGoster();
                    SonucGuncelle();
                }
                else
                {
                    MessageBox.Show("Tüm kelimeler başarıyla öğrenildi.");
                    this.Close();

                }

                dr.Close();
            }
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

            // TextBox'lara yaz
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

                // Kayıt yoksa INSERT et
                string kontrolVarMi = "SELECT COUNT(*) FROM KelimeTekrarDurumu WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                SqlCommand cmdKontrolVarMi = new SqlCommand(kontrolVarMi, baglanti);
                cmdKontrolVarMi.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmdKontrolVarMi.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                int kayitVarMi = (int)cmdKontrolVarMi.ExecuteScalar();

                if (kayitVarMi == 0)
                {
                    string insertSorgu = @"INSERT INTO KelimeTekrarDurumu 
                (KullaniciID, KelimeID, DogruSayisi, YanlisSayisi, SonTekrarTarihi, BilinenSoru, TekrarSayisi)
                VALUES (@kullaniciID, @kelimeID, 0, 0, GETDATE(), 0, 0)";
                    SqlCommand cmdInsert = new SqlCommand(insertSorgu, baglanti);
                    cmdInsert.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdInsert.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdInsert.ExecuteNonQuery();
                }

                // Doğru cevabı al
                string dogruCevapSorgu = "SELECT TrKelime FROM Kelimeler WHERE KelimeID = @kelimeID";
                SqlCommand cmdDogruCevap = new SqlCommand(dogruCevapSorgu, baglanti);
                cmdDogruCevap.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                string dogruCevap = (string)cmdDogruCevap.ExecuteScalar();

                bool dogruMu = string.Equals(kullaniciCevabi, dogruCevap, StringComparison.OrdinalIgnoreCase);

                if (dogruMu)
                {
                    // TekrarSayisi ve SonTekrarTarihi'ni al
                    string tekrarSorgu = "SELECT TekrarSayisi, SonTekrarTarihi FROM KelimeTekrarDurumu WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                    SqlCommand cmdTekrar = new SqlCommand(tekrarSorgu, baglanti);
                    cmdTekrar.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdTekrar.Parameters.AddWithValue("@kelimeID", aktifKelimeID);

                    SqlDataReader dr = cmdTekrar.ExecuteReader();
                    int tekrarSayisi = 0;
                    DateTime sonTekrarTarihi = DateTime.MinValue;

                    if (dr.Read())
                    {
                        tekrarSayisi = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                        sonTekrarTarihi = dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1);
                    }

                    dr.Close();

                    // Zaman kontrolü
                    TimeSpan gerekenSure = tekrarAraliklari[Math.Min(tekrarSayisi, tekrarAraliklari.Length - 1)];
                    DateTime beklenenTarih = sonTekrarTarihi.Add(gerekenSure);

                    if (DateTime.Now < beklenenTarih)
                    {
                        MessageBox.Show("Bu kelimenin tekrar zamanı henüz gelmedi.");
                        KelimeGetir();
                        return;
                    }

                    // Uygunsa: tekrarSayisi++
                    tekrarSayisi++;
                    gecerliDogruSayisi++;
                    gecerliYanlisSayisi = 0;

                    // Güncelle tekrar
                    string guncelleDogru = @"UPDATE KelimeTekrarDurumu
                SET TekrarSayisi = @tekrarSayisi,
                    DogruSayisi = @dogruSayisi,
                    YanlisSayisi = 0,
                    SonTekrarTarihi = GETDATE()
                WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                    SqlCommand cmdGuncelle = new SqlCommand(guncelleDogru, baglanti);
                    cmdGuncelle.Parameters.AddWithValue("@tekrarSayisi", tekrarSayisi);
                    cmdGuncelle.Parameters.AddWithValue("@dogruSayisi", gecerliDogruSayisi);
                    cmdGuncelle.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdGuncelle.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdGuncelle.ExecuteNonQuery();

                    if (tekrarSayisi >= 6)
                    {
                        string bilinenYap = @"UPDATE KelimeTekrarDurumu 
                    SET BilinenSoru = 1 
                    WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                        SqlCommand cmdBilinen = new SqlCommand(bilinenYap, baglanti);
                        cmdBilinen.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                        cmdBilinen.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                        cmdBilinen.ExecuteNonQuery();

                        MessageBox.Show("Bu kelimeyi 6 kez farklı zamanlarda doğru bildiniz. Artık bilinen kelimeler arasında!");
                    }
                    else
                    {
                        MessageBox.Show("Doğru! Bu kelimeyi çalışmaya devam et.");
                    }
                }
                else
                {
                    gecerliYanlisSayisi++;

                    string guncelleYanlis = @"UPDATE KelimeTekrarDurumu
                SET YanlisSayisi = @yanlisSayisi,
                    TekrarSayisi = 0,
                    DogruSayisi = 0,
                    SonTekrarTarihi = GETDATE()
                WHERE KullaniciID = @kullaniciID AND KelimeID = @kelimeID";
                    SqlCommand cmdYanlis = new SqlCommand(guncelleYanlis, baglanti);
                    cmdYanlis.Parameters.AddWithValue("@yanlisSayisi", gecerliYanlisSayisi);
                    cmdYanlis.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    cmdYanlis.Parameters.AddWithValue("@kelimeID", aktifKelimeID);
                    cmdYanlis.ExecuteNonQuery();

                    MessageBox.Show("Yanlış cevap! Süreç sıfırlandı.");
                    gecerliDogruSayisi = 0;
                }

           


        // Form üzerindeki kutulara sayıları yaz
        txtDogru.Text = gecerliDogruSayisi.ToString();
                txtYanlıs.Text = gecerliYanlisSayisi.ToString();

                // Yeni kelime getir
                KelimeGetir();
            }
        }


        private void txtDogru_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
