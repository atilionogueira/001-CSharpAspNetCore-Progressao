using UCode.Business.Interface;
using UCode.Business.Notifications;
using UCode.Business.Services;
using UCode.Data.Context;
using UCode.Data.Repository;

namespace UCode.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services) 
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<ICampoRepository, CampoRepository>();
            services.AddScoped<IClasseRepository, ClasseRepository>();
            services.AddScoped<IComprovanteRepository, ComprovanteRespository>();
            services.AddScoped<ICampusRepository, CampusRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProgressaoRepository, ProgressaoRepository>();
            services.AddScoped<IServidorRepository, ServidorRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ISituacaoRepository, SituacaoRepository>();
            services.AddScoped<IValidacaoRepository, ValidacaoRepository>();
            services.AddScoped<INotificador, Notificador>();


            services.AddScoped<ICampusService, CampusService>();
            services.AddScoped<IServidorSerivce, ServidorService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ISituacaoService, SituacaoService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IClasseService, ClasseService>();
            services.AddScoped<IProgressaoService, ProgressaoService>();
            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<ICampoService, CampoService>();

            return services;

        }
    }
}
