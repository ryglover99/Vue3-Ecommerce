using glovers_backstore.Interfaces;
using glovers_backstore.Services;
using glovers_backstore.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using glovers_backstore.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
});

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(@"Server=.\;Database=BackstoreDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
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

app.UseAuthorization();

app.MapControllers();

app.Run();
