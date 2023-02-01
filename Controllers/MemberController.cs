using IdentityUdemyCourse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using IdentityUdemyCourse.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityUdemyCourse.Enums;
using IdentityUdemyCourse.Services;

namespace IdentityUdemyCourse.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {

        private readonly TwoFactorService _twoFactorService;
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TwoFactorService twoFactorService) : base(userManager, signInManager)
        {
            _twoFactorService = twoFactorService;
        }
        public IActionResult Index()
        {
            AppUser user = CurrentUser;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();
            return View(userViewModel);
        }
        public void Logout()
        {
            signInManager.SignOutAsync();
        }

        [HttpGet]
        public IActionResult UserEdit()
        {
            ViewBag.gender = new SelectList(Enum.GetNames(typeof(Gender)));
            AppUser user = CurrentUser;
            UserViewModel userView = user.Adapt<UserViewModel>();
            return View(userView);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel p, IFormFile userPicture)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;

                if (userPicture != null && userPicture.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await userPicture.CopyToAsync(stream);
                        user.Picture = "/UserPicture/" + fileName;
                    }
                }
                user.City = p.City;
                user.Gender = (int)p.Gender;
                user.BirthDate = p.BirthDate;
                user.UserName = p.UserName;

                user.Email = p.Email;
                user.PhoneNumber = p.PhoneNumber;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, true);
                    ViewBag.success = "true";
                }
                else
                {
                    AddModelError(result);
                }
            }
            return View(p);
        }
        [Authorize(Policy = "BilecikPolicy")]
        public IActionResult OnlyBilecik()
        {
            return View();
        }

        [Authorize(Roles = "Editor,Admin,Manager")]
        public IActionResult Editor()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Admin()
        {
            return View();
        }


        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;
                if (user != null)
                {
                    bool exist = userManager.CheckPasswordAsync(user, p.PasswordOld).Result;
                    if (exist)
                    {
                        IdentityResult result = userManager.ChangePasswordAsync(user, p.PasswordOld, p.PasswordNew).Result;
                        if (result.Succeeded)
                        {
                            userManager.UpdateSecurityStampAsync(user);

                            signInManager.SignOutAsync();
                            signInManager.PasswordSignInAsync(user, p.PasswordNew, true, false);
                            ViewBag.success = "true";
                        }
                        else
                        {
                            AddModelError(result);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eski şifreinizi yanlış girdiniz");
                    }

                }
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> TwoFactorWithAuthenticator()
        {
            string unformettedKey = await userManager.GetAuthenticatorKeyAsync(CurrentUser);
            if (string.IsNullOrEmpty(unformettedKey))
            {
                await userManager.ResetAuthenticatorKeyAsync(CurrentUser);
                unformettedKey = await userManager.GetAuthenticatorKeyAsync(CurrentUser);
            }
            AuthenticatorViewMdodel authenticatorView = new AuthenticatorViewMdodel();
            authenticatorView.SharedKey = unformettedKey;
            authenticatorView.AuthenticationUrl = _twoFactorService.GenerateQrCodeUrl(CurrentUser.Email, unformettedKey);
            return View(authenticatorView);

        }
        [HttpPost]
        public async Task<IActionResult> TwoFactorWithAuthenticator(AuthenticatorViewMdodel p)
        {
            var verificationCode = p.VerificationCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var is2FATokenValid = await userManager.VerifyTwoFactorTokenAsync(CurrentUser, userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

            if (is2FATokenValid)
            {
                CurrentUser.TwoFactorEnabled = true;
                CurrentUser.TwoFactor = (sbyte)TwoFactor.MicrosoftGoogle;

                var recoveryCodes = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(CurrentUser, 5);

                TempData["recoveryCodes"] = recoveryCodes;
                TempData["message"] = "İki adımlı kimlik doğrulama tipiniz Microsoft/Google Authenticator olarak belirlenmiştir.";

                return RedirectToAction("TwoFactorAuth");
            }
            else
            {
                ModelState.AddModelError("", "Girdiğiniz doğrulama kodu yanlıştır");
                return View(p);
            }
        }
        [HttpGet]
        public IActionResult TwoFactorAuth()
        {
            return View(new AuthenticatorViewMdodel()
            {
                TwoFactorType = (TwoFactor)CurrentUser.TwoFactor
            });
        }
        [HttpPost]
        public IActionResult TwoFactorAuth(AuthenticatorViewMdodel p)
        {
            switch (p.TwoFactorType)
            {
                case TwoFactor.None:
                    CurrentUser.TwoFactorEnabled = false;
                    CurrentUser.TwoFactor = (sbyte)TwoFactor.Phone;
                    TempData["message"] = "iki adımlı kimlik doğrulama tipiniz hiçbiri olarak belirtilmiştir";
                    break;
                case TwoFactor.MicrosoftGoogle:
                   return RedirectToAction("TwoFactorWithAuthenticator");
                case TwoFactor.Email:
                    CurrentUser.TwoFactorEnabled = true;
                    CurrentUser.TwoFactor = (sbyte)TwoFactor.Email;
                    TempData["message"] = "iki adımlı kimlik doğrulama tipiniz email olarak belirtilmiştir";
                    break;


                default:
                    break;
            }
           var res=  userManager.UpdateAsync(CurrentUser).Result;
            return View(p);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
