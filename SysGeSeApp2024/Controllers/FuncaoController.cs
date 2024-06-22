using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
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

            var funcaoViewModel = FuncaoConverter.ToViewModel(new Funcao());
         
            return View(funcaoViewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult>Incluir(FuncaoViewModel? funcaoVM)
        {
            if(ModelState.IsValid && funcaoVM != null)
            {
                var funcaoNova = FuncaoConverter.ToModel(funcaoVM);
                try
                {
                    await _funcaoRepository.Adicionar(funcaoNova);
                    TempData["Success"] = "Função cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o usuário, tente novamente";
                    return RedirectToAction("Index");
                }

            }
            return View(funcaoVM);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var funcao = await _funcaoRepository.ObterPorId(id);
          
            var funcaoEditar = FuncaoConverter.ToViewModel(funcao);

            return View(funcaoEditar);
        }

        [HttpPost]
        public async Task<IActionResult>Editar(FuncaoViewModel funcaoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Falha para editar o Registro");
                return View("Editar", funcaoVM);
            }

            var funcaoEditar = FuncaoConverter.ToModel(funcaoVM);
            try
            {
                await _funcaoRepository.Atualizar(funcaoEditar);
                TempData["Success"] = "Registro ALTERADO com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Houve um erro ao adicionar o registro, tente novamente";
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _funcaoRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _funcaoRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult>Detalhar(int id)
        {
            var funcao = await _funcaoRepository.ObterPorId(id);
            var mostrarFuncao = FuncaoConverter.ToViewModel(funcao);

            return View(mostrarFuncao);
        }

        public async Task<IActionResult>Deletar(int id)
        {
            //busca pelo ID
            var funcaoApagar = await _funcaoRepository.ObterPorId(id);
            var mostrarFuncao = FuncaoConverter.ToViewModel(funcaoApagar);

            return View(mostrarFuncao);
        }

        [HttpPost]
        public async Task<IActionResult>Deletar(FuncaoViewModel funcaoVM)
        {
            if(funcaoVM == null)
            {
                TempData["Error"] = "Registro não pode ser apagado, favor verificar e tentar novamente";
                return RedirectToAction("Index");

            }
            else
            {
                try
                {
                    var removerFuncao = FuncaoConverter.ToModel(funcaoVM);
                    await _funcaoRepository.Remover(removerFuncao);
                    TempData["Success"] = "Registro removido com sucesso";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Registro não pode ser apagado, favor verificar e tentar novamente";
                    return RedirectToAction("Index");
                }
            }
            

        }
    }
}
