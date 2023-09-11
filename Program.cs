using System;
using System.IO;
using System.Text.Json;
public class Media
{
    private string Titre { get; }
    private int Numero_reference;
    private int Nb_exemplaire_dispo;
        public virtual void info_media()
        {
            Console.Out.Write("Titre :" + Titre);
            Console.Out.Write("Numero_reference:" + Numero_reference);
            Console.Out.Write("Nb_dispo :" + Nb_exemplaire_dispo);
        }
}

public class Livre : Media
{
    private string auteur;
    public Livre()
    {
        auteur = "auteur";
    }

    public virtual void info_livre()
    {
        Console.Out.Write("Auteur:" + auteur);
    }
}

public class DVD : Media
{
    private int duree;
    public DVD()
    {
        duree = 0;
    }
    public virtual void info_dvd()
    {
        Console.Out.Write("Durée:" + duree);
    }
}

public class CD : Media
{
    private string artiste;
    public CD()
    {
        artiste = "auteur";
    }

    public virtual void info_cd()
    {
        Console.Out.Write("Artiste:" + artiste);
    }
}

public class Library
{
    public List<Media> MediaCollection { get; set; }

    public Library()
    {
        MediaCollection = new List<Media>();
    }

    public Media this[int index]
    {
        get { return MediaCollection[index]; }
        set { MediaCollection[index] = value; }
    }

    public void Remove(Media media) //Suppresion media
    {
        if (MediaCollection.Contains(media))
        {
            MediaCollection.Remove(media);
        }
        else
        {
            throw new Exception("Media exite pas");
        }
    }
    public void AddMedia(Media media) //Ajout media
    {
        MediaCollection.Add(media);
    }

    public void ReturnMedia(Media media)
    {
        var record = MediaCollection.Find(r == media);
        MediaCollection.Remove(record);
    }
    static void Main(string[] args)
    {
        Media myLibrary = new Media();
        myLibrary = new Media();
    }

    public void js()  //Json
    {
        Media myLibrary = new Media();
        myLibrary = new Media();

        string jsonString = "";

        string fileName = "library.json";
        File.WriteAllText(fileName, jsonString);
        Console.WriteLine("Saved JSON to file: " + fileName);

        jsonString = File.ReadAllText(fileName);
        Console.WriteLine("Loaded JSON from file: " + fileName);
        foreach (var media in myLibrary)
        {
            media.DisplayInfo();
        }
    }
}