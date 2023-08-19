
using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface ICustomerRep : IGenericRep<Customer>
    {
        public Customer getbyEmail(string email);
    }
}
