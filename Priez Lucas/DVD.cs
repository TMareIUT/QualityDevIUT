using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premiercours
{
    public class DVD : Media
    {
        private string duree;
    
        public DVD(string titre, int noReference, int nbExemplairesDispo, string duree) : base(titre, noReference, nbExemplairesDispo)
        {
            this.duree = duree;
        }
    
        public override void AfficheInfo()
        {
            base.AfficheInfo();
            Console.WriteLine("Auteur : " + this.duree);
        }
    }
}
