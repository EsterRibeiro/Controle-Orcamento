using AutoMapper;
using Controle_Orcamento.Domain.Model;
using Controle_Orcamento.Infra.Data;
using Controle_Orcamento.Infra.Data.DTOs.Despesa;
using Controle_Orcamento.Services.DTOs.Receita;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Orcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly ControleOrcamentoContext _cOContext;
        private readonly IMapper _mapper;

        public DespesaController(ControleOrcamentoContext cOContext,
            IMapper mapper)
        {
            _cOContext = cOContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarDespesaDTO despesaDto)
        {
            var despesa = _mapper.Map<Despesa>(despesaDto);


            if (ExisteDespesa(despesa))
                return BadRequest("Já existe um cadastro dessa receita no sistema.");

            _cOContext.Despesas.Add(despesa);
            await _cOContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = despesa.Id }, despesa); //mostra onde o recurso foi criado
        }

        [HttpGet]
        public async Task<IEnumerable<Despesa>> GetAll() =>
            _cOContext.Despesas;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var despesa = _cOContext.Despesas.FirstOrDefault(x => x.Id == id);

            if (despesa is not null)
                _mapper.Map<LerDespesaDTO>(despesa);
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarDespesaDTO despesaDto)
        {
            var desp = _cOContext.Despesas.FirstOrDefault(x => x.Id == id);

            if (desp == null)
                return NotFound();


            _mapper.Map(despesaDto, desp);

            _cOContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var despesa = _cOContext.Despesas.FirstOrDefault(x => x.Id == id);

            if (despesa is null)
                return NotFound();

            _cOContext.Remove(despesa);
            await _cOContext.SaveChangesAsync();

            return NoContent();
        }

        public bool ExisteDespesa(Despesa despesa) //todo jogar para validator
        {
            return _cOContext.Despesas.Any(x => x.Descricao == despesa.Descricao
            && x.Data.Month == despesa.Data.Month && x.Data.Year == despesa.Data.Year);
        }
    }
}
