using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tirelires.Models
{
    public class Login
    {
        [Display(Name = "Nom d'utilisateur")]
        [Required(ErrorMessage = "Veuillez entrer votre nom d'utilisateur")]
        public string UserName { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Veuillez entrer votre mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Se souvenir de moi")]
        public bool RememberMe { get; set; }
    }
}
