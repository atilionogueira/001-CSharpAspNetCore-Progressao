using AutoMapper;
using DevIO.App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UCode.App.Configurations;
using UCode.Data.Context;


var builder = WebApplication.CreateBuilder(args);

// Configurações de Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // *** Adiciona log no console ***
builder.Logging.AddDebug();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString));
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    // Certifique-se de habilitar SensitiveDataLogging apenas em desenvolvimento
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(connectionString)
      .EnableSensitiveDataLogging();  //Debug loggin;
});

builder.Services.ResolveDependencies();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMvcConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseGlobalizationConfig();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
