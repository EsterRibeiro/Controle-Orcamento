
namespace Controle_Orcamento.Domain.Model
{
    public class Base
    {
        public Base(int? id)
        {
            Id = id;
        }

        public Base()
        { }
        public int? Id { get; set; }
    }
}
