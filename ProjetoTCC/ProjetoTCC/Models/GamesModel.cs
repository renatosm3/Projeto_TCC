﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC.Models
{
    class GamesModel
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

        private Boolean follow;

        public Boolean Follow
        {
            get { return follow; }
            set { follow = value; }
        }

    }
}
