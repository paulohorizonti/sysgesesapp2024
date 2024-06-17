using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Converters
{
    public class UnidadeConverter
    {
        public static UnidadeViewModel ToViewModel(Unidade unidade)
        {
            return new UnidadeViewModel
            {
                Id = unidade.Id,
                Nome = unidade.Nome,
                Logradouro = unidade.Logradouro,
                Cep = unidade.Cep,
                Bairro = unidade.Bairro,
                Cidade = unidade.Cidade,
                Estado = unidade.Estado,
                Cnpj = unidade.Cnpj,
                Ie = unidade.Ie,
                Telefone = unidade.Telefone,
                Celular = unidade.Celular,
                Observacoes = unidade.Observacoes,
                Email = unidade.Email,
                DataCad = unidade.DataCadTexto,
                DataAlt = unidade.DataAltTexto

            };
        }

        public static Unidade ToModel(UnidadeViewModel unidadeVM)
        {
            DateTime dataCad;
            DateTime dataAlt;


            if (!DateTime.TryParse(unidadeVM.DataCad, out dataCad))
            {
                dataCad = DateTime.Now;
            }

            if (DateTime.TryParse(unidadeVM.DataAlt, out dataAlt))
            {

                if (dataAlt.Date != DateTime.Now.Date)
                {
                    dataAlt = DateTime.Now;
                }
            }
            else
            {

                dataAlt = DateTime.Now;
            }

            return new Unidade
            {
                Id = unidadeVM.Id,
                Nome = unidadeVM.Nome,
                Logradouro = unidadeVM.Logradouro,
                Cep = unidadeVM.Cep,
                Bairro = unidadeVM.Bairro,
                Cidade = unidadeVM.Cidade,
                Estado = unidadeVM.Estado,
                Cnpj = unidadeVM.Cnpj,
                Ie = unidadeVM.Ie,
                Telefone = unidadeVM.Telefone,
                Celular = unidadeVM.Celular,
                Observacoes = unidadeVM.Observacoes,
                Email = unidadeVM.Email,
                DataCad = dataCad,
                DataAlt = dataAlt
            };
        }
        public static List<UnidadeViewModel> ToViewModel(List<Unidade>? unidades)
        {
            List<UnidadeViewModel> lista = new();
            if (unidades != null)
            {
                foreach (var unidade in unidades)
                {
                    lista.Add(ToViewModel(unidade));
                }
            }
            return lista;
        }

    }
}
