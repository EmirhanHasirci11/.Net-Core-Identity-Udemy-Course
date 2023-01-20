using IdentityUdemyCourse.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.CustomValidation
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (char.IsNumber(user.UserName[0])){
                errors.Add(new IdentityError() { Code = "UserNameStartsWithNumber", Description = "Kullanıcı adı bir numara ile başlayamaz" });
            }

            if (errors.Count() == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            

            
        }
    }
}
