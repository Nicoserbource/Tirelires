using System;
using System.Collections.Generic;

namespace Tirelires
{
    public partial class StatutCommande
    {
        public StatutCommande()
        {
            Commande = new HashSet<Commande>();
        }

        public int Id { get; set; }
        public string Statut { get; set; }

        public virtual ICollection<Commande> Commande { get; set; }
    }
}
