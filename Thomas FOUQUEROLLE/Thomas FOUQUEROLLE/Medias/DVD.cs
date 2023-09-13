using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thomas_FOUQUEROLLE.Medias
{
    public class DVD : Media
    {
        public int Duree;

        public DVD(string titre, int numeroReference, int nombreExemplaires, int duree) : base(titre, numeroReference, nombreExemplaires)
        {
            Duree = duree;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Duree: {Duree}");
        }
    }
}
