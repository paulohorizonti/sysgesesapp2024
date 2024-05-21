namespace SysGeSeApp2024.Models.ViewModel
{
    public class FuncaoListViewModel
    {
        public FuncaoListViewModel(List<FuncaoViewModel>? funcoes, int totalItens)
        {
            Funcoes = funcoes;
            TotalItens = totalItens;
        }


        public string Descricao { get; set; }
        public int TotalItens { get; set; }
        public List<FuncaoViewModel>? Funcoes { get; set; }

    }
    public class FuncaoViewModel
    {

        public int Id { get; set; }
        public string Descricao { get; set; }

        public byte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

    }
}
