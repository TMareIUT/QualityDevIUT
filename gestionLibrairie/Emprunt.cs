using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionLibrairie
{
    public class Emprunt
    {
        private int idUser;
        public string userName = "";
        public List<int> refList = new List<int>();

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
    }
}