using IdentityUdemyCourse.CustomValidation;
using IdentityUdemyCourse.Models;
using IdentityUdemyCourse.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });
            services.AddScoped<TwoFactorService>();
            services.AddScoped<EmailSender>();
            services.Configure<TwoFactorOptions>(Configuration.GetSection("TwoFactorOptions"));





            services.AddIdentity<AppUser, AppRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöpqrsþtuvwxyzABCÇDEFGÐHIÝJKLMNOÖPQRSÞTUVWXYZ0123456789-._";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<Context>()
            .AddPasswordValidator<CustomPasswrodValidator>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddUserValidator<CustomUserValidator>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Home/Login");
                opts.Cookie = new CookieBuilder
                {
                    Name = "MyBlog",
                    HttpOnly = false,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan =TimeSpan.FromDays(7);
                opts.LogoutPath=new PathString("/Member/Logout");
                opts.AccessDeniedPath = new PathString("/Member/AccessDenied");
            });

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("BilecikPolicy", policy =>
                 {
                     policy.RequireClaim("city", "Bilecik");
                 });
            });
            services.AddControllersWithViews();
            services.AddScoped<IClaimsTransformation, ClaimProvider.ClaimProvider>();
            services.AddMvc();
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(30);
                opts.Cookie.Name = "MainSession";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
