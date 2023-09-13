using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thomas_FOUQUEROLLE.Medias
{
    public class Media
    {
        public string Titre;
        public int NumRef;
        public int NbExemplaireDispo;

        public Media(string titre, int numeroReference, int nombreExemplaires)
        {
            Titre = titre;
            NumRef = numeroReference;
            NbExemplaireDispo = nombreExemplaires;
        }

        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre: {Titre}");
            Console.WriteLine($"Numéro de référence: {NumRef}");
            Console.WriteLine($"Nombre d'exemplaires disponibles: {NbExemplaireDispo}");
        }

        public void AjouterMedia(int quantite)
        {
            if (quantite < 0)
            {
                Console.WriteLine("La quantité doit être positive.");
                return;
            }

            NbExemplaireDispo += quantite;
            Console.WriteLine($"{quantite} exemplaire(s) de \"{Titre}\" ont été ajoutés.");
        }

        public void RetirerMedia(int quantite)
        {
            if (quantite < 0)
            {
                Console.WriteLine("La quantité doit être positive.");
                return;
            }

            if (NbExemplaireDispo < quantite)
            {
                Console.WriteLine($"Impossible de retirer {quantite} exemplaires de de \"{Titre}\" car le stock est insuffisant.");
                return;
            }

            NbExemplaireDispo -= quantite;
            Console.WriteLine($"{quantite} exemplaire(s) de \"{Titre}\" ont été retirés.");
        }

        public static Media operator +(Media library, int quantite)
        {
            if (quantite <= 0)
            {
                throw new ArgumentException("Impossible d'ajouter un nombre d'exemplaires inférieur à 0.");
            }

            library.NbExemplaireDispo += quantite;
            return library;
        }

        public static Media operator -(Media library, int quantite)
        {
            if (quantite <= 0 || quantite > library.NbExemplaireDispo)
            {
                throw new ArgumentException("Impossible de retirer un nombre d'exemplaires inférieur à 0 et inférieur au nombre d'exemplaires disponibles.");
            }

            library.NbExemplaireDispo -= quantite;
            return library;
        }
    }
}
