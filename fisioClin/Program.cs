using fisioClin.Components;
using fisioClin.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//cada arquivo com final DAO deve ser enfiado aqui igual o paciente e funcionario
builder.Services.AddScoped<FisioClin.Configs.Conexao>();
builder.Services.AddScoped<PacienteDAO>();
builder.Services.AddScoped<FuncionariosDAO>();
builder.Services.AddScoped<CargoDAO>();


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
