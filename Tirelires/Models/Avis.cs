using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class Avis
    {
        public int Id { get; set; }
        public string IdClient { get; set; }
        public int IdProduit { get; set; }
        public string Contenu { get; set; }
        public bool Statut { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Produit IdProduitNavigation { get; set; }
    }
}
