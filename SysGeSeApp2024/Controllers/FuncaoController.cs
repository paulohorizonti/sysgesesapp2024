using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models.Enums;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly IFuncaoRepository _funcaoRepository;
        public FuncaoController(IFuncaoRepository funcaoRepository)
        {
            _funcaoRepository = funcaoRepository;
        }

        public async Task<IActionResult> Index(string descricao, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Funcoes, QtdTotalItens) = await _funcaoRepository.ObterFuncoes(descricao, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);
                      

            var lista = FuncaoConverter.ToViewModel(Funcoes);

            return View(new FuncaoListViewModel(lista, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }

        public async Task<IActionResult> Incluir()
        {
            var lista = await _funcaoRepository.ObterTodos();

            FuncaoViewModel vm = new FuncaoViewModel();
            vm.ListaFunc = lista;

            return View(vm);
            
        }

        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _funcaoRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 2 : 1);

            try
            {
                _funcaoRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
