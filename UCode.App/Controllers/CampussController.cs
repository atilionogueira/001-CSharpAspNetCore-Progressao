using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;
using System.Text.RegularExpressions;

namespace UCode.App.Controllers
{
    public class CampussController : BaseController
    {
        private readonly ICampusRepository _campusRepository;
        // private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICampusService _campusService;
        private readonly IMapper _mapper;

        public CampussController(ICampusRepository campusRepository,
                               // IEnderecoRepository enderecoRepository,
                               ICampusService campusService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _campusRepository = campusRepository;
            //_enderecoRepository = enderecoRepository;
            _campusService = campusService;
            _mapper = mapper;
        }

        [Route("lista-de-Campus")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CampusViewModel>>(await _campusRepository.ObterTodos()));
        }

        [Route("dados-da-campus/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var campusViewModel = await ObterCampusEndereco(id);

            if (campusViewModel == null) return NotFound();
           

            return View(campusViewModel);
        }
        
        [Route("novo-campus")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-campus")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CampusViewModel campusViewModel)
        {
            if (!ModelState.IsValid) return View( campusViewModel);

            campusViewModel.Telefone = Regex.Replace(campusViewModel.Telefone, @"[^\d]", "");

            var campus = _mapper.Map<Campus>(campusViewModel);          

            //  await _campusRepository.Adiconar(campus);
            await _campusService.Adicionar(campus);

            if (!OperacaoValida()) return View(campusViewModel);
            
            return RedirectToAction("Index");                   
        }

        [Route("editar-campus/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var campusViewModel = await ObterCampusEndereco(id);

            if (campusViewModel == null) return NotFound();

            return View(campusViewModel);
        }

        [Route("editar-campus/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,CampusViewModel campusViewModel)
        {
            if (id != campusViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(campusViewModel);

            campusViewModel.Telefone = Regex.Replace(campusViewModel.Telefone, @"[^\d]", "");

            var campus = _mapper.Map<Campus>(campusViewModel);

            //   await _campusRepository.Atualizar(campus);
            await _campusService.Atualizar(campus);

            if (!OperacaoValida()) return View(await ObterCampusEndereco(id));

            return RedirectToAction("Index");

        }

        [Route("excluir-campus/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var campusViewModel = await ObterCampusEndereco(id);

            if (campusViewModel == null) return NotFound();

            return View(campusViewModel);
        }
        [Route("excluir-campus/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var campusViewModel = await ObterCampusEndereco(id);

            if (campusViewModel == null) return NotFound();

            // await _campusRepository.Remover(id);
            await _campusService.Remover(id);

            if (!OperacaoValida()) return View(campusViewModel);

            //??? Analisar Fornecedor e Produto
            return RedirectToAction("Index");

        }
        [Route("obter-endereco/{id:guid}")]
        public async Task<IActionResult>ObterEndereco(Guid id) 
        {
            var campus = await ObterCampusEndereco(id);

            if (campus == null) 
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", campus);
        }

        [Route("atualizar-endereco/{id:guid}")]
        public async Task<IActionResult>AtualizarEndereco(Guid id) 
        {
            var campus = await ObterCampusEndereco(id);

            if (campus == null) 
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new CampusViewModel { Endereco = campus.Endereco });
        }

        [Route("atualizar-endereco/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(CampusViewModel campusViewModel) 
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Telefone");

            if(!ModelState.IsValid) return PartialView("_AtualizarEndereco", campusViewModel);

            await _campusService.AtualizarEndereco(_mapper.Map<Endereco>(campusViewModel.Endereco));

            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", campusViewModel);

            var url = Url.Action("ObterEndereco", "Campuss", new {id = campusViewModel.Endereco.CampusId});

            return Json(new { success = true, url });
         
        }


        private async Task<CampusViewModel> ObterCampusEndereco(Guid id)
        {
            return _mapper.Map<CampusViewModel>(await _campusRepository.ObterCampusEnderecoServidor(id));
        }
        
    }
}