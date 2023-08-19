using E_Commerce.BLL.Interface;
using E_Commerce.BLL.Mapper;
using E_Commerce.BLL.Repository;
using E_Commerce.DAL.Database;
using E_Commerce.DAL.Extend;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(op =>
            {
                //op.UseNpgsql(builder.Configuration.GetConnectionString("Cs"));
                op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            });

            builder.Services.AddScoped<ICustomerRep , CustomerRep>();
            builder.Services.AddScoped<IProductRep , ProductRep>();
            builder.Services.AddScoped<ISuppliersRep , SuppliersRep>();
            builder.Services.AddScoped<ICustomer_OredersRep , Customer_OredersRep>();
            builder.Services.AddScoped<ICustomer_Oreders_ProductsRep , Customer_Oreders_ProductsRep>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<Context>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}