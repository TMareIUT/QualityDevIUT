namespace TP_Gestion_de_librairie
{
	public class Emprunt
	{

        public Media MediaEmprunte { get; set; }
        public string NomEmprunteur { get; set; }
        public DateTime DateEmprunt { get; set; }

        public Emprunt(Media mediaEmprunte, string nomEmprunteur, DateTime dateEmprunt)
        {
            MediaEmprunte = mediaEmprunte;
            NomEmprunteur = nomEmprunteur;
            DateEmprunt = dateEmprunt;
        }

    }
}

