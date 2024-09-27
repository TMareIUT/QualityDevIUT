using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionLibrairie
{
    public class Book : Media
    {
        public string author = "";
        public string editor = "";
        public int publicationYear;

        public void AfficherInfos()
        {
            Console.WriteLine("Titre : " + title);
            Console.WriteLine("Auteur : " + author);
            Console.WriteLine("Editeur : " + editor);
            Console.WriteLine("Année de publication : " + publicationYear);
            Console.WriteLine("Numéro de référence : " + refNumber);
            Console.WriteLine("Nombre d'exemplaires disponibles : "
                              + availableCopiesNumber
            );
        }
    }
}
