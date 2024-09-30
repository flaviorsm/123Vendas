using _123Vendas.Aplicacao.DTOs;

namespace _123Vendas.Aplicacao.Interfaces
{
    public interface IVendaServico
    {
        VendaDTO CriarVenda(VendaDTO vendaDTO);
        IEnumerable<VendaDTO> ObterTodasVendas();
        VendaDTO? ObterVendaPorId(Guid vendaId);
        VendaDTO AtualizarVenda(VendaDTO vendaDTO);
        void DeletarVenda(Guid vendaId);
    }
}
