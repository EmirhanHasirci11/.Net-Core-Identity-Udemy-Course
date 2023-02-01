using IdentityUdemyCourse.Enums;
using IdentityUdemyCourse.Models;
using IdentityUdemyCourse.Services;
using IdentityUdemyCourse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.Controllers
{
    public class HomeController : BaseController
    {

        private TwoFactorService twoFactorService;
        private EmailSender emailSender;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TwoFactorService twoFactorService, EmailSender emailSender) : base(userManager, signInManager)
        {
            this.twoFactorService = twoFactorService;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Member");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> TwoFactorLogin(string ReturnUrl = "/")
        {
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            TempData["ReturnUrl"] = ReturnUrl;
            switch ((TwoFactor)user.TwoFactor)
            {
                case TwoFactor.MicrosoftGoogle:
                    break;
                case TwoFactor.Email:

                    if (twoFactorService.TimeLeft(HttpContext) == 0)
                    {
                        return RedirectToAction("Login");
                    }

                    ViewBag.timeLeft = twoFactorService.TimeLeft(HttpContext);

                    HttpContext.Session.SetString("codeVerification", emailSender.Send(user.Email));

                    break;
            }

            return View(new TwoFactorLoginViewModel() { TwoFactorType = (TwoFactor)user.TwoFactor, isRecoverCode = false, isRememberMe = false, VerificationCode = string.Empty });
        }
        [HttpPost]
        
        public async Task<IActionResult> TwoFactorLogin(TwoFactorLoginViewModel p)
        {
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            ModelState.Clear();
            bool isSuccessAuth = false;
            if ((TwoFactor)user.TwoFactor == TwoFactor.MicrosoftGoogle)
            {
                Microsoft.AspNetCore.Identity.SignInResult result;
                if (p.isRecoverCode)
                {
                    result = await signInManager.TwoFactorRecoveryCodeSignInAsync(p.VerificationCode);
                }
                else
                {
                    result = await signInManager.TwoFactorAuthenticatorSignInAsync(p.VerificationCode, p.isRememberMe, false);
                }
                if (result.Succeeded)
                {
                    isSuccessAuth = true;
                }
                else
                {
                    ModelState.AddModelError("", "Doğrulama kodu hatalı");
                }
            }
            else if (user.TwoFactor == (sbyte)TwoFactor.Email || user.TwoFactor == (int)TwoFactor.Phone)
            {
                ViewBag.timeLeft = twoFactorService.TimeLeft(HttpContext);
                if (p.VerificationCode == HttpContext.Session.GetString("codeVerification"))

                {
                    await signInManager.SignOutAsync();

                    await signInManager.SignInAsync(user, p.isRememberMe);
                    HttpContext.Session.Remove("currentTime");
                    HttpContext.Session.Remove("codeVerification");
                    isSuccessAuth = true;
                }
                else
                {
                    ModelState.AddModelError("", "Doğrulama kodu yanlış");
                }
            }


            if (isSuccessAuth)
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
            p.TwoFactorType = (TwoFactor)user.TwoFactor;
            return View(p);
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/")
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(p.Email);
                if (user != null)
                {

                    if (await userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız belirli bir tarihe kadar kilitlenmiştir");
                        return View(p);
                    }
                    bool userCheck = userManager.CheckPasswordAsync(user, p.Password).Result;
                    if (userCheck)
                    {
                        await userManager.ResetAccessFailedCountAsync(user);
                        await signInManager.SignOutAsync();
                        var result = await signInManager.PasswordSignInAsync(user, p.Password, p.RememberMe, false);

                        if (result.RequiresTwoFactor)
                        {
                            if (user.TwoFactor == (int)TwoFactor.Email || user.TwoFactor == (int)TwoFactor.Phone)
                            {
                                HttpContext.Session.Remove("currentTime");
                            }
                            return RedirectToAction("TwoFactorLogin");
                        }
                        else
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());
                        }
                    }

                    else
                    {
                        await userManager.AccessFailedAsync(user);

                        int failCount = await userManager.GetAccessFailedCountAsync(user);
                        ModelState.AddModelError("", $"{failCount} kez başarısız giriş yapıldı");

                        if (failCount == 3)
                        {
                            await userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
                            ModelState.AddModelError("", "Hesabınız 3 adet başarısız girişte bulunduğunuzdan ötürü 20 dakikalığına kitlenmiştir.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Geçersiz email adresi veya şifresi");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz email adresi veya şifresi");
                }
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = p.UserName;
                user.Email = p.Email;
                user.PhoneNumber = p.PhoneNumber;
                user.TwoFactor = 0;
                IdentityResult result = await userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    AddModelError(result);
                }

            }
            return View(p);

        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(PasswordResetViewModel p)
        {

            AppUser user = userManager.FindByEmailAsync(p.Email).Result;
            if (user != null)
            {
                string passwordResetToken = userManager.GeneratePasswordResetTokenAsync(user).Result;
            }
            return View(p);
        }
    }
}
