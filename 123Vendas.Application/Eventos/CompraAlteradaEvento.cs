using _123Vendas.Dominio.Entities;

namespace _123Vendas.Aplicacao.Eventos
{
    public class CompraAlteradaEvento(Guid id, DateTime now, List<ItemVenda> itens, decimal valorTotal)
    {
        public Guid VendaId { get; set; } = id;
        public DateTime DataAlteracao { get; set; } = now;
        public List<ItemVenda> Itens { get; set; } = itens;
        public decimal ValorTotal { get; set; } = valorTotal;
    }
}