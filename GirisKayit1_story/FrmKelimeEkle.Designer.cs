namespace GirisKayit1_story
{
    partial class FrmKelimeEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKelimeEkle));
            lblIngKelime = new Label();
            lblTrKelime = new Label();
            lblResim = new Label();
            lblCumleler = new Label();
            txtIngKelime = new TextBox();
            txtTrKelime = new TextBox();
            txtResimYolu = new TextBox();
            txtCumleler = new TextBox();
            btnResimSec = new Button();
            btnKaydet = new Button();
            pctSüs = new PictureBox();
            pictureBox1 = new PictureBox();
            cmbZorluk = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtKategori = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pctSüs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblIngKelime
            // 
            lblIngKelime.AutoSize = true;
            lblIngKelime.Location = new Point(119, 109);
            lblIngKelime.Name = "lblIngKelime";
            lblIngKelime.Size = new Size(188, 28);
            lblIngKelime.TabIndex = 0;
            lblIngKelime.Text = "İngilizce Kelimeler:";
            // 
            // lblTrKelime
            // 
            lblTrKelime.AutoSize = true;
            lblTrKelime.Location = new Point(133, 176);
            lblTrKelime.Name = "lblTrKelime";
            lblTrKelime.Size = new Size(161, 28);
            lblTrKelime.TabIndex = 1;
            lblTrKelime.Text = "Türkçe Karşılığı:";
            // 
            // lblResim
            // 
            lblResim.AutoSize = true;
            lblResim.Location = new Point(177, 252);
            lblResim.Name = "lblResim";
            lblResim.Size = new Size(119, 28);
            lblResim.TabIndex = 2;
            lblResim.Text = "Resim Yolu:";
            // 
            // lblCumleler
            // 
            lblCumleler.AutoSize = true;
            lblCumleler.Location = new Point(133, 322);
            lblCumleler.Name = "lblCumleler";
            lblCumleler.Size = new Size(166, 28);
            lblCumleler.TabIndex = 3;
            lblCumleler.Text = "Örnek Cümleler:";
            // 
            // txtIngKelime
            // 
            txtIngKelime.Location = new Point(300, 106);
            txtIngKelime.Name = "txtIngKelime";
            txtIngKelime.Size = new Size(221, 36);
            txtIngKelime.TabIndex = 4;
            // 
            // txtTrKelime
            // 
            txtTrKelime.Location = new Point(300, 176);
            txtTrKelime.Name = "txtTrKelime";
            txtTrKelime.Size = new Size(221, 36);
            txtTrKelime.TabIndex = 5;
            // 
            // txtResimYolu
            // 
            txtResimYolu.Location = new Point(300, 248);
            txtResimYolu.Name = "txtResimYolu";
            txtResimYolu.ReadOnly = true;
            txtResimYolu.Size = new Size(221, 36);
            txtResimYolu.TabIndex = 6;
            // 
            // txtCumleler
            // 
            txtCumleler.Location = new Point(300, 322);
            txtCumleler.Multiline = true;
            txtCumleler.Name = "txtCumleler";
            txtCumleler.ScrollBars = ScrollBars.Vertical;
            txtCumleler.Size = new Size(221, 36);
            txtCumleler.TabIndex = 7;
            // 
            // btnResimSec
            // 
            btnResimSec.BackColor = Color.FromArgb(255, 255, 192);
            btnResimSec.Location = new Point(545, 252);
            btnResimSec.Name = "btnResimSec";
            btnResimSec.Size = new Size(236, 37);
            btnResimSec.TabIndex = 8;
            btnResimSec.Text = "Resim Seç";
            btnResimSec.UseVisualStyleBackColor = false;
            btnResimSec.Click += btnResimSec_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.FromArgb(255, 224, 192);
            btnKaydet.Location = new Point(300, 471);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(221, 60);
            btnKaydet.TabIndex = 9;
            btnKaydet.Text = "Kelime Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // pctSüs
            // 
            pctSüs.Image = (Image)resources.GetObject("pctSüs.Image");
            pctSüs.Location = new Point(715, -3);
            pctSüs.Name = "pctSüs";
            pctSüs.Size = new Size(200, 145);
            pctSüs.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSüs.TabIndex = 10;
            pctSüs.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(554, 310);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // cmbZorluk
            // 
            cmbZorluk.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZorluk.FormattingEnabled = true;
            cmbZorluk.Items.AddRange(new object[] { "Kolay ", "Orta ", "Zor" });
            cmbZorluk.Location = new Point(300, 52);
            cmbZorluk.Name = "cmbZorluk";
            cmbZorluk.Size = new Size(221, 36);
            cmbZorluk.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 55);
            label1.Name = "label1";
            label1.Size = new Size(159, 28);
            label1.TabIndex = 13;
            label1.Text = "Zorluk Seviyesi:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 391);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 14;
            label2.Text = "Kategori:";
            // 
            // txtKategori
            // 
            txtKategori.Location = new Point(300, 383);
            txtKategori.Name = "txtKategori";
            txtKategori.ReadOnly = true;
            txtKategori.Size = new Size(221, 36);
            txtKategori.TabIndex = 15;
            // 
            // FrmKelimeEkle
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(913, 611);
            Controls.Add(txtKategori);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbZorluk);
            Controls.Add(pictureBox1);
            Controls.Add(pctSüs);
            Controls.Add(btnKaydet);
            Controls.Add(btnResimSec);
            Controls.Add(txtCumleler);
            Controls.Add(txtResimYolu);
            Controls.Add(txtTrKelime);
            Controls.Add(txtIngKelime);
            Controls.Add(lblCumleler);
            Controls.Add(lblResim);
            Controls.Add(lblTrKelime);
            Controls.Add(lblIngKelime);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(4);
            Name = "FrmKelimeEkle";
            Text = "FrmKelimeEkle";
            Load += FrmKelimeEkle_Load;
            ((System.ComponentModel.ISupportInitialize)pctSüs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngKelime;
        private Label lblTrKelime;
        private Label lblResim;
        private Label lblCumleler;
        private TextBox txtIngKelime;
        private TextBox txtTrKelime;
        private TextBox txtResimYolu;
        private TextBox txtCumleler;
        private Button btnResimSec;
        private Button btnKaydet;
        private PictureBox pctSüs;
        private PictureBox pictureBox1;
        private ComboBox cmbZorluk;
        private Label label1;
        private Label label2;
        private TextBox txtKategori;
    }
}