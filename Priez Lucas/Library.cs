using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premiercours
{
    public class Library
    {
        private List<Media> media;

        public Library()
        {
            media = new();
        }

        public void AddMedia()
        {
            Media.Add(media);
        }

       
    }
}
