using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Context;
using Produtos.DTO;
using Produtos.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Produtos.Controllers
{
   
   
    [Route("api/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext DBLOJA;
        public ProdutosController(AppDbContext context)
        {
            DBLOJA = context;
        }

        [ProducesResponseType(typeof(List<ProdutosDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "listar produtos",
            Description = "Listar produtos")]
        [HttpGet("ListarProdutos")]
        public ActionResult ListarProdutos()
        {
            try 
            {
                Produtos.Models.Produtos Model = new(DBLOJA);
                List<ProdutosDTO> produtos = Model.ListarProdutos();
                
                return StatusCode((int)HttpStatusCode.OK, produtos);
            }
            catch(Exception er)
            {
                throw er;
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "Insere um produto",
            Description = "Insere um produto")]
        [HttpPost("InserirProduto")]
        public ActionResult InserirProduto([FromBody]ProdutosDTO produtos)
        {
            try
            {
                Produtos.Models.Produtos Model = new(DBLOJA);
                Model.InserirProduto(produtos);

                return StatusCode((int)HttpStatusCode.OK, "Inserido com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [ProducesResponseType(typeof(ProdutosDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "Busca um produto pelo ID",
            Description = "Busca um produto pelo ID")]
        [HttpGet("GetProduto/{id:int}")]
        public ActionResult GetProduto(int id)
        {
            try
            {
                Produtos.Models.Produtos Model = new(DBLOJA);
                ProdutosDTO response = Model.GetProduto(id);

                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "Atualiza um produto",
            Description = "Atualiza um produto")]
        [HttpPut("AtualizarProduto")]
        public ActionResult AtualizarProduto(ProdutosDTO produto)
        {
            try
            {
                Produtos.Models.Produtos Model = new(DBLOJA);
                 Model.AtualizarProduto(produto);

                return StatusCode((int)HttpStatusCode.OK, "Atualizado com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "Remove um produto",
            Description = "Remove um produto")]
        [HttpDelete("DeletarProduto")]
        public ActionResult DeletarProduto(int idProduto)
        {
            try
            {
                Produtos.Models.Produtos Model = new(DBLOJA);
                Model.DeletarProduto(idProduto);

                return StatusCode((int)HttpStatusCode.OK, "Removido com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }

    }
}
