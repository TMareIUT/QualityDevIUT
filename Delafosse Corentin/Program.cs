//permet de convertir un objet en JSON et de le sauvegarder dans un fichier
using Exercice_Gestion_de_librairie;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//main
namespace Exercice_Gestion_de_librairie
{
    public class MainTest
    {
        static void Main(string[] args)
        {
            //créer instance de library et ajouter medias avec +
            Library library = new Library();

            try
            {
                //effectuer des opérations d'emprunt et de retour avec des try catch
                library += new Livre { Titre = "Livre1", Auteur = "Auteur1", Genre = "Genre1", NumeroReference = 1, NombreExemplaire = 1 };
                library += new Livre { Titre = "Livre2", Auteur = "Auteur2", Genre = "Genre2", NumeroReference = 2, NombreExemplaire = 2 };
                library += new DVD { Titre = "DVD1", Duree = 1, NumeroReference = 3, NombreExemplaire = 3 };
                library += new DVD { Titre = "DVD2", Duree = 2, NumeroReference = 4, NombreExemplaire = 4 };
                library += new CD { Titre = "CD1", Artiste = "Artiste1", NumeroReference = 5, NombreExemplaire = 5 };

                //emprunter un media
                library.Emprunter(library.Find("Livre1"), "Utilisateur1", DateTime.Now, DateTime.Now.AddDays(7), "Detail1");
                library.Emprunter(library.Find("Livre1"), "Utilisateur2", DateTime.Now, DateTime.Now.AddDays(7), "Detail2");
                library.Emprunter(library.Find("Livre2"), "Utilisateur1", DateTime.Now, DateTime.Now.AddDays(7), "Detail3");

                //retourner un media
                library.Retourner(library.Find("Livre1"), "Utilisateur1");


                //afficher les infos de chaque media
                foreach (Media media in library.Medias)
                {
                    media.AfficherInfos();
                }

                Console.WriteLine("--------------------------------------------------");

                //sauvegarder puis charger la bibliothèque et afficher les infos sauvegarder
                library.Save("library.json");
                library.Load("library.json");
                foreach (Media media in library.Medias)
                {
                    media.AfficherInfos();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}


/*public class Tools
{
    //surchage de l'opérateur + pour ajouter un media à la bibliothèque
    public static Library operator +(Library l, Media media)
    {
        Library library = l;
        library.Ajouter(media);
        return library;
    }

    //surcharge de l'opérateur - pour retirer un media de la bibliothèque avec gestion d'erreur
    public static Library operator -(Library library, Media media)
    {
        if (media.NombreExemplaire > 0)
        {   
            library.Retirer(media);
            //retirer les emprunts du media retirer
            foreach (Emprunt emprunt in library.Emprunts)
            {
                if (emprunt.Media.Titre == media.Titre)
                {
                    library.Emprunts.Remove(emprunt);
                }
            }
        }
        else
        {
            Console.WriteLine("Erreur : Nombre d'exemplaire < 0");
        }
        return library;
    }
}

*/