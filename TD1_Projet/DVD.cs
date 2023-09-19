using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Projet
{
    public class DVD : Media
    {
        internal int duree;

        //Constructeurs
        public DVD()
        {
            duree = 0;
        }

        public DVD(string titre, int numeroReference, int nombreExemplaires, int duree) : base(titre, numeroReference, nombreExemplaires)
        {
            this.duree = duree;
        }


        //Méthode polymorphique d'affichage des infos
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée : {duree}");
        }
    }
}
