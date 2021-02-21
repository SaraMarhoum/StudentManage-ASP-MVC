using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Authentificaton.Models
{
    public class NewSudentClass
    {
        [Key]

        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Saisir un nom !")]
        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Required(ErrorMessage = "Saisir un prénom !")]
        [Display(Name = "Prénom")]
        public string prenom { get; set; }

        [Display(Name = "CIN")]
        public string cin { get; set; }


        [Display(Name = "Adresse")]
        public string adresse { get; set; }
    }
}
