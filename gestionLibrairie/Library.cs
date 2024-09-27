using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace gestionLibrairie
{
    public class Library
    {
        public List<Media> librairie = new List<Media>();

        public Media? this[int refNumber]
        {
            get
            {
                foreach (Media media in librairie)
                {
                    if (media.refNumber == refNumber)
                    {
                        return media;
                    }
                }
                return null;
            }
        }

        public void AddMedia(Media media)
        {
            librairie.Add(media);
            media.availableCopiesNumber++;
        }

        public void RemoveMedia(int refNumber)
        {
            Media? media = this[refNumber];
            if (media != null)
            {
                librairie.Remove(media);
                media.availableCopiesNumber--;
            }
        }

        public void BorrowMedia(int refNumber)
        {
            Media? media = this[refNumber];
            if (media != null)
            {
                if (media.availableCopiesNumber > 0)
                {
                    media.availableCopiesNumber--;
                    Console.WriteLine("L'emprunt a été effectué avec succès.");
                }
            }
        }

        public void ReturnMedia(int refNumber)
        {
            Media? media = this[refNumber];
            if (media != null)
            {
                media.availableCopiesNumber++;
                Console.WriteLine("Le retour a été effectué avec succès.");
            }
        }

        public void FindMedia(string filter)
        {
            foreach (Media media in librairie)
            {
                if (media.title == filter 
                    || media is Book book && book.author == filter
                    || media is DVD dvd && dvd.director == filter
                    || media is CD cd && cd.artist == filter
                    )
                {
                    media.AfficherInfos();
                }
            }
        }
    }
}
