using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.helpers;
using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.models.dtos;
using Orders.Api.repository;
using Orders.Api.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<StudentInfo>()
    .BindConfiguration(StudentInfo.SectionName);

//Utilizando una conexion Scoped para cada petición
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IStudentService,StudentService>();
//Implementacion de Dapper en Program.cs
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ITransportOrderRepository, TransportOrderRepository>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
                new BadRequestObjectResult(new ApiErrorResponse(
                    StatusCodes.Status400BadRequest,
                    "The request contains invalid data.",
                    ValidationErrors.FromModelState(context.ModelState)));
        });
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
       options.SwaggerEndpoint("/openapi/v1.json","Orders.Api"); 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
