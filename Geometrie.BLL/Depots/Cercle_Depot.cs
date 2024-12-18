using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.BLL.Depots
{
    public class Cercle_Depot : IDepot<Cercle>
    {
        private GeometrieContext context;
        private Point_Depot pointDepot;

        public Cercle_Depot(GeometrieContext context, Point_Depot pointDepot)
        {
            this.context = context;
            this.pointDepot = pointDepot;
        }

        public Cercle Add(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Centre, nameof(element.Centre));

            // Ajouter le point dans la base de données via Point_Depot
            //var centreDAL = pointDepot.Add(element.Centre).ToDAL();

            // Créer un objet Cercle_DAL avec l'ID du point ajouté
            var cercleDAL = new Cercle_DAL(element.Centre.ToDAL(), element.Rayon);
            context.Cercles.Add(cercleDAL);
            context.SaveChanges();

            // Récupérer l'ID généré pour le cercle et l'affecter à l'objet BLL
            element.Id = cercleDAL.Id;

            return element;
        }

        public IEnumerable<Cercle> GetAll()
        {
            // Charger tous les cercles et leurs points associés
            return context.Cercles.Select(c =>
                new Cercle(
                    new Point(c.Centre.X, c.Centre.Y),
                    c.Rayon
                )
                { Id = c.Id }
            ).ToList();
        }

        public Cercle? GetById(int id)
        {
            var cercleDAL = context.Cercles.Find(id);
            if (cercleDAL == null)
                return null;

            var centre = new Point(cercleDAL.Centre.X, cercleDAL.Centre.Y);
            return new Cercle(centre, cercleDAL.Rayon) { Id = cercleDAL.Id };
        }

        public Cercle Update(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var cercleDAL = context.Cercles.Find(element.Id);
            if (cercleDAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(element));

            // Mettre à jour le rayon et le centre
            cercleDAL.Rayon = element.Rayon;
            cercleDAL.Id = element.Id.Value;
            cercleDAL.Centre.Id = element.Centre.Id;
            cercleDAL.Centre.X = element.Centre.X;
            cercleDAL.Centre.Y = element.Centre.Y;

            context.Cercles.Update(cercleDAL);
            context.SaveChanges();

            return element;
        }


        public IDepot<Cercle> Delete(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IDepot<Cercle> Delete(int id)
        {
            var cercleDAL = context.Cercles.Find(id);
            if (cercleDAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(id));

            context.Cercles.Remove(cercleDAL);
            context.SaveChanges();

            return this;
        }
    }
}
