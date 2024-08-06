using AutoMapper;
using DevIO.App.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UCode.App.Configurations;
using UCode.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Configurações gerais do aplicativo
builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.FormatterName = Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Systemd; // Use o formato apropriado aqui
    options.LogToStandardErrorThreshold = LogLevel.Debug;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configuração do ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configuração do Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configuração do MeuDbContext
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

// Resolução de Dependências
builder.Services.ResolveDependencies();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configuração do MVC
builder.Services.AddMvcConfiguration();

var app = builder.Build();

// Configuração do ambiente de desenvolvimento e produção
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configurações gerais do middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalizationConfig(); // Considerando que este middleware foi configurado externamente

// Configuração de rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configuração de páginas Razor
app.MapRazorPages();

app.Run();
