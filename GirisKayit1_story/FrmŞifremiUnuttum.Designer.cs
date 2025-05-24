namespace GirisKayit1_story
{
    partial class FrmŞifremiUnuttum
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
            txtYeniSifreTekrar = new TextBox();
            lblYeniSifreTekrar = new Label();
            btnSifreGüncel = new Button();
            txtYeniSifre = new TextBox();
            txtEmail = new TextBox();
            lblYeniSifre = new Label();
            lblEmail = new Label();
            SuspendLayout();
            // 
            // txtYeniSifreTekrar
            // 
            txtYeniSifreTekrar.Location = new Point(294, 246);
            txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            txtYeniSifreTekrar.Size = new Size(166, 36);
            txtYeniSifreTekrar.TabIndex = 22;
            txtYeniSifreTekrar.UseSystemPasswordChar = true;
            // 
            // lblYeniSifreTekrar
            // 
            lblYeniSifreTekrar.AutoSize = true;
            lblYeniSifreTekrar.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblYeniSifreTekrar.Location = new Point(136, 253);
            lblYeniSifreTekrar.Name = "lblYeniSifreTekrar";
            lblYeniSifreTekrar.Size = new Size(152, 29);
            lblYeniSifreTekrar.TabIndex = 21;
            lblYeniSifreTekrar.Text = "Yeni Şifre Tekrar:";
            // 
            // btnSifreGüncel
            // 
            btnSifreGüncel.BackColor = Color.FromArgb(255, 224, 192);
            btnSifreGüncel.Location = new Point(294, 302);
            btnSifreGüncel.Name = "btnSifreGüncel";
            btnSifreGüncel.Size = new Size(166, 45);
            btnSifreGüncel.TabIndex = 20;
            btnSifreGüncel.Text = "Şifre Güncelle";
            btnSifreGüncel.UseVisualStyleBackColor = false;
            btnSifreGüncel.Click += btnSifreGüncel_Click;
            // 
            // txtYeniSifre
            // 
            txtYeniSifre.Location = new Point(294, 191);
            txtYeniSifre.Name = "txtYeniSifre";
            txtYeniSifre.Size = new Size(166, 36);
            txtYeniSifre.TabIndex = 19;
            txtYeniSifre.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(294, 134);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(166, 36);
            txtEmail.TabIndex = 18;
            // 
            // lblYeniSifre
            // 
            lblYeniSifre.AutoSize = true;
            lblYeniSifre.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblYeniSifre.Location = new Point(186, 198);
            lblYeniSifre.Name = "lblYeniSifre";
            lblYeniSifre.Size = new Size(96, 29);
            lblYeniSifre.TabIndex = 17;
            lblYeniSifre.Text = "Yeni Şifre:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Franklin Gothic Medium Cond", 13.8F);
            lblEmail.Location = new Point(209, 134);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(73, 29);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "E-mail:";
            // 
            // FrmŞifremiUnuttum
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(682, 516);
            Controls.Add(txtYeniSifreTekrar);
            Controls.Add(lblYeniSifreTekrar);
            Controls.Add(btnSifreGüncel);
            Controls.Add(txtYeniSifre);
            Controls.Add(txtEmail);
            Controls.Add(lblYeniSifre);
            Controls.Add(lblEmail);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FrmŞifremiUnuttum";
            Text = "FrmŞifremiUnuttum";
            Load += FrmŞifremiUnuttum_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtYeniSifreTekrar;
        private Label lblYeniSifreTekrar;
        private Button btnSifreGüncel;
        private TextBox txtYeniSifre;
        private TextBox txtEmail;
        private Label lblYeniSifre;
        private Label lblEmail;
    }
}