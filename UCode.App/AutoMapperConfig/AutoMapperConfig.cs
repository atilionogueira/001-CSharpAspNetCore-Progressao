using AutoMapper;
using UCode.App.ViewModels;
using UCode.Business.Models;

namespace UCode.App.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Atividade, AtividadeViewModel>().ReverseMap();
            CreateMap<Campo, CampoViewModel>().ReverseMap();
            CreateMap<Campus, CampusViewModel>().ReverseMap();
            CreateMap<Cidade, CidadeViewModel>().ReverseMap();
            CreateMap<Comprovante, ComprovanteViewModel>().ReverseMap();
            CreateMap<Classe, ClasseViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Estado, EstadoViewModel>().ReverseMap();
            CreateMap<Progressao, ProgressaoViewModel>().ReverseMap();
            CreateMap<Servidor, ServidorViewModel>().ReverseMap();
            CreateMap<Situacao, SituacaoViewModel>().ReverseMap();
            CreateMap<Status, StatusViewModel>().ReverseMap();
            CreateMap<Validacao, ValidacaoViewModel>().ReverseMap();

            // Mapeamento de listas
            CreateMap<IEnumerable<Comprovante>, List<ComprovanteViewModel>>().ReverseMap();
            CreateMap<IEnumerable<Atividade>, List<AtividadeViewModel>>().ReverseMap();
            CreateMap<IEnumerable<Progressao>, List<ProgressaoViewModel>>().ReverseMap();
        }
    }
}
