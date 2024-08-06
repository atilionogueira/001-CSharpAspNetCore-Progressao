using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using AutoMapper;
using UCode.Business.Models;

namespace UCode.App.Controllers
{
    public class ServidorsController : BaseController
    {
        private readonly IServidorRepository _servidorRepository;
        private readonly ICampusRepository _campusRepository;
        private readonly IMapper _mapper;
        private readonly IServidorSerivce _servidorSerivce;

        public ServidorsController(IServidorRepository servidorRepository,
                                   ICampusRepository campusRepository,
                                   IMapper mapper,
                                   IServidorSerivce servidorSerivce,
                                   INotificador notificador) : base(notificador)
        {
            _servidorRepository = servidorRepository;
            _campusRepository = campusRepository;
            _mapper = mapper;
            _servidorSerivce = servidorSerivce;
        }
        [Route("lista-de-servidores")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ServidorViewModel>>(await _servidorRepository.ObterTodosComCampo()));
        }

        [Route("dados-do-servidor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var servidorViewModel = await ObterServidor(id);

            if (servidorViewModel == null) return NotFound();

            return View(servidorViewModel);
        }

        [Route("novo-servidor")]
        public async Task<IActionResult> Create()
        {
            var servidorViewModel = await PopularCampus(new ServidorViewModel());

            return View(servidorViewModel);
        }

        [Route("novo-servidor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServidorViewModel servidorViewModel)
        {
            servidorViewModel = await PopularCampus(servidorViewModel);

            if (!ModelState.IsValid) return View(servidorViewModel);

            var servidor = _mapper.Map<Servidor>(servidorViewModel);

            //  await _servidorRepository.Adiconar(servidor);

            await _servidorSerivce.Adicionar(servidor);

            if (!OperacaoValida()) return View(servidorViewModel);

            return RedirectToAction("Index");

        }
        [Route("editar-servidor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var servidorViewModel = await ObterServidor(id);

            if (servidorViewModel == null) return NotFound();

            return View(servidorViewModel);
        }

        [Route("editar-servidor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServidorViewModel servidorViewModel)
        {
            if (id != servidorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(servidorViewModel);

            var servidorAtualizar = await ObterServidor(id);
            servidorViewModel.Campus = servidorAtualizar.Campus;

            servidorAtualizar.NomeCompleto = servidorViewModel.NomeCompleto;
            servidorAtualizar.Siape = servidorViewModel.Siape;
            servidorAtualizar.Cpf = servidorViewModel.Cpf;


            //   await _servidorRepository.Atualizar(_mapper.Map<Servidor>(servidorAtualizar));
            await _servidorSerivce.Atualizar(_mapper.Map<Servidor>(servidorAtualizar));

            if (!OperacaoValida()) return View(servidorViewModel);

            return RedirectToAction("Index");

        }

        [Route("excluir-servidor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var servidorViewModel = await ObterServidor(id);

            if (servidorViewModel == null) return NotFound();

            return View(servidorViewModel);
        }

        [Route("excluir-servidor/{id:guid}")]
        [HttpPost, ActionName("Delete")] // Esse atributo especifica que a ação é "Delete"
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servidor = await ObterServidor(id);

            if (servidor == null) return NotFound();


            await _servidorSerivce.Remover(id);

            if (!OperacaoValida()) return View("Delete", _mapper.Map<ServidorViewModel>(servidor));

            TempData["Sucesso"] = "Servidor excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<ServidorViewModel> ObterServidor(Guid id)
        {
            var servidor = _mapper.Map<ServidorViewModel>(await _servidorRepository.ObterServidorCampus(id));
            servidor.Campuss = _mapper.Map<IEnumerable<CampusViewModel>>(await _campusRepository.ObterTodos());
            return servidor;
        }

        private async Task<ServidorViewModel> PopularCampus(ServidorViewModel servidor)
        {
            servidor.Campuss = _mapper.Map<IEnumerable<CampusViewModel>>(await _campusRepository.ObterTodos());
            return servidor;
        }

    }
}
