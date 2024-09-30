namespace _123Vendas.Aplicacao.DTOs
{
    public class VendaDTO
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public string? NomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelada { get; set; }
        public string? NomeFilial { get; set; }
        public required List<ItemVendaDTO> Itens { get; set; }
    }
}
