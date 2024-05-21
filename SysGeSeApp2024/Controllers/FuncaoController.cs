﻿using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
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

        public async Task<IActionResult> Index(string descricao, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Funcoes, QtdTotalItens) = await _funcaoRepository.ObterFuncoes(descricao, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);

            var lista = FuncaoConverter.ToViewModel(Funcoes);

            return View(new FuncaoListViewModel(lista, QtdTotalItens, paginaAtual, qtdItensPagina));
        }
    }
}