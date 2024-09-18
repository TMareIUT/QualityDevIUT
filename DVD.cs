using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class DVD : Media
    {
        public double Duree;

        public DVD(string titre, int numeroReference, int nombreExemplairesDisponibles, double duree)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Duree = duree;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Durée : {Duree} minutes");
        }
    }
}
