using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class Commande
    {
        public Commande()
        {
            DetailCommande = new HashSet<DetailCommande>();
        }

        public int Id { get; set; }
        public string IdClient { get; set; }
        public DateTime Date { get; set; }
        public int IdStatut { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual StatutCommande IdStatutNavigation { get; set; }
        public virtual ICollection<DetailCommande> DetailCommande { get; set; }
    }
}
