using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;

namespace UCode.App.Controllers
{
    public class StatussController : BaseController
    {
        private readonly IStatusService _statusService;
        private readonly IStatusRepository _statusRepository;
     
        private readonly IMapper _mapper;

        public StatussController(IStatusService statusService,                               
                                 IStatusRepository statusRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _statusService = statusService;
            _statusRepository = statusRepository;       
           _mapper = mapper;
        }

        [Route("lista-de-status")]
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<StatusViewModel>>(await _statusRepository.ObterTodos()));
        }

        [Route("dados-da-status/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var status = await _statusRepository.ObterStatus(id);
           
            if (status == null) return NotFound();

            var statusViewModel = _mapper.Map<StatusViewModel>(status);

            return View(statusViewModel); ;
        }

        [Route("novo-status")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-status")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid) return View(statusViewModel);
            {
                var status = _mapper.Map<Status>(statusViewModel);

                await _statusService.Adicionar(status);

                if (!OperacaoValida()) return View(statusViewModel);

                return RedirectToAction("Index");
            }
        }

        [Route("editar-status/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var statusViewModel = await ObterStatus(id);

            if (statusViewModel == null)
            {
                return NotFound();
            }

            return View(statusViewModel);

        }

        [Route("editar-status/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid) return View(statusViewModel);

            var status = _mapper.Map<Status>(statusViewModel);

            await _statusService.Atualizar(status);

            if (!OperacaoValida()) return View(statusViewModel);

            return RedirectToAction("Index");

        }

        [Route("excluir-status/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterStatus(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [Route("excluir-status/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        { 
            var statusViewModel = await ObterStatusSituacao(id); // Obtém a entidade do repositório.

            if (statusViewModel == null) return NotFound();

            // Remove a entidade pelo ID
            await _statusService.Remover(id);

            if (!OperacaoValida()) return View(statusViewModel);

            TempData["Sucesso"] = "Status excluído com sucesso!";

            return RedirectToAction("Index");
           
        }        

        private async Task<StatusViewModel> ObterStatusSituacao(Guid id) 
        {
            return _mapper.Map<StatusViewModel>(await _statusRepository.ObterStatusSituacao(id));
        }

        private async Task<StatusViewModel> ObterStatus(Guid id)
        {
            return _mapper.Map<StatusViewModel>(await _statusRepository.ObterStatus(id));
        }
    }
}
