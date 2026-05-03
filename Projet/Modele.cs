using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Projet
{
    // FormeGeo est la classe de base pour toutes les formes géométriques.
    // Elle est marquée avec des attributs JsonDerivedType pour permettre la sérialisation polymorphique.
    [JsonDerivedType(typeof(Rectangle), typeDiscriminator: "rect")]
    [JsonDerivedType(typeof(Disque), typeDiscriminator: "disq")]
    [JsonDerivedType(typeof(Trait), typeDiscriminator: "trait")]
    public abstract class FormeGeo
    {
        [JsonIgnore]
        // Les propriétés de type Color ne sont pas directement sérialisables, donc on les ignore et on utilise des propriétés auxiliaires pour stocker les valeurs ARGB.
        public Color Couleur { get; set; } = Color.White;

        [JsonIgnore]
        // Pareil
        public Color CouleurPinceau { get; set; } = Color.Black;

        [JsonPropertyName("CouleurArgb")]
        // Propriété auxiliaire pour sérialiser la couleur en ARGB
        public int CouleurArgb
        {
            get => Couleur.ToArgb();
            set => Couleur = Color.FromArgb(value);
        }
        // Propriété auxiliaire pour sérialiser la couleur du pinceau en ARGB
        [JsonPropertyName("PinceauArgb")]
        public int PinceauArgb
        {
            get => CouleurPinceau.ToArgb();
            set => CouleurPinceau = Color.FromArgb(value);
        }
        // Position est le point de référence pour la forme
        public Point Position { get; set; }

        public FormeGeo(Point p)
        {
            this.Position = p;
        }

        public FormeGeo() { }

        public abstract bool contient(Point p);
        public abstract FormeGeo Cloner();
    }

    // Rectangle hérite de FormeGeo et ajoute des propriétés spécifiques pour la largeur et la hauteur.
    public class Rectangle : FormeGeo
    {
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public Rectangle(Point point) : base(point)
        {}
        public Rectangle() : base() { }


        public override bool contient(Point p)
        {
            int xMin = Math.Min(Position.X, Position.X + Largeur);
            int yMin = Math.Min(Position.Y, Position.Y + Hauteur);
            return p.X >= xMin && p.X <= xMin + Math.Abs(Largeur) &&
                   p.Y >= yMin && p.Y <= yMin + Math.Abs(Hauteur);
        }
        public override FormeGeo Cloner()
        {
            // On crée un nouveau rectangle avec les mêmes propriétés
            return new Rectangle(new Point(this.Position.X + 10, this.Position.Y + 10))
            {
                Largeur = this.Largeur,
                Hauteur = this.Hauteur,
                Couleur = this.Couleur,
                CouleurPinceau = this.CouleurPinceau
            };
        }
    }

    // Disque hérite de FormeGeo et ajoute une propriété pour le rayon.

    public class Disque : FormeGeo
    {
        public int Rayon { get; set; }
        public Disque(Point point) : base(point)
        { }
        public Disque() : base() { }

        public override bool contient(Point p)
        {
            double distance = Math.Sqrt(Math.Pow(p.X - this.Position.X, 2) + Math.Pow(p.Y - this.Position.Y, 2));
            return distance <= Rayon;
        }
        public override FormeGeo Cloner()
        {
            return new Disque(new Point(this.Position.X + 10, this.Position.Y + 10))
            {
                Rayon = this.Rayon,
                Couleur = this.Couleur,
                CouleurPinceau = this.CouleurPinceau
            };
        }
    }

    // Trait hérite de FormeGeo et ajoute une propriété pour le point de fin du trait.

    public class Trait : FormeGeo
    {
        public Point Fin { get; set; }

        public Trait(Point debut) : base(debut)
        {
            this.Fin = debut;
            this.CouleurPinceau = Color.Black;
        }
        public Trait() : base() { }

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
        public override FormeGeo Cloner()
        {
            Trait t = new Trait(new Point(this.Position.X + 10, this.Position.Y + 10));
            t.Fin = new Point(this.Fin.X + 10, this.Fin.Y + 10);
            t.CouleurPinceau = this.CouleurPinceau;
            return t;
        }
    }



    // Modele est la classe qui gère la collection de formes géométriques. Elle fournit des méthodes pour ajouter, supprimer, et accéder aux formes.

    internal class Modele
    {
        private List<FormeGeo> formes = new List<FormeGeo>();

        public Modele()
        {
        }
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

        public List<FormeGeo> GetFormes()
        {
            return formes;
        }

        public void Clear()
        {
            formes.Clear();
        }

    }
}
