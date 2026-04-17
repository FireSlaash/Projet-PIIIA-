using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7
{
    public abstract class FormeGeo
    {
        public Point Position { get; set; }
        public Color Couleur { get; set; } = Color.White;

        public FormeGeo(Point p)
        {
            this.Position = p;
        }

        public abstract bool contient(Point p);
    }

    public class Rectangle : FormeGeo
    {
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public Rectangle(Point point) : base(point)
        {}

        public override bool contient(Point p)
        {
            return p.X >= this.Position.X && p.X <= Position.X + Largeur && p.Y >= Position.Y && p.Y <= Position.Y + Hauteur; 
        }

    }

    public class Disque : FormeGeo
    {
        public int Rayon { get; set; }
        public Disque(Point point) : base(point)
        { }

        public override bool contient(Point p)
        {
            double distance = Math.Sqrt(Math.Pow(p.X - this.Position.X, 2) + Math.Pow(p.Y - this.Position.Y, 2));
            return distance <= Rayon;
        }
    }

    public class Trait : FormeGeo
    {
        public Point Fin { get; set; }

        public Trait(Point debut) : base(debut)
        {
            this.Fin = debut;
            this.Couleur = Color.Black;
        }

        public override bool contient(Point p)
        {
            double distance = DistancePointToSegment(p, this.Position, this.Fin);
            return distance <= 5; // tolérance de 5 pixels pour la sélection  
        }

        public void DeplacerTrait(int dx, int dy)
        {
            this.Position = new Point(this.Position.X + dx, this.Position.Y + dy);
            this.Fin = new Point(this.Fin.X + dx, this.Fin.Y + dy);
        }

        private double DistancePointToSegment(Point p, Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            if (dx == 0 && dy == 0)
            {
                // a et b sont le même point  
                return Math.Sqrt(Math.Pow(p.X - a.X, 2) + Math.Pow(p.Y - a.Y, 2));
            }
            double t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t)); // clamp t entre 0 et 1  
            double closestX = a.X + t * dx;
            double closestY = a.Y + t * dy;
            return Math.Sqrt(Math.Pow(p.X - closestX, 2) + Math.Pow(p.Y - closestY, 2));
        }
    }


    internal class Modele
    {
        private List<FormeGeo> formes = new List<FormeGeo>();

        public void AjouterForme(FormeGeo forme)
        {
            formes.Add(forme);
        }

        public int NbFormes()
        {
            return formes.Count;
        }

        public FormeGeo GetForme(int index)
        {
            if (index >= 0 && index < formes.Count)
            {
                return formes[index];
            }
            return null;
        }

        public void SupprimerForme(FormeGeo forme)
        {
            formes.Remove(forme);
        }

        public void AjouterDebutForme(FormeGeo forme)
        {
            formes.Insert(0, forme);
        }

    }
}
