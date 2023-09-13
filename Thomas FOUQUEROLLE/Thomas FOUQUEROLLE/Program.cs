using Thomas_FOUQUEROLLE;
using Thomas_FOUQUEROLLE.Medias;

namespace TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library bibliotheque = new Library();

            Livre livre_1 = new Livre("Deepside", 101, 25, "Sarah Epstein");
            DVD dvd_1 = new DVD("Batman", 102, 8, 148);
            CD cd_1 = new CD("Nevermind", 103, 1, "Nirvana");

            bibliotheque.AjouterMedia(livre_1);
            bibliotheque.AjouterMedia(dvd_1);
            bibliotheque.AjouterMedia(cd_1);

            Console.WriteLine("Informations sur le livre :");
            livre_1.AfficherInfos();

            Console.WriteLine("\nInformations sur le DVD :");
            dvd_1.AfficherInfos();

            Console.WriteLine("\nInformations sur le CD :");
            cd_1.AfficherInfos();

            Console.WriteLine("\n");

            bibliotheque.EmprunterMedia(livre_1);
            bibliotheque.EmprunterMedia(dvd_1);
            bibliotheque.EmprunterMedia(cd_1);

            Console.WriteLine("\n");

            Console.WriteLine("\nInformations sur le livre après l'emprunt :");
            livre_1.AfficherInfos();

            Console.WriteLine("\nInformations sur le DVD après l'emprunt :");
            dvd_1.AfficherInfos();

            Console.WriteLine("\nInformations sur le CD après l'emprunt :");
            cd_1.AfficherInfos();

            Console.WriteLine("\n");

            Console.WriteLine("Recherche de médias par titre ou artiste :");
            List<Media> resultatsRecherche = bibliotheque.RechercherMedia("Deepside");
            foreach (var media in resultatsRecherche)
            {
                media.AfficherInfos();
            }

            Console.WriteLine("\n");

            Console.WriteLine("Statistiques de la bibliothèque :");
            bibliotheque.AfficherStatistiques();

        }
    }
}