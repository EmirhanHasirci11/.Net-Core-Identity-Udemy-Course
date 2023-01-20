using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityUdemyCourse.Models
{
    public class Context:IdentityDbContext<AppUser,AppRole,string>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
