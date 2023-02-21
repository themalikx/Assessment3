using Assesment3.Db;
using Assesment3.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterServices(builder.Services, builder.Configuration);
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void RegisterServices(IServiceCollection services, IConfiguration configuration)
{



    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



}