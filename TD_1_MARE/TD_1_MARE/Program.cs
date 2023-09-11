using System;
using TD_1_MARE;

namespace Tp_gestion
{
    class Program
    {
        static void Main(string[] args)
        {
            Media livre = new Media("lelivre", 7, 10);
            Media livre2 = new Media("le livre 2", 1, 4);
            Media livre3 = new Media("un super livre", 2, 0);

            Library library = new Library();

            library.AddMedia(livre);
            library.AddMedia(livre2);
            library.AddMedia(livre3);

            String livreRecherche = Console.ReadLine();

            Emprunt emprunt = library.EmprunterMedia(livre, "Jayson");
            Console.WriteLine(emprunt.mediaEmprunte.titre);

            library.RetourMedia(emprunt);

            Media livretest = library.RechercheMedia(livreRecherche);
            Console.WriteLine(livretest.titre);


            livre.AfficherInfos();
            livre += 2;
            livre.AfficherInfos();
            livre -= 4;
            livre.AfficherInfos();
        }
    }
}
