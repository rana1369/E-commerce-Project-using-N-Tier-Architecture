using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface ISuppliersRep : IGenericRep<Suppliers>
    {
        public Suppliers getbyEmail(string email);
    }
}
