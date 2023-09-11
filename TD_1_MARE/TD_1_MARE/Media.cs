using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_1_MARE
{
    internal class Media
    {
        public string titre { get; set; }

        public int reference { get; set; }

        public int nombreExemplaireDispo { get; set; }

        public Media(string titre, int reference, int nombreExemplaireDispo)
        {
            this.titre = titre;
            this.reference = reference;
            this.nombreExemplaireDispo = nombreExemplaireDispo;
        }

        public static Media operator +(Media mediaAModifier, int aAjouter)
        {
            if (aAjouter <= 0)
            {
                throw new ArgumentException("Le nombre que vous avez tenter d'ajouter est inferieur ou égal a 0");
            }
            mediaAModifier.nombreExemplaireDispo += aAjouter;
            return mediaAModifier;
        }

        public static Media operator -(Media mediaAModifier, int aRetirer)
        {
            if (mediaAModifier.nombreExemplaireDispo <= aRetirer)
            {
                throw new ArgumentException("Vous avez tenté de retirer plus de livre que vous n'en avez de disponible");
            }
            mediaAModifier.nombreExemplaireDispo -= aRetirer;
            return mediaAModifier;
        }
        public virtual void AfficherInfos()
        {
            Console.WriteLine("Titre du média : " + titre);
            Console.WriteLine("Reference du média : " + reference);
            Console.WriteLine("Nombre d'exemplaire disponible du média : " + nombreExemplaireDispo);

        }
    }
}
