using E_Commerce.BLL.EntityVM;
using E_Commerce.BLL.Interface;
using E_Commerce.DAL.Entity;
using E_Commerce.DAL.Extend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_Commerce.Controllers
{
    [Authorize (Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ISuppliersRep suppliersRep;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RolesController(ISuppliersRep suppliersRep, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.suppliersRep = suppliersRep;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var Roles = roleManager.Roles;
            return View(Roles);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {

            var role = new IdentityRole()
            {

                Name = model.Name,
                NormalizedName = model.Name.ToUpper()
            };

            var result = await roleManager.CreateAsync(role);

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


            return View(model);
        }


        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.Name;
            role.NormalizedName = model.Name.ToUpper();
            role.ConcurrencyStamp = model.ConcurrencyStamp;

            var result = await roleManager.UpdateAsync(role);

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


            return View(model);
        }





        public async Task<IActionResult> AddOrRemoveUsers(string RoleId)
        {
            if (RoleId == null)
                return NotFound();

            ViewBag.RoleId = RoleId;

            var role = await roleManager.FindByIdAsync(RoleId);
            if (role == null)
                return NotFound();

            var model = new List<UserInRoleVM>();

            foreach (var user in userManager.Users)
            {
                var userInRole = new UserInRoleVM()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userInRole.IsSelected = true;
                }
                else
                {
                    userInRole.IsSelected = false;
                }

                model.Add(userInRole);
            }

            return View(model);
            

        }



        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(List<UserInRoleVM> model, string RoleId)
        {

            var role = await roleManager.FindByIdAsync(RoleId);

            for (int i = 0; i < model.Count; i++)
            {

                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    if(role.Name== "Suppliers")
                    {
                        Suppliers suppliers = new Suppliers();
                        suppliers.name = user.UserName;
                        suppliers.email = user.Email;
                        suppliersRep.Create(suppliers);
                    }

                    result = await userManager.AddToRoleAsync(user, role.Name);

                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                //else
                //{
                //    continue;
                //}

                //if (i < model.Count)
                //    continue;


            }

            return RedirectToAction("Edit", new { id = RoleId });
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var Roles = roleManager.Roles;
            return View(Roles);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var role = await roleManager.FindByIdAsync(model.Id);

                    var result = await roleManager.DeleteAsync(role);

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
