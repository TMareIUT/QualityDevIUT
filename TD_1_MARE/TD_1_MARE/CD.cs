using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_1_MARE
{
    internal class CD : Media
    {
        private string artiste;

        public CD(string artiste, string titre, int reference, int nombreExemplaireDispo) : base(titre, reference, nombreExemplaireDispo)
        {
            this.artiste = artiste;
        }
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine("Artiste : " + artiste);
        }
    }
}
