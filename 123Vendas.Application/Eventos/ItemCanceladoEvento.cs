namespace _123Vendas.Aplicacao.Eventos
{
    public class ItemCanceladoEvento(Guid vendaId, Guid produtoId, DateTime dataCancelamento)
    {
        public Guid VendaId { get; private set; } = vendaId;
        public Guid ProdutoId { get; private set; } = produtoId;
        public DateTime DataCancelamento { get; private set; } = dataCancelamento;
    }
}
