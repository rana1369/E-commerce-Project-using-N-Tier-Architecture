using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.EntityVM
{
    public class RegistrationVM
    {
        [MinLength(2, ErrorMessage = "Min Len 2")]
        [Required(ErrorMessage = "This Field Required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
