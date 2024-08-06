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

// Configura��es gerais do aplicativo
builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.FormatterName = Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Systemd; // Use o formato apropriado aqui
    options.LogToStandardErrorThreshold = LogLevel.Debug;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura��o do ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configura��o do Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configura��o do MeuDbContext
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

// Resolu��o de Depend�ncias
builder.Services.ResolveDependencies();

// Configura��o do AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configura��o do MVC
builder.Services.AddMvcConfiguration();

var app = builder.Build();

// Configura��o do ambiente de desenvolvimento e produ��o
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configura��es gerais do middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalizationConfig(); // Considerando que este middleware foi configurado externamente

// Configura��o de rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configura��o de p�ginas Razor
app.MapRazorPages();

app.Run();
