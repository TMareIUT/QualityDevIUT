using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace TD1QualiteDev
{


    //Exercice 1
    public class Media
    {
        internal string Titre;
        internal int NumeroReference;
        internal int NbExemplairesDispo;

        public Media(string titre, int numeroReference, int exemplairesDisponibles)
        {
            Titre = titre;
            NumeroReference = numeroReference;
            NbExemplairesDispo = exemplairesDisponibles;
        }

        public virtual void AfficherInfos()
        {
            Console.Out.WriteLine("Titre: " + Titre +
                                  " ; Numéro de référence: " + NumeroReference +
                                  " ; Nombre d'exemplaires disponibles: " + NbExemplairesDispo);
        }
    }

    public class Livre : Media
    {
        internal string Auteur;

        public Livre(string titre, int numeroReference, int exemplairesDisponibles, string auteur)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Auteur = auteur;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.Out.WriteLine("; Auteur: " + Auteur);
        }
    }

    public class DVD : Media
    {
        internal float Duree;

        public DVD(string titre, int numeroReference, int exemplairesDisponibles, float duree)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Duree = duree;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.Out.WriteLine("; Durée: " + Duree);
        }
    }

    public class CD : Media
    {
        internal string Artiste;

        public CD(string titre, int numeroReference, int exemplairesDisponibles, string artiste)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Artiste = artiste;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.Out.WriteLine("; Artiste: " + Artiste);
        }
    }

    // Exercice 3

    public class Emprunt
    {
        public Media Media { get; }
        public string NomEmprunteur { get; }

        public Emprunt(Media media, string nomEmprunteur)
        {
            Media = media;
            NomEmprunteur = nomEmprunteur;
        }
    }

    public class Library
    {
        private List<Media> collectionMedias;
        private List<Emprunt> emprunts;

        public Library()
        {
            collectionMedias = new List<Media>();
            emprunts = new List<Emprunt>();
        }

        // Méthode pour ajouter un média à la bibliothèque
        public void AjouterMedia(Media media)
        {
            collectionMedias.Add(media);
        }

        // Méthode pour retirer un média de la bibliothèque
        public void RetirerMedia(Media media)
        {
            collectionMedias.Remove(media);
        }

        // Méthode pour emprunter un média de la bibliothèque
        public bool EmprunterMedia(Media media, string nomEmprunteur)
        {
            if (collectionMedias.Contains(media) && media.NbExemplairesDispo > 0)
            {
                media.NbExemplairesDispo--;
                emprunts.Add(new Emprunt(media, nomEmprunteur));
                return true;
            }
            return false;
        }

        // Méthode pour retourner un média emprunté
        public bool RetournerMedia(Media media)
        {
            var emprunt = emprunts.FirstOrDefault(e => e.Media == media);
            if (emprunt != null)
            {
                media.NbExemplairesDispo++;
                emprunts.Remove(emprunt);
                return true;
            }
            return false;
        }

        // Méthode pour rechercher un média par titre ou auteur
        public List<Media> RechercherMedia(string critere)
        {
            return collectionMedias.Where(media =>
                media.Titre.Contains(critere, StringComparison.OrdinalIgnoreCase) ||
                (media is Livre livre && livre.Auteur.Contains(critere, StringComparison.OrdinalIgnoreCase))
                || (media is CD cd && cd.Artiste.Contains(critere, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Méthode pour lister les médias empruntés par un utilisateur spécifique
        public List<Media> ListerMediasEmpruntesParUtilisateur(string nomUtilisateur)
        {
            var mediasEmpruntes = emprunts
                .Where(e => e.NomEmprunteur == nomUtilisateur)
                .Select(e => e.Media)
                .ToList();

            return mediasEmpruntes;
        }

        // Méthode pour afficher les statistiques de la bibliothèque
        public void AfficherStatistiques()
        {
            int nombreTotalMedias = collectionMedias.Count;
            int nombreExemplairesEmpruntes = emprunts.Count;
            int nombreExemplairesDisponibles = collectionMedias.Sum(media => media.NbExemplairesDispo);

            Console.WriteLine("Statistiques de la bibliothèque :");
            Console.WriteLine($"Nombre total de médias : {nombreTotalMedias}");
            Console.WriteLine($"Nombre d'exemplaires empruntés : {nombreExemplairesEmpruntes}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {nombreExemplairesDisponibles}");
        }

        // Méthode pour sauvegarder la bibliothèque dans un fichier JSON
        public void SauvegarderBibliothèque(string cheminFichier)
        {
            string Json = JsonSerializer.Serialize(this);
            File.WriteAllText(cheminFichier, Json);

        }

        // Méthode pour charger la bibliothèque à partir d'un fichier JSON
        public static Library ChargerBibliothèque(string cheminFichier)
        {
            string Json = File.ReadAllText(cheminFichier);
            return JsonSerializer.Deserialize<Library>(Json);
        }

    }


    // Exercice 2

    public class Tools
    {
        internal string nomOutil;
    }

    // Exercice 4

    
}
