using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;
using UCode.Business.Services;

namespace UCode.App.Controllers
{
    public class CamposController : BaseController
    {
        private readonly ICampoRepository _campoRepository;
        private readonly ICampoService _campoService;
        private readonly IMapper _mapper;

        public CamposController(ICampoRepository campoRepository,
                                ICampoService campoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _campoRepository = campoRepository;
            _campoService = campoService;
            _mapper = mapper;
        }
        [Route("lista-de-campos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CampoViewModel>>(await _campoRepository.ObterTodos()));
        }

        [Route("lista-de-campos/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var campoViewModel = await ObterCampo(id);

            if (campoViewModel == null)
            {
                return NotFound();
            }

            return View(campoViewModel);
        }
        [Route("novo-campo")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-campo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CampoViewModel campoViewModel)
        {
            if (!ModelState.IsValid) return View(campoViewModel);
          
                var campo = _mapper.Map<Campo>(campoViewModel);

                await _campoService.Adicionar(campo);

            if (!OperacaoValida()) return View(campoViewModel);

                return RedirectToAction("Index");
          
        }

        [Route("editar-campo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var campoViewModel = await ObterCampo(id);

            if (campoViewModel == null)
            {
                return NotFound();
            }

            return View(campoViewModel);
        }

        [Route("editar-campo/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CampoViewModel campoViewModel)       {
                        
            if (!ModelState.IsValid) return View(campoViewModel);

            var campo = _mapper.Map<Campo>(campoViewModel);

            await _campoService.Atualizar(campo);

            if (!OperacaoValida()) return View(campoViewModel);

            return RedirectToAction("Index");           

        }

        [Route("excluir-campo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterCampo(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [Route("excluir-campo/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            /*
            var campo = await ObterCampo(id);

            if (campo == null) return NotFound();

            await _campoRepository.Remover(id);

            return RedirectToAction("Index");
            */

            var campoViewModel = await _campoRepository.ObterCampoAtividade(id);

            if (campoViewModel == null) return NotFound();

            if (campoViewModel.Atividades.Any())
            {
                TempData["Erro"] = "O Campo possui atividades cadastradas e não pode ser removido.";
                return RedirectToAction("Index");
            }

            await _campoService.Remover(id);

            TempData["Sucesso"] = "Campo excluído com sucesso";

            return RedirectToAction("Index");

        }
        /*
        private async Task<CampoViewModel> ObterCamposAtividade(Guid id) 
        {
            return _mapper.Map(CampoViewModel)(await _campoRepository.ObterCampoAtividade(id));
        }
        */

        private async Task<CampoViewModel> ObterCampo(Guid id) 
        {
            return _mapper.Map<CampoViewModel>(await _campoRepository.ObterCampo(id));
        }

    }
}
