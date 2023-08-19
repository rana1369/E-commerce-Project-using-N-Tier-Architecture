using AutoMapper;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Database;
using E_Commerce.DAL.Entity;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
using E_Commerce.BLL.EntityVM;
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.BLL.Repository
{
    public class CustomerRep : ICustomerRep
    {
<<<<<<< HEAD
        private readonly IMapper mapper;
=======
      private readonly IMapper mapper;
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd

        private readonly Context context;

        public CustomerRep(Context _context)
        {
            context = _context;
        }
        public Customer Create(Customer obj)
<<<<<<< HEAD
        {
=======
        { 
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
            context.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public Customer Edit(Customer obj)
        {

            var customer = GetById(obj.id);

            customer.address = obj.address;
            customer.email = obj.email;
<<<<<<< HEAD
            customer.name = obj.name;
            customer.phone = obj.phone;
            customer.Oreders = obj.Oreders;


            context.Customers.Update(customer);
            context.SaveChanges();
=======
            customer.name= obj.name;
            customer.phone = obj.phone;
            customer.Oreders= obj.Oreders;
          

            context.Customers.Update(customer);
            context.SaveChanges();  
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd

            // v customerVM = mapper.Map<CustomerVM>(customer);
            return customer;


        }

        public List<Customer> Get()
        {
<<<<<<< HEAD
            var data = context.Customers.Include(i => i.Oreders).ToList();
            return data;
        }

        public Customer getbyEmail(string email)
        {
            Customer customer = context.Customers.FirstOrDefault(c => c.email == email);
            return customer;
=======
            var data = context.Customers.Include(i=>i.Oreders).ToList();
            return data;
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        }

        public Customer GetById(int id)
        {

<<<<<<< HEAD
            Customer customer = context.Customers.Include(i => i.Oreders).FirstOrDefault(x => x.id == id);
=======
            Customer customer = context.Customers.Include(i=>i.Oreders).FirstOrDefault(x => x.id == id);
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
            return customer;

        }

<<<<<<< HEAD

=======
      
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
    }
}
