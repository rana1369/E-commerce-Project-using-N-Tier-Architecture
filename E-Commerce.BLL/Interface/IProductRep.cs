using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface IProductRep : IGenericRep<Products>
    {
        IQueryable<Products> SearchByName(string name);
        public List<Products> ProductsBySupplier(int supplierId);
        public List<Products>  SearchByNameAndSuppId (string name, int supplierId);
    }
}
