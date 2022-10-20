

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using WebAppTutorial.Models;
using WebAppTutorial.Views.Administration;
using WebAppTutorial.ViewsModel;

namespace WebAppTutorial.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);   
            if(user == null)
            {
                ViewBag.ErrorMSG = $"User with ID = {id} cannot be found";
                return View("NotFound");
            }else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("ListUsers");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMSG = $"Role with ID = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("ListRoles");
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateViewRoleModel viewRoleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = viewRoleModel.RoleName
                };

                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewRoleModel);
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role =await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMSG = $"Role with ID = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name,
        
            };
            var userList = await userManager.Users.ToListAsync();
            foreach (var user in userList)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }

            }
            return View(model);
         
        }
        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);
            if(role == null)
            {
                ViewBag.ErrorMSG = $"Role with Id {roleId} cannot be found";
                return RedirectToAction("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            var userList = await userManager.Users.ToListAsync();
            foreach (var user in userList)
            {
                var userViewModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user,role.Name))
                {
                    userViewModel.IsSelected = true;
                }
                else
                {
                    userViewModel.IsSelected = false;   
                }
                model.Add(userViewModel);
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel viewRoleModel)
        {
            var role = await roleManager.FindByIdAsync(viewRoleModel.RoleId);
            if(role == null)
            {
                ViewBag.ErrorMSG = $"Role with ID = {viewRoleModel.RoleId} cannot be found";
                return View("NotFound");

            }
            else
            {
                role.Name = viewRoleModel.RoleName;
            }
            var result = await roleManager.UpdateAsync(role);
            
                
            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            return View(viewRoleModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMSG = $"Role with ID = {roleId} cannot be found";
                return View("NotFound");

            }

            for(int i=0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                var existInRole = await userManager.IsInRoleAsync(user, role.Name);
                if (model[i].IsSelected && !existInRole)
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);

                }else if (!model[i].IsSelected && existInRole)
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);

                }
                else
                {
                    continue;
                }
                if(result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { id = roleId });
                }

            }

            return View(model);
            
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;

            return View(users);
        }//EditUser
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMSG = $"User with Id {id} cannot be found";
                return RedirectToAction("NotFound");
            }
            var claims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel()
            {
                Id = user.Id,
                City = user.city,
                Email = user.Email,
                UserName = user.UserName,
                Claims = claims.Select(c => c.Value).ToList(),
                Roles = roles.ToList()

            };
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel userViewModel)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userViewModel.Id);
            if (user == null)
            {
                ViewBag.ErrorMSG = $"User with Id {userViewModel.Id} cannot be found";
                return RedirectToAction("NotFound");
            }
            else
            {
                user.city = userViewModel.City;
                user.Email = userViewModel.Email;
                user.UserName = userViewModel.UserName;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(userViewModel);
        }
    }
    
}

