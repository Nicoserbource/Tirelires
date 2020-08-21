using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Tirelires
{
    public partial class Client : IdentityUser
    {
        public Client()
        {
            Avis = new HashSet<Avis>();
            Commande = new HashSet<Commande>();
        }

        //public string Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        public bool Statut { get; set; }

        public virtual ICollection<Avis> Avis { get; set; }
        public virtual ICollection<Commande> Commande { get; set; }
    }
}
