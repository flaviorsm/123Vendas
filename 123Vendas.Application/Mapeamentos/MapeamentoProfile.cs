using _123Vendas.Aplicacao.DTOs;
using _123Vendas.Dominio.Entities;
using AutoMapper;

namespace _123Vendas.Aplicacao.Mapeamentos
{
    public class MapeamentoProfile : Profile
    {
        public MapeamentoProfile()
        {
            CreateMap<Venda, VendaDTO>()
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.ClienteId.ToString()))
                .ForMember(dest => dest.NomeFilial, opt => opt.MapFrom(src => src.Cliente.Nome));

            CreateMap<VendaDTO, Venda>();

            CreateMap<ItemVenda, ItemVendaDTO>()
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto.Nome));
            
            CreateMap<ItemVendaDTO, ItemVenda>();
        }
    }
}
