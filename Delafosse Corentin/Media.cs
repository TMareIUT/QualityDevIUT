using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_Gestion_de_librairie
{
    public class Media
    {
        public string Titre;
        public int NumeroReference;
        public int NombreExemplaire;

        //permet d'afficher les infos d'un media
        public virtual void AfficherInfos()
        {
            Console.WriteLine("Titre : " + Titre);
            Console.WriteLine("Numero de reference : " + NumeroReference);
            Console.WriteLine("Nombre d'exemplaire : " + NombreExemplaire);
        }
    }
}
