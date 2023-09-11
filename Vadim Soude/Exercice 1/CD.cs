using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours1
{
    internal class CD : Media
    {

        protected string Artiste;

        public CD(string titre, string artiste, int numero, int nombre) : base(titre, numero, nombre)
        {
            this.Artiste = artiste;
        }

        public override void Afficherinfos()
        {
            Console.WriteLine(Titre + " : " + Numero + " : " + Nombre + " : " + Artiste);
        }
    }
}
