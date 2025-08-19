using Employix.Presentation.Components;
using Employix.Infrastructure;
using Employix.Presentation.Extensions;
using Employix.Application.Extensions;
using Employix.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
                .AddApplication()
                .AddInfrastructure()
                .AddPresentation();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Employix.Presentation.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

await app.AddMigrations();
await app.AddSeeders();

await app.RunAsync();



