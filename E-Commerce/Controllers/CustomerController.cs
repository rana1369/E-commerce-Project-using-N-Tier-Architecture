using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICustomerRep customerRep;

        public CustomerController(IMapper mapper, ICustomerRep _customerRep)
        {
            this.mapper = mapper;
            this.customerRep = _customerRep;
        }
        public IActionResult Index()
        {
            var data = customerRep.Get();

            var model = mapper.Map<List<CustomerVM>>(data);
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new CustomerVM();
            return View(model);
        }

       public IActionResult Remove(int id)
       {
           customerRep.Delete(id);
           return RedirectToAction("Index");
       }
        public IActionResult Edit(int id)
        {

            var model = customerRep.GetById(id);
            // var mm= customerRep.Edit(model);
            return View(model);

        }
        public IActionResult Save(Customer obj)
        {
            customerRep.Edit(obj);
         return RedirectToAction("Index");

        }

        public IActionResult GetById(int id)
        {
            var model = customerRep.GetById(id);
            return View(model);
        }

    }
}
