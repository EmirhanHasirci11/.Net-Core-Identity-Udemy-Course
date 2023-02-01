using IdentityUdemyCourse.Models;
using IdentityUdemyCourse.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.Controllers
{
    public class AdminController : BaseController
    {


        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : base(userManager, roleManager)
        {

        }
        public IActionResult Claims()
        {
            return View(User.Claims.ToList());
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View(userManager.Users.ToList());
        }
        public IActionResult Roles()
        {
            return View(roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleCreate(RoleViewModel p)
        {
            AppRole role = new AppRole();
            role.Name = p.Name;
            IdentityResult result = roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                AddModelError(result);
            }
            return View(p);
        }
        public IActionResult DeleteRole(string id)
        {
            AppRole role = roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                IdentityResult result = roleManager.DeleteAsync(role).Result;
            }
            return RedirectToAction("Roles");
        }
        [HttpGet]
        public IActionResult UpdateRole(string id)
        {
            AppRole role = roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                return View(role.Adapt<RoleViewModel>());
            }
            return RedirectToAction("Roles");
        }
        [HttpPost]
        public IActionResult UpdateRole(RoleViewModel p)
        {
            AppRole role = roleManager.FindByIdAsync(p.Id).Result;
            if (role != null)
            {

                role.Name = p.Name;
                IdentityResult result = roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    AddModelError(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Güncelleme işlemi tamamlanamadı");
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult AssignRole(string id)
        {
            AppUser user = userManager.FindByIdAsync(id).Result;            
            List<string> userRoles = (List<string>)userManager.GetRolesAsync(user).Result;
            TempData["Userid"] = id;
            ViewBag.user = user.UserName;
            List<RoleAssignViewModel> roleAssignViewModel = new List<RoleAssignViewModel>();
            foreach(var role in roleManager.Roles)
            {
                RoleAssignViewModel r = new RoleAssignViewModel();
                r.RoleName = role.Name;
                r.RoleID = role.Id;
                if (userRoles.Contains(role.Name))
                {
                    r.Exist = true;
                }
                else
                {
                    r.Exist = false;
                }
                roleAssignViewModel.Add(r);
            }
            return View(roleAssignViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> p)
        {
            AppUser user = userManager.FindByIdAsync(TempData["Userid"].ToString()).Result;

            foreach(var item in p)
            {
                if (item.Exist)
                {
                   await userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                   await userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Users");
        }
    }
}
