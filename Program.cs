using asp_code_base.Extensions;
using asp_code_base.Middlewares;
using asp_code_base.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ConfigureSwaggerOptions();
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"));
});
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureExceptionHandler(app.Logger);
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.Run();




//Microsoft.EntityFrameworkCore 6.0.0
//Microsoft.EntityFrameworkCore.SqlServer 6.0.0
//Microsoft.EntityFrameworkCore.Tools 6.0.0
//Microsoft.AspNetCore.Authentication.JwtBearer 6.0.0
//AutoMapper
//AutoMapper.Extensions.Microsoft.DependencyInjection
//copy appsetting too