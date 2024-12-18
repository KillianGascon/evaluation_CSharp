using System;



namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        // ID du cercle
        public int? Id { get; set; }

        // Point central du cercle
        public Point_DAL Centre { get; private set; }

        // Rayon du cercle
        public double Rayon { get; set; }

        public Cercle_DAL()
        {
            
        }

        // Constructeur pour convertir un cercle de la BLL en DAL
        public Cercle_DAL(int id, Point_DAL centre, double rayon)
        {
            Id = id;
            Centre = centre;
            Rayon = rayon;
        }

        // Constructeur sans ID pour l'ajout d'un nouveau cercle
        public Cercle_DAL(Point_DAL centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }
    }
}
