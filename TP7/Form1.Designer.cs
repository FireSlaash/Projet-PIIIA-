namespace TP7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(0, 117);
            button1.Name = "button1";
            button1.Size = new Size(117, 23);
            button1.TabIndex = 0;
            button1.Text = "Sélectionner";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(0, 172);
            button2.Name = "button2";
            button2.Size = new Size(117, 23);
            button2.TabIndex = 1;
            button2.Text = "Créer Rectangle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(0, 201);
            button4.Name = "button4";
            button4.Size = new Size(117, 23);
            button4.TabIndex = 3;
            button4.Text = "Créer Ovale";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(0, 146);
            button3.Name = "button3";
            button3.Size = new Size(117, 22);
            button3.TabIndex = 4;
            button3.Text = "Créer Trait";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button13);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Location = new Point(212, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 29);
            panel1.TabIndex = 5;
            // 
            // button13
            // 
            button13.BackColor = Color.FromArgb(255, 128, 0);
            button13.FlatStyle = FlatStyle.Flat;
            button13.Location = new Point(235, 3);
            button13.Name = "button13";
            button13.Size = new Size(23, 23);
            button13.TabIndex = 7;
            button13.UseVisualStyleBackColor = false;
            button13.Click += changerCouleur_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.Blue;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Location = new Point(206, 3);
            button12.Name = "button12";
            button12.Size = new Size(23, 23);
            button12.TabIndex = 9;
            button12.UseVisualStyleBackColor = false;
            button12.Click += changerCouleur_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(255, 192, 192);
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(177, 3);
            button11.Name = "button11";
            button11.Size = new Size(23, 23);
            button11.TabIndex = 8;
            button11.UseVisualStyleBackColor = false;
            button11.Click += changerCouleur_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Yellow;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(148, 3);
            button10.Name = "button10";
            button10.Size = new Size(23, 23);
            button10.TabIndex = 7;
            button10.UseVisualStyleBackColor = false;
            button10.Click += changerCouleur_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Cyan;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Location = new Point(119, 3);
            button9.Name = "button9";
            button9.Size = new Size(23, 23);
            button9.TabIndex = 7;
            button9.UseVisualStyleBackColor = false;
            button9.Click += changerCouleur_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(90, 3);
            button8.Name = "button8";
            button8.Size = new Size(23, 23);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = false;
            button8.Click += changerCouleur_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Green;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(61, 3);
            button7.Name = "button7";
            button7.Size = new Size(23, 23);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = false;
            button7.Click += changerCouleur_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(32, 3);
            button6.Name = "button6";
            button6.Size = new Size(23, 23);
            button6.TabIndex = 7;
            button6.UseVisualStyleBackColor = false;
            button6.Click += changerCouleur_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(23, 23);
            button5.TabIndex = 6;
            button5.UseVisualStyleBackColor = false;
            button5.Click += changerCouleur_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Click += changerCouleur_Click;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button4;
        private Button button3;
        private Panel panel1;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
    }
}
