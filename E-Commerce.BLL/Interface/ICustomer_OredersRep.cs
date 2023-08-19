
using E_Commerce.BLL.EntityVM;
using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface ICustomer_OredersRep : IGenericRep<Customer_Oreders>
    {
        public Customer_OredersVM CreateOrder(List<Customer_Oreders_ProductsVM> products, int customerId);
        public List<Customer_OredersVM> GetAll(int customerId);
        public Customer_OredersVM Get(int orderId);

        public Task<Customer_Oreders> CreateAsync(Customer_Oreders obj);

        public List<Customer_Oreders_ProductsVM> getOrderProducts(int orderId);
    }
}
