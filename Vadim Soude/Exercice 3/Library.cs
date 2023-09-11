using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace cours1.Exercice_3
{
    public class Library
    {

        public static List<Media> medias { get; set; } = new List<Media>();

        public static List<Emprunt> mediaEmprunté { get; set; } = new List<Emprunt>();

        public Library() {
        }

        public Media this[int numero]
        {
            get { return findMediaByNum(numero); }
        }

        public void storeDataToFile()
        {
            string data;
            string data2;
            data = JsonSerializer.Serialize(medias);
            data2 = JsonSerializer.Serialize(mediaEmprunté);
            File.WriteAllText(@"D:\BUT 3\Qualité dev\cours1\data.json", data);
            File.WriteAllText(@"D:\BUT 3\Qualité dev\cours1\data2.json", data2);
        }

        public void getDataFromFile()
        {
            string data;
            string data2;
            data = File.ReadAllText(@"D:\BUT 3\Qualité dev\cours1\data.json");
            data2 = File.ReadAllText(@"D:\BUT 3\Qualité dev\cours1\data2.json");
            if(data != "" && data != null)
            {
                medias = JsonSerializer.Deserialize<List<Media>>(data);
            }
            if (data2 != "" && data2 != null)
            {
                mediaEmprunté = JsonSerializer.Deserialize<List<Emprunt>>(data2);
            }
        }

        public static Media findMediaByNum(int numero)
        {
            foreach (Media media in medias)
            {
                if(media.Numero == numero)
                {
                    return media;
                }
            }
            return null;
            throw new Exception("No media had been found with this number");
        }

        public static List<Media> findMediaByName(string name)
        {
            List<Media> list = new List<Media>();

            foreach (Media media in medias)
            {
                if (media.Titre == name)
                {
                    list.Add(media);
                }
            }
            return list;
        }

        public void Add(Media media)
        {
            if(medias.Count > 0)
            {
                Media media1 = findMediaByNum(media.Numero);
                if (medias.Contains(media1))
                {
                    media1 += media;
                }
                else
                {
                    medias.Add(media);
                }
            }
            else
            {
                medias.Add(media);
            }
        }


        public void Remove(Media media)
        {
            Media media1 = findMediaByNum(media.Numero);
            if (medias.Contains(media1))
            {
                media1 -= media;
            }
        }

        public void Borrow(Media media, string user)
        {
            if(media != null)
            {
                if(media.Nombre > 0)
                {
                    medias.Remove(media);
                    mediaEmprunté.Add(new Emprunt(user, media));
                }
            }
            else
            {
                throw new ArgumentNullException("The media you provided is null");
            }
        }

        public void Return(Media media, string user)
        {
            if (media != null)
            {
                Emprunt emprunt = Emprunt.findEmpruntByMedia(mediaEmprunté, media, user);

                if (emprunt != null)
                {
                    if (mediaEmprunté.Contains(emprunt))
                    {
                        media += emprunt.Media;
                        mediaEmprunté.Remove(emprunt);
                    }
                }
                else
                {
                    throw new ArgumentNullException("This media havent been borrowed");
                }
            }
            else
            {
                throw new ArgumentNullException("The media you provided is null");
            }
        }

        public void displayStats()
        {
            Console.WriteLine("Nombre total de media : " + medias.Count);
            Console.WriteLine("Nombre de media emprunté : " + mediaEmprunté.Count);
            Console.WriteLine("Nombre d'exemplaires disponible : " + getNumberOfItem());

        }

        public static int getNumberOfItem()
        {
            int nombreExemplaire = 0;
            foreach (Media media in medias)
            {
                nombreExemplaire += media.Nombre;
            }
            return nombreExemplaire;
        }

        
    }
    
}
