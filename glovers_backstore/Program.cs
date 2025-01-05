using glovers_backstore.Interfaces;
using glovers_backstore.Services;
using glovers_backstore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Models;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(@"Server=.\;Database=BackstoreDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
});


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StoreDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, StoreDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});


// DI
builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
// TODO: Add HTTP Client Factory

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
