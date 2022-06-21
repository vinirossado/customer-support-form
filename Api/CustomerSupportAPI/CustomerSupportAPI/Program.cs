using CustomerSupport.Infra.CrossCutting.Context;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Repository.Implements;
using CustomerSupportAPI.Repository.Interfaces;
using CustomerSupportAPI.Service.Implements;
using CustomerSupportAPI.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var services = builder.Services;
var env = builder.Environment;

services.AddDbContext<CustomerSupportDbContext>();

// Add services to the container.
builder.Services.AddScoped<ICustomerSupportService, CustomerSupportService>();
builder.Services.AddScoped<ICustomerSupportRepository, CustomerSupportRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var allowedOrigins = ""; /*LaunchEnvironment.AllowedOrigins.Split(";")*/;
app.UseCors(x => x
    .WithOrigins(allowedOrigins)
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();