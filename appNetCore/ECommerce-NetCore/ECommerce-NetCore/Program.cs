using appDist.Event.MQ.Src;
using ECommerce_NetCore.DataAccess;
using ECommerce_NetCore.DataAccess.repositories;
using ECommerce_NetCore.Entities;
using ECommerce_NetCore.Services.Implementations;
using ECommerce_NetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using ECommerce_NetCore.Messages.Commands;
using ECommerce_NetCore.Messages.CommandHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//INYECCION DE DEPENDENCIAS PARA LOS Repository y Service
//se pone <NOMBRE_INTERFAS, NOMBRE_CLASE_IMPLEMENTACION>
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddSingleton<List<Category>>(new List<Category>());


///MQ
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<IRequestHandler<TransactionHistoryCreateCommand, bool>, TransactionHistoryCommandHandler>();



//LA CADENA DE CONEXION ESTA EN EL appsettings.json
//CON EL SIGUIENTA LINEA OBTENEMOS LA CADENA DE CONEXIONA SQL SERVER
var conSqlServer = builder.Configuration.GetConnectionString("BDDSqlServer")!;
builder.Services.AddDbContext<ECommerceNetCoreDbContext>(options =>
{
    //options.UseSqlServer("Server=localhost,1434;Database=ECommerceData;User Id=sa;Password=adminAppDist2024#;TrustServerCertificate=True");
    Console.WriteLine(conSqlServer);
    options.UseSqlServer(conSqlServer);
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
