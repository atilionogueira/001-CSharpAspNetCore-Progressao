using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UCode.App.Controllers;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using UCode.App.Extensions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UCode.Data.Repository;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class ComprovantesController : BaseController
    {
        private readonly IComprovanteRepository _comprovanteRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IProgressaoRepository _progressaoRepository;
        private readonly IValidacaoRepository _validacaoRepository;
        private readonly IMapper _mapper;


        public ComprovantesController(IComprovanteRepository comprovanteRepository,
                                      IAtividadeRepository atividadeRepository,
                                      IProgressaoRepository progressaoRepository,
                                      IValidacaoRepository validacaoRepository,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)


        {
            _comprovanteRepository = comprovanteRepository;
            _atividadeRepository = atividadeRepository;
            _progressaoRepository = progressaoRepository;
            _validacaoRepository = validacaoRepository;
            // _notificador = notificador;
            _mapper = mapper;

        }
        [AllowAnonymous]
        [Route("lista-de-comprovante")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ComprovanteViewModel>>(await _comprovanteRepository.ObterTodosComprovanteAtividadeProgressao()));
        }

        [Route("dados-do-comprovante/{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var comprovante = await _comprovanteRepository.ObterComprovanteAtividadeProgressao(id);

            if (comprovante == null) return NotFound();

            var comprovanteViewModel = _mapper.Map<ComprovanteViewModel>(comprovante);

            return View(comprovanteViewModel);
        }






        [ClaimsAuthorize("Comprovante", "Adicionar")]
        [Route("novo-comprovante")]      
        public async Task<IActionResult> Create()
        {
            var atividades = await _atividadeRepository.ObterTodos();
            var progressaos = await _progressaoRepository.ObterTodos();

            var model = new ComprovanteViewModel
            {
                Atividades = atividades?.Any() == true ? _mapper.Map<IEnumerable<AtividadeViewModel>>(atividades) : new List<AtividadeViewModel>(),
                Progressaos = progressaos?.Any() == true ? _mapper.Map<IEnumerable<ProgressaoViewModel>>(progressaos) : new List<ProgressaoViewModel>()
            };

            return View(model);
        }

        [ClaimsAuthorize("Comprovante", "Adicionar")]
        [Route("novo-comprovante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComprovanteViewModel comprovanteViewModel)
        {
            if (!ModelState.IsValid) return View(comprovanteViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";

            if (!await UploadArquivo(comprovanteViewModel.ImagemUpload, imgPrefixo))
            {
                return View(comprovanteViewModel);
            }

            comprovanteViewModel.Arquivo = imgPrefixo + comprovanteViewModel.ImagemUpload.FileName;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null || !Guid.TryParse(userId, out _))
            {
                // Lidar com o cenário onde o UserId não é válido
                return RedirectToAction("Erro", "Home");
            }

            comprovanteViewModel.UsuarioId = Guid.Parse(userId);
           // comprovanteViewModel.Validacao.UsuarioId = Guid.Parse(userId);

            await _comprovanteRepository.Adicionar(_mapper.Map<Comprovante>(comprovanteViewModel));

            return RedirectToAction("Index");

        }

        [AllowAnonymous]
       // [ClaimsAuthorize("Comprovante", "Editar")]
        [Route("editar-comprovante/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var comprovanteViewModel = await ObterComprovante(id);

            if (comprovanteViewModel == null)
            {
                return NotFound();
            }

            return View(comprovanteViewModel);
        }







        [AllowAnonymous]
       // [ClaimsAuthorize("Comprovante", "Editar")]
        [Route("editar-comprovante/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ComprovanteViewModel comprovanteViewModel)
        {
            if (id != comprovanteViewModel.Id) return NotFound();

            var comprovanteAtualizacao = await _comprovanteRepository.ObterPorId(id);

            if (!ModelState.IsValid) return View(comprovanteViewModel);

            if (comprovanteViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(comprovanteViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(comprovanteViewModel);
                }

                comprovanteAtualizacao.Arquivo = imgPrefixo + comprovanteViewModel.ImagemUpload.FileName;
            }

            comprovanteAtualizacao.Quantidade = comprovanteViewModel.Quantidade;
            comprovanteAtualizacao.Data = comprovanteViewModel.Data;
            comprovanteAtualizacao.DataFinal = comprovanteViewModel.DataFinal;

            await _comprovanteRepository.Atualizar(_mapper.Map<Comprovante>(comprovanteAtualizacao));

            return RedirectToAction("Index");
        }


        [ClaimsAuthorize("Comprovante", "Excluir")]
        [Route("excluir-comprovante/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var comprovanteViewModel = await ObterComprovanteValidacao(id);

            if (comprovanteViewModel == null)
            {
                return NotFound();
            }

            return View(comprovanteViewModel);
        }

        [ClaimsAuthorize("Comprovante", "Excluir")]
        [Route("excluir-comprovante/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var comprovanteViewModel = await ObterComprovanteValidacao(id);

            if (comprovanteViewModel == null) return NotFound();

            await _comprovanteRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ComprovanteViewModel> ObterComprovante(Guid id)
        {
            var comprovante = _mapper.Map<ComprovanteViewModel>(await _comprovanteRepository.ObterComprovante(id));
            comprovante.Validacaos = _mapper.Map<IEnumerable<ValidacaoViewModel>>(await _validacaoRepository.ObterTodos());
            ; return comprovante;
        }


        private async Task<ComprovanteViewModel> ObterComprovanteValidacao(Guid id)
        {
            return _mapper.Map<ComprovanteViewModel>(await _comprovanteRepository.ObterComprovanteValidacao(id));
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            await using var stream = new FileStream(path, FileMode.Create);
            await arquivo.CopyToAsync(stream);  // gravar em disco

            return true;
        }


    }

}

