using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thomas_FOUQUEROLLE.Medias
{
    public class CD : Media
    {
        public string Artiste;

        public CD(string titre, int numeroReference, int nombreExemplaires, string artiste) : base(titre, numeroReference, nombreExemplaires)
        {
            Artiste = artiste;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste: {Artiste}");
        }
    }
}
