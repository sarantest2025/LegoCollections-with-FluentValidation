using Microsoft.EntityFrameworkCore;
using MediatR;
using LegoCollections.Data;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using LegoCollections.Models;
using LegoCollections.Commands.Minifigure;
using LegoCollections.Behaviors;

var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<LegoDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDataProtection();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
        })
            .AddEntityFrameworkStores<LegoDbContext>()
            .AddDefaultTokenProviders();
          builder.Services.AddMediatR(typeof(CreateMinifigureCommand).Assembly);
          builder.Services.AddValidatorsFromAssemblyContaining<CreateMinifigureCommandValidator>();
          builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
          builder.Services.AddControllers();
          
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

