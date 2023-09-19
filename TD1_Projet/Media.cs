using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TD1_Projet;
using System.IO;
using Newtonsoft.Json;


namespace TD1_Projet
{
    //PARTIE 1
    public class Media
    {
        internal String titre;
        internal int numeroReference;
        internal int nombreExemplaires;

        //Constructeurs
        public Media()
        {
            titre = "";
            numeroReference = 0;
            nombreExemplaires = 0;
        }

        public Media(String titre, int numeroReference, int nombreExemplaires)
        {
            this.titre = titre;
            this.numeroReference = numeroReference;
            this.nombreExemplaires = nombreExemplaires;
        }


        //Méthode polymorphique d'affichage des infos
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre : {titre}");
            Console.WriteLine($"Numéro de référence : {numeroReference}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {nombreExemplaires}");
        }
    }
}