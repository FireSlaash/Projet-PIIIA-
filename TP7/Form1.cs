namespace TP7
{
    public partial class Form1 : Form
    {
        private ZoneDessin zoneDessin;

        private Size tailleNormale = new Size(38, 31);
        private Size tailleSelectionnee = new Size(55, 31);
        private Modele modele;

        public Form1()
        {
            InitializeComponent();
            Modele modele = new Modele();
            this.modele = modele;
            ZoneDessin zoneDessin = new ZoneDessin(modele);
            zoneDessin.SelectionChangee += (s, e) =>
            {
                panelCouleurs.Visible = false;
                panelSelect.Visible = (zoneDessin.formeSelected != null);
                if (zoneDessin.formeSelected != null)
                {
                    btnColor.BackColor = zoneDessin.formeSelected.Couleur;
                }

                ActualiserStyleBoutons();
            };

            zoneDessin.ZoomChangee += (s, e) => {
                labelZoom.Text = $"Zoom : {Math.Round(zoneDessin.niveauZoom * 100)}%";
            };
            this.zoneDessin = zoneDessin;
            this.Controls.Add(zoneDessin);
            modele.AjouterForme(new Rectangle(new Point(50, 50)) { Largeur = 100, Hauteur = 50 });
            modele.AjouterForme(new Disque(new Point(200, 200)) { Rayon = 40 });


        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.Selectionner;
            ActualiserStyleBoutons();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerRectangle;
            ActualiserStyleBoutons();
        }

        private void btnOvale_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerOvale;
            ActualiserStyleBoutons();
        }

        private void btnTrait_Click(object sender, EventArgs e)
        {
            zoneDessin.ModeActuel = ModeAction.CreerTrait;
            ActualiserStyleBoutons();
        }

        private void changerCouleur_Click(object sender, EventArgs e)
        {
            if (zoneDessin.formeSelected != null)
            {
                Button btn = (Button)sender;
                Color color = btn.BackColor;
                btnColor.BackColor = color;
                zoneDessin.formeSelected.Couleur = color;
                zoneDessin.Invalidate();
            }
        }

        private void ActualiserStyleBoutons()
        {
            // Liste des boutons pour automatiser le nettoyage
            Button[] tousLesBoutons = { btnSelect, btnRectangle, btnTrait, btnOvale };

            foreach (var btn in tousLesBoutons)
            {
                btn.Size = tailleNormale;
            }

            // Agrandir le bouton actif
            Button boutonActif = null;
            switch (zoneDessin.ModeActuel)
            {
                case ModeAction.Selectionner: boutonActif = btnSelect; break;
                case ModeAction.CreerRectangle: boutonActif = btnRectangle; panelCouleurs.Visible = false; break;
                case ModeAction.CreerOvale: boutonActif = btnOvale; panelCouleurs.Visible = false; break;
                case ModeAction.CreerTrait: boutonActif = btnTrait; panelCouleurs.Visible = false; break;
            }
            if (zoneDessin.ModeActuel != ModeAction.Selectionner) zoneDessin.formeSelected = null; zoneDessin.Invalidate();
            if (boutonActif != null)
            {
                boutonActif.Size = tailleSelectionnee;

            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (zoneDessin.formeSelected is Trait) { return; } // Les traits n'ont pas de couleur à changer }

            panelCouleurs.Visible = !panelCouleurs.Visible;

        }

        private void btnPinceau_Click(object sender, EventArgs e)
        {
            panelPinceau.Visible = !panelPinceau.Visible;
        }


        private void btnChangerCouleur_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Color color = btn.BackColor;
            btnPinceau.BackColor = color;
            zoneDessin.myPen.Color = color;
            if (zoneDessin.formeSelected != null)
            {
                zoneDessin.formeSelected.CouleurPinceau = color;
            }
            panelPinceau.Visible = false;

        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {

            modele.SupprimerForme(zoneDessin.formeSelected);

            zoneDessin.formeSelected = null;

            panelCouleurs.Visible = false;
            panelSelect.Visible = false;

            zoneDessin.Invalidate();
        }

        private void btnDupli_Click(object sender, EventArgs e)
        {

            FormeGeo copie = zoneDessin.formeSelected.Cloner();

            modele.AjouterForme(copie);

            zoneDessin.formeSelected = copie;

            zoneDessin.Invalidate();
        }
    }
}
