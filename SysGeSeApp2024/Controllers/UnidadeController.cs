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
        private readonly IEstadoRepository _estadoRepository;

        public UnidadeController(IUnidadeRepository unidadeRepository, IEstadoRepository estadoRepository)
        {
            _unidadeRepository = unidadeRepository;
            _estadoRepository = estadoRepository;
        }

        public async Task<IActionResult> Index(string cidade, string estado, string nome, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var est = await _estadoRepository.ObterTodos();
            var (Unidades, QtdTotalItens) = await _unidadeRepository.ObterUnidades(cidade, estado, nome, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);

            var estados = EstadoConverter.ToViewModel(est);

            var lista = UnidadeConverter.ToViewModel(Unidades);

            return View(new UnidadeListViewModel(lista, estados, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }
    }
}