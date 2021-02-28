using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityCoreTraining.Models;
using IdentityCoreTraining.Models.Context;
using IdentityCoreTraining.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace IdentityCoreTraining
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppIdentityDbContext>(options =>

                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"])

                );
            services.AddDbContext<RequestContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));


            CookieBuilder cookieBuilder = new CookieBuilder();

            cookieBuilder.Name = "PeerPilotSupportProgramme";
            cookieBuilder.HttpOnly = true;
            cookieBuilder.SameSite = SameSiteMode.Lax;// CSRF onlemek icin Strict yapmalisin.
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Always dersem browser sadece https uzerinden istek geldiyse requestte kullanici bilgisini sunucuya gonderiyor.

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Home/Login");
                options.LogoutPath = new PathString("/Member/Logout");
                options.Cookie = cookieBuilder;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true; 
                options.AccessDeniedPath = new PathString("/Member/AccessDenied");// sayfaya erisim izni olmayan kullanicilarin gidecegi path
            });



            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<AppIdentityDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
