using _123Vendas.Dominio.ObjetoValor;

namespace _123Vendas.Dominio.Entities
{
    public class ItemVenda(Produto produto, int quantidade, decimal valorUnitario, decimal desconto)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Produto Produto { get; private set; } = produto;
        public int Quantidade { get; private set; } = quantidade;
        public decimal ValorUnitario { get; private set; } = valorUnitario;
        public decimal Desconto { get; private set; } = desconto;
        public decimal ValorTotal { get; private set; } = valorUnitario * quantidade - desconto;
        public Guid VendaId { get; set; }
    }

}
