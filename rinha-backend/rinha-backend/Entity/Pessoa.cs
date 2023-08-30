using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
        public string? Apelido { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("nascimento")]
        [Required]
        public string Nascimento { get; set; }

        [Column("stack")]
        [JsonIgnore]
        public string? DbStack { get; set; }

        [NotMapped]
        public List<string> Stack
        {
            get
            {
                if (!string.IsNullOrEmpty(DbStack))
                {
                    return DbStack.Split(',').ToList();
                }
                return new List<string>();
            }
            set
            {
                DbStack = string.Join(",", value);
            }

        }
    }
}

