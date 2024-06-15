using Microsoft.EntityFrameworkCore;
using Shop.Application.Contract.Dtos;
using Shop.Application.Contract.IServices;
using Shop.Application.Services;
using Shop.Infrastructure.Contexts;
using Shop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductPanelService, ProductPanelService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITShirtSizeRepository, TShirtSizeRepository>();
var connectionString = builder.Configuration.GetConnectionString("ShopConnectionStrings");
builder.Services.AddDbContext<ShopContext>(option => option.UseSqlServer(connectionString));

//var path = builder.Configuration.GetValue<string>("HttpImagePath");
builder.Services.Configure<AppSetting>(builder.Configuration);
 builder.Configuration.GetSection("Images").Bind(new Images());

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Products}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}"
    );
});
app.Run();
