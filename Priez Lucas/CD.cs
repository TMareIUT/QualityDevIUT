using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premiercours
{
    public class CD : Media
    {
        
        private string artiste;

        public CD(string titre, int noReference, int nbExemplairesDispo, string artiste) : base(titre, noReference, nbExemplairesDispo)
        {
            this.artiste = artiste;
        }


        public void AfficherInfo()
        {
            Console.WriteLine("Titre : " + this.getTitre() +
                                "\nNuméro de références : " + this.getNoReference() +
                                "\nNombres d'exemplaires disponibles : " + this.getNbExemplaire() +
                                "\nAuteur : " + this.artiste);
        }

        public override void AfficheInfo()
        {
            base.AfficheInfo();
            Console.WriteLine("Auteur : " + this.artiste);
        }
        
    }
}
