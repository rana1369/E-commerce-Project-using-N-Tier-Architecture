using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Entity;
using E_Commerce.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerRep customerRep;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ISuppliersRep suppliersRep;

        public AccountController(ISuppliersRep suppliersRep, RoleManager<IdentityRole> roleManager, ICustomerRep customerRep, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.customerRep = customerRep;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.suppliersRep = suppliersRep;
        }


        #region Registration (Sign up)
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = new ApplicationUser()
                    {

                        UserName = model.Name,
                        Email = model.Email,
                        IsAgree = model.IsAgree
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    
                    if (result.Succeeded)
                    {
                        Customer customer = new Customer();
                        customer.name = model.Name;
                        customer.email = model.Email;
                        customerRep.Create(customer);
                        await userManager.AddToRoleAsync(user, "Users");
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }

            return View();
        }


        #endregion


        #region Login (Sign in)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        Customer customer = customerRep.getbyEmail(model.Email);
                        Suppliers suppliers = suppliersRep.getbyEmail(model.Email);
                        if(suppliers != null) 
                        {
                            HttpContext.Session.SetInt32("SupplierId", suppliers.id);

                        }
                        if(customer != null)
                        {
                            HttpContext.Session.SetInt32("CustomerId", customer.id);

                        }
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName or Password");
                    }

                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }



            return View();
        }


        #endregion


        #region LogOff (Sign Out)

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("index" ,"Product");
        }

        #endregion


        #region Forget Password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        #endregion


        #region Reset Password
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        #endregion



    }
}
