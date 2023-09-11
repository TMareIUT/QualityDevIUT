namespace TP_Gestion_de_librairie
{
    public class CD : Media
	{

        public string Artiste { get; set; }

        public CD(string titre, int numeroReference, int exemplairesDisponibles, string artiste)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Artiste = artiste;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste: {Artiste}");
        }

        public override bool EstRecherche(string critere)
        {
            return base.EstRecherche(critere) || Artiste.Contains(critere, StringComparison.OrdinalIgnoreCase);
        }

    }
}

