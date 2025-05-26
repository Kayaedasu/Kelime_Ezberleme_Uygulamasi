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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


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

        private void btnPfKaydet_Click(object sender, EventArgs e)
        {
            if (dgvAnaliz.Rows.Count == 0)
            {
                MessageBox.Show("Rapor tablosu boş!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            saveFileDialog.Title = "Analiz Raporunu Kaydet";
            saveFileDialog.FileName = "BasariAnalizRaporu.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfPTable pdfTable = new PdfPTable(dgvAnaliz.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Başlıklar
                    foreach (DataGridViewColumn column in dgvAnaliz.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 10)));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        pdfTable.AddCell(cell);
                    }

                    // Satırlar
                    foreach (DataGridViewRow row in dgvAnaliz.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }

                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        Paragraph title = new Paragraph("Başarı Analiz Raporu", FontFactory.GetFont("Arial", 14));
                        title.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Chunk("\n"));
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("PDF başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
