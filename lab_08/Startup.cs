using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lab_06.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_06.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab_06
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICommentRepository, EFCommentRepository>();
            services.AddTransient<IGenreRepository, EFGenreRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IVideoRepository, EFVideoRepository>();
            services.AddTransient<ILikedVideoRepository, EFLikedVideoRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<Role>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, template: "Home/{search}/Page{page}", defaults: new {controller = "Home", action = "Index"});
                routes.MapRoute(name: "pagination", template: "Home/Page{page}", defaults: new { Controller = "Home", action = "Index", page=1 });
                routes.MapRoute(name: null, template: "Home/{search}", defaults: new { controller = "Home", action = "Index", page=1 });
                routes.MapRoute(name: null, template: "", defaults: new { controller = "Home", action = "Index", page=1 });
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            Seeder.EnsurePopulated(app);
        }
    }
}
