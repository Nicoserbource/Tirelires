using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class Image
    {
        /*public Image()
        {
            IdProduitNavigation = new Produit();
        }*/

        public int Id { get; set; }
        public int IdProduit { get; set; }
        public string Chemin { get; set; }

        public virtual Produit IdProduitNavigation { get; set; }
    }
}
