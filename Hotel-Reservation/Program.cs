using Hotel_Reservation.Components;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Data.Class;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<HotelContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SQL-Server")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

WebApplication? app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
