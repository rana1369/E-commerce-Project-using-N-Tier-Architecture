using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Mapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Products, ProductsVM>().ReverseMap();
            CreateMap<Suppliers, SuppliersVM>().ReverseMap();
            CreateMap<Customer_Oreders, Customer_OredersVM>().ReverseMap();
            CreateMap<Customer_Oreders_Products, Customer_Oreders_ProductsVM>().ReverseMap();
        }
    }
}
