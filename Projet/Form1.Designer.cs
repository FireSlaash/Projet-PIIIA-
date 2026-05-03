namespace Projet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelect = new Button();
            btnRectangle = new Button();
            btnOvale = new Button();
            btnTrait = new Button();
            panelCouleurs = new Panel();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            panelSelect = new Panel();
            btnSuppr = new Button();
            btnDupli = new Button();
            btnColor = new Button();
            btnPinceau = new Button();
            panelPinceau = new Panel();
            button4 = new Button();
            button14 = new Button();
            button16 = new Button();
            button18 = new Button();
            button20 = new Button();
            labelZoom = new Label();
            openFile = new OpenFileDialog();
            saveFile = new SaveFileDialog();
            buttonSave = new Button();
            btnCharger = new Button();
            panelCouleurs.SuspendLayout();
            panelSelect.SuspendLayout();
            panelPinceau.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelect
            // 
            btnSelect.BackColor = SystemColors.Control;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Image = Properties.Resources.pointeur1;
            btnSelect.Location = new Point(0, 155);
            btnSelect.Margin = new Padding(3, 4, 3, 4);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(55, 31);
            btnSelect.TabIndex = 0;
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.BackgroundImage = Properties.Resources.pngegg__3_;
            btnRectangle.BackgroundImageLayout = ImageLayout.Stretch;
            btnRectangle.FlatStyle = FlatStyle.Flat;
            btnRectangle.Location = new Point(0, 228);
            btnRectangle.Margin = new Padding(3, 4, 3, 4);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(38, 31);
            btnRectangle.TabIndex = 1;
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnOvale
            // 
            btnOvale.BackgroundImage = Properties.Resources.circle;
            btnOvale.BackgroundImageLayout = ImageLayout.Stretch;
            btnOvale.FlatStyle = FlatStyle.Flat;
            btnOvale.Location = new Point(0, 265);
            btnOvale.Margin = new Padding(3, 4, 3, 4);
            btnOvale.Name = "btnOvale";
            btnOvale.Size = new Size(38, 31);
            btnOvale.TabIndex = 3;
            btnOvale.UseVisualStyleBackColor = true;
            btnOvale.Click += btnOvale_Click;
            // 
            // btnTrait
            // 
            btnTrait.BackgroundImage = (Image)resources.GetObject("btnTrait.BackgroundImage");
            btnTrait.BackgroundImageLayout = ImageLayout.Stretch;
            btnTrait.FlatStyle = FlatStyle.Flat;
            btnTrait.Location = new Point(0, 191);
            btnTrait.Margin = new Padding(3, 4, 3, 4);
            btnTrait.Name = "btnTrait";
            btnTrait.Size = new Size(38, 31);
            btnTrait.TabIndex = 4;
            btnTrait.UseVisualStyleBackColor = true;
            btnTrait.Click += btnTrait_Click;
            // 
            // panelCouleurs
            // 
            panelCouleurs.BorderStyle = BorderStyle.FixedSingle;
            panelCouleurs.Controls.Add(button13);
            panelCouleurs.Controls.Add(button12);
            panelCouleurs.Controls.Add(button11);
            panelCouleurs.Controls.Add(button10);
            panelCouleurs.Controls.Add(button9);
            panelCouleurs.Controls.Add(button8);
            panelCouleurs.Controls.Add(button7);
            panelCouleurs.Controls.Add(button6);
            panelCouleurs.Controls.Add(button5);
            panelCouleurs.Location = new Point(242, 49);
            panelCouleurs.Margin = new Padding(3, 4, 3, 4);
            panelCouleurs.Name = "panelCouleurs";
            panelCouleurs.Size = new Size(303, 38);
            panelCouleurs.TabIndex = 5;
            panelCouleurs.Visible = false;
            // 
            // button13
            // 
            button13.BackColor = Color.FromArgb(255, 128, 0);
            button13.FlatStyle = FlatStyle.Flat;
            button13.Location = new Point(269, 4);
            button13.Margin = new Padding(3, 4, 3, 4);
            button13.Name = "button13";
            button13.Size = new Size(26, 31);
            button13.TabIndex = 7;
            button13.UseVisualStyleBackColor = false;
            button13.Click += changerCouleur_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.Blue;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Location = new Point(235, 4);
            button12.Margin = new Padding(3, 4, 3, 4);
            button12.Name = "button12";
            button12.Size = new Size(26, 31);
            button12.TabIndex = 9;
            button12.UseVisualStyleBackColor = false;
            button12.Click += changerCouleur_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(255, 192, 192);
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(202, 4);
            button11.Margin = new Padding(3, 4, 3, 4);
            button11.Name = "button11";
            button11.Size = new Size(26, 31);
            button11.TabIndex = 8;
            button11.UseVisualStyleBackColor = false;
            button11.Click += changerCouleur_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Yellow;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(169, 4);
            button10.Margin = new Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new Size(26, 31);
            button10.TabIndex = 7;
            button10.UseVisualStyleBackColor = false;
            button10.Click += changerCouleur_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Cyan;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Location = new Point(136, 4);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(26, 31);
            button9.TabIndex = 7;
            button9.UseVisualStyleBackColor = false;
            button9.Click += changerCouleur_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(103, 4);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(26, 31);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = false;
            button8.Click += changerCouleur_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Green;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(70, 4);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(26, 31);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = false;
            button7.Click += changerCouleur_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(37, 4);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(26, 31);
            button6.TabIndex = 7;
            button6.UseVisualStyleBackColor = false;
            button6.Click += changerCouleur_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(3, 4);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(26, 31);
            button5.TabIndex = 6;
            button5.UseVisualStyleBackColor = false;
            button5.Click += changerCouleur_Click;
            // 
            // panelSelect
            // 
            panelSelect.BorderStyle = BorderStyle.FixedSingle;
            panelSelect.Controls.Add(btnSuppr);
            panelSelect.Controls.Add(btnDupli);
            panelSelect.Controls.Add(btnColor);
            panelSelect.Location = new Point(242, 1);
            panelSelect.Name = "panelSelect";
            panelSelect.Size = new Size(303, 45);
            panelSelect.TabIndex = 6;
            panelSelect.Visible = false;
            // 
            // btnSuppr
            // 
            btnSuppr.BackColor = Color.White;
            btnSuppr.BackgroundImage = Properties.Resources.poubelle;
            btnSuppr.BackgroundImageLayout = ImageLayout.Zoom;
            btnSuppr.FlatStyle = FlatStyle.Flat;
            btnSuppr.Location = new Point(180, 5);
            btnSuppr.Margin = new Padding(3, 4, 3, 4);
            btnSuppr.Name = "btnSuppr";
            btnSuppr.Size = new Size(31, 31);
            btnSuppr.TabIndex = 9;
            btnSuppr.UseVisualStyleBackColor = false;
            btnSuppr.Click += btnSuppr_Click;
            // 
            // btnDupli
            // 
            btnDupli.BackColor = Color.White;
            btnDupli.BackgroundImage = Properties.Resources.dupliquer;
            btnDupli.BackgroundImageLayout = ImageLayout.Stretch;
            btnDupli.FlatStyle = FlatStyle.Flat;
            btnDupli.Location = new Point(131, 5);
            btnDupli.Margin = new Padding(3, 4, 3, 4);
            btnDupli.Name = "btnDupli";
            btnDupli.Size = new Size(31, 31);
            btnDupli.TabIndex = 8;
            btnDupli.UseVisualStyleBackColor = false;
            btnDupli.Click += btnDupli_Click;
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.White;
            btnColor.FlatStyle = FlatStyle.Flat;
            btnColor.Location = new Point(82, 5);
            btnColor.Margin = new Padding(3, 4, 3, 4);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(31, 31);
            btnColor.TabIndex = 7;
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // btnPinceau
            // 
            btnPinceau.BackColor = Color.Black;
            btnPinceau.BackgroundImage = (Image)resources.GetObject("btnPinceau.BackgroundImage");
            btnPinceau.BackgroundImageLayout = ImageLayout.Zoom;
            btnPinceau.FlatStyle = FlatStyle.Flat;
            btnPinceau.Location = new Point(0, 116);
            btnPinceau.Margin = new Padding(3, 4, 3, 4);
            btnPinceau.Name = "btnPinceau";
            btnPinceau.Size = new Size(38, 31);
            btnPinceau.TabIndex = 7;
            btnPinceau.UseVisualStyleBackColor = false;
            btnPinceau.Click += btnPinceau_Click;
            // 
            // panelPinceau
            // 
            panelPinceau.BorderStyle = BorderStyle.FixedSingle;
            panelPinceau.Controls.Add(button4);
            panelPinceau.Controls.Add(button14);
            panelPinceau.Controls.Add(button16);
            panelPinceau.Controls.Add(button18);
            panelPinceau.Controls.Add(button20);
            panelPinceau.Location = new Point(44, 116);
            panelPinceau.Margin = new Padding(3, 4, 3, 4);
            panelPinceau.Name = "panelPinceau";
            panelPinceau.Size = new Size(168, 31);
            panelPinceau.TabIndex = 8;
            panelPinceau.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Green;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(133, -1);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(26, 31);
            button4.TabIndex = 10;
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnChangerCouleur_Click;
            // 
            // button14
            // 
            button14.BackColor = Color.Blue;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Location = new Point(101, -1);
            button14.Margin = new Padding(3, 4, 3, 4);
            button14.Name = "button14";
            button14.Size = new Size(26, 31);
            button14.TabIndex = 9;
            button14.UseVisualStyleBackColor = false;
            button14.Click += btnChangerCouleur_Click;
            // 
            // button16
            // 
            button16.BackColor = Color.Yellow;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Location = new Point(70, -1);
            button16.Margin = new Padding(3, 4, 3, 4);
            button16.Name = "button16";
            button16.Size = new Size(26, 31);
            button16.TabIndex = 7;
            button16.UseVisualStyleBackColor = false;
            button16.Click += btnChangerCouleur_Click;
            // 
            // button18
            // 
            button18.BackColor = Color.Red;
            button18.FlatStyle = FlatStyle.Flat;
            button18.Location = new Point(38, 0);
            button18.Margin = new Padding(3, 4, 3, 4);
            button18.Name = "button18";
            button18.Size = new Size(26, 31);
            button18.TabIndex = 7;
            button18.UseVisualStyleBackColor = false;
            button18.Click += btnChangerCouleur_Click;
            // 
            // button20
            // 
            button20.BackColor = Color.Black;
            button20.FlatStyle = FlatStyle.Flat;
            button20.Location = new Point(6, -1);
            button20.Margin = new Padding(3, 4, 3, 4);
            button20.Name = "button20";
            button20.Size = new Size(26, 31);
            button20.TabIndex = 7;
            button20.UseVisualStyleBackColor = false;
            button20.Click += btnChangerCouleur_Click;
            // 
            // labelZoom
            // 
            labelZoom.AutoSize = true;
            labelZoom.Location = new Point(806, 571);
            labelZoom.Name = "labelZoom";
            labelZoom.Size = new Size(96, 20);
            labelZoom.TabIndex = 9;
            labelZoom.Text = "Zoom : 100%";
            // 
            // openFile
            // 
            openFile.Title = "Ouvrir un fichier sauvegardé";
            // 
            // saveFile
            // 
            saveFile.DefaultExt = "json";
            saveFile.Filter = "Fichier Dessin (*.json)|*.json|Tous les fichiers (*.*)|*.*";
            saveFile.Title = "Sauvegarder Votre Dessin";
            // 
            // buttonSave
            // 
            buttonSave.BackgroundImage = (Image)resources.GetObject("buttonSave.BackgroundImage");
            buttonSave.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(54, 559);
            buttonSave.Margin = new Padding(3, 4, 3, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(55, 45);
            buttonSave.TabIndex = 10;
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // btnCharger
            // 
            btnCharger.BackgroundImage = (Image)resources.GetObject("btnCharger.BackgroundImage");
            btnCharger.BackgroundImageLayout = ImageLayout.Stretch;
            btnCharger.FlatStyle = FlatStyle.Flat;
            btnCharger.Location = new Point(0, 559);
            btnCharger.Margin = new Padding(3, 4, 3, 4);
            btnCharger.Name = "btnCharger";
            btnCharger.Size = new Size(55, 45);
            btnCharger.TabIndex = 11;
            btnCharger.UseVisualStyleBackColor = true;
            btnCharger.Click += btnCharger_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnCharger);
            Controls.Add(buttonSave);
            Controls.Add(labelZoom);
            Controls.Add(panelPinceau);
            Controls.Add(btnPinceau);
            Controls.Add(panelSelect);
            Controls.Add(panelCouleurs);
            Controls.Add(btnTrait);
            Controls.Add(btnOvale);
            Controls.Add(btnRectangle);
            Controls.Add(btnSelect);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Click += changerCouleur_Click;
            panelCouleurs.ResumeLayout(false);
            panelSelect.ResumeLayout(false);
            panelPinceau.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelect;
        private Button btnRectangle;
        private Button btnOvale;
        private Button btnTrait;
        private Panel panelCouleurs;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Panel panelSelect;
        private Button btnColor;
        private Button btnSuppr;
        private Button btnDupli;
        private Button btnPinceau;
        private Panel panelPinceau;
        private Button button4;
        private Button button14;
        private Button button16;
        private Button button18;
        private Button button20;
        private Label labelZoom;
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        private Button buttonSave;
        private Button btnCharger;
    }
}
