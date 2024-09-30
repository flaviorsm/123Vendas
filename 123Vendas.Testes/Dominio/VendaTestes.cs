using _123Vendas.Dominio.Entities;
using _123Vendas.Dominio.ObjetoValor;

namespace _123Vendas.Testes.Dominio
{
    public class VendaTestes
    {
        [Fact]
        public void Venda_ValorTotal_DeveSerCalculadoCorretamente()
        {
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 1", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial1", "Rua 2"));
            var produto = new Produto(Guid.NewGuid(), "Teste", 100);

            venda.Itens.Add(new ItemVenda(produto, 2, 50, 10));
            venda.Itens.Add(new ItemVenda(produto, 1, 100, 0));

            decimal valorTotal = venda.ValorTotal;

            Assert.Equal(190, valorTotal);
        }

        [Fact]
        public void Venda_DeveEstarCancelada_AoCancelar()
        {
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 1", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial1", "Rua 2"));

            venda.Cancelar();

            Assert.True(venda.Cancelado);
        }

        [Fact]
        public void ItemVenda_ValorTotal_DeveSerCalculadoCorretamente()
        {
            var produto = new Produto(Guid.NewGuid(), "Teste", 50);
            var item = new ItemVenda(produto, 3, 50, 20);

            decimal valorTotal = item.ValorTotal;

            Assert.Equal(130, valorTotal); // (50 * 3) - 20 = 130
        }
    }
}
