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
    public partial class FormLLM : Form
    {
        private int kullaniciID;
        public FormLLM(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            if (kullaniciID == 0)
            {
                MessageBox.Show("Lütfen giriş yapın.");
                return;
            }

            // Bilinen kelimeleri getir
            List<string> bilinenKelimeler = BilinenKelimeleriGetir(kullaniciID);

            // Label'a yazdır
            lblBilinenKelimeler.Text = "Bilinen Kelimeler: " + string.Join(", ", bilinenKelimeler);

            // Hikaye dosyasını oku
            string hikayeDosyaYolu = @"C:\Users\edasu\Desktop\LLM hikaye\ela.txt";

            if (File.Exists(hikayeDosyaYolu))
            {
                txtHikaye.Text = File.ReadAllText(hikayeDosyaYolu);
            }
            else
            {
                MessageBox.Show("Hikaye dosyası bulunamadı.");
                txtHikaye.Text = "";
            }

            // Resmi göster
            string gorselDosyaYolu = @"C:\Users\edasu\Desktop\LLM görsel\ela.png";

            if (File.Exists(gorselDosyaYolu))
            {
                pictureBox1.Image = Image.FromFile(gorselDosyaYolu);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("Görsel dosyası bulunamadı.");
                pictureBox1.Visible = false;
            }
        }
        private List<string> BilinenKelimeleriGetir(int kullaniciID)
        {
            List<string> kelimeler = new List<string>();
            string connStr = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
            SELECT TOP 10 k.IngKelime
            FROM KelimeTekrarDurumu d
            INNER JOIN Kelimeler k ON d.KelimeID = k.KelimeID
            WHERE d.KullaniciID = @kullaniciID AND d.BilinenSoru = 1
            ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        kelimeler.Add(reader["IngKelime"].ToString());
                }
            }
            return kelimeler;
        }

    }
}

