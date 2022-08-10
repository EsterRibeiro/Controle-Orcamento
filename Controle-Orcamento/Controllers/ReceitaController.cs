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
        public async Task<IActionResult> Post([FromBody] ReceitaDto receita)
        {
            if (ExisteReceita(receita))
                return BadRequest("Já existe um cadastro dessa receita no sistema.");

            _cOContext.Add(receita);
            await _cOContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = receita.Id }, receita); //mostra onde o recurso foi criado
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_cOContext.Receitas);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receita = _cOContext.Receitas.FirstOrDefault(x => x.Id == id);

            if (receita is not null)
                return Ok(receita);

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Receita receitaAtt)
        {

            var receita = _cOContext.Receitas.FirstOrDefault(x => x.Id == id);

            if (receita == null)
               return NotFound();


            receita.Valor = receitaAtt.Valor;
            receita.Descricao = receitaAtt.Descricao;
            receita.Data = receitaAtt.Data;

            _cOContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var receita = _cOContext.Receitas.FirstOrDefault(x => x.Id == id);

            if (receita is null)
                return NotFound();

            _cOContext.Remove(receita);
            await _cOContext.SaveChangesAsync();

            return NoContent();

            //return await _cOContext.Receitas.;

        }

        public bool ExisteReceita(ReceitaDto receita)
        {
            return _cOContext.Receitas.Any(x => x.Descricao == receita.Descricao
            && x.Data.Month == receita.Data.Month && x.Data.Year == receita.Data.Year);
        }
    }
}
