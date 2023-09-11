using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_1_MARE
{
    internal class Livre : Media
    {
        public string auteur;

        public Livre(string auteur, string titre, int reference, int nombreExemplaireDispo) : base(titre, reference, nombreExemplaireDispo)
        {
            this.auteur = auteur;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine("Auteur du livre : " + auteur);
        }
    }
}
