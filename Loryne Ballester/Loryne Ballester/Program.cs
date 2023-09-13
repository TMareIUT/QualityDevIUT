using System;
using System.Collections.Generic;

public class Media
{

    public string Titre { get; set; }
    public int NumeroReference { get; set; }
    public int NombreExemplairesDisponibles { get; set; }

    public Media(string titre, int numeroReference, int nombreExemplairesDisponibles)
    {
        Titre = titre;
        NumeroReference = numeroReference;
        NombreExemplairesDisponibles = nombreExemplairesDisponibles;
    }

    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Titre: {Titre}");
        Console.WriteLine($"Numéro de référence: {NumeroReference}");
        Console.WriteLine($"Nombre d'exemplaires disponibles: {NombreExemplairesDisponibles}");
    }

    public void AjouterMedia(int quantite)
    {
        if (quantite < 0)
        {
            Console.WriteLine("La quantité doit être positive.");
            return;
        }

        NombreExemplairesDisponibles += quantite;
        Console.WriteLine($"{quantite} exemplaires de \"{Titre}\" ont été ajoutés.");
    }

    public void RetirerMedia(int quantite)
    {
        if (quantite < 0)
        {
            Console.WriteLine("La quantité doit être positive.");
            return;
        }

        if (NombreExemplairesDisponibles < quantite)
        {
            Console.WriteLine($"Impossible de retirer {quantite} exemplaires de \"{Titre}\". Stock insuffisant.");
            return;
        }

        NombreExemplairesDisponibles -= quantite;
        Console.WriteLine($"{quantite} exemplaires de \"{Titre}\" ont été retirés.");
    }

    public static Media operator +(Media media, int quantite)
    {
        media.AjouterMedia(quantite);
        return media;
    }

    public static Media operator -(Media media, int quantite)
    {
        media.RetirerMedia(quantite);
        return media;
    }
}

public class Livre : Media
{
    public string Auteur { get; set; }

    public Livre(string titre, int numeroReference, int nombreExemplairesDisponibles, string auteur)
        : base(titre, numeroReference, nombreExemplairesDisponibles)
    {
        Auteur = auteur;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Auteur: {Auteur}");
    }
}

public class DVD : Media
{
    public int Duree { get; set; }

    public DVD(string titre, int numeroReference, int nombreExemplairesDisponibles, int duree)
        : base(titre, numeroReference, nombreExemplairesDisponibles)
    {
        Duree = duree;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Durée: {Duree} minutes");
    }
}

public class CD : Media
{
    public string Artiste { get; set; }

    public CD(string titre, int numeroReference, int nombreExemplairesDisponibles, string artiste)
        : base(titre, numeroReference, nombreExemplairesDisponibles)
    {
        Artiste = artiste;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artiste: {Artiste}");
    }
}

public class Library
{
    private List<Media> medias = new List<Media>();

    public Media this[int numeroReference]
    {
        get
        {
            return medias.Find(media => media.NumeroReference == numeroReference);
        }
    }

    public void AjouterMedia(Media media)
    {
        if (media != null)
        {
            medias.Add(media);
            Console.WriteLine($"Le média \"{media.Titre}\" a été ajouté à la bibliothèque.");
        }
    }

    public void RetirerMedia(Media media)
    {
        if (media != null)
        {
            medias.Remove(media);
            Console.WriteLine($"Le média \"{media.Titre}\" a été retiré de la bibliothèque.");
        }
    }

    public void EmprunterMedia(Media media)
    {
        if (media != null && media.NombreExemplairesDisponibles > 0)
        {
            media.NombreExemplairesDisponibles--;
            Console.WriteLine($"Vous avez emprunté le média \"{media.Titre}\".");
        }
        else
        {
            Console.WriteLine($"Le média \"{media.Titre}\" n'est pas disponible pour l'emprunt.");
        }
    }

    public void RetournerMedia(Media media)
    {
        if (media != null)
        {
            media.NombreExemplairesDisponibles++;
            Console.WriteLine($"Vous avez retourné le média \"{media.Titre}\".");
        }
    }

    public List<Media> RechercherMedia(string critere)
    {
        return medias.FindAll(media => media.Titre.Contains(critere) || (media is Livre && ((Livre)media).Auteur.Contains(critere)));
    }

    public List<Media> ListerMediasEmpruntes()
    {
        return medias.FindAll(media => media.NombreExemplairesDisponibles < media.NombreExemplairesDisponibles);
    }

    public void AfficherStatistiques()
    {
        int totalMedias = medias.Count;
        int totalEmpruntes = medias.FindAll(media => media.NombreExemplairesDisponibles < media.NombreExemplairesDisponibles).Count;
        int totalDisponibles = medias.FindAll(media => media.NombreExemplairesDisponibles > 0).Count;

        Console.WriteLine($"Nombre total de médias dans la bibliothèque : {totalMedias}");
        Console.WriteLine($"Nombre d'exemplaires empruntés : {totalEmpruntes}");
        Console.WriteLine($"Nombre d'exemplaires disponibles : {totalDisponibles}");
    }
}

public static class Tools
{
    public static void AjouterMedia(Media media, int quantite)
    {
        media += quantite;
    }

    public static void RetirerMedia(Media media, int quantite)
    {
        media -= quantite;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library bibliotheque = new Library();

        Livre livre = new Livre("Culpa Mia", 101, 50, "Mercedes Ronn");
        DVD dvd = new DVD("After", 201, 26, 106);
        CD cd = new CD("Jaipasdinspi", 301, 17, "Jesaispas");

        bibliotheque.AjouterMedia(livre);
        bibliotheque.AjouterMedia(dvd);
        bibliotheque.AjouterMedia(cd);

        Console.WriteLine("Informations sur le livre:\n");
        livre.AfficherInfos();

        Console.WriteLine("\nInformations sur le DVD:\n");
        dvd.AfficherInfos();

        Console.WriteLine("\nInformations sur le CD:\n");
        cd.AfficherInfos();

        Console.WriteLine("\n");

        Tools.AjouterMedia(livre, 10); // Ajouter 10 exemplaires de livre
        Tools.RetirerMedia(dvd, 5);   // Retirer 5 exemplaires de DVD
        Tools.RetirerMedia(cd, 20);   // Tentative de retrait de 20 exemplaires de CD

        Console.WriteLine("\n");

        //affichage des nouvelles informations avec les nouvelles quantités.
        Console.WriteLine("Informations sur le livre:\n");
        livre.AfficherInfos();

        Console.WriteLine("\nInformations sur le DVD:\n");
        dvd.AfficherInfos();

        Console.WriteLine("\nInformations sur le CD:\n");
        cd.AfficherInfos();

        Console.WriteLine("\n");

        Console.WriteLine("Recherche de médias par titre ou auteur contenant 'Culpa':");
        List<Media> resultatsRecherche = bibliotheque.RechercherMedia("Culpa");
        foreach (Media media in resultatsRecherche)
        {
            media.AfficherInfos();
            Console.WriteLine();
        }

        Console.WriteLine("\nListe des médias empruntés:");
        List<Media> mediasEmpruntes = bibliotheque.ListerMediasEmpruntes();
        foreach (Media media in mediasEmpruntes)
        {
            media.AfficherInfos();
            Console.WriteLine();
        }

        Console.WriteLine("\nStatistiques de la bibliothèque:");
        bibliotheque.AfficherStatistiques();
    }
}