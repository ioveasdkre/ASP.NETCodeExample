using EFCoreConsoleAppla.Models.Data;
using Microsoft.EntityFrameworkCore;
using net6MVCCRUD.Access;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<AdsPumaDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("AdsPumaDb")));

builder.Services.AddTransient<ICaptcha, Captcha>();

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
