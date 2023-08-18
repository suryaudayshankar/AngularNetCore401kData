using AngularNetCore401kData.Interfaces;
using AngularNetCore401kData.DataAccess;
using Microsoft.AspNetCore.Cors;
using AngularNetCore401kData.DataAccess;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IRasCode, RasCodeDataAccessLayer>();
builder.Services.AddTransient<IHour, HourDataAccessLayer>();
builder.Services.AddTransient<SearchDataAccessLayer>();


builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

//builder.Services.AddSingleton<IRasCode, RasCodeDataAccessLayer>();

//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

//// In production, the Angular files will be served from this directory
//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "ClientApp/dist";
//});

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("https://localhost:4200") 
                           .AllowAnyMethod()
                           .AllowAnyHeader());
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                        /*  .WithHeaders("Access-Control-Allow-Origin")*/);
});

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var rasConnection = builder.Configuration.GetConnectionString("RasConnection");
var rasDevConnection = builder.Configuration.GetConnectionString("RasDevConnection");

ConnectionString = connString;
RasConnectionString = rasConnection;
RasDevConnectionString = rasDevConnection;

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

//app.UseCors("AllowMyOrigin");
app.UseRouting();

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();


public partial class Program
{
    public static string? ConnectionString { get; private set; }
    public static string? RasConnectionString { get; private set; }

    public static string? RasDevConnectionString { get; private set; }

  //  public static MsSqlDataConnection? ReportSqlConnection { get; private set; }

  

}