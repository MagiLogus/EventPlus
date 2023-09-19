using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.event_.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "Numero de CNPJ obrigatorio!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereco obrigatorio!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        [Required(ErrorMessage = "Nome Fantasia obrigatorio!")]
        public string? NomeFantasia { get; set; }

    }
}
