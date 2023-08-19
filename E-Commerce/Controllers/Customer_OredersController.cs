using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
namespace E_Commerce.Controllers
{
    public class Customer_OredersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRep productRep;
        private readonly ICustomer_Oreders_ProductsRep customer_Oreders_ProductsRep;
        private readonly ICustomer_OredersRep customer_OredersRep;
        private readonly ICustomerRep customerRep;
        public Customer_OredersController(IMapper mapper, ICustomerRep customerRep, IProductRep productRep, ICustomer_Oreders_ProductsRep customer_Oreders_ProductsRep, ICustomer_OredersRep customer_OredersRep)
        {
            this.mapper = mapper;
            this.productRep = productRep;
            this.customerRep = customerRep;
            this.customer_Oreders_ProductsRep = customer_Oreders_ProductsRep;
            this.customer_OredersRep = customer_OredersRep;
        }
        public IActionResult Index()
        {
            int customerId = (int)HttpContext.Session.GetInt32("CustomerId");

            if (customerId != 0)
            {
                List<Customer_OredersVM> customer_OredersVMs = customer_OredersRep.GetAll(customerId);
                if (customer_OredersVMs.Count == 0) 
                    return View("NoOrders");
                return View(customer_OredersVMs);
            }
            // to signup view 
            return RedirectToAction("Login","Account");
        }

        public IActionResult Details(int id)
        {
            Customer_OredersVM oredersVM = customer_OredersRep.Get(id);
            List<Customer_Oreders_ProductsVM> orderProduct = customer_Oreders_ProductsRep.GetOrderProducts(id);
            orderDetails orderDetails = new orderDetails();
            orderDetails.orderProduct = orderProduct;
            orderDetails.oredersVM = oredersVM;
            return View(orderDetails);
        }
        public IActionResult Detete(int id)
        {
            // 1- delete order
            customer_OredersRep.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult NoOrders()
        {
            return View();
        }
    }
}
