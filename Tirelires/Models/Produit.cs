using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tirelires
{
    public partial class Produit
    {
        public Produit()
        {
            Image = new HashSet<Image>();
            Avis = new HashSet<Avis>();
            DetailCommande = new HashSet<DetailCommande>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int IdCouleur { get; set; }
        public int IdFabricant { get; set; }
        public int? IdImage { get; set; }
        public decimal Hauteur { get; set; }
        public decimal Largeur { get; set; }
        public decimal Longueur { get; set; }
        public decimal Poids { get; set; }
        public int Capacité { get; set; }
        public decimal Prix { get; set; }
        public string Description { get; set; }
        public bool Statut { get; set; }

        [DisplayName("Couleur")]
        public virtual Couleur IdCouleurNavigation { get; set; }
        [DisplayName("Fabricant")]
        public virtual Fabricant IdFabricantNavigation { get; set; }
        [DisplayName("Image")]
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Avis> Avis { get; set; }
        public virtual ICollection<DetailCommande> DetailCommande { get; set; }
    }
}
