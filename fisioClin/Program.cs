using fisioClin.Components;
using fisioClin.Configs;
using fisioClin.Models; // <-- certifique-se de importar o namespace que contém Conexao e PacienteDAO

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ?? REGISTRA AS DEPENDÊNCIAS
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<PacienteDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
