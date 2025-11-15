using ShoppingCart.Infrastructure.Repository.Seller;
using ShoppingCartAdmin.Class.Repository.Abstraction.Sellers;
using ShoppingCartAdmin.Infrastructure.Repository.Seller;
using ShoppingCartAdmin.Infrastructure.Sql;
using ShoppingCartAdmin.Service.Abstraction.Seller;
using ShoppingCartAdmin.Service.Services.Seller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DbHelper>();

builder.Services.AddScoped<ISellerDetailsRepository, SellerDetailsRepository>();
builder.Services.AddScoped<ISellerDetailsService, SellerDetailsService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<ISellerLoginRepository, SellerLoginRepository>();
builder.Services.AddScoped<ISellerLoginService, SellerLoginService>();

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
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
