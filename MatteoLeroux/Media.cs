namespace QualiteDev1
{
    public class Media
    {
        public String titre;
        public int nref;
        public int nbEx;

        public Media(String titre, int nref, int nbEx)
        {
            this.titre = titre;
            this.nref = nref;
            this.nbEx = nbEx;
        }

        public Media(Media media)
        {
            this.titre = media.titre;
            this.nref = media.nref;
            this.nbEx = media.nbEx;
        }

        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre: {titre}");
            Console.WriteLine($"Numéro de Référence: {nref}");
            Console.WriteLine($"Exemplaires Disponibles: {nbEx}");
        }

        public static Media operator +(Media media1, Media media2)
        {
            if (media1.titre == media2.titre && media1.nref == media2.nref)
            {
                return new Media(media1.titre, media1.nref, media1.nbEx + media2.nbEx);
            }
            else
            {
                throw new InvalidOperationException("Les médias doivent avoir le même titre et numéro de référence pour être additionnés.");
            }
        }

        public static Media operator +(Media media1, int nbEx)
        {
            media1.nbEx += nbEx;
            return media1;
        }

        public static Media operator -(Media media1, int nbEx)
        {
            if (media1.nbEx >= nbEx)
            {
                media1.nbEx -= nbEx;
                return media1;
            }
            else
            {
                throw new InvalidOperationException("Nombre d'exemplaires insuffisant pour le retrait.");
            }
        }
    }

    public class Livre : Media
    {
        public String auteur;

        public Livre(String titre, int nref, int nbEx, String auteur)
            : base(titre, nref, nbEx)
        {
            this.auteur = auteur;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur: {auteur}");
        }
    }

    public class DVD : Media
    {
        public int duree;

        public DVD(String titre, int nref, int nbEx, int duree)
            : base(titre, nref, nbEx)
        {
            this.duree = duree;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée: {duree}");
        }
    }

    public class CD : Media
    {
        public String artiste;

        public CD(String titre, int nref, int nbEx, String artiste)
            : base(titre, nref, nbEx)
        {
            this.artiste = artiste;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste: {artiste}");
        }
    }

    public class Librairie
    {
        public List<Media> medias = new List<Media>();
        public List<Media> mediasEmpruntes = new List<Media>();

        // Indexeur pour accéder aux médias par leur numéro de référence
        public Media this[int numReference]
        {
            get
            {
                return medias.Find(media => media.nref == numReference);
            }
        }

        // Méthode pour ajouter un média à la bibliothèque
        public void AjouterMedia(Media media)
        {
            medias.Add(media);
        }

        // Méthode pour retirer un média de la bibliothèque
        public void RetirerMedia(Media media)
        {
            medias.Remove(media);
        }

        // Méthode pour emprunter un média de la bibliothèque
        public void EmprunterMedia(Media media)
        {
            if (media.nbEx > 0)
            {
                media.nbEx--;
                mediasEmpruntes.Add(media);
                Console.WriteLine($"Média \"{media.titre}\" emprunté.");
            }
            else
            {
                Console.WriteLine($"Le média \"{media.titre}\" n'est pas disponible pour l'emprunt.");
            }
        }

        // Méthode pour retourner un média emprunté
        public void RetournerMedia(Media media)
        {
            if (mediasEmpruntes.Contains(media))
            {
                media.nbEx++;
                mediasEmpruntes.Remove(media);
                Console.WriteLine($"Média \"{media.titre}\" retourné.");
            }
            else
            {
                Console.WriteLine($"Le média \"{media.titre}\" n'a pas été emprunté.");
            }
        }

        // Autres méthodes de gestion de la bibliothèque peuvent être ajoutées ici

        // Méthode pour afficher les médias dans la bibliothèque
        public void AfficherMedias()
        {
            Console.WriteLine("Médias dans la bibliothèque:");
            foreach (Media media in medias)
            {
                media.AfficherInfos();
                Console.WriteLine();
            }
        }

        // Méthode pour afficher les médias empruntés
        public void AfficherMediasEmpruntes()
        {
            Console.WriteLine("Médias empruntés:");
            foreach (Media media in mediasEmpruntes)
            {
                media.AfficherInfos();
                Console.WriteLine();
            }
        }



    }
}
