using IdentityUdemyCourse.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ClaimProvider
{
    public class ClaimProvider : IClaimsTransformation
    {

        public UserManager<AppUser> userManager { get; set; }

        public ClaimProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null && principal.Identity.IsAuthenticated)
            {
                ClaimsIdentity identtity = principal.Identity as ClaimsIdentity;

                AppUser user = await userManager.FindByNameAsync(identtity.Name);

                if (user != null)
                {
                    if (user.City != null)
                    {
                        if (!principal.HasClaim(c => c.Type == "City"))
                        {
                            Claim CityClaim = new Claim("city", user.City, ClaimValueTypes.String, "Internal");
                            identtity.AddClaim(CityClaim);
                        }
                    }
                }
            }
            return principal;
        }
    }
}
