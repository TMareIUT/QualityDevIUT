using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_Gestion_de_librairie
{
    public class Emprunt
    {
        public Media Media;
        public string Utilisateur;
        public DateTime DateEmprunt;
        public DateTime DateRetour;
        public string Detail;

        //constructeur
        public Emprunt(Media media, string utilisateur, DateTime dateEmprunt, DateTime dateRetour, string detail)
        {
            Media = media;
            Utilisateur = utilisateur;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
            Detail = detail;
        }
    }
}
