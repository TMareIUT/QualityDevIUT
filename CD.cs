using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class CD : Media
    {
        public string Artiste;

        public CD(string titre, int numeroReference, int nombreExemplairesDisponibles, string artiste)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Artiste = artiste;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Artiste : {Artiste}");
        }
    }
}
