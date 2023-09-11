using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Projet
{
    public class Emprunt
    {
        public Media media { get; }
        public DateTime dateEmprunt { get; }
        public string utilisateur { get; }

        public Emprunt(Media media, DateTime dateEmprunt, string utilisateur)
        {
            this.media = media;
            this.dateEmprunt = dateEmprunt;
            this.utilisateur = utilisateur;
        }
    }
}
