using System.Reflection;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

public class Media
{
    public string Title;
    public int NumRef;
    public int NbDispo;
    public int NbMax;

    public Media(int numRef, string title, int nbDispo, int nbMax)
    {
        Title = title;
        NbDispo = nbDispo;
        NumRef = numRef;
        NbMax = nbMax;
    }

    public virtual void AfficherInfos()
    {
        Console.WriteLine("Title : " + Title + ", Numéro de référence : " + NumRef + ", Nombre d'exemplaire disponible : " + NbDispo);
    }
}



public class Livre : Media
{
    private string Auteur;

    public Livre(int numRef, string auteur, string title, int nbDispo, int nbMax) :base(nbDispo,title,numRef,nbMax)
    {
        Auteur = auteur;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("Auteur : " + Auteur);
    }
}



public class DVD : Media
{
    private int DureeMin;

    public DVD(int numRef, int dureeMin, string title, int nbDispo, int nbMax) : base(nbDispo, title, numRef, nbMax)
    {
        DureeMin = dureeMin;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("Durée en minutes : " + DureeMin);
    }
}



public class CD : Media
{
    private string Artiste;

    public CD(int numRef, string artiste, string title, int nbDispo, int nbMax) : base(nbDispo, title, numRef, nbMax)
    {
        Artiste = artiste;
    }

    public override void AfficherInfos()
    {
        Console.WriteLine("Artiste : " + Artiste);
    }
}




public class Emprunt
{
    public Media MediaEmprunte { get; set; }
    public string Utilisateur { get; set; }
    public DateTime DateEmprunt { get; set; }
    public DateTime DateRetour { get; set; }
}



public class Library
{
    public List<Media> mediaCollection;
    public List<Emprunt> emprunts;

    public Library()
    {
        mediaCollection = new List<Media>();
        emprunts = new List<Emprunt>();
    }


    // Indexeur pour accéder aux médias par leur numéro de référence
    public Media this[int numRef]
    {
        get
        {
            return mediaCollection.Find(media => media.NumRef == numRef);
        }
    }

    public void AjouterMedia(Media media)
    {
        mediaCollection.Add(media);
    }

