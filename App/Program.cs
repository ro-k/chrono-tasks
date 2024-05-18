using System.Text.Json.Serialization;
using Lib;
using Lib.Exceptions;
using Lib.Extensions;
using Microsoft.OpenApi.Models;


// ReSharper disable once HeapView.ClosureAllocation
var builder = WebApplication.CreateBuilder(args);

// Build app configuration
// ReSharper disable once HeapView.DelegateAllocation
builder.Services.Configure<AppSettings>(x =>
{
    builder.Configuration.AddEnvironmentVariables();
    
    // x.ConnectionString = builder.Configuration.GetConnectionString("TaskDb");
    x.ConnectionString = builder.Configuration["TaskDb"];
    x.JwtKey = builder.Configuration["JwtKey"];
    x.JwtIssuer = builder.Configuration["JwtIssuer"];
    x.JwtAudience = builder.Configuration["JwtAudience"];
});

// Add services to the container.
builder.Services.ConfigureServices(); // add services in here

// Add auth
builder.Services.AddAuth(builder.Configuration.Get<AppSettings>()!);

// Register the Swagger generator, defining one or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task API", Version = "v1" });
});

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    app.UseDeveloperExceptionPage();
    
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API V1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseMiddleware<ExceptionHandler>();

app.Run();