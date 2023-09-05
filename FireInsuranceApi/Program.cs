using BimehApi.API;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureLogging(builder.Configuration, builder.Environment);
builder.Services.AddDbContext<FireDbContext>(options =>
   options.UseOracle(builder.Configuration["ConnectionStrings:FireConnection"]));
builder.Services.AddCors(options =>
{
    options.AddPolicy("devCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddControllers();
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
    //var xmlFile =
    //         $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);


});
builder.Services.AddHttpClient();

builder.Services.AddFireServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $" پنل سرویس های بیمه");
    c.InjectStylesheet("/css/swagger.css");
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
