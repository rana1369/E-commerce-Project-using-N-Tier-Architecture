using AutoMapper;
using E_Commerce.BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SuppliersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRep productRep;

        public SuppliersController(IMapper mapper, IProductRep productRep)
        {
            this.mapper = mapper;
            this.productRep = productRep;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
