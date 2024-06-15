using Microsoft.EntityFrameworkCore;
using Shop.Application.Contract.Dtos;
using Shop.Application.Contract.IServices;
using Shop.Application.Services;
using Shop.Infrastructure.Contexts;
using Shop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductPanelService, ProductPanelService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITShirtSizeRepository, TShirtSizeRepository>();
var connectionString = builder.Configuration.GetConnectionString("ShopConnectionStrings");
builder.Services.AddDbContext<ShopContext>(option => option.UseSqlServer(connectionString));

builder.Services.Configure<AppSetting>(builder.Configuration);
builder.Configuration.GetSection("Images").Bind(new Images());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
