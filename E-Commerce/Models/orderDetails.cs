using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Repository;

namespace E_Commerce.Models
{
    public class orderDetails
    {
        public Customer_OredersVM oredersVM { set; get; }
        public List<Customer_Oreders_ProductsVM> orderProduct { set; get; }
    }
}
