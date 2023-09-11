using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premiercours
{
    public class Media
    {
        private string titre;

        private int noReference;

        private int nbExemplairesDispo;

        /// <summary>
        /// Constructeur de la classe Média
        /// </summary>
        /// <param name="titre">Le titre du média</param>
        /// <param name="noReference">Le numéro de référence</param>
        /// <param name="nbExemplairesDispo">Le nombre d'exemplaire disponnible</param>
        public Media(string titre, int noReference, int nbExemplairesDispo)
        {
            this.titre = titre;
            this.noReference = noReference;
            this.nbExemplairesDispo = nbExemplairesDispo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTitre()
        {
            return this.titre;
        }

        public int getNoReference()
        {
            return this.noReference;
        }

        public int getNbExemplaire()
        {
            return this.nbExemplairesDispo;
        }

        public virtual void AfficheInfo()
        {
            Console.WriteLine("Titre : " + this.getTitre() +
                                "\nNuméro de références : " + this.getNoReference() +
                                "\nNombres d'exemplaires disponibles : " + this.getNbExemplaire());
        }


    }
}