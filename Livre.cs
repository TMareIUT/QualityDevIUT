using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class Livre : Media
    {
        public string Auteur;

        public Livre(string titre, int numeroReference, int nombreExemplairesDisponibles, string auteur)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Auteur = auteur;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Auteur : {Auteur}");
        }
    }
}
