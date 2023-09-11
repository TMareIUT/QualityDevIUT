namespace TP_Gestion_de_librairie
{
    public class Livre : Media
	{

        public string Auteur { get; set; }

        public Livre(string titre, int numeroReference, int exemplairesDisponibles, string auteur)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Auteur = auteur;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur: {Auteur}");
        }

        public override bool EstRecherche(string critere)
        {
            return base.EstRecherche(critere) || Auteur.Contains(critere, StringComparison.OrdinalIgnoreCase);
        }

    }
}

