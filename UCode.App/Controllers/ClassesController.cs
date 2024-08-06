using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UCode.App.ViewModels;
using UCode.Business.Interface;
using UCode.Business.Models;

namespace UCode.App.Controllers
{
    public class ClassesController : BaseController
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IClasseService _classeService;
        private readonly IMapper _mapper;

        public ClassesController(IClasseRepository classeRepository,
                                 IClasseService classeService,
                                  IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _classeRepository = classeRepository;
            _classeService = classeService;
            _mapper = mapper;
        }

        [Route("lista-de-classe")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClasseViewModel>>(await _classeRepository.ObterTodos()));
        }


        [Route("dados-da-classe/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var classeViewModel = await ObterClasse(id);
                        
            if (classeViewModel == null) return NotFound();           

            return View(classeViewModel);
        }

        [Route("nova-classe")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-classe")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClasseViewModel classeViewModel)
        {
            if (!ModelState.IsValid) return View(classeViewModel);

            var classe = _mapper.Map<Classe>(classeViewModel);

            await _classeService.Adicionar(classe);

            if (!OperacaoValida()) return View(classeViewModel);

            return RedirectToAction("Index");

        }
        [Route("editar-classe/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var classeViewModel = await ObterClasse(id);

            if (classeViewModel == null) return NotFound();

            return View(classeViewModel);

        }

        [Route("editar-classe/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClasseViewModel classeViewModel) 
        {
            if (!ModelState.IsValid) return View(classeViewModel);

            var classe = _mapper.Map<Classe>(classeViewModel);

            await _classeService.Atualizar(classe);

            if (!OperacaoValida()) return View(classeViewModel);

            return RedirectToAction("Index");

        }

        [Route("excluir-classe/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var classe = await ObterClasse(id);

            if (classe == null) return NotFound();

            return View(classe);            
        }

        [Route("excluir-classe/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id) 
        {
            var classeViewModel = await ObterClasseProgressao(id);

            if (classeViewModel == null) return NotFound();

            await _classeService.Remover(id);

            if (!OperacaoValida()) return View(classeViewModel);

            TempData["Sucesso"] = "A Classe excluida com sucesso";

            return RedirectToAction("Index");

        }
        
        private async Task<ClasseViewModel> ObterClasse(Guid id) 
        {
            return _mapper.Map<ClasseViewModel>(await _classeRepository.ObterClasse(id));
        }

        private async Task<ClasseViewModel> ObterClasseProgressao(Guid id)
        {
            return _mapper.Map<ClasseViewModel>(await _classeRepository.ObterClasseProgressao(id));
        }

    }
}
