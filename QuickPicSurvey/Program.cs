using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickPicSurvey.Application;
using QuickPicSurvey.Components;
using QuickPicSurvey.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddQuickPikSurveyApplication();
//builder.Services.AddDbContext<QuickPicSurveyContext>(options => options.UseSqlServer("Server = Chrisi7SRV\\SQLEXPRESS; Database = QuickPicSurveys; Integrated Security = True; TrustServerCertificate = True;"));
builder.Services.AddQuickPikSurveyInfrastructure();
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
