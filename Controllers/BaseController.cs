﻿using IdentityUdemyCourse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.Controllers
{
    public class BaseController : Controller
    {
        protected  UserManager<AppUser> userManager { get; }
        protected  SignInManager<AppUser> signInManager { get; }
        protected  RoleManager<AppRole> roleManager { get; }
        protected AppUser CurrentUser => userManager.FindByNameAsync(User.Identity.Name).Result;

        public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public BaseController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void AddModelError(IdentityResult result)
        {
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

    }
}
