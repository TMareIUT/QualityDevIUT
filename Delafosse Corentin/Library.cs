using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_Gestion_de_librairie
{
    public class Library
    {
        public List<Media> Medias = new List<Media>();

        public List<Emprunt> Emprunts = new List<Emprunt>();

        //indexeur
        public Media this[int index]
        {
            get
            {
                return Medias[index];
            }
            set
            {
                Medias[index] = value;
            }
        }

        public void Ajouter(Media media)
        {
            Medias.Add(media);
        }

        public void Retirer(Media media)
        {
            Medias.Remove(media);
        }

        //emprunter un media
        public void Emprunter(Media media, string utilisateur, DateTime dateEmprunt, DateTime dateRetour, string detail)
        {
            //ajouter des exceptions pour gérer les erreurs
            try
            {
                //vérifier si il y a des exemplaires disponible
                if (media.NombreExemplaire > 0)
                {
                    media.NombreExemplaire--;
                    Emprunts.Add(new Emprunt(media, utilisateur, dateEmprunt, dateRetour, detail));
                }
                else
                {
                    throw new Exception("Erreur : Plus d'exemplaire disponible");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //retourner un media
        public void Retourner(Media media, string utilisateur)
        {
            try
            {
                media.NombreExemplaire++;
                //retirer l'emprunt du media retourner
                foreach (Emprunt emprunt in Emprunts)
                {
                    if (emprunt.Media.Titre == media.Titre && emprunt.Utilisateur == utilisateur)
                    {
                        //vérifier si la date de retour est dépasser
                        if (emprunt.DateRetour < DateTime.Now)
                        {
                            throw new Exception("Erreur : Date de retour dépasser");
                        }
                        else
                        {
                            Emprunts.Remove(emprunt);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //find un media selon Titre
        public Media Find(string titre)
        {
            foreach (Media media in Medias)
            {
                if (media.Titre == titre)
                {
                    return media;
                }
            }
            return null;
        }

        //lister les medias emprunter par un utilisateur
        public List<Media> List(string utilisateur)
        {
            List<Media> medias = new List<Media>();
            foreach (Emprunt emprunt in Emprunts)
            {
                if (emprunt.Utilisateur == utilisateur)
                {
                    medias.Add(emprunt.Media);
                }
            }
            return medias;
        }

        //afficher les stats de la bibliotheque
        public void Stats()
        {
            Console.WriteLine("Nombre de medias : " + Medias.Count);
            foreach (Media media in Medias)
            {
                Console.WriteLine("Titre : " + media.Titre);
                Console.WriteLine("Nombre d'exemplaire disponible : " + media.NombreExemplaire);

                //afficher le nombre d'exemplaire emprunter
                int nbEmprunter = 0;
                foreach (Emprunt emprunt in Emprunts)
                {
                    if (emprunt.Media.Titre == media.Titre)
                    {
                        nbEmprunter++;
                    }
                }
                Console.WriteLine("Nombre d'exemplaire emprunter : " + nbEmprunter);
            }
        }


        //sauvegarder la bibliotheque dans un fichier JSON
        public void Save(string path)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }

        //charger la bibliotheque depuis un fichier JSON
        public void Load(string path)
        {
            string json = File.ReadAllText(path);
            Library library = JsonConvert.DeserializeObject<Library>(json);
            Medias = library.Medias;
            Emprunts = library.Emprunts;
        }


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
}
