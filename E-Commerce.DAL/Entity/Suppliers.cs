using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Entity
{
    public class Suppliers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public List<Products>? Products { get; set; }
    }
}
