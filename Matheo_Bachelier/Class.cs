using System;
using System.Collections.Generic;
using System.Linq;

public class Media
{
    public string Titre { get; set; }
    public int NumeroReference { get; set; }
    public int ExemplairesDisponibles { get; set; }

    public Media()
    {
        Titre = "Titre inconnu";
        NumeroReference = 0;
        ExemplairesDisponibles = 0;
    }

    public Media(string titre, int numeroReference, int exemplairesDisponibles)
    {
        Titre = titre;
        NumeroReference = numeroReference;
        ExemplairesDisponibles = exemplairesDisponibles;
    }

    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Titre : {Titre}");
        Console.WriteLine($"Numéro de référence : {NumeroReference}");
        Console.WriteLine($"Exemplaires disponibles : {ExemplairesDisponibles}");
    }
}

public class Livre : Media
{
    public string Auteur { get; set; }

    public Livre()
    {
        Auteur = "Auteur inconnu";
    }

    public Livre(string titre, int numeroReference, int exemplairesDisponibles, string auteur)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Auteur = auteur;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("Livre");
        base.AfficherInfos();
        Console.WriteLine($"Auteur : {Auteur}");
    }
}

public class DVD : Media
{
    public int Duree { get; set; }

    public DVD()
    {
        Duree = 0;
    }

    public DVD(string titre, int numeroReference, int exemplairesDisponibles, int duree)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Duree = duree;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("DVD");
        base.AfficherInfos();
        Console.WriteLine($"Durée : {Duree} minutes");
    }
}

public class CD : Media
{
    public string Artiste { get; set; }

    public CD()
    {
        Artiste = "Artiste inconnu";
    }

    public CD(string titre, int numeroReference, int exemplairesDisponibles, string artiste)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Artiste = artiste;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("CD");
        base.AfficherInfos();
        Console.WriteLine($"Artiste : {Artiste}");
    }
}

public class Library
{
    public List<Media> Collection { get; set; }

    public Library()
    {
        Collection = new List<Media>();
    }

    public Library(List<Media> collection)
    {
        Collection = collection;
    }

    public static Library operator +(Library library, Media media)
    {
        if (library.Collection.Contains(media))
        {
            library.Collection
                .FirstOrDefault(m => m.Equals(media))
                .ExemplairesDisponibles += media.ExemplairesDisponibles;
        }
        else
        {
            library.Collection.Add(media);
        }
        return library;
    }

    public static Library operator -(Library library, Media media)
    {
        if (!library.Collection.Contains(media))
        {
            throw new Exception("Media not found in the library.");
        }
        else
        {
            if (library.Collection
                .FirstOrDefault(m => m.Equals(media))
                .ExemplairesDisponibles < media.ExemplairesDisponibles)
            {
                throw new Exception("Error in the amount of copies to remove");
            }
            else
            {
                library.Collection
                .FirstOrDefault(m => m.Equals(media))
                .ExemplairesDisponibles -= media.ExemplairesDisponibles;
            }
        }
        return library;
    }
}