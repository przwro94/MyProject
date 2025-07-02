using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Repositories;
using MyProject.Services;

namespace MyProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
        
        // builder.Services.AddDbContext<AppDbContext>(opt =>
        //     opt.UseInMemoryDatabase("WhateverNameYouWant"));
        
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        PrepDb.PrepPopulation(app);

        app.Run();
    }
}