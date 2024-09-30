using _123Vendas.Aplicacao.DTOs;
using _123Vendas.Aplicacao.Eventos;
using _123Vendas.Aplicacao.Interfaces;
using _123Vendas.Dominio.Entities;
using AutoMapper;
using Eventos;
using Microsoft.Extensions.Logging;
using Repositorios;

namespace _123Vendas.Aplicacao.Servicos
{
    public class VendaServico(IVendaRepositorio vendaRepositorio, IPublicarEvento publicarEvento, IMapper mapper, ILogger logger) : IVendaServico
    {
        public VendaDTO AtualizarVenda(VendaDTO vendaDTO)
        {
            logger.LogInformation("Iniciando a atualização da venda {VendaId}", vendaDTO.Id);

            if (vendaDTO == null)
            {
                throw new Exception("A venda não pode ser nula.");
            }

            var venda = mapper.Map<Venda>(vendaDTO);

            vendaRepositorio.Atualizar(venda);

            var evento = new CompraAlteradaEvento(venda.Id, DateTime.Now, venda.Itens, venda.ValorTotal);
            publicarEvento.Publicar(evento);

            logger.LogInformation("Venda {VendaId} atualizada com sucesso", vendaDTO.Id);

            return mapper.Map<VendaDTO>(venda);
        }

        public VendaDTO CriarVenda(VendaDTO vendaDTO)
        {
            logger.LogInformation("Iniciando a criação de uma nova venda para o cliente {ClienteId} em {DataVenda}", vendaDTO.ClienteId, DateTime.UtcNow);

            if (vendaDTO.Itens.Count == 0)
            {
                throw new Exception("A venda deve conter pelo menos um item.");
            }
            var venda = mapper.Map<Venda>(vendaDTO);

            vendaRepositorio.Adicionar(venda);

            var evento = new CompraCriadaEvento(venda.Id, venda.DataVenda, venda.ValorTotal);
            publicarEvento.Publicar(evento);

            logger.LogInformation("Venda {VendaId} criada com sucesso para o cliente {ClienteId}", venda.Id, venda.Cliente.Nome);

            return mapper.Map<VendaDTO>(venda);
        }

        public void DeletarVenda(Guid vendaId)
        {
            logger.LogInformation("Iniciando a exclusão da venda {VendaId}", vendaId);

            var venda = vendaRepositorio.ObterPorId(vendaId) ?? throw new Exception("Venda não encontrada.");

            vendaRepositorio.Deletar(venda);

            var evento = new CompraCanceladaEvento(venda.Id, DateTime.Now);
            publicarEvento.Publicar(evento);

            logger.LogInformation("Venda {VendaId} excluída com sucesso", vendaId);
        }

        public IEnumerable<VendaDTO> ObterTodasVendas()
        {
            var vendas = vendaRepositorio.ObterTodos();
            return mapper.Map<IEnumerable<VendaDTO>>(vendas);
        }

        public VendaDTO? ObterVendaPorId(Guid vendaId)
        {
            var venda = vendaRepositorio.ObterPorId(vendaId);
            if (venda == null)
                return null;

            return mapper.Map<VendaDTO>(venda);
        }
    }
}
