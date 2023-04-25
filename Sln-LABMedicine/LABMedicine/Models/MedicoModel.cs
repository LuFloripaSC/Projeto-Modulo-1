﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LABMedicine.Base;

namespace LABMedicine.Models
{
    [Table("Medico")]
    public class MedicoModel : Pessoa 
    {
        [Required]
        [Column("INSTITUICAO DE ENSINO"), MaxLength(40)]
        public string Ensino { get; set; }

        [Required]
        [Column("CRM/UF"), MaxLength(10)]
        public string CRM { get; set; }

        [Required]
        [Column("ESPECIALIZACAO"), MaxLength(20)]
        public string Especializao { get; set; }

        [NotNull]
        [Column("STATUS")]
        public bool EstadoNoSistema { get; set; }
    }
}