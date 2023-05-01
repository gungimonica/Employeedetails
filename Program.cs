using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlX.XDevAPI;
using TodoApi;
using TodoApi.BasicAuth;
using TodoApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDbcontext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("EmployeedetailsDb"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
});
builder.Services.AddScoped<ValidateUser, ValidateUser>();
builder.Services.AddScoped<EmployeeDbcontext, EmployeeDbcontext>();
//builder.Services.AddScoped << BasicAuthentication, BasicAuthentication > ();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
