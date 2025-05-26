namespace GirisKayit1_story
{
    partial class FormÖğrenciPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormÖğrenciPanel));
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            button4 = new Button();
            label4 = new Label();
            button5 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 128);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(57, 26);
            button1.Name = "button1";
            button1.Size = new Size(172, 182);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 128);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(296, 36);
            button2.Name = "button2";
            button2.Size = new Size(163, 182);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 227);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 2;
            label1.Text = "Wordle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 241);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 3;
            label2.Text = "Quiz Ayarları";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 128);
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(536, 36);
            button3.Name = "button3";
            button3.Size = new Size(163, 182);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(594, 241);
            label3.Name = "label3";
            label3.Size = new Size(56, 28);
            label3.TabIndex = 5;
            label3.Text = "Quiz";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 192, 128);
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Location = new Point(191, 309);
            button4.Name = "button4";
            button4.Size = new Size(156, 152);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(242, 482);
            label4.Name = "label4";
            label4.Size = new Size(55, 28);
            label4.TabIndex = 7;
            label4.Text = "LLM";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 192, 128);
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(436, 309);
            button5.Name = "button5";
            button5.Size = new Size(159, 152);
            button5.TabIndex = 8;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(485, 482);
            label5.Name = "label5";
            label5.Size = new Size(70, 28);
            label5.TabIndex = 9;
            label5.Text = "Analiz";
            // 
            // FormÖğrenciPanel
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(779, 550);
            Controls.Add(label5);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormÖğrenciPanel";
            Text = "FormÖğrenciPanel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Button button3;
        private Label label3;
        private Button button4;
        private Label label4;
        private Button button5;
        private Label label5;
    }
}