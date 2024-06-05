using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Converters
{
    public static class FuncaoConverter
    {
        //Converte de Model para ViewModel
        public static FuncaoViewModel ToViewModel(Funcao funcao)
        {
            return new FuncaoViewModel
            {
                Id = funcao.Id,
                Descricao = funcao.Descricao,
                Status = funcao.Status,
                DataAlt = funcao.DataAltTexto,
                DataCad = funcao.DataCadTexto

            };
        }

        //Converte de ViewModel para Model
        public static Funcao ToModel(FuncaoViewModel funcaoVm)
        {
            return new Funcao
            {
                Id = funcaoVm.Id,
                Descricao = funcaoVm.Descricao.ToUpper(),
                Status = 1,
                DataCad = DateTime.Now,
                DataAlt = DateTime.Now
            };

        }

        public static List<FuncaoViewModel> ToViewModel(List<Funcao>? funcoes)
        {
            List<FuncaoViewModel> lista = new();
            if (funcoes != null)
            {
                foreach (var funcao in funcoes)
                {
                    lista.Add(ToViewModel(funcao));
                }
            }
            return lista;
        }

    }
}