    public void RetirerMedia(int numRef)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.NumRef == numRef);
        if (media != null)
        {
            mediaCollection.Remove(media);
        }
    }
    public void EmprunterMedia(int numRef, string utilisateur)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.NumRef == numRef);
        if (media != null && media.NbDispo > 0)
        {
            media.NbDispo--;
            emprunts.Add(new Emprunt
            {
                MediaEmprunte = media,
                Utilisateur = utilisateur,
                DateEmprunt = DateTime.Now,
                DateRetour = DateTime.MinValue // La date de retour est initialement définie à MinValue
            });
            Console.WriteLine("Emprunt bien effectué");
        }
    }

    public void RetournerMedia(int numRef)
    {
        Emprunt emprunt = emprunts.FirstOrDefault(e => e.MediaEmprunte.NumRef == numRef && e.DateRetour == DateTime.MinValue);
        if (emprunt != null)
        {
            emprunt.DateRetour = DateTime.Now;
            emprunt.MediaEmprunte.NumRef++;
        }
    }

    public List<Media> RechercherMedia(string critere)
    {
        return mediaCollection.Where(m =>
            m.Title.Contains(critere, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Emprunt> ListeEmpruntsUtilisateur(string utilisateur)
    {
        return emprunts.Where(e => e.Utilisateur == utilisateur).ToList();
    }

    public void AfficherStatsBibliotheque()
    {
        int totalMedia = mediaCollection.Count;
        int nbEmprunts = emprunts.Count;
        int nbDispo = mediaCollection.Sum(m => m.NbDispo);

        Console.WriteLine("Statistiques de la bibliothèque :");
        Console.WriteLine($"- Nombre total de médias : {totalMedia}");
        Console.WriteLine($"- Nombre d'exemplaires empruntés : {nbEmprunts}");
        Console.WriteLine($"- Nombre d'exemplaires disponibles : {nbDispo}");
    }

    public static Library operator +(Library library, Media media)
    {
        if (media != null)
        {
            Media existingMedia = library[media.NumRef];
            if (existingMedia != null)
            {
                existingMedia.NbMax += 1;
                existingMedia.NbDispo += 1;
            }
            else
            {
                library.AjouterMedia(media);
            }
        }
        return library;
    }

    public static Library operator -(Library library, int referenceNumber)
    {
        Media media = library[referenceNumber];
        if (media != null)
        {
            if (media.NbDispo > 0)
            {
                media.NbMax -= 1;
                media.NbDispo -= 1;
                if (media.NbMax == 0)
                {
                    library.RetirerMedia(referenceNumber);
                }
            }
            else
            {
                throw new InvalidOperationException("Tous les exemplaires sont déjà empruntés.");
            }
        }
        else
        {
            throw new ArgumentException("Le média avec ce numéro de référence n'existe pas dans la bibliothèque.");
        }
        return library;
    }

    public void SauvegarderBibliothèque(string nomFichier)
    {
        var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(nomFichier, jsonData);
    }

    // Méthode pour charger la bibliothèque à partir d'un fichier JSON
    public static Library ChargerBibliothèque(string nomFichier)
    {
        if (File.Exists(nomFichier))
        {
            var jsonData = File.ReadAllText(nomFichier);
            return JsonConvert.DeserializeObject<Library>(jsonData);
        }
        else
        {
            throw new FileNotFoundException("Le fichier de sauvegarde de la bibliothèque n'a pas été trouvé.");
        }
    }
}


/*public class Tools
{
    public static Library operator +(Library library, Media media)
    {
        if (media != null)
        {
            Media existingMedia = library[media.NumRef];
            if (existingMedia != null)
            {
                existingMedia.NbMax += 1;
                existingMedia.NbDispo += 1;
            }
            else
            {
                library.AjouterMedia(media);
            }
        }
        return library;
    }

    public static Library operator -(Library library, int referenceNumber)
    {
        Media media = library[referenceNumber];
        if (media != null)
        {
            if (media.NbDispo > 0)
            {
                media.NbMax -= 1;
                media.NbDispo -= 1;
                if (media.NbMax == 0)
                {
                    library.RetirerMedia(referenceNumber);
                }
            }
            else
            {
                throw new InvalidOperationException("Tous les exemplaires sont déjà empruntés.");
            }
        }
        else
        {
            throw new ArgumentException("Le média avec ce numéro de référence n'existe pas dans la bibliothèque.");
        }
        return library;
    }

}*/











class Program
{
    static void Main()
    {
        // Création d'une instance de Library
        Library library = new Library();

        try
        {
            // Ajout de médias à la bibliothèque en utilisant l'opérateur "+"
            library += new Media(1, "Livre 1", 1,1);
            library += new Media(2, "CD 1", 3,3);
            library += new Media(3,"DVD 1", 4,4);

            // Emprunt de médias
            library.EmprunterMedia(1, "Utilisateur 1");
            library.EmprunterMedia(2, "Utilisateur 2");
            library.EmprunterMedia(3, "Utilisateur 3");

            // Tentative d'emprunter un média avec un nombre insuffisant d'exemplaires disponibles
            //library.EmprunterMedia(1, "Utilisateur 4");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }

        try
        {
            // Retour de médias
            library.RetournerMedia(1);
            library.RetournerMedia(2);
            library.RetournerMedia(3);

            // Tentative de retour d'un média déjà retourné
            library.RetournerMedia(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }

        // Affichage des informations de chaque média dans la bibliothèque
        foreach (Media media in library.mediaCollection)
        {
            media.AfficherInfos();

        }

        // Sauvegarde de la bibliothèque dans un fichier JSON
        library.SauvegarderBibliothèque("bibliotheque.json");

        // Chargement de la bibliothèque à partir du fichier JSON
        Library loadedLibrary = Library.ChargerBibliothèque("bibliotheque.json");

        Console.WriteLine("\nInformations de la bibliothèque chargée :");
        loadedLibrary.AfficherStatsBibliotheque();
    }
}