namespace GirisKayit1_story
{
    partial class FormTekrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTekrar));
            lblIngKelime = new Label();
            lblDogru = new Label();
            pbResim = new PictureBox();
            txtCevap = new TextBox();
            label1 = new Label();
            btnKontrolEt = new Button();
            lstCumleler = new ListBox();
            lblYanlis = new Label();
            txtDogru = new TextBox();
            txtYanlıs = new TextBox();
            pictureBox1 = new PictureBox();
            rbKolay = new RadioButton();
            rbOrta = new RadioButton();
            rbZor = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pbResim).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblIngKelime
            // 
            lblIngKelime.AutoSize = true;
            lblIngKelime.Font = new Font("Elephant", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblIngKelime.Location = new Point(30, 9);
            lblIngKelime.Name = "lblIngKelime";
            lblIngKelime.Size = new Size(264, 38);
            lblIngKelime.TabIndex = 0;
            lblIngKelime.Text = "İngilizce Kelime";
            // 
            // lblDogru
            // 
            lblDogru.AutoSize = true;
            lblDogru.Location = new Point(94, 533);
            lblDogru.Name = "lblDogru";
            lblDogru.Size = new Size(135, 28);
            lblDogru.TabIndex = 1;
            lblDogru.Text = "Doğru Sayısı:";
            // 
            // pbResim
            // 
            pbResim.Location = new Point(50, 123);
            pbResim.Name = "pbResim";
            pbResim.Size = new Size(260, 177);
            pbResim.SizeMode = PictureBoxSizeMode.StretchImage;
            pbResim.TabIndex = 3;
            pbResim.TabStop = false;
            // 
            // txtCevap
            // 
            txtCevap.Location = new Point(440, 175);
            txtCevap.Name = "txtCevap";
            txtCevap.Size = new Size(266, 36);
            txtCevap.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Footlight MT Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(440, 123);
            label1.Name = "label1";
            label1.Size = new Size(103, 24);
            label1.TabIndex = 5;
            label1.Text = "Cevabınız";
            // 
            // btnKontrolEt
            // 
            btnKontrolEt.BackColor = Color.FromArgb(255, 224, 192);
            btnKontrolEt.Location = new Point(563, 247);
            btnKontrolEt.Name = "btnKontrolEt";
            btnKontrolEt.Size = new Size(143, 42);
            btnKontrolEt.TabIndex = 6;
            btnKontrolEt.Text = "Kontol Et";
            btnKontrolEt.UseVisualStyleBackColor = false;
            btnKontrolEt.Click += btnKontrolEt_Click;
            // 
            // lstCumleler
            // 
            lstCumleler.BackColor = Color.FromArgb(255, 192, 128);
            lstCumleler.FormattingEnabled = true;
            lstCumleler.ItemHeight = 28;
            lstCumleler.Location = new Point(46, 337);
            lstCumleler.Name = "lstCumleler";
            lstCumleler.Size = new Size(342, 144);
            lstCumleler.TabIndex = 7;
            // 
            // lblYanlis
            // 
            lblYanlis.AutoSize = true;
            lblYanlis.Location = new Point(473, 538);
            lblYanlis.Name = "lblYanlis";
            lblYanlis.Size = new Size(130, 28);
            lblYanlis.TabIndex = 8;
            lblYanlis.Text = "Yanlış Sayısı:";
            // 
            // txtDogru
            // 
            txtDogru.Location = new Point(247, 533);
            txtDogru.Name = "txtDogru";
            txtDogru.Size = new Size(81, 36);
            txtDogru.TabIndex = 9;
            txtDogru.TextChanged += txtDogru_TextChanged;
            // 
            // txtYanlıs
            // 
            txtYanlıs.Location = new Point(625, 538);
            txtYanlıs.Name = "txtYanlıs";
            txtYanlıs.Size = new Size(81, 36);
            txtYanlıs.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(575, 321);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // rbKolay
            // 
            rbKolay.AutoSize = true;
            rbKolay.Location = new Point(46, 73);
            rbKolay.Name = "rbKolay";
            rbKolay.Size = new Size(86, 32);
            rbKolay.TabIndex = 12;
            rbKolay.TabStop = true;
            rbKolay.Text = "Kolay";
            rbKolay.UseVisualStyleBackColor = true;
            // 
            // rbOrta
            // 
            rbOrta.AutoSize = true;
            rbOrta.Location = new Point(138, 73);
            rbOrta.Name = "rbOrta";
            rbOrta.Size = new Size(77, 32);
            rbOrta.TabIndex = 13;
            rbOrta.TabStop = true;
            rbOrta.Text = "Orta";
            rbOrta.UseVisualStyleBackColor = true;
            // 
            // rbZor
            // 
            rbZor.AutoSize = true;
            rbZor.Location = new Point(225, 73);
            rbZor.Name = "rbZor";
            rbZor.Size = new Size(66, 32);
            rbZor.TabIndex = 14;
            rbZor.TabStop = true;
            rbZor.Text = "Zor";
            rbZor.UseVisualStyleBackColor = true;
            // 
            // FormTekrar
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(841, 595);
            Controls.Add(rbZor);
            Controls.Add(rbOrta);
            Controls.Add(rbKolay);
            Controls.Add(pictureBox1);
            Controls.Add(txtYanlıs);
            Controls.Add(txtDogru);
            Controls.Add(lblYanlis);
            Controls.Add(lstCumleler);
            Controls.Add(btnKontrolEt);
            Controls.Add(label1);
            Controls.Add(txtCevap);
            Controls.Add(pbResim);
            Controls.Add(lblDogru);
            Controls.Add(lblIngKelime);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormTekrar";
            Text = "FormTekrar";
            Load += FormTekrar_Load;
            ((System.ComponentModel.ISupportInitialize)pbResim).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngKelime;
        private Label lblDogru;
        private PictureBox pbResim;
        private TextBox txtCevap;
        private Label label1;
        private Button btnKontrolEt;
        private ListBox lstCumleler;
        private Label lblYanlis;
        private TextBox txtDogru;
        private TextBox txtYanlıs;
        private PictureBox pictureBox1;
        private RadioButton rbKolay;
        private RadioButton rbOrta;
        private RadioButton rbZor;
    }
}