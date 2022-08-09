using System.ComponentModel.DataAnnotations;

namespace Controle_Orcamento.Domain.Model
{
    public class DespesaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
