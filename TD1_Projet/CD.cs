using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Projet
{
    public class CD : Media
    {
        internal string artiste;

        //Constructeurs
        public CD()
        {
            artiste = "";
        }

        public CD(string titre, int numeroReference, int nombreExemplaires, string artiste) : base(titre, numeroReference, nombreExemplaires)
        {
            this.artiste = artiste;
        }


        //Méthode polymorphique d'affichage des infos
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste : {artiste}");
        }
    }
}
