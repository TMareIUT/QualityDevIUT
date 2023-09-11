using TP_Gestion_de_librairie;

internal class Program
{

    private static void Main()
    {
        Library library = Library.Deserialiser() ?? Init();

        library.Emprunter(123, "Antoine");

        library.Serialiser();
    }

    private static Library Init()
    {

        Media livre = new Livre("Le Seigneur des Anneaux", 12345, 1, "J.R.R. Tolkien");
        Media cd = new CD("Abbey Road", 123456, 1, "The Beatles");
        Library library = new();
        livre += 10;
        library.AjouterMedia(livre);
        library.AjouterMedia(cd);
        library.Serialiser();
        return library;
    }

}