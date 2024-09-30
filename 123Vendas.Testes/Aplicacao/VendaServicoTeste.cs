using _123Vendas.Aplicacao.DTOs;
using _123Vendas.Aplicacao.Eventos;
using _123Vendas.Aplicacao.Interfaces;
using _123Vendas.Aplicacao.Servicos;
using _123Vendas.Dominio.Entities;
using _123Vendas.Dominio.ObjetoValor;
using AutoMapper;
using Eventos;
using Moq;
using Repositorios;
using Microsoft.Extensions.Logging;

namespace _123Vendas.Testes.Aplicacao
{
    public class VendaServicoTeste
    {
        private readonly Mock<IVendaRepositorio> vendaRepositorioMock;
        private readonly Mock<IPublicarEvento> publicarEventoMock;
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IVendaServico vendaServico;

        public VendaServicoTeste()
        {
            vendaRepositorioMock = new Mock<IVendaRepositorio>();
            publicarEventoMock = new Mock<IPublicarEvento>();
            vendaServico = new VendaServico(vendaRepositorioMock.Object, publicarEventoMock.Object, mapper, logger);
        }

        [Fact]
        public void CriarVendaDeveChamarRepositorioEPublicarEvento()
        {
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial", "Rua 2"));

            var itens = new List<ItemVenda> { new(new Produto(Guid.NewGuid(), "Teste", 100), 10, 100, 0) };

            var dto = mapper.Map<VendaDTO>(venda);

            vendaServico.CriarVenda(dto);

            vendaRepositorioMock.Verify(repo => repo.Adicionar(venda), Times.Once);
            publicarEventoMock.Verify(pub => pub.Publicar(It.IsAny<CompraCriadaEvento>()), Times.Once);
        }

        [Fact]
        public void AtualizarVendaDeveChamarRepositorioEPublicarEvento()
        {
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial", "Rua 2"));

            var itens = new List<ItemVenda> { new(new Produto(Guid.NewGuid(), "Teste", 100), 10, 100, 0) };

            var dto = mapper.Map<VendaDTO>(venda);

            vendaServico.AtualizarVenda(dto);

            vendaRepositorioMock.Verify(repo => repo.Atualizar(venda), Times.Once);
            publicarEventoMock.Verify(pub => pub.Publicar(It.IsAny<CompraAlteradaEvento>()), Times.Once);
        }

        [Fact]
        public void DeletarVendaDeveChamarRepositorioEPublicarEvento()
        {
            // Arrange
            var vendaId = Guid.NewGuid();
            var venda = new Venda(new Cliente(Guid.NewGuid(), "Nome Cliente", "email@email.com"), new Filial(Guid.NewGuid(), "NomeFilial", "Rua 2"));
            
            vendaRepositorioMock.Setup(repo => repo.ObterPorId(vendaId)).Returns(venda);

            vendaServico.DeletarVenda(vendaId);

            vendaRepositorioMock.Verify(repo => repo.Deletar(venda), Times.Once);
            publicarEventoMock.Verify(pub => pub.Publicar(It.IsAny<CompraCanceladaEvento>()), Times.Once);
        }
    }
}