namespace GirisKayit1_story
{
    partial class FormLLM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLLM));
            lblHikaye = new Label();
            pictureBox1 = new PictureBox();
            btnIslem = new Button();
            txtHikaye = new TextBox();
            lblBilinenKelimeler = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblHikaye
            // 
            lblHikaye.AutoSize = true;
            lblHikaye.Location = new Point(128, 101);
            lblHikaye.Name = "lblHikaye";
            lblHikaye.Size = new Size(82, 28);
            lblHikaye.TabIndex = 0;
            lblHikaye.Text = "Hikaye:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(447, 237);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(379, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // btnIslem
            // 
            btnIslem.BackColor = Color.FromArgb(255, 224, 192);
            btnIslem.Location = new Point(598, 494);
            btnIslem.Name = "btnIslem";
            btnIslem.Size = new Size(116, 62);
            btnIslem.TabIndex = 2;
            btnIslem.Text = "Yükle";
            btnIslem.UseVisualStyleBackColor = false;
            btnIslem.Click += btnIslem_Click;
            // 
            // txtHikaye
            // 
            txtHikaye.Location = new Point(233, 27);
            txtHikaye.Multiline = true;
            txtHikaye.Name = "txtHikaye";
            txtHikaye.Size = new Size(593, 204);
            txtHikaye.TabIndex = 3;
            txtHikaye.TextChanged += txtHikaye_TextChanged;
            // 
            // lblBilinenKelimeler
            // 
            lblBilinenKelimeler.AutoSize = true;
            lblBilinenKelimeler.Location = new Point(27, 263);
            lblBilinenKelimeler.Name = "lblBilinenKelimeler";
            lblBilinenKelimeler.Size = new Size(101, 28);
            lblBilinenKelimeler.TabIndex = 4;
            lblBilinenKelimeler.Text = "Kelimeler";
            // 
            // FormLLM
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(869, 568);
            Controls.Add(lblBilinenKelimeler);
            Controls.Add(txtHikaye);
            Controls.Add(btnIslem);
            Controls.Add(pictureBox1);
            Controls.Add(lblHikaye);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormLLM";
            Text = "FormLLM";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHikaye;
        private PictureBox pictureBox1;
        private Button btnIslem;
        private TextBox txtHikaye;
        private Label lblBilinenKelimeler;
    }
}