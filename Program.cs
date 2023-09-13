using System.Collections.Generic;

namespace gestion_livres;

class Media
{
    protected string? titre;
    protected int num_ref;
    protected int remaining;
}

class Livre : Media
{
    private string author;

    public Livre(string titre, int numref, int remaining, string author)
    {
        this.titre = titre;
        this.num_ref = numref;
        this.remaining = remaining;
        this.author = author;
    }

    void AfficherInfos()
    {
        Console.WriteLine($"Titre: {this.titre}");
        Console.WriteLine($"Numéro de référence: {this.num_ref}");
        Console.WriteLine($"Nb d'exemplaires restant: {this.remaining}");
        Console.WriteLine($"Auteur: {this.author}");
    }
}

class DVD : Media
{
    private int duration;

    public DVD(string titre, int numref, int remaining, int duration)
    {
        this.titre = titre;
        this.num_ref = numref;
        this.remaining = remaining;
        this.duration = duration;
    }

    void AfficherInfos()
    {
        Console.WriteLine($"Titre: {this.titre}");
        Console.WriteLine($"Numéro de référence: {this.num_ref}");
        Console.WriteLine($"Nb d'exemplaires restant: {this.remaining}");
        Console.WriteLine($"Durée (en s): {this.duration}");
    }
}

class CD : Media
{
    private string artist;

    public CD(string titre, int numref, int remaining, string artist)
    {
        this.titre = titre;
        this.num_ref = numref;
        this.remaining = remaining;
        this.artist = artist;
    }

    public void AfficherInfos()
    {
        Console.WriteLine($"Titre: {this.titre}");
        Console.WriteLine($"Numéro de référence: {this.num_ref}");
        Console.WriteLine($"Nb d'exemplaires restant: {this.remaining}");
        Console.WriteLine($"Artiste: {this.artist}");
    }
}

class Library
{
    private List<Media> medias;

    public Library()
    {
        medias = new List<Media>();
    }

    public void Add(Media mediaToAdd)
    {
        medias.Add(mediaToAdd);
    }
}

class Program
{
    static void Main(string[] args)
    {

    }
}
