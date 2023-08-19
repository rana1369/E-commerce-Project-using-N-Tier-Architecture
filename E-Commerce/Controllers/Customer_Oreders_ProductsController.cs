using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Users")]
    public class Customer_Oreders_ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRep productRep;
        private readonly ICustomer_Oreders_ProductsRep customer_Oreders_ProductsRep;
        private readonly ICustomer_OredersRep customer_OredersRep;

        public Customer_Oreders_ProductsController(IMapper mapper, IProductRep productRep, ICustomer_Oreders_ProductsRep customer_Oreders_ProductsRep, ICustomer_OredersRep customer_OredersRep)
        {
            this.mapper = mapper;
            this.productRep = productRep;
            this.customer_Oreders_ProductsRep = customer_Oreders_ProductsRep;
            this.customer_OredersRep = customer_OredersRep;
        }
        public IActionResult Index()
        {
            //check if the customer is in signin
            var CustomerId = HttpContext.Session.GetInt32("CustomerId");
            //get cart products
            var sessionData = HttpContext.Session.GetString("cart" + CustomerId);
            //if cart empty
            if (sessionData == null)
            {
                return RedirectToAction("Empty");
            }
            int[] productsId = sessionData.Split(',').Select(int.Parse).ToArray();
            TempData["CustomerId"] = CustomerId;
            List<Customer_Oreders_ProductsVM> orders_Products = customer_Oreders_ProductsRep.createOrderProducrs(productsId);
            return View(orders_Products);
        }
        [HttpPost]
        public IActionResult Index(List<Customer_Oreders_ProductsVM> productsVMs)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            //get cart products
            var sessionData = HttpContext.Session.GetString("cart" + customerId);
            int[] productsId = sessionData.Split(',').Select(int.Parse).ToArray();
            Customer_OredersVM order =  customer_OredersRep.CreateOrder(productsVMs,(int)customerId);
            return RedirectToAction("Details", "Customer_Oreders", new { id = order.id });
        }
        public IActionResult Delete(int id)
        {
            // orderProduct from arr
            //ProductsVM products = customer_Oreders_ProductsRep.GetProductONE(1);
            int[] ids = TempData["ids"] as int[];
            ids = ids.Where(val => val != id).ToArray();
            TempData["ids"] = ids;

            return RedirectToAction("Index");
        }

        public IActionResult Empty()
        {
            return View();
        }
    }
}
