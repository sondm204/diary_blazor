using diary_blazor_web;
using diary_blazor_web.Components;
using diary_blazor_web.Services;
using LumexUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLumexServices();
builder.Services.AddControllers();
builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<ToastService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
