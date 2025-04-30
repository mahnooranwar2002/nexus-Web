using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Options;
using Nexus.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Configuration

builder.Services.AddDbContext
    <MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
/*for seesion*/
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Website}/{action=Index}");

app.Run();
