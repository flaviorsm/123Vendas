using _123Vendas.Aplicacao.DTOs;
using _123Vendas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _123Vendas.Api.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento das operações de vendas.
    /// Fornece métodos para criar, obter, atualizar e deletar vendas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController(IVendaServico vendaServico, ILogger logger) : Controller
    {
        /// <summary>
        /// Cria uma nova venda.
        /// </summary>
        /// <param name="venda">Objeto VendaDTO contendo os dados da venda a ser criada.</param>
        /// <returns>Retorna 201 Created se a venda for criada com sucesso; 400 Bad Request se houver erros de validação.</returns>
        [HttpPost]
        public IActionResult CriarVenda([FromBody] VendaDTO venda)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var novaVenda = vendaServico.CriarVenda(venda);
                return CreatedAtAction(nameof(ObterVendaPorId), new { id = novaVenda.Id }, novaVenda);
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Obtém todas as vendas cadastradas.
        /// </summary>
        /// <returns>Retorna uma lista de vendas. Se houver erro, retorna 400 Bad Request.</returns>
        [HttpGet]
        public IActionResult ObterTodasVendas()
        {
            try
            {
                var vendas = vendaServico.ObterTodasVendas();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Obtém uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda a ser buscada.</param>
        /// <returns>Retorna a venda correspondente ao ID; 404 Not Found se a venda não for encontrada; 400 Bad Request em caso de erro.</returns>
        [HttpGet("{id:guid}")]
        public IActionResult ObterVendaPorId(Guid id)
        {
            try
            {
                var venda = vendaServico.ObterVendaPorId(id);
                if (venda == null)
                    return NotFound();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                return BadRequest(ex.Message);
            }           
        }

        /// <summary>
        /// Atualiza uma venda existente.
        /// </summary>
        /// <param name="id">ID da venda a ser atualizada.</param>
        /// <param name="venda">Objeto VendaDTO com os novos dados da venda.</param>
        /// <returns>Retorna 200 OK se a venda for atualizada com sucesso; 400 Bad Request se o ID não corresponder ou houver erros.</returns>
        [HttpPut("{id:guid}")]
        public IActionResult AtualizarVenda(Guid id, [FromBody] VendaDTO venda)
        {
            try
            {
                if (id != venda.Id)
                    return BadRequest("O ID da venda não corresponde.");

                var vendaAtualizada = vendaServico.AtualizarVenda(venda);
                return Ok(vendaAtualizada);
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Exclui uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda a ser excluída.</param>
        /// <returns>Retorna 204 No Content se a venda for excluída com sucesso; 400 Bad Request se houver erro.</returns>
        [HttpDelete("{id:guid}")]
        public IActionResult DeletarVenda(Guid id)
        {
            try
            {
                vendaServico.DeletarVenda(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                return BadRequest(ex.Message);
            }            
        }
    }
}
