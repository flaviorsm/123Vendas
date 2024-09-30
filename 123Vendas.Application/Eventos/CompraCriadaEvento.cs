namespace _123Vendas.Aplicacao.Eventos
{
    public class CompraCriadaEvento(Guid vendaId, DateTime dataVenda, decimal valorTotal)
    {
        public Guid VendaId { get; private set; } = vendaId;
        public DateTime DataVenda { get; private set; } = dataVenda;
        public decimal ValorTotal { get; private set; } = valorTotal;
    }
}
