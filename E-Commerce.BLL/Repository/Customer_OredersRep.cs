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
    public class Customer_OredersRep : ICustomer_OredersRep
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public Customer_OredersRep(Context _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }
        public async Task<Customer_Oreders> CreateAsync(Customer_Oreders obj)
        {
            context.Customer_Oreders.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public Customer_OredersVM CreateOrder(List<Customer_Oreders_ProductsVM> products, int customerId)
        {
            Customer_Oreders customer_Oreders = new Customer_Oreders();
            List<Customer_Oreders_Products> _Products = new List<Customer_Oreders_Products>(products.Count);
            var total = 0;
            products.ForEach(p =>
            {

                total += (int)(p.quantity * p.Products.price);
                p.Products = null;
                var pro = mapper.Map<Customer_Oreders_Products>(p);
                _Products.Add(pro);
            });
            customer_Oreders.Customer_Oreders_Products = _Products;
            customer_Oreders.CustomerId = customerId;
            customer_Oreders.date_order_placed = DateTime.Now;
            customer_Oreders.price = total;
            CreateAsync(customer_Oreders);

            var customer_OredersVM = mapper.Map<Customer_OredersVM>(customer_Oreders);
            return customer_OredersVM;
        }

        public void Delete(int id)
        {
            Customer_Oreders oreders = GetById(id);
            context.Customer_Oreders.Remove(oreders);
            context.SaveChanges();
        }

<<<<<<< HEAD
        public List<Customer_OredersVM> GetAll(int customerId)
=======
        public Customer_Oreders Edit(Customer_Oreders obj)
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        {
            List<Customer_Oreders> customer_Oreders = context.Customer_Oreders.Where(i => i.CustomerId == customerId).ToList();
            List<Customer_OredersVM> customer_OredersVM = new List<Customer_OredersVM>();
            customer_Oreders.ForEach(p =>
            {
                var pro = mapper.Map<Customer_OredersVM>(p);
                customer_OredersVM.Add(pro);
            });
            return customer_OredersVM;
        }

        public Customer_OredersVM Get(int orderId)
        {
            Customer_Oreders order = context.Customer_Oreders.Include(i => i.Customer_Oreders_Products).FirstOrDefault(i => i.id == orderId);
            var orderVM = mapper.Map<Customer_OredersVM>(order);
            return orderVM;
        }

        public Customer_Oreders GetById(int id)
        {
            Customer_Oreders order = context.Customer_Oreders.FirstOrDefault(i => i.id == id);
            return order;
        }
      
        public List<Customer_Oreders_ProductsVM> getOrderProducts(int orderId)
        {
            List<Customer_Oreders_Products> orderProduct = context.Customer_Oreders_Products.Where(i => i.Customer_OredersId == orderId).ToList();
            List<Customer_Oreders_ProductsVM> orderProductVM = new List<Customer_Oreders_ProductsVM>();
            orderProduct.ForEach(p =>
            {
                var pro = mapper.Map<Customer_Oreders_ProductsVM>(p);
                orderProductVM.Add(pro);
            });
            return orderProductVM;
        }

        #region
        public Customer_Oreders Create(Customer_Oreders obj)
        {
            throw new NotImplementedException();
        }
        public List<Customer_Oreders> Get()
        {
            throw new NotImplementedException();
        }
        public Customer_Oreders Edit(Customer_Oreders obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
