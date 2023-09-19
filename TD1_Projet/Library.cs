using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace TD1_Projet
{
    [Serializable]
    public class Library
    {
        // La bibliothèque contient plusieurs éléments. La totalité des media dont elle dispose ainsi que la liste des media qui ont été empruntés
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

        // Suppression d'un media de la bibliothèque
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

        // Retourner un media emprunté en faisant la liaison avec la liste des emprunts
        public bool RetournerMedia(Media media, string utilisateur)
        {
            // Vérification de l'emprunt du média
            foreach (var emprunt in emprunts)
            {
                // Vérification de l'emprunt du media renseigné
                if (emprunt.media == media && emprunt.utilisateur == utilisateur)
                {
                    media.nombreExemplaires++;

                    emprunts.Remove(emprunt);

                    Console.WriteLine("Retour effectué");
                    return true;
                }
            }

            Console.WriteLine("Le media n'a pas été emprunté par l'utilisateur spécifié");
            return false;
        }


        //Recherche un média selon plusieurs critères personnalisés
        public List<Media> RechercherMedias(string critere)
        {
            critere = critere.ToLower(); // Conversion des critères en minuscules pour une recherche insensible à la casse
            List<Media> resultatsRecherche = new List<Media>();

            foreach (var media in collectionMedia)
            {
                // On ajoute ici les critères de recherches
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

        //Liste des medias empruntés par un utilisateur en renseignant ce dernier
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



        // Indexeur pour accéder à un élément de la bibliothèque grâce à son numéro de référence
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

        // Méthode pour sauvegarder la bibliothèque dans un fichier JSON
        public void SauvegarderBibliothèque(string cheminFichier)
        {
            string Json = JsonSerializer.Serialize(this);
            File.WriteAllText(cheminFichier, Json);

        }

        // Méthode pour charger la bibliothèque à partir d'un fichier JSON
        public static Library? ChargerBibliothèque(string cheminFichier)
        {
            string Json = File.ReadAllText(cheminFichier);
            return JsonSerializer.Deserialize<Library>(Json);
        }
    }
}
