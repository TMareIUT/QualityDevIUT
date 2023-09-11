namespace HelloWorld {
  class Program {
    public class Media { public string title { get; } public int reference { get; }
      public int stock { get; private set; }

      public Media(string p_title, int p_reference, int p_stock) {
        this.title = p_title;
        this.reference = p_reference;
        this.stock = p_stock;
      }

      public virtual void AfficherInfos()
     {
        Console.WriteLine($"{this.title}, {this.reference}, {this.stock}");
      }

      public static Media operator +(Media p_media_first, Media p_media_second) {
        if (p_media_first.reference == p_media_second.reference) {
          return new Media(p_media_first.title, p_media_first.reference, p_media_first.stock + p_media_second.stock);
        } else {
          throw new ArgumentException($"Media can't be add because not the same ref {p_media_first.reference} not the same as {p_media_second.reference}");
        }
      }

      public static Media operator -(Media p_media_first, Media p_media_second) {
        if (p_media_first.reference == p_media_first.reference) {
          return new Media(p_media_first.title, p_media_first.reference, p_media_first.stock - p_media_first.stock);
        } else {
          throw new ArgumentException($"Media can't be add because not the same ref {p_media_first.reference} not the same as {p_media_first.reference}");
        }
      }

      public static Media operator -(Media p_first_media, int p_number_delete) {
        if (p_first_media.stock > 0 && p_first_media.stock >= p_number_delete) {
          return new Media(p_first_media.title, p_first_media.reference, p_first_media.stock - p_number_delete);
        } else {
          throw new ArgumentException($"Media can't be substract because Stock is not correct");
        }
      }
    }

    public class Livre : Media {
      public string author { get; }

      public Livre(string p_title, int p_reference, int p_stock, string p_author) : base(p_title, p_reference, p_stock)
      {
        this.author = p_author;
      }

      public override void AfficherInfos()
      {
        Console.WriteLine($"{this.title}, {this.reference}, {this.stock}, {this.author}");
      }
    }

    public class Dvd : Media {
      public int duration { get; }

      public Dvd(string titleParams, int referenceParams, int stockParams, int durationParams) : base(titleParams, referenceParams, stockParams)
      {
        this.duration = durationParams;
      }

      public override void AfficherInfos()
      {
        Console.WriteLine($"{this.title}, {this.reference}, {this.stock}, {this.duration}");
      }
    }

    public class CD : Media {
      public string artist { get; }

      public CD(string titleParams, int referenceParams, int stockParams, string artistParams) : base(titleParams, referenceParams, stockParams)
      {
        this.artist = artistParams;
      }

      public override void AfficherInfos()
      {
        Console.WriteLine($"{this.title}, {this.reference}, {this.stock}, {this.artist}");
      }
    }

    public class Tools {
    }

    public class Customer {
      public string surname;
      public string name;
      public List<int> mediaBorrow = new List<int>();
    }

    public class Library {
      public List<Media> LibraryMedia = new List<Media>();

      public Media this[int index] {
        get { return LibraryMedia.FirstOrDefault(media => media.reference == index); } 
      }

      public void addMedia(string title,int reference, int stock) {
        Media mediaAdded = new Media(title,reference,stock);

        LibraryMedia.Add(mediaAdded);
      }

      public void addMedia(Media p_media) {
        try {
        LibraryMedia.Add(p_media);
        } catch (Exception e) {
          System.Console.WriteLine(e);
        }
      }

      public void deleteMedia(string p_title) {
        Media mediaToRemove = LibraryMedia.FirstOrDefault(media => media.title == p_title);

        LibraryMedia.Remove(mediaToRemove);
      }

      public void deleteMedia(int p_reference) {
        Media mediaToRemove = LibraryMedia.FirstOrDefault(media => media.reference == p_reference);

        LibraryMedia.Remove(mediaToRemove);
      }

      public void deleteMedia(Media p_media) {
        try {
        LibraryMedia.Remove(p_media);
        } catch (Exception e) {
          System.Console.WriteLine(e);
        }
      }

      public string borrowMedia(string title) {
        Media mediaToBorrow = LibraryMedia.FirstOrDefault(media => media.title == title);

        if (mediaToBorrow == null) {
          return "The media does'nt exist";
        }
      }

    }

    static void Main(string[] args)
    {
      Media saucisse = new Media("saucisse",0,2);
      Media deuxiemeSaucisse = new Media("deuxiemeSaucisse",1,2);
      // saucisse.AfficherInfos();
      // deuxiemeSaucisse.AfficherInfos();

      Media finalSaucisse = saucisse + saucisse;
      // finalSaucisse.AfficherInfos();

      saucisse = saucisse - 2;
      // saucisse.AfficherInfos();


      Library test = new Library();
      test.addMedia(saucisse);
    }
  }
}
