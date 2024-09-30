using _123Vendas.Dominio.ObjetoValor;

namespace _123Vendas.Dominio.Entities
{
    public class Venda(Cliente cliente, Filial filial)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime DataVenda { get; private set; } = DateTime.Now;
        public Cliente Cliente { get; private set; } = cliente;
        public Filial Filial { get; private set; } = filial;
        public decimal ValorTotal { get; private set; }
        public bool Cancelado { get; private set; } = false;
        public List<ItemVenda> Itens { get; private set; } = [];

        public void AdicionarItem(Produto produto, int quantidade, decimal valorUnitario, decimal desconto)
        {
            var item = new ItemVenda(produto, quantidade, valorUnitario, desconto);
            Itens.Add(item);
            RecalcularValorTotal();
        }

        public void Cancelar()
        {
            Cancelado = true;
        }

        private void RecalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.ValorTotal);
        }
    }

}
