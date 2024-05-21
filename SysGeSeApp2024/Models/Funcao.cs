using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models
{
    [Table("FUNCAO")]
    public class Funcao : Entity
    {       

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
                

    }
}
