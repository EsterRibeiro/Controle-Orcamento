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

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
