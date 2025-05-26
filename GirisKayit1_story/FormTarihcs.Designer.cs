namespace GirisKayit1_story
{
    partial class FormTarihcs
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
            Label = new Label();
            BtnTarih = new Button();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(110, 258);
            Label.Name = "Label";
            Label.Size = new Size(265, 28);
            Label.TabIndex = 0;
            Label.Text = "Tarih kontrol butonuna bas";
            Label.Click += label1_Click;
            // 
            // BtnTarih
            // 
            BtnTarih.BackColor = Color.FromArgb(255, 224, 192);
            BtnTarih.Location = new Point(149, 117);
            BtnTarih.Name = "BtnTarih";
            BtnTarih.Size = new Size(191, 104);
            BtnTarih.TabIndex = 1;
            BtnTarih.Text = "Tarih";
            BtnTarih.UseVisualStyleBackColor = false;
            BtnTarih.Click += BtnTarih_Click;
            // 
            // FormTarihcs
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(493, 377);
            Controls.Add(BtnTarih);
            Controls.Add(Label);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormTarihcs";
            Text = "FormTarihcs";
            Load += FormTarihcs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label;
        private Button BtnTarih;
    }
}