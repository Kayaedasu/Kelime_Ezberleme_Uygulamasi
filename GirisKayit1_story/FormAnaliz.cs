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
    public partial class FormAnaliz : Form
    {
        string baglantiCumlesi = @"Server=EdasMatebook\SQLEXPRESS;Database=KelimeEzberlemeDB;Trusted_Connection=True;";
        private int kullaniciID;
        public FormAnaliz(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        private void FormAnaliz_Load(object sender, EventArgs e)
        {
            RaporuYukle();
        }
        private void RaporuYukle()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = @"
    SELECT 
        k.Kategori AS [Kategori],
        COUNT(*) AS [Toplam Cevaplanan],
        SUM(kt.DogruSayisi) AS [Doğru Sayısı],
        SUM(kt.YanlisSayisi) AS [Yanlış Sayısı],
        CAST(
            100.0 * SUM(kt.DogruSayisi) / NULLIF(SUM(kt.DogruSayisi + kt.YanlisSayisi), 0)
            AS DECIMAL(5,2)
        ) AS [% Başarı]
    FROM 
        KelimeTekrarDurumu kt
    INNER JOIN 
        Kelimeler k ON k.KelimeID = kt.KelimeID
    WHERE 
        kt.KullaniciID = @kullaniciID
    GROUP BY 
        k.Kategori";


                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAnaliz.DataSource = dt;
            }
        }
    }
}
