using BlazorApp1.Components;
using DAL_Interface.Repository;
using MudBlazor.Services;
using ORM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

using (LegalContext context = new LegalContext())
{
    context.Database.EnsureCreated();

    using (IUnitOfWork unitOfWork = new UnitOfWork(context))
    {
        if (unitOfWork.RoleRepository.FindById(1) != null)
        {
            unitOfWork.RoleRepository.Create(new Role
            {
                Name = "Admin"
            });
            unitOfWork.Save();
        }
    }
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
