using Lib;
using Lib.Extensions;


// ReSharper disable once HeapView.ClosureAllocation
var builder = WebApplication.CreateBuilder(args);

// ReSharper disable once HeapView.DelegateAllocation
builder.Services.Configure<AppSettings>(x =>
{
    // build app configuration
    x.ConnectionString = builder.Configuration.GetConnectionString("TaskDb");
});

// Add services to the container.
builder.Services.ConfigureServices(); // add services in here


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //app.UseDeveloperExceptionPage();
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

app.Run();