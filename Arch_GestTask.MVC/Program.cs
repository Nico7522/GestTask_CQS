using ArchNet_GestTask.Domains.Repositories;
using ArchNet_GestTask.Domains.Services;
using Microsoft.Data.SqlClient;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DbConnection, SqlConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IPersonneRepository, PersonneService>();
builder.Services.AddScoped<ITaskRepository, TaskService>();

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
