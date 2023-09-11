using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours1.Exercice_3
{
    public class Emprunt
    {
        public string Utilisateur { get; set; }
        public Media Media { get; set; }

        public Emprunt(string utilisateur, Media media)
        {
            Utilisateur = utilisateur;
            Media = media;
        }

        public Emprunt this[Media media, string user]
        {
            get { return findEmpruntByMedia(Library.mediaEmprunté, media, user); }
        }

        public static Emprunt findEmpruntByMedia(List<Emprunt> emprunts, Media media, string user)
        {
            foreach (Emprunt emprunt in emprunts)
            {
                if (emprunt.Media == media && emprunt.Utilisateur == user)
                {
                    return emprunt;
                }
            }
            return null;
        }

        public static List<Media> getMediaBorrowByUser(List<Emprunt> emprunts, string user)
        {
            List<Media> temp = new List<Media>();
            foreach (Emprunt emprunt in emprunts)
            {
                if (emprunt.Utilisateur == user)
                {
                    temp.Add(emprunt.Media);
                }
            }
            return temp;
        }
    }
}
