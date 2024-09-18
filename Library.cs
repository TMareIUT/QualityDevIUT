using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class Library
    {
        private List<Media> medias;

        public Library()
        {
            medias = new List<Media>();
        }

        // Indexeur pour accéder aux médias par leur numéro de référence
        public Media this[int numeroReference]
        {
            get
            {
                return medias.Find(m => m.NumeroReference == numeroReference);
            }
        }

        public void AjouterMedia(Media media)
        {
            medias.Add(media);
            Console.WriteLine($"Le média '{media.Titre}' a été ajouté à la bibliothèque.");
        }

        public void RetirerMedia(int numeroReference)
        {
            var media = medias.Find(m => m.NumeroReference == numeroReference);
            if (media != null)
            {
                medias.Remove(media);
                Console.WriteLine($"Le média '{media.Titre}' a été retiré de la bibliothèque.");
            }
            else
            {
                Console.WriteLine("Média non trouvé.");
            }
        }

        public void EmprunterMedia(int numeroReference, string utilisateur)
        {
            var media = medias.Find(m => m.NumeroReference == numeroReference);
            if (media != null && media.NombreExemplairesDisponibles > 0)
            {
                media.NombreExemplairesDisponibles--;
                emprunts.Add(new Emprunt(utilisateur, media));
                Console.WriteLine($"L'utilisateur '{utilisateur}' a emprunté '{media.Titre}'.");
            }
            else
            {
                Console.WriteLine("Média non disponible pour l'emprunt.");
            }
        }
    }
}
