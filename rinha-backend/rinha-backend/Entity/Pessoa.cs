using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rinha_backend.Entity
{
    [Table("pessoa")]
    [Index(nameof(Apelido), IsUnique = true)]
    public class Pessoa
    {
        [Key]
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("apelido")]
        [Required]
        public string Apelido { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("nascimento")]
        [Required]
        public string Nascimento { get; set; }

        [Column("stack")]
        public string[]? Stack { get; set; }
    }
}

