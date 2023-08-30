using BimehApi.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureLogging(builder.Configuration, builder.Environment);
builder.Services.AddDbContext<FireDbContext>(options =>
   options.UseOracle(builder.Configuration["ConnectionStrings:BimehConnection"]));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }

        var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
        if (controllerActionDescriptor != null)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }

        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });
    // c.OperationFilter<FileResponseTypeOperationFilter>();
    c.DocInclusionPredicate((name, api) => true);

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = Assembly.GetAssembly(typeof(StartupBase))?.GetName().Name,
        // Version = GetType().Assembly.GetName().Version?.ToString(),
    });
    c.EnableAnnotations();


});
builder.Services.AddHttpClient();

builder.Services.AddFireServices(builder.Configuration);

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
