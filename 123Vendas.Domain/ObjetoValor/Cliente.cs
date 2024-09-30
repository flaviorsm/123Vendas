namespace _123Vendas.Dominio.ObjetoValor
{
    public class Cliente(Guid clienteId, string nome, string email)
    {
        public Guid ClienteId { get; private set; } = clienteId;
        public string Nome { get; private set; } = nome;
        public string Email { get; private set; } = email;
    }

}
