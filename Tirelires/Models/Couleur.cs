﻿using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class Couleur
    {
        public Couleur()
        {
            Produit = new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Produit> Produit { get; set; }
    }
}
