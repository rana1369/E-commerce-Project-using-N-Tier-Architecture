using AutoMapper;
using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRep productRep;
        private readonly ISuppliersRep suppliersRep;

        public ProductController(IMapper mapper, IProductRep productRep, ISuppliersRep suppliersRep)
        {
            this.mapper = mapper;
            this.productRep = productRep;
            this.suppliersRep = suppliersRep;
        }
        public IActionResult Index(string SearchValue)
        {
<<<<<<< HEAD

            if (string.IsNullOrEmpty(SearchValue))
            {
                var data = productRep.Get();
                var model = mapper.Map<List<ProductsVM>>(data);
                return View(model);

            }
            else
            {
                var data = productRep.SearchByName(SearchValue);
                var model = mapper.Map<List<ProductsVM>>(data);
                return View(model);
            }

        }
        [Authorize(Roles = "Suppliers")]
        public IActionResult ViewProductSupp(string SearchValue)
        {
            var suppId = (int)HttpContext.Session.GetInt32("SupplierId");
            if (string.IsNullOrEmpty(SearchValue))
            {
                
                var data = productRep.ProductsBySupplier(suppId);
                var model = mapper.Map<List<ProductsVM>>(data);
                return View(model);

            }
            else
            {
                var data = productRep.SearchByNameAndSuppId(SearchValue, suppId);
                var model = mapper.Map<List<ProductsVM>>(data);
                return View(model);
            }

        }


        [Authorize(Roles = "Suppliers")]
        public IActionResult Add()
        {
            ViewData["Supplie"] = (int)HttpContext.Session.GetInt32("SupplierId");
            return View();
        }

        [Authorize(Roles = "Suppliers")]
        [HttpPost]
        public IActionResult Add(ProductsVM productsVM, IFormFile Image)
        {
            var model = mapper.Map<Products>(productsVM);

            if (ModelState.IsValid == true)
            {

                if (Image != null && Image.Length > 0)
                {

                    var fileName = Image.FileName;

                    //var filePath = $"/image/{fileName}";


                    var absolutePath = Path.Combine("wwwroot\\image", fileName);
                    using (var fileStream = new FileStream(absolutePath, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }

                    model.Image = fileName;

                }

                productRep.Create(model);
                return RedirectToAction("ViewProductSupp");
            }
            
            ViewData["Supplie"] = (int)HttpContext.Session.GetInt32("SupplierId");
            return View(model);
        }

        [Authorize(Roles = "Suppliers")]
        public IActionResult Delete(int id)
        {
            productRep.Delete(id);

            return RedirectToAction("Index");
        }

        
=======
            var data = productRep.Get();

            var model = mapper.Map<List<ProductsVM>>(data);
            return View(model);
        }



        public IActionResult Add()
        {
            ViewData["Supplie"] = suppliersRep.Get();
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductsVM productsVM)
        {
            var model = mapper.Map<Products>(productsVM);
            if (ModelState.IsValid == true)
            {

                productRep.Create(model);


                return RedirectToAction("Index");

            }
            ViewData["Supplie"] = suppliersRep.Get();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            productRep.Delete(id);

            return RedirectToAction("Index");
        }

>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
        public IActionResult Detels(int id)
        {

            var data = productRep.GetById(id);
            var model = mapper.Map<ProductsVM>(data);
            return View(model);
        }
<<<<<<< HEAD

        [Authorize(Roles = "Suppliers")]
        public IActionResult Edit(int id)
        {
            var data = productRep.GetById(id);
            var model = mapper.Map<ProductsVM>(data);
            ViewData["Supplie"] = (int)HttpContext.Session.GetInt32("SupplierId");
            return View(model);
        }

        [Authorize(Roles = "Suppliers")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, ProductsVM productsVM, IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                var data = mapper.Map<Products>(productsVM);


                if (Image != null && Image.Length > 0)
                {
                    var fileName = Image.FileName;

                    var filePath = Path.Combine("wwwroot", "image", $"{productsVM.id}.jpg");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    data.Image = $"{productsVM.id}.jpg";
                }

                productRep.Edit(data);
                return RedirectToAction("ViewProductSupp");
            }

            ViewData["Supplie"] = (int)HttpContext.Session.GetInt32("SupplierId");

            return View(productsVM);
        }

        [Authorize(Roles = "Users")]
        public IActionResult saveId(int id)
        {

            int CustomerId = (int)HttpContext.Session.GetInt32("CustomerId");
            var sessionData = HttpContext.Session.GetString("cart" + CustomerId);
            if (sessionData != null)
            {
                string value = sessionData + ',' + id;
                HttpContext.Session.SetString("cart" + CustomerId, value);
            }
            else
            {
                HttpContext.Session.SetString("cart" + CustomerId, id.ToString());
            }

            return RedirectToAction("Index");
        }
=======
>>>>>>> d403ac127da79efd0db40c8947847da2b92e29dd
    }
}
