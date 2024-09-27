namespace gestionLibrairie
{
    public class Media
    {
        public string title = "";
        public int refNumber;
        public int availableCopiesNumber;

        public void AfficherInfos()
        {
            Console.WriteLine("Titre : " + title);
            Console.WriteLine("Numéro de référence : " + refNumber);
            Console.WriteLine("Nombre d'exemplaires disponibles : "
                              + availableCopiesNumber
            );
        }
    }
}
