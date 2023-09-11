using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours1
{
    internal class DVD : Media
    {

        protected string Durée;

        public DVD(string titre, string durée, int numero, int nombre) : base(titre, numero, nombre)
        {
            this.Durée = durée;
        }

        public override void Afficherinfos()
        {
            Console.WriteLine(Titre + " : " + Numero + " : " + Nombre + " : " + Durée);
        }
    }
}
