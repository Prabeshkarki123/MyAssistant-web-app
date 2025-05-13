using Microsoft.EntityFrameworkCore;
using MyAssistant.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context in container
builder.Services.AddDbContext<MyAssistantContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:MyAssistantConnection"]);
});

builder.Services.AddScoped<IMyAssistantRepo, MyAssistantRepoClass>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
