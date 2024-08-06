using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using UCode.Business.Models;
using AutoMapper;
using UCode.Data.Repository;

namespace UCode.App.Controllers
{
    public class ProgressaosController : BaseController
    {
        private readonly IProgressaoRepository _progressaoRepository;
        private readonly IProgressaoService _progressaoService;
        private readonly IClasseRepository _classeRepository;
        private readonly IMapper _mapper;

        public ProgressaosController(IProgressaoRepository progressaoRepository,
                                     IProgressaoService progressaoService,
                                     IClasseRepository classeRepository,
                                     IMapper mapper,
                                     INotificador notificador) : base(notificador)
        {
            _progressaoRepository = progressaoRepository;
            _progressaoService = progressaoService;
            _classeRepository = classeRepository;
            _mapper = mapper;
        }

        [Route("lista-de-Progressao")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProgressaoViewModel>>(await _progressaoRepository.ObterTodosComClasse()));

        }

        [Route("dados-do-progressao/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var progressaoViewModel = await ObterProgressao(id);

            if (progressaoViewModel == null) return NotFound();

            return View(progressaoViewModel);

        }

        [Route("nova-progressao")]
        public async Task<IActionResult> Create()
        {
            var progressaoViewModel = await PopularClasse(new ProgressaoViewModel());

            return View(progressaoViewModel);
        }

        [Route("nova-progressao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgressaoViewModel progressaoViewModel)
        {

            if (!ModelState.IsValid) return View(progressaoViewModel);

            var progressao = _mapper.Map<Progressao>(progressaoViewModel);

            await _progressaoService.Adicionar(progressao);

            if (!OperacaoValida()) return View(progressaoViewModel);

            return RedirectToAction("Index");

        }

        [Route("editar-progressao/{id:guid}")]
       
        public async Task<IActionResult> Edit(Guid id)
        {
            var progressaoViewModel= await ObterProgressao(id);

            if (progressaoViewModel == null) return NotFound();
          
            return View(progressaoViewModel);

        }

        [Route("editar-progressao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProgressaoViewModel progressaoViewModel)
        {
            if (id != progressaoViewModel.Id) return NotFound();

            var progressaoAtualizar = await _progressaoRepository.ObterPorId(id);

            if (!ModelState.IsValid) return View(progressaoViewModel);


            progressaoAtualizar.DataInicial = progressaoViewModel.DataInicial;
            progressaoAtualizar.DataFinal = progressaoViewModel.DataFinal;
            progressaoAtualizar.Observacao = progressaoViewModel.Observacao;


            await _progressaoService.Atualizar(_mapper.Map<Progressao>(progressaoAtualizar));

            if (!OperacaoValida()) return View(progressaoViewModel);

            return RedirectToAction("Index");

        }

        [Route("excluir-progressao/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var progressao = await ObterProgressao(id);

            if (progressao == null) return NotFound();

            return View(progressao);
        }

        [Route("excluir-progressao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var progressao = await ObterProgressao(id);

            if (progressao == null) return NotFound();

            await _progressaoService.Remover(id);

            if (!OperacaoValida()) return View(progressao);

            TempData["Sucesso"] = "Situação excluido com sucesso!";

            return RedirectToAction("Index");
        }


        private async Task<ProgressaoViewModel> ObterProgressao(Guid id)
        {
            var progressao = _mapper.Map<ProgressaoViewModel>(await _progressaoRepository.ObterProgressaoClasse(id));
            progressao.Classes = _mapper.Map<IEnumerable<ClasseViewModel>>(await _classeRepository.ObterTodos());
            return progressao;
        }

        private async Task<ProgressaoViewModel> PopularClasse(ProgressaoViewModel classe)
        {
            classe.Classes = _mapper.Map<IEnumerable<ClasseViewModel>>(await _classeRepository.ObterTodos());
            return classe;
        }

    }

}
