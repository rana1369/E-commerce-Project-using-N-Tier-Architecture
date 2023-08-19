using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.EntityVM
{
    public class CustomerVM
    {
        public int? id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [MinLength(3, ErrorMessage = "Min Lin 3")]
        [StringLength(50, ErrorMessage = "Max Len 50")]
        public string name { get; set; }

        [EmailAddress(ErrorMessage = "Email Invalid")]
        [Required(ErrorMessage = "Email Required")]
        public string email { get; set; }

        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Phone Invalid")]
        public string? phone { get; set; }

        [RegularExpression("[0-9]{1,5}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}", ErrorMessage = "Like : 11-StreetName-City-Country")]
        [Required(ErrorMessage = "Choose Adress")]
        public string? address { get; set; }
        //public List<Customer_Oreders> Oreders { get; set; }

    }
}
