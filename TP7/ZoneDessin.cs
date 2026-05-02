using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7
{
    internal class ZoneDessin : Control
    {
        private FormeGeo formeDeplacee;
        public FormeGeo formeSelected;
        private Modele modele;
        private Point lastMousePosition;
        public event EventHandler SelectionChangee;
        public event EventHandler ZoomChangee;

        public ModeAction ModeActuel { get; set; }
        private FormeGeo FormeCreation;
        public Pen myPen = new Pen(Color.Black);

        /* Variables pour la gestion du redimensionnement */
        private bool estEnTrainDeRedimensionner = false;
        private enum CoinRedim{ Aucune, HautGauche, HautDroite, BasGauche, BasDroite, SommetDisque, DebutTrait, FinTrait }
        private CoinRedim CoinActif = CoinRedim.Aucune;

        /* Variable pour le zoom */
        public float niveauZoom = 1.0f; // 1.0 = 100%, 2.0 = 200%, etc.

        public ZoneDessin(Modele modele)
        {
            
            this.Location = new Point(0, 0);
            this.Size = new Size(1000, 1000);
            this.modele = modele;
            this.DoubleBuffered = true; // pour éviter les scintillements lors du dessin
            this.MouseWheel += ZoneDessin_MouseWheel;
            ModeActuel = ModeAction.Selectionner;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            // On crée un point "virtuel" ajusté selon le zoom
            Point pointAjuste = new Point((int)(e.X / niveauZoom), (int)(e.Y / niveauZoom));

            /* Si on est en mode sélection, on vérifie d'abord si on clique sur un coin de la forme sélectionnée pour redimensionner */
            /* Cas rectangle */
            if (formeSelected is Rectangle r)
            {
                // On définit la zone des petits ronds rouges (ex: 10x10 pixels)
                if (new System.Drawing.Rectangle(r.Position.X - 5, r.Position.Y - 5, 10, 10).Contains(pointAjuste))
                    CoinActif = CoinRedim.HautGauche;
                else if (new System.Drawing.Rectangle(r.Position.X + r.Largeur - 5, r.Position.Y - 5, 10, 10).Contains(pointAjuste))
                    CoinActif = CoinRedim.HautDroite;
                else if (new System.Drawing.Rectangle(r.Position.X - 5, r.Position.Y + r.Hauteur - 5, 10, 10).Contains(pointAjuste))
                    CoinActif = CoinRedim.BasGauche;
                else if (new System.Drawing.Rectangle(r.Position.X + r.Largeur - 5, r.Position.Y + r.Hauteur - 5, 10, 10).Contains(pointAjuste))
                    CoinActif = CoinRedim.BasDroite;
                else
                    CoinActif = CoinRedim.Aucune;


                if (CoinActif != CoinRedim.Aucune)
                {
                    estEnTrainDeRedimensionner = true;
                    lastMousePosition = pointAjuste;
                    return; // On arrête pour ne pas déclencher le déplacement
                }
            }

            /* Cas dique */
            if (formeSelected is Disque d)
            {
                Point poigneeSommet = new Point(d.Position.X, d.Position.Y - d.Rayon);
                // Verifier si le clic est proche de la poignée de redimensionnement
                if (Math.Abs(e.X - poigneeSommet.X) <= 5 && Math.Abs(e.Y - poigneeSommet.Y) <= 5)
                {
                    CoinActif = CoinRedim.SommetDisque;
                    estEnTrainDeRedimensionner = true;
                    lastMousePosition = pointAjuste;
                    
                    return;
                }
            }

            if (formeSelected is Trait t)
            {
                // Test du point de départ
                if (Math.Abs(e.X - t.Position.X) <= 5 && Math.Abs(e.Y - t.Position.Y) <= 5)
                {
                    CoinActif = CoinRedim.DebutTrait;
                    estEnTrainDeRedimensionner = true;
                    lastMousePosition = pointAjuste;
                    return;
                }
                // Test du point d'arrivée
                else if (Math.Abs(e.X - t.Fin.X) <= 5 && Math.Abs(e.Y - t.Fin.Y) <= 5)
                {
                    CoinActif = CoinRedim.FinTrait;
                    estEnTrainDeRedimensionner=true;
                    lastMousePosition = pointAjuste;
                    return;
                }
            }

            /* Si on veut pas redimensionner, on continue avec le comportement normal de sélection/déplacement/création */
            switch (ModeActuel)
            {

                case ModeAction.Selectionner:
                    bool trouve = false;
                    for (int i = modele.NbFormes() - 1; i >= 0; i--)
                    {
                        if (modele.GetForme(i).contient(pointAjuste))
                        {
                            if (formeSelected == null || formeSelected != modele.GetForme(i))
                            {
                                formeSelected = modele.GetForme(i);
                                
                            } else {
                                formeDeplacee = modele.GetForme(i);
                            }
                            trouve = true;
                            break;
                        }

                    }
                    if (formeDeplacee != null)
                    {
                        modele.SupprimerForme(formeDeplacee);
                        modele.AjouterForme(formeDeplacee);
                    }
                    if (!trouve) formeSelected = null;
                    break;

                case ModeAction.CreerRectangle:
                    FormeCreation = new Rectangle(pointAjuste) { Largeur = 0, Hauteur = 0 };
                    FormeCreation.CouleurPinceau = myPen.Color;
                    modele.AjouterForme(FormeCreation);
                    break;

                case ModeAction.CreerOvale:
                    FormeCreation = new Disque(pointAjuste) { Rayon = 0 };
                    FormeCreation.CouleurPinceau = myPen.Color;
                    modele.AjouterForme(FormeCreation);
                    break;

                case ModeAction.CreerTrait:
                    FormeCreation = new Trait(pointAjuste) { Fin = pointAjuste };
                    FormeCreation.CouleurPinceau = myPen.Color;
                    modele.AjouterForme(FormeCreation);
                    break;
            }

            lastMousePosition = pointAjuste;
            SelectionChangee?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point pointAjuste = new Point((int)(e.X / niveauZoom), (int)(e.Y / niveauZoom));

            switch (ModeActuel)
            {
                case ModeAction.CreerTrait:
                    if (FormeCreation != null && FormeCreation is Trait)
                    {
                        Trait trait = (Trait)FormeCreation;
                        trait.Fin = pointAjuste;
                    }
                    break;

                case ModeAction.Selectionner:
                    if (estEnTrainDeRedimensionner) 
                    { 
                        if (formeSelected is Rectangle r)
                        {
                            int dx = pointAjuste.X - lastMousePosition.X;
                            int dy = pointAjuste.Y - lastMousePosition.Y;

                            switch (CoinActif)
                            {
                                case CoinRedim.BasDroite:
                                    r.Largeur += dx;
                                    r.Hauteur += dy;
                                    break;
                                case CoinRedim.BasGauche:
                                    r.Position = new Point(r.Position.X + dx, r.Position.Y);
                                    r.Largeur -= dx;
                                    r.Hauteur += dy;
                                    break;
                                case CoinRedim.HautDroite:
                                    r.Position = new Point(r.Position.X, r.Position.Y + dy);
                                    r.Largeur += dx;
                                    r.Hauteur -= dy;
                                    break;
                                case CoinRedim.HautGauche:
                                    r.Position = new Point(r.Position.X + dx, r.Position.Y + dy);
                                    r.Largeur -= dx;
                                    r.Hauteur -= dy;
                                    break;
                            }
                            lastMousePosition = pointAjuste;
                           
                        } else if (formeSelected is Disque d)
                        {
                            // On calcule la distance entre le centre (fixe) et la souris actuelle
                            // La distance Y entre le centre et la souris nous donne le nouveau rayon
                            d.Rayon = Math.Abs(pointAjuste.Y - d.Position.Y);
                            lastMousePosition = pointAjuste;

                        } else if (formeSelected is Trait t)
                        {
                            if (CoinActif == CoinRedim.DebutTrait)
                            {
                                // On déplace le point de départ
                                t.Position = pointAjuste;
                                this.Invalidate();
                            }
                            else if (CoinActif == CoinRedim.FinTrait)
                            {
                                // On déplace le point d'arrivée

                                t.Fin = pointAjuste;
                                this.Invalidate();
                            }
                        }

                    }
                    else
                    {
                        if (formeDeplacee != null)
                        {
                            int dx = pointAjuste.X - lastMousePosition.X;
                            int dy = pointAjuste.Y - lastMousePosition.Y;
                            if (formeDeplacee is Trait)
                            {
                                Trait trait = (Trait)formeDeplacee;
                                trait.DeplacerTrait(dx, dy);
                            }
                            else
                            {

                                Point p = formeDeplacee.Position;
                                formeDeplacee.Position = new Point(p.X + dx, p.Y + dy);

                            }
                            lastMousePosition = pointAjuste;
                        }
                    }
                    break;
                case ModeAction.CreerRectangle:

                    if (FormeCreation != null && FormeCreation is Rectangle)
                    {
                        Rectangle rect = (Rectangle)FormeCreation;
                        rect.Largeur = pointAjuste.X - lastMousePosition.X;
                        rect.Hauteur = pointAjuste.Y - lastMousePosition.Y;
                    }
                    break;
                case ModeAction.CreerOvale:

                    if (FormeCreation != null && FormeCreation is Disque)
                    {
                        Disque disque = (Disque)FormeCreation;
                        int dx = pointAjuste.X - lastMousePosition.X;
                        int dy = pointAjuste.Y - lastMousePosition.Y;
                        disque.Rayon = (int)Math.Sqrt(dx * dx + dy * dy);
                    }
                    break;
            
            }
            this.Invalidate(); // pour redessiner la zone de dessin
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            estEnTrainDeRedimensionner = false;
            
            if (FormeCreation != null)
            {
                
               
                if (ModeActuel != ModeAction.CreerTrait)
                {
                    formeSelected = FormeCreation;
                    ModeActuel = ModeAction.Selectionner;
                    SelectionChangee?.Invoke(this, EventArgs.Empty);
                } else
                {
                    formeSelected = null;
                }
                FormeCreation = null;
            }
            formeDeplacee = null;
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.ScaleTransform(niveauZoom, niveauZoom);
            Pen myBluePen = new Pen(Color.Cyan, 5);
            e.Graphics.Clear(Color.White);
            for (int i = 0; i < modele.NbFormes(); i++)
            {
                FormeGeo forme = modele.GetForme(i);
                SolidBrush brush = new SolidBrush(forme.Couleur);
                Pen myPen = new Pen(forme.CouleurPinceau, 2);
                if (forme is Rectangle)
                {
                    Rectangle rect = (Rectangle)forme;
                    // On détermine le X le plus à gauche et le Y le plus haut
                    int x = Math.Min(rect.Position.X, rect.Position.X + rect.Largeur);
                    int y = Math.Min(rect.Position.Y, rect.Position.Y + rect.Hauteur);
                    // On prend la valeur absolue pour la taille (toujours positif)
                    int largeurAbsolue = Math.Abs(rect.Largeur);
                    int hauteurAbsolue = Math.Abs(rect.Hauteur);

                    if (rect == formeSelected) e.Graphics.DrawRectangle(myBluePen, x, y, largeurAbsolue, hauteurAbsolue);
                    e.Graphics.DrawRectangle(myPen, x, y, largeurAbsolue, hauteurAbsolue);
                    e.Graphics.FillRectangle(brush, x, y, largeurAbsolue, hauteurAbsolue);
                  if (forme == formeSelected)
                    {
                        // Dessiner 4 petits ronds aux coins
                        e.Graphics.FillEllipse(Brushes.Red, rect.Position.X - 4, rect.Position.Y - 4, 8, 8); // Haut-Gauche
                        e.Graphics.FillEllipse(Brushes.Red, rect.Position.X + rect.Largeur - 4, rect.Position.Y - 4, 8, 8); // Haut-Droite
                        e.Graphics.FillEllipse(Brushes.Red, rect.Position.X - 4, rect.Position.Y + rect.Hauteur - 4, 8, 8); // Bas-Gauche
                        e.Graphics.FillEllipse(Brushes.Red, rect.Position.X + rect.Largeur - 4, rect.Position.Y + rect.Hauteur - 4, 8, 8); // Bas-Droite
                    }

                }
                else if (forme is Disque)
                {
                    Disque disque = (Disque)forme;
                    if (disque == formeSelected) e.Graphics.DrawEllipse(myBluePen, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);
                    e.Graphics.DrawEllipse(myPen, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);
                    e.Graphics.FillEllipse(brush, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);

                    if (forme == formeSelected)
                    {
                        // Dessiner 1 petit rond en haut sur le disque pour le redimensionnement
                        e.Graphics.FillEllipse(Brushes.Red, disque.Position.X - 4, disque.Position.Y - disque.Rayon - 4, 8, 8);
                    }
                }
                else if (forme is Trait)
                {
                    
                    Trait trait = (Trait)forme;
                    if (trait == formeSelected) e.Graphics.DrawLine(myBluePen, trait.Position, trait.Fin);
                    e.Graphics.DrawLine(myPen, trait.Position, trait.Fin);

                    if (trait == formeSelected)
                    {
                        // Dessiner 2 petits ronds au bout des traits pour le redimensionnement
                        e.Graphics.FillEllipse(Brushes.Red, trait.Position.X - 4, trait.Position.Y - 4, 8, 8);
                        e.Graphics.FillEllipse(Brushes.Red, trait.Fin.X - 4, trait.Fin.Y - 4, 8, 8);
                    }
                }




            }
        }
        private void ZoneDessin_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                niveauZoom += 0.1f; // Zoom avant
            else
                niveauZoom = Math.Max(0.1f, niveauZoom - 0.1f); // Zoom arrière (min 10%)

            // On déclenche l'événement pour prévenir le controleur
            ZoomChangee?.Invoke(this, EventArgs.Empty);
            this.Invalidate(); // On redessine tout
        }

    }

     
}
