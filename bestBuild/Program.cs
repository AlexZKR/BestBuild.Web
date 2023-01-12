using Microsoft.EntityFrameworkCore;
using bestBuild.DAL.Data;
using bestBuild.Data;
using Microsoft.AspNetCore.Identity;
using bestBuild.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));


builder.Services.AddDbContext<bestBuildIdentityDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("bestBuildIdentityDbContextConnection")));

builder.Services.AddDefaultIdentity<ClientCred>(options =>
 options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<bestBuildIdentityDbContext>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
DbInitializer.Seed(app);

app.Run();
