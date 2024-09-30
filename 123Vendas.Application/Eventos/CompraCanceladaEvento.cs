namespace _123Vendas.Aplicacao.Eventos
{
    public class CompraCanceladaEvento(Guid vendaId, DateTime dataCancelamento)
    {
        public Guid VendaId = vendaId;
        public DateTime DataCancelamento = dataCancelamento;
    }
}