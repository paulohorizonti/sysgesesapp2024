﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("users")]
    public class UserModel : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("APELIDO")]
        public string Apelido { get; set; }

        public ICollection<UsuarioFiltroEmpresas> UsuarioFiltros { get; set; }



    }
}
