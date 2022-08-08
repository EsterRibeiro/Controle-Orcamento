using System.ComponentModel.DataAnnotations;

namespace Controle_Orcamento.Domain.Model
{
    public class Receita: Base
    {
        public Receita(int id,string descricao, decimal valor, DateTime data)
            :base(id)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }

        [Required(ErrorMessage = "O campo descricao é obrigatório"),
            MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
