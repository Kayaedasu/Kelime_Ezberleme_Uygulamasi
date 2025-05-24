namespace GirisKayit1_story
{
    partial class FrmKayıtOl
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
            btnKayıtOl = new Button();
            txtSifreTekrar = new TextBox();
            lblSifreTekrar = new Label();
            txtSifre = new TextBox();
            txtEmail = new TextBox();
            txtKullaniciAd = new TextBox();
            lblSifre = new Label();
            lblEmail = new Label();
            lblKullaniciAdi = new Label();
            lblRol = new Label();
            chkOgretmen = new CheckBox();
            chkOgrenci = new CheckBox();
            SuspendLayout();
            // 
            // btnKayıtOl
            // 
            btnKayıtOl.BackColor = Color.FromArgb(255, 224, 192);
            btnKayıtOl.Location = new Point(300, 324);
            btnKayıtOl.Name = "btnKayıtOl";
            btnKayıtOl.Size = new Size(166, 45);
            btnKayıtOl.TabIndex = 13;
            btnKayıtOl.Text = "Kayıt Ol";
            btnKayıtOl.UseVisualStyleBackColor = false;
            btnKayıtOl.Click += btnKayıtOl_Click;
            // 
            // txtSifreTekrar
            // 
            txtSifreTekrar.Location = new Point(300, 272);
            txtSifreTekrar.Name = "txtSifreTekrar";
            txtSifreTekrar.Size = new Size(166, 36);
            txtSifreTekrar.TabIndex = 15;
            txtSifreTekrar.UseSystemPasswordChar = true;
            // 
            // lblSifreTekrar
            // 
            lblSifreTekrar.AutoSize = true;
            lblSifreTekrar.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblSifreTekrar.Location = new Point(181, 279);
            lblSifreTekrar.Name = "lblSifreTekrar";
            lblSifreTekrar.Size = new Size(113, 29);
            lblSifreTekrar.TabIndex = 14;
            lblSifreTekrar.Text = "Şifre Tekrar:";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(300, 219);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(166, 36);
            txtSifre.TabIndex = 21;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(300, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(166, 36);
            txtEmail.TabIndex = 20;
            // 
            // txtKullaniciAd
            // 
            txtKullaniciAd.Location = new Point(300, 106);
            txtKullaniciAd.Name = "txtKullaniciAd";
            txtKullaniciAd.Size = new Size(166, 36);
            txtKullaniciAd.TabIndex = 19;
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblSifre.Location = new Point(231, 222);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(57, 29);
            lblSifre.TabIndex = 18;
            lblSifre.Text = "Şifre:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblEmail.Location = new Point(215, 162);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(73, 29);
            lblEmail.TabIndex = 17;
            lblEmail.Text = "E-mail:";
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblKullaniciAdi.Location = new Point(171, 106);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(123, 29);
            lblKullaniciAdi.TabIndex = 16;
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblRol.Location = new Point(248, 45);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(46, 29);
            lblRol.TabIndex = 22;
            lblRol.Text = "Rol:";
            // 
            // chkOgretmen
            // 
            chkOgretmen.AutoSize = true;
            chkOgretmen.Location = new Point(318, 36);
            chkOgretmen.Name = "chkOgretmen";
            chkOgretmen.Size = new Size(132, 32);
            chkOgretmen.TabIndex = 23;
            chkOgretmen.Text = "Öğretmen";
            chkOgretmen.UseVisualStyleBackColor = true;
            // 
            // chkOgrenci
            // 
            chkOgrenci.AutoSize = true;
            chkOgrenci.Location = new Point(318, 74);
            chkOgrenci.Name = "chkOgrenci";
            chkOgrenci.Size = new Size(109, 32);
            chkOgrenci.TabIndex = 24;
            chkOgrenci.Text = "Öğrenci";
            chkOgrenci.UseVisualStyleBackColor = true;
            // 
            // FrmKayıtOl
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(705, 498);
            Controls.Add(chkOgrenci);
            Controls.Add(chkOgretmen);
            Controls.Add(lblRol);
            Controls.Add(txtSifre);
            Controls.Add(txtEmail);
            Controls.Add(txtKullaniciAd);
            Controls.Add(lblSifre);
            Controls.Add(lblEmail);
            Controls.Add(lblKullaniciAdi);
            Controls.Add(txtSifreTekrar);
            Controls.Add(lblSifreTekrar);
            Controls.Add(btnKayıtOl);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FrmKayıtOl";
            Text = "FrmKayıtOl";
            Load += FrmKayıtOl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKayıtOl;
        private TextBox txtSifreTekrar;
        private Label lblSifreTekrar;
        private TextBox txtSifre;
        private TextBox txtEmail;
        private TextBox txtKullaniciAd;
        private Label lblSifre;
        private Label lblEmail;
        private Label lblKullaniciAdi;
        private Label lblRol;
        private CheckBox chkOgretmen;
        private CheckBox chkOgrenci;
    }
}