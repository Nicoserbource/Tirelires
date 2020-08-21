using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tirelires
{
    public partial class DetailCommande
    {
        public int Id { get; set; }
        public int IdCommande { get; set; }
        public int IdProduit { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        [DisplayName("Commande")]
        public virtual Commande IdCommandeNavigation { get; set; }
        [DisplayName("Produit")]
        public virtual Produit IdProduitNavigation { get; set; }
    }
}
