using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.DataAccess;
using Microsoft.AspNetCore.Cors;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IRasCode, RasCodeDataAccessLayer>();
builder.Services.AddTransient<IHour, HourDataAccessLayer>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

//builder.Services.AddSingleton<IRasCode, RasCodeDataAccessLayer>();

//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

//// In production, the Angular files will be served from this directory
//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "ClientApp/dist";
//});


var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var rasConnection = builder.Configuration.GetConnectionString("RasConnection");

ConnectionString = connString;
RasConnectionString = rasConnection;

var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:4200") // Adjust this to your Angular app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowSpecificOrigin");
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public partial class Program
{
    public static string? ConnectionString { get; private set; }
    public static string? RasConnectionString { get; private set; }

  //  public static MsSqlDataConnection? ReportSqlConnection { get; private set; }

  

}