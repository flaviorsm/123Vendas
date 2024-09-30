using _123Vendas.Dominio.ObjetoValor;

namespace _123Vendas.Aplicacao.DTOs
{
    public class ItemVendaDTO
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}