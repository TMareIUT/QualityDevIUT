using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours1
{
    public class Media
    {
        public string Titre { get; set; }
        public int Numero { get; set; }
        public int Nombre { get; set; }

        public Media(string titre, int numero, int nombre) { 
            this.Titre = titre;
            this.Numero = numero;
            this.Nombre = nombre;
        }

        public virtual void Afficherinfos() {
            Console.WriteLine(Titre + " : " + Numero + " : " + Nombre);
        }

        public static Media operator + (Media media1, Media media2)
        {
            media1.Nombre += media2.Nombre;
            return media1;
        }

        public static Media operator +(Media media1, int nbr)
        {
            media1.Nombre += nbr;
            return media1;
        }

        public static Media operator -(Media media1, Media media2)
        {
            if(media1.Nombre > media2.Nombre)
            {
                media1.Nombre -= media2.Nombre;
                return media1;
            }
            else
            {
                throw new InvalidOperationException("You are trying to remove more quantity than you have (quantity can't be negative)");
            }
        }

        public static Media operator -(Media media1, int nbr)
        {
            if (media1.Nombre > nbr)
            {
                media1.Nombre -= nbr;
                return media1;
            }
            else
            {
                throw new InvalidOperationException("You are trying to remove more quantity than you have (quantity can't be negative)");
            }
        }
    }
}
