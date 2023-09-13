using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD1;
using Thomas_FOUQUEROLLE.Medias;

namespace Thomas_FOUQUEROLLE
{
    public class Library
    {
        private List<Media> medias = new List<Media>();

        public Media this[int numRef]
        {
            get
            {
                return medias.Find(media => media.NumRef == numRef);
            }
        }

        public void AjouterMedia(Media media)
        {
            medias.Add(media);
        }

        public void RetirerMedia(Media media)
        {
            medias.Remove(media);
        }

        public void EmprunterMedia(Media media)
        {
            if (media.NbExemplaireDispo > 0)
            {
                media.NbExemplaireDispo--;
                Console.WriteLine($"Emprunt de \"{media.Titre}\" effectué.");
            }
            else
            {
                Console.WriteLine($"Aucun exemplaire disponible de \"{media.Titre}\".");
            }
        }

        public void RetournerMedia(Media media)
        {
            media.NbExemplaireDispo++;
            Console.WriteLine($"Retour de \"{media.Titre}\" effectué.");
        }

        public List<Media> RechercherMedia(string recherche)
        {
            return medias.FindAll(media =>
                media.Titre.Contains(recherche) ||
                (media is Livre livre && livre.Auteur.Contains(recherche)) ||
                (media is CD cd && cd.Artiste.Contains(recherche))
            );
        }

        public List<Media> MediasEmpruntesParUtilisateur()
        {
            return new List<Media>();
        }

        public void AfficherStatistiques()
        {
            int totalMedias = medias.Count;
            int totalEmpruntes = medias.Count(media => media.NbExemplaireDispo == 0);
            int totalDisponibles = totalMedias - totalEmpruntes;

            Console.WriteLine($"Nombre total de médias dans la bibliothèque: {totalMedias}");
            Console.WriteLine($"Nombre d'exemplaires empruntés: {totalEmpruntes}");
            Console.WriteLine($"Nombre d'exemplaires disponibles: {totalDisponibles}");
        }
    }
}
