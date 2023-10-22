using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VasVas.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string SmsIdName { get; set; }
        [Required]
        public string ConnectionPointName { get; set; }



    }
}
