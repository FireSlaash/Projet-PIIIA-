namespace TP7
{
    public partial class Form1 : Form
    {
        private ZoneDessin zoneDessin;
        public Form1()
        {
            InitializeComponent();
            Modele modele = new Modele();
            ZoneDessin zoneDessin = new ZoneDessin(modele);
            this.zoneDessin = zoneDessin;
            this.Controls.Add(zoneDessin);
            modele.AjouterForme(new Rectangle(new Point(50, 50)) { Largeur = 100, Hauteur = 50 });
            modele.AjouterForme(new Disque(new Point(200, 200)) { Rayon = 40 });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.Selectionner;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerRectangle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerOvale;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerTrait;
        }

        private void changerCouleur_Click(object sender, EventArgs e)
        {
            if (zoneDessin.formeSelected != null)
            {
                Button btn = (Button)sender;
                Color color = btn.BackColor;
                zoneDessin.formeSelected.Couleur = color;
                zoneDessin.Invalidate();
            }
        }
    }
}
