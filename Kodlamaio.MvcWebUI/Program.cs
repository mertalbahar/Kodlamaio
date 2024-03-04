using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Concretes;
using Kodlamaio.DataAccess.Abstracts;
using Kodlamaio.DataAccess.Concretes.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KodlamaioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KodlamaioContext"), b => b.MigrationsAssembly("Kodlamaio.MvcWebUI")));

builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<ICourseDal, EfCourseDal>();

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

app.Run();
