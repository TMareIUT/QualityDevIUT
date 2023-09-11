namespace TP_Gestion_de_librairie
{
    public class DVD : Media
	{

        public int Duree { get; set; }

        public DVD(string titre, int numeroReference, int exemplairesDisponibles, int duree)
            : base(titre, numeroReference, exemplairesDisponibles)
        {
            Duree = duree;
        }

        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée: {Duree} minutes");
        }

    }
}

