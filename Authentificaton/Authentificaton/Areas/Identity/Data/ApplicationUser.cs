using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentificaton.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string prenom { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string nom { get; set; }
    }
}