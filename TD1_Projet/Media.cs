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
        public String titre { get; set; }
        public int numeroReference { get; set; }
        public int nombreExemplaires { get; set; }

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


        //Fonction polymorphique d'affichage des infos
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre : {titre}");
            Console.WriteLine($"Numéro de référence : {numeroReference}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {nombreExemplaires}");
        }
    }


    public class Livre : Media
    {
        public string auteur { get; set; }

        //Constructeurs
        public Livre()
        {
            auteur = "";
        }

        public Livre(string titre, int numeroReference, int nombreExemplaires, string auteur) : base(titre, numeroReference, nombreExemplaires)
        {
            this.auteur = auteur;
        }


        //Fonction polymorphique d'affichage des infos
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur : {auteur}");
        }
    }
    public class DVD : Media
    {
        public int duree { get; set; }

        //Constructeurs
        public DVD()
        {
            duree = 0;
        }

        public DVD(string titre, int numeroReference, int nombreExemplaires, int duree) : base(titre, numeroReference, nombreExemplaires)
        {
            this.duree = duree;
        }
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée : {duree}");
        }
    }

    public class CD : Media
    {
        public string artiste { get; set; }

        //Constructeurs
        public CD()
        {
            artiste = "";
        }

        public CD(string titre, int numeroReference, int nombreExemplaires, string artiste) : base(titre, numeroReference, nombreExemplaires)
        {
            this.artiste = artiste;
        }


        //Fonction polymorphique d'affichage des infos
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste : {artiste}");
        }
    }
}