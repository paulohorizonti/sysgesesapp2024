using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

namespace SysGeSeApp2024.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeRepository _unidadeRepository;
        public UnidadeController(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<IActionResult> Index(string cidade, string estado, string nome, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Unidades, QtdTotalItens) = await _unidadeRepository.ObterUnidades(cidade, estado, nome, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);

            var lista = UnidadeConverter.ToViewModel(Unidades);

            return View(new UnidadeListViewModel(lista, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }

    }
}
