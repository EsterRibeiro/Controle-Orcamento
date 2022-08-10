using System.ComponentModel.DataAnnotations;

namespace Controle_Orcamento.Domain.Model
{
    public class Despesa : Base
    {
        public Despesa(int id, string descricao, decimal valor, DateTime data)
            : base(id)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        [Range(typeof(decimal),"0", "1000000000000")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
