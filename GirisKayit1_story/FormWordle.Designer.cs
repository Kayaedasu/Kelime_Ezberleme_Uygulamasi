namespace GirisKayit1_story
{
    partial class FormWordle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordle));
            lblTitle = new Label();
            lblHarfX = new Label();
            lblDurum = new Label();
            txtTahmin = new TextBox();
            btnTahminEt = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Gloucester MT Extra Condensed", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(418, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(281, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Wordle Oyunu";
            // 
            // lblHarfX
            // 
            lblHarfX.AutoSize = true;
            lblHarfX.Location = new Point(465, 218);
            lblHarfX.Name = "lblHarfX";
            lblHarfX.Size = new Size(169, 28);
            lblHarfX.TabIndex = 1;
            lblHarfX.Text = "Tahminizi Yazınız";
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(432, 428);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(78, 28);
            lblDurum.TabIndex = 2;
            lblDurum.Text = "Durum";
            // 
            // txtTahmin
            // 
            txtTahmin.Location = new Point(418, 267);
            txtTahmin.Name = "txtTahmin";
            txtTahmin.Size = new Size(273, 36);
            txtTahmin.TabIndex = 3;
            // 
            // btnTahminEt
            // 
            btnTahminEt.BackColor = Color.FromArgb(255, 224, 192);
            btnTahminEt.Location = new Point(475, 334);
            btnTahminEt.Name = "btnTahminEt";
            btnTahminEt.Size = new Size(178, 44);
            btnTahminEt.TabIndex = 4;
            btnTahminEt.Text = "Tahmin Et";
            btnTahminEt.UseVisualStyleBackColor = false;
            btnTahminEt.Click += btnTahminEt_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-9, 446);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(299, 158);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // FormWordle
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(861, 592);
            Controls.Add(pictureBox1);
            Controls.Add(btnTahminEt);
            Controls.Add(txtTahmin);
            Controls.Add(lblDurum);
            Controls.Add(lblHarfX);
            Controls.Add(lblTitle);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormWordle";
            Text = "FormWordle";
            Load += FormWordle_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHarfX;
        private Label lblDurum;
        private TextBox txtTahmin;
        private Button btnTahminEt;
        private PictureBox pictureBox1;
    }
}