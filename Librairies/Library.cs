using Newtonsoft.Json;

namespace TP_Gestion_de_librairie
{
    public class Library
    {

        private static readonly string PATH = "/Users/antoine/Library/BUT/Gestion_de_librairie/cache.json";

        public static Library Deserialiser()
        {
            try
            {
                if (File.Exists(PATH))
                {
                    string json = File.ReadAllText(PATH);
                    return JsonConvert.DeserializeObject<Library>(json);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erreur lors de la désérialisation de la bibliothèque : {exception.Message}");
            }
            return null;
        }

        private static bool EstEmprunteur(Emprunt emprunt, string emprunteur)
        {
            return emprunt.NomEmprunteur.ToLower().Equals(emprunteur, StringComparison.OrdinalIgnoreCase);
        }

        [JsonProperty]
        private readonly List<Media> medias = new();
        [JsonProperty]
        private readonly List<Emprunt> emprunts = new();
        
        public Media this[int numeroReference]
        {
            get
            {
                return medias.FirstOrDefault(media => media.NumeroReference == numeroReference) ?? throw new Exception("Ce média n'existe pas !");
            }
        }

        public void AjouterMedia(Media media)
        {
            medias.Add(media);
        }

        public void RetirerMedia(Media media)
        {
            medias.Remove(media);
        }

        // Méthode pour emprunter un média (CD, DVD, Livre)
        public void Emprunter(int numeroReference, string emprunteur)
        {
            Media media = this[numeroReference]; // Récupérer le média selon le numéro de référence
            if (media.ExemplairesDisponibles <= 0) // Pas d'exemplaires disponibles
            {
                throw new Exception($"Le média '{media.Titre}' n'est pas disponible pour l'emprunt.");
            }
            media.ExemplairesDisponibles--; 
            Emprunt emprunt = new(media, emprunteur, DateTime.Now); // Instantiation d'un emprunt
            emprunts.Add(emprunt);
            Console.WriteLine($"Le média '{media.Titre}' a été emprunté par '{emprunteur}'.");
        }

        // Méthode pour retourner un média (CD, DVD, Livre) via son numéro de référence
        public void Retourner(int numeroReference, string emprunteur)
        {
            Media media = this[numeroReference];
            Emprunt emprunt = GetEmprunt(media, emprunteur);
            media.ExemplairesDisponibles++;
            emprunts.Remove(emprunt);
            Console.WriteLine($"Le média '{media.Titre}' a été retourné par '{emprunt.NomEmprunteur}'.");
        }

        // Méthode pour rechercher des médias selon un critère (ref, titre, artiste, auteur)
        public List<Media> Rechercher(string critere)
        {
            List<Media> mediasRecherches = new();
            mediasRecherches = medias
                .Where(media => media.EstRecherche(critere))
                .ToList();
            return mediasRecherches;
        }

        // Méthode pour récupérer la liste des médias empruntés par un utilisateur
        public List<Media> Emprunts(string emprunteur)
        {
            List<Media> medias = new();
            foreach (Emprunt emprunt in this.emprunts)
            {
                if (emprunt.NomEmprunteur.Equals(emprunteur, StringComparison.OrdinalIgnoreCase))
                {
                    medias.Add(emprunt.MediaEmprunte);
                }
            }
            return medias;
        }

        // Méthode pour voir les statistiques de la bibliothèque (nbrMédias, nbrEmprunts, médiasDispo)
        public void Statistiques()
        {
            int nbrMedias = medias.Count;
            int nbrEmprunts = emprunts.Count;
            int mediasDispo = medias.Select(media => media.ExemplairesDisponibles).Sum();
            Console.WriteLine($"Il y a {nbrMedias} média(s) dont {nbrEmprunts} emprunté(s) et {mediasDispo} disponible(s).");
        }

        // Méthode pour sauvegarder la librairie (médias et emprunts)
        public void Serialiser()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(PATH, json);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erreur lors de la sérialisation de la bibliothèque : {exception.Message}");
            }
        }

        // Méthode pour récupérer l'emprunt d'un utilisateur 
        private Emprunt GetEmprunt(Media media, string emprunteur)
        {
            return emprunts.FirstOrDefault(emprunt =>
                 emprunt.MediaEmprunte.Equals(media) && EstEmprunteur(emprunt, emprunteur)) ?? throw new Exception(
                            $"Le média '{media.Titre}' n'est pas emprunté par {emprunteur}.");
        }

    }
}

