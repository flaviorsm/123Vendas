namespace _123Vendas.Dominio.ObjetoValor
{
    public class Filial(Guid filialId, string nome, string endereco)
    {
        public Guid FilialId { get; private set; } = filialId;
        public string Nome { get; private set; } = nome;
        public string Endereco { get; private set; } = endereco;
    }

}
