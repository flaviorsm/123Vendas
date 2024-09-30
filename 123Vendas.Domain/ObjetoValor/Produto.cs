namespace _123Vendas.Dominio.ObjetoValor
{
    public class Produto(Guid produtoId, string nome, decimal preco)
    {
        public Guid ProdutoId { get; private set; } = produtoId;
        public string Nome { get; private set; } = nome;
        public decimal Preco { get; private set; } = preco;
    }

}
