using Microsoft.EntityFrameworkCore;
using MediatR;
using LegoCollections.Data;
using LegoCollections.Models;
using LegoCollections.LegoFigures.Commands;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<LegoDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddMediatR(typeof(Program).Assembly);
    builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LegoCollections.Api.Application.Behaviors.ValidationBehaviour<,>));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

