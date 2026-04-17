using System;
using System.Collections.Generic;
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
        public ModeAction ModeActuel { get; set; }
        private FormeGeo FormeCreation;
        private Pen myPen = new Pen(Color.Black, 2);
        private Brush myBrush = Brushes.White;

        public ZoneDessin(Modele modele)
        {
            
            this.Location = new Point(10, 10);
            this.Size = new Size(1000, 1000);
            this.modele = modele;
            this.DoubleBuffered = true; // pour éviter les scintillements lors du dessin
            ModeActuel = ModeAction.Selectionner;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            switch (ModeActuel)
            {
                case ModeAction.Selectionner:
                    bool trouve = false;
                    for (int i = modele.NbFormes() - 1; i >= 0; i--)
                    {
                        if (modele.GetForme(i).contient(e.Location))
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
                    FormeCreation = new Rectangle(e.Location) { Largeur = 0, Hauteur = 0 };
                    modele.AjouterForme(FormeCreation);
                    break;

                case ModeAction.CreerOvale:
                    FormeCreation = new Disque(e.Location) { Rayon = 0 };
                    modele.AjouterForme(FormeCreation);
                    break;

                case ModeAction.CreerTrait:
                    FormeCreation = new Trait(e.Location) { Fin = e.Location };
                    modele.AjouterForme(FormeCreation);
                    break;
            }

            lastMousePosition = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            switch (ModeActuel)
            {
                case ModeAction.CreerTrait:
                    if (FormeCreation != null && FormeCreation is Trait)
                    {
                        Trait trait = (Trait)FormeCreation;
                        trait.Fin = e.Location;
                    }
                    break;

                case ModeAction.Selectionner:

                    if (formeDeplacee != null)
                    {
                        int dx = e.X - lastMousePosition.X;
                        int dy = e.Y - lastMousePosition.Y;
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
                        lastMousePosition = e.Location;
                    }
                    break;
                case ModeAction.CreerRectangle:

                    if (FormeCreation != null && FormeCreation is Rectangle)
                    {
                        Rectangle rect = (Rectangle)FormeCreation;
                        rect.Largeur = e.X - lastMousePosition.X;
                        rect.Hauteur = e.Y - lastMousePosition.Y;
                    }
                    break;
                case ModeAction.CreerOvale:

                    if (FormeCreation != null && FormeCreation is Disque)
                    {
                        Disque disque = (Disque)FormeCreation;
                        int dx = e.X - lastMousePosition.X;
                        int dy = e.Y - lastMousePosition.Y;
                        disque.Rayon = (int)Math.Sqrt(dx * dx + dy * dy);
                    }
                    break;
            
            }
            this.Invalidate(); // pour redessiner la zone de dessin
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (FormeCreation != null)
            {
                modele.AjouterForme(FormeCreation);
                formeSelected = FormeCreation;
                FormeCreation = null;
                ModeActuel = ModeAction.Selectionner;
            }
            formeDeplacee = null;
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Pen myBluePen = new Pen(Color.Cyan, 4);
            e.Graphics.Clear(Color.White);
            for (int i = 0; i < modele.NbFormes(); i++)
            {
                FormeGeo forme = modele.GetForme(i);
                SolidBrush brush = new SolidBrush(forme.Couleur);
                
                if (forme is Rectangle)
                {
                    Rectangle rect = (Rectangle)forme;
                    if (rect == formeSelected) e.Graphics.DrawRectangle(myBluePen, rect.Position.X, rect.Position.Y, rect.Largeur, rect.Hauteur);
                    e.Graphics.DrawRectangle(myPen, rect.Position.X, rect.Position.Y, rect.Largeur, rect.Hauteur);
                    e.Graphics.FillRectangle(brush, rect.Position.X, rect.Position.Y, rect.Largeur, rect.Hauteur);


                }
                else if (forme is Disque)
                {
                    Disque disque = (Disque)forme;
                    if (disque == formeSelected) e.Graphics.DrawEllipse(myBluePen, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);
                    e.Graphics.DrawEllipse(myPen, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);
                    e.Graphics.FillEllipse(brush, disque.Position.X - disque.Rayon, disque.Position.Y - disque.Rayon, 2 * disque.Rayon, 2 * disque.Rayon);

                }
                else if (forme is Trait)
                {
                    
                    Trait trait = (Trait)forme;
                    Pen myPen = new Pen(trait.Couleur);
                    if (trait == formeSelected) e.Graphics.DrawLine(myBluePen, trait.Position, trait.Fin);
                    e.Graphics.DrawLine(myPen, trait.Position, trait.Fin);
                }
                
            }
        }

    }
}
