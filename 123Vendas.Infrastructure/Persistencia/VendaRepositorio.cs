using _123Vendas.Dominio.Entities;
using _123Vendas.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Repositorios;

namespace Persistencia
{
    public class VendaRepositorio(ApplicationDbContext context) : IVendaRepositorio
    {
        public void Adicionar(Venda venda)
        {
            context.Vendas.Add(venda);
            context.SaveChanges();
        }

        public void Atualizar(Venda venda)
        {
            context.Vendas.Update(venda);
            context.SaveChanges();
        }

        public void Deletar(Venda venda)
        {
            context.Vendas.Remove(venda);
            context.SaveChanges();
        }

        public Venda? ObterPorId(Guid vendaId)
        {
            return context.Vendas.Include(v => v.Itens).FirstOrDefault(v => v.Id == vendaId);
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return context.Vendas.Include(v => v.Itens).ToList();
        }
    }
}
