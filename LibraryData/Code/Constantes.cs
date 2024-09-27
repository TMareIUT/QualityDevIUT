using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Code
{
    /// <summary>
    /// Classe de constantes du projet
    /// </summary>
    internal class Constantes
    {
        //Nom du fichier d'enregistrement du json de la librairie
        public readonly string NOM_FICHIER = "fileOfDataFromMyLibrary";
        //Constantes spécifiques à l'enregistrement des médias dans un json
        public readonly string KEY_MEDIAS = "MEDIAS";
        public readonly string KEY_LIVRE = "MEDIAS_LIVRES";
        public readonly string KEY_CD = "MEDIAS_CD";
        public readonly string KEY_DVD = "MEDIAS_DVD";
        public readonly string KEY_EMPRUNTS = "EMPRUNTS";
    }
}
