using Blazored.Toast;
using EM.Pedido.Business.Implementations;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DataAccess.Context;
using EM.Pedido.Repositories.Implementations;
using EM.Pedido.Repositories.Interfaces;
using EM.Pedido.UI.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<BdpedidosContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BdPedidos"));
});
/*
    SCOPED: Se crea una nueva instancia cada vez que se solicita el servicio. Esto es útil para servicios que mantienen estado por solicitud, como los repositorios.
    TRANSIENT: Se crea una nueva instancia cada vez que se solicita el servicio. Esto es útil para servicios ligeros y sin estado, como los servicios de negocio.
    SINGLETON: Se crea una única instancia para toda la aplicación. Esto es útil para servicios que mantienen estado global o que son costosos de crear, como los servicios de configuración.
 */
builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
