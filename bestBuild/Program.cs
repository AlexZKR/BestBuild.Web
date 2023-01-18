using Microsoft.EntityFrameworkCore;
using bestBuild.DAL.Data;
using bestBuild.Data;
using Microsoft.AspNetCore.Identity;
using bestBuild.Areas.Identity.Data;
using bestBuild.Models;
using bestBuild.Services;
using bestBuild.DAL.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));


builder.Services.AddDbContext<bestBuildIdentityDbContext>(
    options => options.UseLazyLoadingProxies()
    .UseSqlite(builder.Configuration.GetConnectionString("bestBuildIdentityDbContextConnection")));


builder.Services.AddIdentity<ClientCred, IdentityRole>()
.AddEntityFrameworkStores<bestBuildIdentityDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("admin", policy =>
            {
                policy.RequireAuthenticatedUser().RequireClaim("admin", bool.TrueString);
            }
        );
    }
);

builder.Services.AddSession(opt =>
    {
        opt.Cookie.HttpOnly = true;
        opt.Cookie.IsEssential = true;
    });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp => CartService.GetCart(sp));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
            });

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
await DbInitializer.Seed(app);

app.Run();
