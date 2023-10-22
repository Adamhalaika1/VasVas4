using System.ComponentModel.DataAnnotations;

namespace VasVas.Models
{
    public class ProfileFormViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "اسم الشركة")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "SMS اسم معرف")]
        public string SmsIdName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "ايميل الشركة ")]
        public string Email { get; set; }


        [Required]
        [Phone]
        [Display(Name = "رقم الهاتف  ")]
        public string PhoneNumber { get; set; }

    }
}
