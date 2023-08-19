using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Database;
using E_Commerce.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Repository
{
    public class Customer_Oreders_ProductsRep : ICustomer_Oreders_ProductsRep
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private readonly IProductRep productRep;

        public Customer_Oreders_ProductsRep(Context _context, IMapper mapper, IProductRep productRep)
        {
            context = _context;
            this.mapper = mapper;
            this.productRep = productRep;
        }
        #region
        public Customer_Oreders_Products Create(Customer_Oreders_Products obj)
        {
            throw new NotImplementedException();
        }

        public Customer_Oreders_Products Edit(Customer_Oreders_Products obj)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD
=======

      
        public Customer_Oreders_Products Edit(Customer_Oreders_Products obj)
        {
            throw new NotImplementedException();
        }

>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        public List<Customer_Oreders_Products> Get()
        {
            throw new NotImplementedException();
        }
        #endregion
        public void Delete(int id)
        {
            Customer_Oreders_Products product = GetById(id);
            context.Customer_Oreders_Products.Remove(product);
        }
        public Customer_Oreders_Products GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer_Oreders_ProductsVM> GetOrderProducts(int orderId)
        {
            List<Customer_Oreders_Products> orderProduct = context.Customer_Oreders_Products.Include(p => p.Products).ToList().Where(i => i.Customer_OredersId == orderId).ToList();
            List<Customer_Oreders_ProductsVM> orderProductVM = new List<Customer_Oreders_ProductsVM>();
            orderProduct.ForEach(p =>
            {
                var pro = mapper.Map<Customer_Oreders_ProductsVM>(p);
                orderProductVM.Add(pro);
            });
            return orderProductVM;
        }
        public List<ProductsVM> GetProducts(int[] id)
        {
            List<ProductsVM> productsVMs = new List<ProductsVM>();
            for (int x = 0; x < id.Length; x++)
            {
                Products product = context.Products.FirstOrDefault(i => i.id == id[x]);
                var pvm = mapper.Map<ProductsVM>(product);
                productsVMs.Add(pvm);
            }
            return productsVMs;
        }
        public List<Customer_Oreders_ProductsVM> createOrderProducrs(int[] id)
        {
            List<ProductsVM> products = GetProducts(id);
            List<Customer_Oreders_ProductsVM> orders_Products = new List<Customer_Oreders_ProductsVM>();
            products.ForEach(o =>
            {
                var p = productRep.GetById((int)o.id);
                Customer_Oreders_ProductsVM orders = new Customer_Oreders_ProductsVM();
                orders.ProductsId = p.id;
                orders.Products = p;
                orders_Products.Add(orders);
            });
            return orders_Products;
        }

    }
}
