/* Partie 1 : Classes, Héritage et Polymorphisme */

public class Media
{
    protected string titre;
    protected int numRef;
    protected int numExempDispo;

    public Media(string titre, int numRef, int numExempDispo)
    {
        this.titre = titre;
        this.numRef = numRef;
        this.numExempDispo = numExempDispo;
    }

    public virtual void AfficherInfos()
    {
        Console.Write($"Media: {{ titre: {titre}, numRef: {numRef}, numExempDispo: {numExempDispo} }}");
    }

    public static Media operator +(Media media1, Media media2)
    {
        
    }
}

public class Livre : Media
{
    private string auteur;

    public Livre(string titre, int numRef, int numExempDispo, string auteur) : base(titre, numRef, numExempDispo)
    {
        this.auteur = auteur;
    }

    public override void AfficherInfos()
    {
        Console.Write("Livre: { ");
        base.AfficherInfos();
        Console.Write($", auteur: {auteur}");
        Console.Write(" }\n");
    }
}

public class DVD : Media
{
    private TimeSpan duree;

    public DVD(string titre, int numRef, int numExempDispo, TimeSpan duree) : base(titre, numRef, numExempDispo)
    {
        this.duree = duree;
    }

    public override void AfficherInfos()
    {
        Console.Write("DVD: { ");
        base.AfficherInfos();
        Console.Write($", duree: {duree}");
        Console.Write(" }\n");
    }
}

public class CD : Media
{
    private string artiste;

    public CD(string titre, int numRef, int numExempDispo, string artiste) : base(titre, numRef, numExempDispo)
    {
        this.artiste = artiste;
    }

    public override void AfficherInfos()
    {
        Console.Write("CD: { ");
        base.AfficherInfos();
        Console.Write($", artiste: {artiste}");
        Console.Write(" }\n");
    }
}

/* Partie 2 : Surcharge des opérateurs */

public class Tools
{
}

public class MonMain
{
    static void Main(string[] args)
    {
        Livre unLivre = new Livre("Mon Livre", 85695, 10, "Moi");
        unLivre.AfficherInfos();

        TimeSpan dureeMonDVD = new TimeSpan(1, 2, 3);
        DVD unDVD = new DVD("Mon DVD", 88255, 5, dureeMonDVD);
        unDVD.AfficherInfos();

        CD unCD = new CD("Mon CD", 14692, 3, "Moi");
        unCD.AfficherInfos();
    }
}