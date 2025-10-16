using fisioClin.Components;
using fisioClin.Configs;
using fisioClin.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<PacienteDAO>();

builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<PagamentosDAO>();


var app = builder.Build();

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
