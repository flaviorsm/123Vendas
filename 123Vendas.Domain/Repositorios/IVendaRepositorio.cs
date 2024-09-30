using _123Vendas.Dominio.Entities;

namespace Repositorios
{
    public interface IVendaRepositorio
    {
        Venda? ObterPorId(Guid vendaId);
        IEnumerable<Venda> ObterTodos();
        void Adicionar(Venda venda);
        void Atualizar(Venda venda);
        void Deletar(Venda venda);
    }
}
