namespace TP_Gestion_de_librairie
{
    public class Media
	{

        public string Titre { get; set; }
        public int NumeroReference { get; set; }
        public int ExemplairesDisponibles { get; set; }

        public Media(string titre, int numeroReference, int exemplairesDisponibles)
        {
            Titre = titre;
            NumeroReference = numeroReference;
            ExemplairesDisponibles = exemplairesDisponibles;
        }

        public virtual bool EstRecherche(string critere)
        {
            return NumeroReference.ToString().Contains(critere)
                || Titre.Contains(critere, StringComparison.OrdinalIgnoreCase);
        }

        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre: {Titre}");
            Console.WriteLine($"Numéro de Référence: {NumeroReference}");
            Console.WriteLine($"Exemplaires Disponibles: {ExemplairesDisponibles}");
        }

        public static Media operator +(Media library, int numToAdd)
        {
            if (numToAdd <= 0)
            {
                throw new ArgumentException("Le nombre d'exemplaires à ajouter doit être supérieur à zéro.");
            }

            library.ExemplairesDisponibles += numToAdd;
            return library;
        }

        public static Media operator -(Media library, int numToRemove)
        {
            if (numToRemove <= 0)
            {
                throw new ArgumentException("Le nombre d'exemplaires à retirer doit être supérieur à zéro.");
            }

            if (numToRemove > library.ExemplairesDisponibles)
            {
                throw new InvalidOperationException("Le nombre d'exemplaires à retirer est supérieur au nombre d'exemplaires disponibles.");
            }

            library.ExemplairesDisponibles -= numToRemove;
            return library;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Media)
            {
                return false;
            }
            Media media = (Media)obj;
            return NumeroReference == media.NumeroReference;
        }

        public override int GetHashCode()
        {
            return NumeroReference.GetHashCode();
        }

    }
}

