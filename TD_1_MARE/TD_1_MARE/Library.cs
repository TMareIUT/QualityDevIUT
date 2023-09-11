using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_1_MARE
{
    internal class Library
    {
        private List<Media> library { get; set; } = new List<Media>();

        private List<Emprunt> listEmprunts { get; set; } = new List<Emprunt>();

        public void AddMedia(Media media)
        {
            library.Add(media);
        }

        public void RemoveMedia(Media media)
        {
            library.Remove(media);
        }

        public Emprunt? EmprunterMedia(Media media, String nomEmprunteur)
        {
            if (media.nombreExemplaireDispo > 0)
            {
                media.nombreExemplaireDispo--;
                Emprunt nouvelEmprunt = new Emprunt(media, nomEmprunteur);
                listEmprunts.Add(nouvelEmprunt);
                return nouvelEmprunt;
            }
            return null;
        }

        public Boolean RetourMedia(Emprunt emprunt)
        {
            if (listEmprunts.Contains(emprunt))
            {
                emprunt.mediaEmprunte.nombreExemplaireDispo++;
                listEmprunts.Remove(emprunt); return true;
            }
            return false;
            
        }

        public Media? RechercheMedia(String saisieRecherche)
        {
            foreach (Media media in library)
            {
                if(saisieRecherche == media.titre || saisieRecherche == media.reference.ToString())
                {
                    return media;
                }
            }
            return null;
        }
      
    }
}
