using System.ComponentModel.DataAnnotations;

namespace Controle_Orcamento.Domain.Model
{
    public class ReceitaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo descricao é obrigatório"),
            MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório"), 
            Range(typeof(decimal),"0", "1000000000000")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
