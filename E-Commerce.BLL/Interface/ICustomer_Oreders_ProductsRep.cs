using E_Commerce.BLL.EntityVM;
using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface ICustomer_Oreders_ProductsRep : IGenericRep<Customer_Oreders_Products>
    {
        public List<ProductsVM> GetProducts(int[] id);
        public List<Customer_Oreders_ProductsVM> GetOrderProducts(int orderId);
        public List<Customer_Oreders_ProductsVM> createOrderProducrs(int[] id);
    }
}
