using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class Fabricant
    {
        public Fabricant()
        {
            Produit = new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }

        public virtual ICollection<Produit> Produit { get; set; }
    }
}
