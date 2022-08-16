using AutoMapper;
using Controle_Orcamento.Domain.Model;
using Controle_Orcamento.Infra.Data.DTOs.Despesa;
using Controle_Orcamento.Infra.Data.DTOs.Receita;
using Controle_Orcamento.Services.DTOs.Receita;

namespace Controle_Orcamento.Profiles
{
    public class ControleOrcamentoProfile : Profile
    {
        public ControleOrcamentoProfile()
        {
            CreateMap<CriarDespesaDTO, Despesa>();
            CreateMap<Despesa, LerDespesaDTO>();
            CreateMap<AtualizarDespesaDTO, Despesa>();
            //analisar o read
            CreateMap<CriarReceitaDTO, Receita>();
            CreateMap<Receita, LerReceitaDTO>();
            CreateMap<AtualizarReceitaDTO, Receita>();
        }
    }
}
