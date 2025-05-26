namespace GirisKayit1_story
{
    partial class FormAnaliz
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
            btnYenile = new Button();
            btnPfKaydet = new Button();
            dgvAnaliz = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAnaliz).BeginInit();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Corbel", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(69, 49);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(401, 45);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "\t📊 Başarı Analiz Raporu";
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.FromArgb(255, 224, 192);
            btnYenile.Location = new Point(191, 525);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(155, 45);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "\t🔄 Yenile";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnPfKaydet
            // 
            btnPfKaydet.BackColor = Color.FromArgb(255, 224, 192);
            btnPfKaydet.Location = new Point(140, 474);
            btnPfKaydet.Name = "btnPfKaydet";
            btnPfKaydet.Size = new Size(258, 45);
            btnPfKaydet.TabIndex = 2;
            btnPfKaydet.Text = "🖨️ Yazdır / PDF Kaydet";
            btnPfKaydet.UseVisualStyleBackColor = false;
            btnPfKaydet.Click += btnPfKaydet_Click;
            // 
            // dgvAnaliz
            // 
            dgvAnaliz.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAnaliz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnaliz.Location = new Point(69, 131);
            dgvAnaliz.Name = "dgvAnaliz";
            dgvAnaliz.RowHeadersWidth = 51;
            dgvAnaliz.Size = new Size(401, 316);
            dgvAnaliz.TabIndex = 3;
            // 
            // FormAnaliz
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(553, 624);
            Controls.Add(dgvAnaliz);
            Controls.Add(btnPfKaydet);
            Controls.Add(btnYenile);
            Controls.Add(lblBaslik);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormAnaliz";
            Text = "FormAnaliz";
            Load += FormAnaliz_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnaliz).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaslik;
        private Button btnYenile;
        private Button btnPfKaydet;
        private DataGridView dgvAnaliz;
    }
}