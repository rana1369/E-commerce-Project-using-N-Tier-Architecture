using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Entity
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string descreption { get; set; }
        public List<Customer_Oreders_Products>? Customer_Oreders_Products { get; set; }
        public int SupplierId { get; set; }
        public Suppliers? Supplier { get; set; }
<<<<<<< HEAD
        public string? Image { get; set; }
=======
      
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
    }
}
