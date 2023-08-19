using E_Commerce.DAL.Extend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin ")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser model)
        {

            try
            {


                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByIdAsync(model.Id);

                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.SecurityStamp = model.SecurityStamp;

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
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
            catch (Exception ex)
            {
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByIdAsync(model.Id);

                    var result = await userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
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
            catch (Exception ex)
            {
                return View(model);
            }

        }

    }
}
