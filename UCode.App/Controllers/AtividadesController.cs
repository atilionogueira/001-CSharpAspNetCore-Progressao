using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;
using Microsoft.AspNetCore.Authorization;
using UCode.App.Extensions;

namespace UCode.App.Controllers
{
 //   [Authorize]
    public class AtividadesController : BaseController
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAtividadeService _atividadeService;
        private readonly ICampoRepository _campoRepository;
        private readonly IMapper _mapper;

        public AtividadesController(IAtividadeRepository atividadeRepository,
                                    IAtividadeService atividadeService,
                                    ICampoRepository campoRepository,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _atividadeRepository = atividadeRepository;
            _atividadeService = atividadeService;
            _campoRepository = campoRepository;
            _mapper = mapper;
        }


   //     [AllowAnonymous]
        [Route("lista-de-atividades")]
        public async Task<IActionResult> Index()
        {
            var atividades = await _atividadeRepository.ObterTodosComCampo();
            var atividadesViewModel = _mapper.Map<IEnumerable<AtividadeViewModel>>(atividades);
            return View(atividadesViewModel);
        }

     //   [AllowAnonymous]
        [Route("dados-da-atividade/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var atividadeViewModel = await ObterAtividadeCampo(id);
            if (atividadeViewModel == null) return NotFound();

            return View(atividadeViewModel);
        }
     
       // [ClaimsAuthorize("Atividade","Adicionar")]
        [Route("nova-atividade")]
        public async Task<IActionResult> Create()
        {
            var atividadeViewModel = await PopularCampos(new AtividadeViewModel());
            return View(atividadeViewModel);
        }

        //[ClaimsAuthorize("Atividade", "Adicionar")]
        [Route("nova-atividade")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtividadeViewModel atividadeViewModel)
        {
            if (!ModelState.IsValid) return View(atividadeViewModel);

            var atividade = _mapper.Map<Atividade>(atividadeViewModel);
            await _atividadeService.Adicionar(atividade);

            if (!OperacaoValida()) return View(atividadeViewModel);

            return RedirectToAction("Index");
        }

       // [ClaimsAuthorize("Atividade", "Editar")]
        [Route("editar-atividade/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var atividadeViewModel = await ObterAtividade(id);
            if (atividadeViewModel == null) return NotFound();

            return View(atividadeViewModel);
        }

       // [ClaimsAuthorize("Atividade", "Editar")]
        [Route("editar-atividade/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtividadeViewModel atividadeViewModel)
        {
            if (id != atividadeViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(atividadeViewModel);

            var atividadeAtualizar = await ObterAtividade(id);
            atividadeViewModel.Campo = atividadeAtualizar.Campo;

            atividadeAtualizar.Numero = atividadeViewModel.Numero;
            atividadeAtualizar.Descricao = atividadeViewModel.Descricao;
            atividadeAtualizar.Pontos = atividadeViewModel.Pontos;
            atividadeAtualizar.Detalhes = atividadeViewModel.Detalhes;

            await _atividadeService.Atualizar(_mapper.Map<Atividade>(atividadeAtualizar));

            if (!OperacaoValida()) return View(atividadeViewModel);

            return RedirectToAction("Index");
        }

       // [ClaimsAuthorize("Atividade", "Excluir")]
        [Route("excluir-atividade/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var atividadeViewModel = await ObterAtividadeCampo(id);
            if (atividadeViewModel == null) return NotFound();

            return View(atividadeViewModel);
        }

       // [ClaimsAuthorize("Atividade", "Excluir")]
        [Route("excluir-atividade/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atividade = await ObterAtividade(id);
            if (atividade == null) return NotFound();

            if (atividade.Campos.Any())
            {
                TempData["Erro"] = "A atividade não pode ser excluída porque está vinculada campo.";
               
                return RedirectToAction("Delete", new { id });
            }

            await _atividadeService.Remover(id);

            if (!OperacaoValida()) return View("Delete", _mapper.Map<AtividadeViewModel>(atividade));

            TempData["Sucesso"] = "Atividade excluída com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<AtividadeViewModel> ObterAtividade(Guid id)
        {
            var atividade = await _atividadeRepository.ObterAtividadeCampo(id);
            var atividadeViewModel = _mapper.Map<AtividadeViewModel>(atividade);
            atividadeViewModel.Campos = _mapper.Map<IEnumerable<CampoViewModel>>(await _campoRepository.ObterTodos());
            return atividadeViewModel;
        }

        private async Task<AtividadeViewModel> ObterAtividadeCampo(Guid id)
        {
            return _mapper.Map<AtividadeViewModel>(await _atividadeRepository.ObterAtividadeCampo(id));
        }

        private async Task<AtividadeViewModel> PopularCampos(AtividadeViewModel atividade)
        {
            atividade.Campos = _mapper.Map<IEnumerable<CampoViewModel>>(await _campoRepository.ObterTodos());
            return atividade;
        }
    }
}
