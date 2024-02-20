using BlazorApp1.Components;
using DAL;
using DAL_Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using ORM;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
string connectionString = "Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;";
{
    builder.Services.AddDbContext<DbContext, LegalContext>(options =>
   	options.UseSqlServer(connectionString));
}

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();  

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

string[] roles = new string[] { "Admin", "User" };

using var scope = app.Services.CreateScope();
 

//using (LegalContext context = new LegalContext())
{
	using LegalContext context = scope.ServiceProvider.GetRequiredService<LegalContext>();
	context.Database.EnsureCreated();

    using (IUnitOfWork unitOfWork = new UnitOfWork(context))
    {
        foreach (string role in roles)
        {
            var dbRole = unitOfWork.RoleRepository.Get((x) => x.Name == role).FirstOrDefault();
            if (dbRole == null)
            {
                unitOfWork.RoleRepository.Create(new Role
                {
                    Name = role
                });

            }
        }
        unitOfWork.Save();
       
    }
}


/*var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
