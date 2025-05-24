namespace GirisKayit1_story
{
    partial class FormOgrenciSec
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
            btnAnaliz = new Button();
            dgvOgrenciler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOgrenciler).BeginInit();
            SuspendLayout();
            // 
            // btnAnaliz
            // 
            btnAnaliz.BackColor = Color.FromArgb(255, 224, 192);
            btnAnaliz.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnAnaliz.Location = new Point(182, 346);
            btnAnaliz.Name = "btnAnaliz";
            btnAnaliz.Size = new Size(213, 44);
            btnAnaliz.TabIndex = 0;
            btnAnaliz.Text = "Analiz";
            btnAnaliz.UseVisualStyleBackColor = false;
            btnAnaliz.Click += btnAnaliz_Click;
            // 
            // dgvOgrenciler
            // 
            dgvOgrenciler.BackgroundColor = SystemColors.ButtonHighlight;
            dgvOgrenciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOgrenciler.Location = new Point(94, 49);
            dgvOgrenciler.Name = "dgvOgrenciler";
            dgvOgrenciler.RowHeadersWidth = 51;
            dgvOgrenciler.Size = new Size(379, 262);
            dgvOgrenciler.TabIndex = 1;
            // 
            // FormOgrenciSec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(589, 450);
            Controls.Add(dgvOgrenciler);
            Controls.Add(btnAnaliz);
            Name = "FormOgrenciSec";
            Text = "FormOgrenciSec";
            Load += FormOgrenciSec_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOgrenciler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAnaliz;
        private DataGridView dgvOgrenciler;
    }
}