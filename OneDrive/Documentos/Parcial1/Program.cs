using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parcial1.Data;
using Parcial1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CursoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CursoContext") ?? throw new InvalidOperationException("Connection string 'CursoContext' not found.")));

// Add services to the container.

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CursoContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped <IEstudianteServices, EstudianteService>();
builder.Services.AddScoped <ICursoServices, CursoServices>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

app.Run();
