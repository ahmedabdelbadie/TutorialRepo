using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using WebAppTutorial.Data;
using WebAppTutorial.Models;
using WebAppTutorial.Repo;

namespace WebAppTutorial
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeConnectionString")));
            Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<AppDBContext>();
            Services.AddSession();
            Services.AddMvc(
                //opt =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser().Build();
            //    opt.Filters.Add(new AuthorizeFilter(policy));
            //}
            );
            
            Services.AddScoped<IEmployeeRepository, SQLEmployeeRepo>();

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();


            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IPizzaRepository, PizzaRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            //services.AddHttpContextAccessor();
            //services.AddSession();

            //services.AddControllersWithViews();//services.AddMvc(); would also work still
            //services.AddRazorPages();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //// Configure the HTTP request pipeline.
            //if (!env.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            //app.Run();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

              
            });
        }
    }
}
