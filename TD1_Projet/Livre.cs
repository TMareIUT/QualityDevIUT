using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Projet
{
    public class Livre : Media
    {
        internal string auteur;

        //Constructeurs
        public Livre()
        {
            auteur = "";
        }

        public Livre(string titre, int numeroReference, int nombreExemplaires, string auteur) : base(titre, numeroReference, nombreExemplaires)
        {
            this.auteur = auteur;
        }


        //Méthode polymorphique d'affichage des infos
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur : {auteur}");
        }
    }
}
