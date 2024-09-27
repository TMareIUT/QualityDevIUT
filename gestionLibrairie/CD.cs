using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionLibrairie
{
    public class CD : Media
    {
        public string artist = "";
        public int duration;

        public void AfficherInfos()
        {
            Console.WriteLine("Titre : " + title);
            Console.WriteLine("Artiste : " + artist);
            Console.WriteLine("Durée : " + duration);
            Console.WriteLine("Numéro de référence : " + refNumber);
            Console.WriteLine("Nombre d'exemplaires disponibles : "
                              + availableCopiesNumber
            );
        }
    }
}
