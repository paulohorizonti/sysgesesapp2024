﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models
{
    public abstract class Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STATUS")]
        public byte? Status { get; set; }


        [Column("DATA_CAD")]
        public DateTime? DataCad { get; set; }


        [Column("DATA_ALT")]
        public DateTime? DataAlt { get; set; }

        public string? DataCadTexto
        {
            get { return DataCad?.ToShortDateString(); }
        }

        public string? DataAltTexto
        {
            get { return DataAlt?.ToShortDateString(); }
        }
    }
}
