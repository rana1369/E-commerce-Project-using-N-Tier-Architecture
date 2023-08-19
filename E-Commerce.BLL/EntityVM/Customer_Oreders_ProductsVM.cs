using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.EntityVM
{
    public class Customer_Oreders_ProductsVM
    {
        public int quantity { get; set; }


        [Column(Order = 1)]
        [ForeignKey("Customer_Oreders")]
        [Key]
        public int Customer_OredersId { get; set; }
        public Customer_Oreders? Customer_Oreders { get; set; }
        [Column(Order = 2)]
        [ForeignKey("Products")]
        [Key]
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
    }
}
