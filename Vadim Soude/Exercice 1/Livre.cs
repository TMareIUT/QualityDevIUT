using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours1
{
    public class Livre : Media
    {

        protected string Auteur;

        public Livre(string titre, string auteur, int numero, int nombre) : base(titre, numero, nombre)
        {
            this.Auteur = auteur;
        }

        public override void Afficherinfos()
        {
            Console.WriteLine(Titre + " : " + Numero + " : " + Nombre + " : " + Auteur);
        }
    }
}
