using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.EntityVM
{
    public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }
    }
}
