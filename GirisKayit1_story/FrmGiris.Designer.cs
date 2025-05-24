namespace GirisKayit1_story
{
    partial class FrmGiris
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
            lblKullaniciAdi = new Label();
            lblEmail = new Label();
            lblSifre = new Label();
            txtKullaniciAd = new TextBox();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            btnGirisYap = new Button();
            lnkSifreUnuttum = new LinkLabel();
            SuspendLayout();
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblKullaniciAdi.Location = new Point(201, 115);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(123, 29);
            lblKullaniciAdi.TabIndex = 0;
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblEmail.Location = new Point(245, 171);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(73, 29);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail:";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblSifre.Location = new Point(245, 235);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(57, 29);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre:";
            // 
            // txtKullaniciAd
            // 
            txtKullaniciAd.Location = new Point(330, 115);
            txtKullaniciAd.Name = "txtKullaniciAd";
            txtKullaniciAd.Size = new Size(166, 36);
            txtKullaniciAd.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(330, 171);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(166, 36);
            txtEmail.TabIndex = 4;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(330, 228);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(166, 36);
            txtSifre.TabIndex = 5;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // btnGirisYap
            // 
            btnGirisYap.BackColor = Color.FromArgb(255, 224, 192);
            btnGirisYap.Location = new Point(340, 289);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(143, 45);
            btnGirisYap.TabIndex = 6;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = false;
            btnGirisYap.Click += btnGirisYap_Click;
            // 
            // lnkSifreUnuttum
            // 
            lnkSifreUnuttum.AutoSize = true;
            lnkSifreUnuttum.LinkColor = Color.FromArgb(64, 64, 64);
            lnkSifreUnuttum.Location = new Point(512, 243);
            lnkSifreUnuttum.Name = "lnkSifreUnuttum";
            lnkSifreUnuttum.Size = new Size(170, 28);
            lnkSifreUnuttum.TabIndex = 7;
            lnkSifreUnuttum.TabStop = true;
            lnkSifreUnuttum.Text = "Şifremi Unuttum";
            lnkSifreUnuttum.LinkClicked += lnkSifreUnuttum_LinkClicked;
            // 
            // FrmGiris
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(758, 481);
            Controls.Add(lnkSifreUnuttum);
            Controls.Add(btnGirisYap);
            Controls.Add(txtSifre);
            Controls.Add(txtEmail);
            Controls.Add(txtKullaniciAd);
            Controls.Add(lblSifre);
            Controls.Add(lblEmail);
            Controls.Add(lblKullaniciAdi);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FrmGiris";
            Text = "FrmGiris";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKullaniciAdi;
        private Label lblEmail;
        private Label lblSifre;
        private TextBox txtKullaniciAd;
        private TextBox txtEmail;
        private TextBox txtSifre;
        private Button btnGirisYap;
        private LinkLabel lnkSifreUnuttum;
    }
}