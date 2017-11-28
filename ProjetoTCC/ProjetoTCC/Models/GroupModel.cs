using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC
{
    class GroupModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        private string nomeJogo;
        public string NomeJogo
        {
            get { return nomeJogo; }
            set { nomeJogo = value; }
        }

    }
}
