using DBProject.Database.MySql;
using DBProject.Database.redis;
using DBProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mySql = new MySqlDataContext("Server=localhost;Port=3306;Database=final;Uid=root;Pwd=abc123456789def");
var customerService = new CustomerService(mySql);

//var redis = new RedisDataContext("localhost=6379"); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddSingleton(customerService);

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
