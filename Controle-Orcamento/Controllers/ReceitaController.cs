using Controle_Orcamento.Domain.Model;
using Controle_Orcamento.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Orcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ControleOrcamentoContext _cOContext = new();

        [HttpPost]
        public async Task<Receita> Post([FromBody] Receita receita)
        {
            await _cOContext.AddAsync(receita);
            return receita;
        }

        //public IActionResult Get()
        //{

        //}


    }
}
