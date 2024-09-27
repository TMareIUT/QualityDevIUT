using Code.LibraryManager;
using Data.Code.Medias;

class Program
{

    /// <summary>
    /// Programme principal permettant de lancer la gestion de la librairie
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Library library = new Library();
        RunTest(library);
    }   

    /// <summary>
    /// Run des exercices sur la librairie
    /// </summary>
    /// <param name="library"></param>
    public static void RunTest(Library library)
    {
        // Ajoutez quelques médias à la bibliothèque
        library.AjouterMedia(new Livre("Livre 1", 1, 5, "Auteur 1"));
        library.AjouterMedia(new Dvd("DVD 1", 2, 3, 120));
        library.AjouterMedia(new Cd("CD 1", 3, 2, "Artiste 1"));

        // Affichez tous les médias dans la bibliothèque
        Console.WriteLine("Médias dans la bibliothèque :");
        library.AfficherTousLesMedias();
        Console.WriteLine();

        // Empruntez un média
        try
        {
            Console.WriteLine("Tentative d'emprunt de Livre 1 par l'utilisateur 1 :");
            library.EmprunterMedia(library.RechercherMediaParTitre("Livre 1").FirstOrDefault(), "Utilisateur 1");
            Console.WriteLine("Emprunt réussi.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Erreur lors de l'emprunt : " + ex.Message);
        }

        // Affichez les médias empruntés par un utilisateur spécifique
        Console.WriteLine("\nMédias empruntés par l'utilisateur 1 :");
        var mediasEmpruntes = library.MediasEmpruntesParUtilisateur("Utilisateur 1");
        foreach (Media media in mediasEmpruntes)
        {
            media.AfficherInfos();
            Console.WriteLine();
        }

        // Retournez un média
        Console.WriteLine("Retour du Livre 1 par l'utilisateur 1 :");
        library.RetournerEmprunt(library[library.RechercherEmpruntParNumeroDeReference(1, "Utilisateur 1").FirstOrDefault().GetMediaNumRef()]);
        Console.WriteLine("Retour effectué.");

        // Affichez tous les médias dans la bibliothèque après l'emprunt et le retour
        Console.WriteLine("\nMédias dans la bibliothèque après l'emprunt et le retour :");
        library.AfficherTousLesMedias();

        // Sauvegardez l'état de la bibliothèque dans un fichier JSON
        library.SaveLibrary();
        Console.WriteLine("\nÉtat de la bibliothèque sauvegardé dans le fichier 'bibliotheque.json'.");

        library = new Library();
        // Chargez la bibliothèque à partir du fichier JSON
        library.LoadLibrary();
        Console.WriteLine("\nÉtat de la bibliothèque chargé à partir du fichier 'bibliotheque.json'.");

        // Affichez tous les médias dans la bibliothèque après le chargement
        Console.WriteLine("\nMédias dans la bibliothèque après le chargement :");
        library.AfficherTousLesMedias();
        Console.WriteLine("\nEmprunt fait à la bibliothèque après le chargement :");
        library.AfficherTousLesEmprunts();

        Console.ReadKey();
        }
    }
