using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TicketWeb.Areas.Identity.Data;
using TicketWeb.Data;

namespace TicketWeb
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
            //services.AddDbContext<TicketWebContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("TicketWebContext")));
            ////services.AddIdentity<AppUser, IdentityRole>(option =>
            ////{
            ////    option.Password.RequiredLength = 8;
            ////}).AddEntityFrameworkStores<TicketWebContext>();
            //services.AddMvc(
            //    options =>
            //    {
            //        options.EnableEndpointRouting = false;
            //        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //        options.Filters.Add(new AuthorizeFilter(policy));
            //    }
            //    ).AddXmlSerializerFormatters();
            //services.AddDatabaseDeveloperPageExceptionFilter();
            ////services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<TicketWebContext>();

            //services.AddDefaultIdentity<TicketWebUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<TicketWebContext>();
            //services.AddControllersWithViews();
            //services.Configure<IdentityOptions>(options => {
            //    // Thiết lập về Password
            //    options.Password.RequireDigit = false; // Không bắt phải có số
            //    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
            //    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
            //    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
            //    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
            //    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

            //    // Cấu hình Lockout - khóa user
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // Khóa 2 phút
            //    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
            //    options.Lockout.AllowedForNewUsers = true;

            //    // Cấu hình về User.
            //    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
            //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = true;  // Email là duy nhất

            //    // Cấu hình đăng nhập.
            //    options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
            //    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

            //});

            services.AddDbContext<TicketWebContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<AppUser, IdentityRole>(option =>
            //{
            //    option.Password.RequiredLength = 8;
            //}).AddEntityFrameworkStores<TicketWebContext>();
            services.AddMvc(
                options =>
                {
                    options.EnableEndpointRouting = false;
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }
                ).AddXmlSerializerFormatters();
            services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<TicketWebContext>();

            services.AddDefaultIdentity<TicketWebUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TicketWebContext>();
            services.AddControllersWithViews();
            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // Khóa 2 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
