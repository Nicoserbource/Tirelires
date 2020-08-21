using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tirelires.Models
{
    public class Register : Login
    {
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Veuillez enter votre prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez entrer votre nom")]
        public string LastName { get; set; }

        [Display(Name = "Rôle")]
        [Required(ErrorMessage = "Veuillez sélectionner un rôle")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre adresse e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
