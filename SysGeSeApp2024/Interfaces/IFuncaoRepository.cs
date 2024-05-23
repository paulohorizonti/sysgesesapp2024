using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.Enums;

namespace SysGeSeApp2024.Interfaces
{
    public interface IFuncaoRepository : IRepository<Funcao>
    {

        Task<(List<Funcao>? Funcoes, int QtdTotalItens)> ObterFuncoes(string descricao, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);
       
       
    }
}
