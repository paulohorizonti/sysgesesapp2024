using Microsoft.AspNetCore.Mvc.Rendering;
using SysGeSeApp2024.Models.Enums;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class FuncaoListViewModel : BaseListViewModel
    {
        public FuncaoListViewModel(List<FuncaoViewModel>? funcoes, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Funcoes = funcoes;
            TotalItens = totalItens;
            Status = status;
           
        }


        public string Descricao { get; set; }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }

       public string Func { get; set; }
        public List<FuncaoViewModel>? Funcoes { get; set; }

        public List<Funcao> ListaFunc { get; set; }
        
       
    }
    public class FuncaoViewModel
    {

        public int Id { get; set; }
        public string Descricao { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

        public string Func { get; set; }
        public List<Funcao> ListaFunc { get; set; }



    }
}
