using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Projet
{
    public class Library
    {
        private List<Media> collectionMedia;
        private List<Emprunt> emprunts;

        public Library()
        {
            collectionMedia = new List<Media>();
            emprunts = new List<Emprunt>();
        }

        // Ajout d'un media à la bibliothèque
        public void AjouterMedia(Media media)
        {
            collectionMedia.Add(media);
            Console.WriteLine("Media ajouté\n");
        }

        // Retirer un media de la bibliothèque
        public void RetirerMedia(Media media)
        {
            collectionMedia.Remove(media);
            Console.WriteLine("Media retiré\n");
        }

        // Emprunter un media de la bibliothèque
        public void EmprunterMedia(Media media, string utilisateur)
        {
            if (media.nombreExemplaires > 0)
            {
                media.nombreExemplaires--;

                // Enregistrement des détails de l'emprunt
                emprunts.Add(new Emprunt(media, DateTime.Now, utilisateur));
            }
            else
            {
                Console.WriteLine("Le media n'est pas disponible");
            }
        }

        // Retourner un media emprunté
        public bool RetournerMedia(Media media, string utilisateur)
        {
            // Vérification de l'emprunt du média
            foreach (var emprunt in emprunts)
            {
                if (emprunt.media == media && emprunt.utilisateur == utilisateur)
                {
                    media.nombreExemplaires++;

                    // Suppression de l'emprunt
                    emprunts.Remove(emprunt);

                    Console.WriteLine("Retour effectué");
                    return true;
                }
            }

            Console.WriteLine("Le media n'a pas été emprunté par l'utilisateur spécifié");
            return false;
        }

        public List<Media> RechercherMedias(string critere)
        {
            critere = critere.ToLower(); // Convertir le critère en minuscules pour une recherche insensible à la casse
            List<Media> resultatsRecherche = new List<Media>();

            foreach (var media in collectionMedia)
            {
                // Recherche par titre ou auteur (ajoutez d'autres critères au besoin)
                if (media.titre.ToLower().Contains(critere)
                    || (media.numeroReference.ToString().Contains(critere))
                    || (media is Livre livre && livre.auteur.ToLower().Contains(critere))
                    || (media is CD cd && cd.artiste.ToLower().Contains(critere)))
                {
                    resultatsRecherche.Add(media);
                }
            }

            if (resultatsRecherche.Count > 0)
            {
                Console.WriteLine($"Resultats pour {critere} :");
                foreach (var resultat in resultatsRecherche)
                {
                    Console.WriteLine($" - {resultat.titre}, {resultat.numeroReference}");
                }
            }
            else
            {
                Console.WriteLine($"Aucun résultat");
            }
            return resultatsRecherche;
        }

        public void MediasEmpruntesParUtilisateur(string utilisateur)
        {
            List<Media> mediasEmpruntes = new List<Media>();

            foreach (var emprunt in emprunts)
            {
                if (emprunt.utilisateur == utilisateur)
                {
                    mediasEmpruntes.Add(emprunt.media);
                }
            }

            if (mediasEmpruntes.Count > 0)
            {
                Console.WriteLine($"Médias empruntés par {utilisateur} :");
                foreach (var mediaEmprunte in mediasEmpruntes)
                {
                    Console.WriteLine($" - {mediaEmprunte.titre}");
                }
            }
            else
            {
                Console.WriteLine($"Aucun média emprunté par {utilisateur}.");
            }
        }

        // Affichage des statistiques de la bibliothèque
        public void AfficherStatistiques()
        {
            int totalMedias = collectionMedia.Count;
            int exemplairesEmpruntes = emprunts.Count;
            int exemplairesDisponibles = collectionMedia.Sum(media => media.nombreExemplaires);

            Console.WriteLine("Statistiques de la bibliothèque :");
            Console.WriteLine($"Nombre total de médias : {totalMedias}");
            Console.WriteLine($"Nombre d'exemplaires empruntés : {exemplairesEmpruntes}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {exemplairesDisponibles}");
            Console.WriteLine();
        }

        // Affichage des informations de chaque média dans la bibliothèque
        public void AfficherTousLesMedias()
        {
            Console.WriteLine("Médias dans la bibliothèque :");
            foreach (var media in collectionMedia)
            {
                media.AfficherInfos();
                Console.WriteLine();
            }
        }



        //Indexeur
        public Media this[int numeroReference]
        {
            get
            {
                Media media = collectionMedia.Find(media => media.numeroReference == numeroReference);
                if (media == null)
                {
                    throw new ArgumentException("Aucun média trouvé avec ce numéro de référence.");
                }
                return media;
            }
        }



        //Surcharges d'opérateurs
        public static Library operator +(Library library, Media media)
        {
            library.AjouterMedia(media);
            return library;
        }

        public static Library operator -(Library library, Media media)
        {
            try
            {
                library.RetirerMedia(media);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Erreur : {e.Message}");
            }
            return library;
        }


        /*
        // Sauvegarder l'état de la bibliothèque dans un fichier JSON
        public void SauvegarderBibliothèque(string cheminFichier)
        {
            var libraryState = new LibraryState
            {
                CollectionMedia = collectionMedia,
                Emprunts = emprunts
            };

            string json = JsonConvert.SerializeObject(libraryState, Formatting.Indented);
            File.WriteAllText(cheminFichier, json);
        }

        // Charger la bibliothèque à partir d'un fichier JSON
        public void ChargerBibliothèque(string cheminFichier)
        {
            if (File.Exists(cheminFichier))
            {
                string json = File.ReadAllText(cheminFichier);
                var libraryState = JsonConvert.DeserializeObject<LibraryState>(json);

                collectionMedia = libraryState.CollectionMedia;
                emprunts = libraryState.Emprunts;
            }
            else
            {
                Console.WriteLine("Le fichier de sauvegarde n'existe pas.");
            }
        }*/
    }
}
