namespace GirisKayit1_story
{
    partial class FormAyarlar
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
            lblBaslik = new Label();
            lblSoru = new Label();
            btnKaydet = new Button();
            nudKelimeSayisi = new NumericUpDown();
            lblMevcut = new Label();
            ((System.ComponentModel.ISupportInitialize)nudKelimeSayisi).BeginInit();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Corbel", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(159, 68);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(174, 41);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "🛠 Ayarlar";
            // 
            // lblSoru
            // 
            lblSoru.AutoSize = true;
            lblSoru.Location = new Point(114, 177);
            lblSoru.Name = "lblSoru";
            lblSoru.Size = new Size(285, 28);
            lblSoru.TabIndex = 1;
            lblSoru.Text = "Günde Çıkacak Kelime Sayısı:";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.FromArgb(255, 224, 192);
            btnKaydet.Location = new Point(143, 296);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(243, 63);
            btnKaydet.TabIndex = 2;
            btnKaydet.Text = "\t💾 Ayarı Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // nudKelimeSayisi
            // 
            nudKelimeSayisi.Location = new Point(114, 231);
            nudKelimeSayisi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudKelimeSayisi.Name = "nudKelimeSayisi";
            nudKelimeSayisi.Size = new Size(285, 36);
            nudKelimeSayisi.TabIndex = 3;
            nudKelimeSayisi.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblMevcut
            // 
            lblMevcut.AutoSize = true;
            lblMevcut.Location = new Point(184, 421);
            lblMevcut.Name = "lblMevcut";
            lblMevcut.Size = new Size(173, 28);
            lblMevcut.TabIndex = 4;
            lblMevcut.Text = "Mevcut Değer:10";
            // 
            // FormAyarlar
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(531, 579);
            Controls.Add(lblMevcut);
            Controls.Add(nudKelimeSayisi);
            Controls.Add(btnKaydet);
            Controls.Add(lblSoru);
            Controls.Add(lblBaslik);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormAyarlar";
            Text = "FormAyarlar";
            Load += FormAyarlar_Load;
            ((System.ComponentModel.ISupportInitialize)nudKelimeSayisi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaslik;
        private Label lblSoru;
        private Button btnKaydet;
        private NumericUpDown nudKelimeSayisi;
        private Label lblMevcut;
    }
}