using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;

namespace UCode.App.Controllers
{
    public class SituacaosController : BaseController
    {
        private readonly ISituacaoRepository _situacaoRepository;
        private readonly ISituacaoService _situacaoService;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public SituacaosController(ISituacaoRepository situacaoRepository,
                                   ISituacaoService situacaoService,
                                   IStatusRepository statusRepository,
                                   IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _situacaoRepository = situacaoRepository;
            _situacaoService = situacaoService;
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [Route("lista-de-situacao")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SituacaoViewModel>>(await _situacaoRepository.ObterSituacaosStatuss()));
        }

        [Route("dados-da-situacao/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var situacaoViewModel = await ObterSituacao(id);

            if (situacaoViewModel == null) return NotFound();

            return View(situacaoViewModel);
        }

        [Route("nova-situacao")]
        public async Task<IActionResult> Create()
        {
            var situacaoViewModel = await PopularStatus(new SituacaoViewModel());

            return View(situacaoViewModel);

        }

        [Route("nova-situacao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SituacaoViewModel situacaoViewModel)
        {
            if (!ModelState.IsValid) return View(situacaoViewModel);

            var situacao = _mapper.Map<Situacao>(situacaoViewModel);

            await _situacaoService.Adicionar(situacao);

            if (!OperacaoValida()) return View(situacaoViewModel);

            return RedirectToAction("Index");

        }

        [Route("editar-situacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var situacaoViewModel = await ObterSituacao(id);

            if (situacaoViewModel == null)
            {
                return NotFound();
            }

            return View(situacaoViewModel);
        }

        [Route("editar-situacao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SituacaoViewModel situacaoViewModel)
        {
            if (id != situacaoViewModel.Id) return NotFound();

            var situacaoAtualizacao = await _situacaoRepository.ObterPorId(id);

            if (!ModelState.IsValid) return View(situacaoViewModel);

            situacaoAtualizacao.MovimentadoEm = situacaoViewModel.MovimentadoEm;
            situacaoAtualizacao.Detalhes = situacaoViewModel.Detalhes;

            await _situacaoService.Atualizar(_mapper.Map<Situacao>(situacaoAtualizacao));

            if (!OperacaoValida()) return View(situacaoViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-situacao/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var situacao = await ObterSituacao(id);

            if (situacao == null) return NotFound();

            return View(situacao);

        }

        [Route("excluir-situacao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var situacao = await ObterSituacao(id);

            if (situacao == null) return NotFound();

            await _situacaoService.Remover(id);

            if (!OperacaoValida()) return View(situacao);

            TempData["Sucesso"] = "Situação excluido com sucesso!";

            return RedirectToAction("Index");      
          
        }



        private async Task<SituacaoViewModel> ObterSituacao(Guid id)
        {
            var situacao = _mapper.Map<SituacaoViewModel>(await _situacaoRepository.ObterSituacaoStatus(id));
            situacao.Statuss = _mapper.Map<IEnumerable<StatusViewModel>>(await _statusRepository.ObterTodos());
            return situacao;
        }

        private async Task<SituacaoViewModel> PopularStatus(SituacaoViewModel situacao)
        {
            situacao.Statuss = _mapper.Map<IEnumerable<StatusViewModel>>(await _statusRepository.ObterTodos());
            return situacao;
        }

    }
}
