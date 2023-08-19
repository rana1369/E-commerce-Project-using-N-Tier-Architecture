using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Database;
using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Repository
{
    public class ProductRep : IProductRep
    {
        private readonly Context context;

        public ProductRep(Context _context)
        {
            context = _context;
        }
        public Products Create(Products obj)
        {
            context.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var data = GetById(id);
            context.Remove(data);
            context.SaveChanges();

        }

<<<<<<< HEAD


        public Products Edit(Products products)
=======
        public Products Edit(Products obj)
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        {
            context.Update(products);
            context.SaveChanges();
            return products;

        }

        public List<Products> Get()
        {
            var data = context.Products.ToList();
            return data;
        }

        public Products GetById(int id)
        {
            var data = context.Products.FirstOrDefault(e => e.id == id);
            return data;
<<<<<<< HEAD

        }

        public List<Products> ProductsBySupplier(int supplierId)
        {
            List<Products> products = context.Products.Where(p=>p.SupplierId == supplierId).ToList();   
            return products;
        }

        public IQueryable<Products> SearchByName(string name)
          => context.Products.Where(s => s.name.ToLower().Contains(name.ToLower()));

        public List<Products> SearchByNameAndSuppId(string name, int supplierId)
        {
            List<Products> products = context.Products.Where(p=>p.SupplierId == supplierId&&p.name.ToLower().Contains(name.ToLower())).ToList();
            return products;
=======
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        }
    }

}
