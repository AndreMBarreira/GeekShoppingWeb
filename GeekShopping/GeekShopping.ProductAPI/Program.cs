using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GeekShopping.ProductAPI.Models.Context;
using AutoMapper;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MySQLContext") ?? throw new InvalidOperationException("Connection string 'MySQLContext' not found.")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GeekShopping.ProductAPI" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
