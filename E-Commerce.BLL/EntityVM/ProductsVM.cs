using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.EntityVM
{
    public class ProductsVM
    {
        public int? id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MinLength(2, ErrorMessage = "name must be more be than 2 char")]
        [MaxLength(30)]
        public string name { get; set; }
        [Range(10, 70000, ErrorMessage = "must be more be than10")]
        public float price { get; set; }
        [MinLength(4, ErrorMessage = "Descreption must be more be than 4 char")]
        [MaxLength(40)]
        public string descreption { get; set; }
        //public List<Customer_Oreders_Products> Customer_Oreders_Products { get; set; }
        public int SupplierId { get; set; }
        public Suppliers? Supplier { get; set; }
        public string? Image { get; set; }
    }
}
