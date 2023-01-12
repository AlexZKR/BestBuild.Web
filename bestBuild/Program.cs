using Microsoft.EntityFrameworkCore;
using bestBuild.DAL.Data;
using bestBuild.Data;
using Microsoft.AspNetCore.Identity;
using bestBuild.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddDefaultIdentity<ClientCred>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<bestBuildIdentityDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);

app.Run();
