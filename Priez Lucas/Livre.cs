using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premiercours
{
    public class Livre : Media
    {
        private string auteur;
        
        public Livre(string titre, int noReference, int nbExemplairesDispo, string auteur) : base(titre, noReference, nbExemplairesDispo)
        {
            this.auteur = auteur;
        }
        
        public override void AfficheInfo()
        {
            base.AfficheInfo();
            Console.WriteLine("Auteur : " + this.auteur);
        }
    }
}
