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
    public class SuppliersRep : ISuppliersRep
    {
        private readonly Context context;

        public SuppliersRep(Context _context)
        {
            context = _context;
        }
        public Suppliers Create(Suppliers obj)
        {
            context.Suppliers.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Suppliers Edit(Suppliers obj)
        {
            throw new NotImplementedException();
        }

        public List<Suppliers> Get()
        {
            var data = context.Suppliers.ToList();
            return data;
        }

        public Suppliers getbyEmail(string email)
        {
            Suppliers suppliers = context.Suppliers.FirstOrDefault(s=>s.email == email);
            return suppliers;
        }

        public Suppliers GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
