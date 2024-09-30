using _123Vendas.Dominio.Entities;
using _123Vendas.Dominio.ObjetoValor;
using _123Vendas.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace _123Vendas.Testes.Infraestrutura
{
    public class VendaRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions;

        public VendaRepositoryTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestVendaDB")
                .Options;
        }

        [Fact]
        public void AdicionarDeveAdicionarVenda()
        {
            using var context = new ApplicationDbContext(dbContextOptions);
            var repositorio = new VendaRepositorio(context);
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial", "Rua 2"));
            venda.AdicionarItem(new Produto(Guid.NewGuid(), "Teste", 100), 10, 12, 0);

            repositorio.Adicionar(venda);

            var vendaFromDb = context.Vendas.Find(venda.Id);
            Assert.NotNull(vendaFromDb);
        }

        [Fact]
        public void ObterTodosDeveRetornarTodasVendas()
        {
            using var context = new ApplicationDbContext(dbContextOptions);

            context.Vendas.Add(new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 1", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial1", "Rua 2")));
            context.Vendas.Add(new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 2", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial2", "Rua 3")));
            context.SaveChanges();

            var repository = new VendaRepositorio(context);

            var vendas = repository.ObterTodos();

            Assert.Equal(2, vendas.Count());
        }

        [Fact]
        public async Task ObterPorIdDeveRetornarVendaPorId()
        {
            using var context = new ApplicationDbContext(dbContextOptions);
            var vendaId = Guid.NewGuid();
            context.Vendas.Add(new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 2", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial2", "Rua 3")));
            await context.SaveChangesAsync();

            var repositorio = new VendaRepositorio(context);

            var venda = repositorio.ObterPorId(vendaId);

            Assert.NotNull(venda);
            Assert.Equal(vendaId, venda.Id);
        }

        [Fact]
        public async Task DeletarDeveRemoverVenda()
        {
            using var context = new ApplicationDbContext(dbContextOptions);
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente 1", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial1", "Rua 2"));
            context.Vendas.Add(venda);
            context.SaveChanges();

            var repository = new VendaRepositorio(context);

            repository.Deletar(venda);
            var vendaFromDb = await context.Vendas.FindAsync(venda.Id);

            Assert.Null(vendaFromDb);
        }
    }
}

