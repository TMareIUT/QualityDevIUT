using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class Media
    {
        public string Titre;

        public int NumeroReference;

        public int NombreExemplairesDisponibles;

        public Media(string titre, int numeroReference, int nombreExemplairesDisponibles)
        {
            Titre = titre;
            NumeroReference = numeroReference;
            NombreExemplairesDisponibles = nombreExemplairesDisponibles;
        }

        public virtual void AfficherDetails()
        {
            Console.WriteLine($"Titre : {Titre}");
            Console.WriteLine($"Numéro de référence : {NumeroReference}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {NombreExemplairesDisponibles}");
        }
    }
}
