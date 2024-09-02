﻿using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

namespace SysGeSeApp2024.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
        public async Task<IActionResult> Index(string descricao, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Perfis, QtdTotalItens) = await _perfilRepository.ObterPerfis(descricao, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);


            var lista = PerfilConverter.ToViewModel(Perfis);

            return View(new PerfilListViewModel(lista, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }
        public async Task<IActionResult> Incluir()
        {

            var perfilViewModel = PerfilConverter.ToViewModel(new Perfil());

            return View(perfilViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Incluir(PerfilViewModel? perfilVM)
        {
            if (ModelState.IsValid && perfilVM != null)
            {
                var perfilNovo = PerfilConverter.ToModel(perfilVM);

                try
                {
                    await _perfilRepository.Adicionar(perfilNovo);
                    TempData["Success"] = "Registro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o REGISTRO, tente novamente";
                    return RedirectToAction("Index");
                }

            }
            return View(perfilVM);
        }

        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _perfilRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _perfilRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
