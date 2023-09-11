namespace QualiteDev1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Livre livre = new Livre("Le Seigneur des Anneaux", 101, 5, "J.R.R. Tolkien");
            DVD dvd = new DVD("Inception", 102, 3, 148);
            CD cd = new CD("Thriller", 103, 7, "Michael Jackson");

            Console.WriteLine("Informations sur le Livre:");
            livre.AfficherInfos();

            Console.WriteLine("\nInformations sur le DVD:");
            dvd.AfficherInfos();

            Console.WriteLine("\nInformations sur le CD:");
            cd.AfficherInfos();

            Media media1 = new Media("Titre 1", 1, 5);
            Media media2 = new Media("Titre 1", 1, 3);
            Media resultat = media1 + media2; // Additionne les exemplaires de media1 et media2

            Console.WriteLine("\nNouveau nombre d'exemplaires : " + resultat.nbEx); // Affiche 8

            
        }
    }
}