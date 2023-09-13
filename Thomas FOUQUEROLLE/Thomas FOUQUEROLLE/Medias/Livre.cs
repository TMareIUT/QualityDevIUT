using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD1;

namespace Thomas_FOUQUEROLLE.Medias
{
    public class Livre : Media
    {
        public string Auteur;

        public Livre(string titre, int numeroReference, int nombreExemplaires, string auteur) : base(titre, numeroReference, nombreExemplaires)
        {
            Auteur = auteur;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur: {Auteur}");
        }

    }
}
