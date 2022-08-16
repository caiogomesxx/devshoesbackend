using Microsoft.AspNetCore.Mvc;
using Produtos.Context;
using Produtos.DTO;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Produtos.Controllers
{
    [Route("api/v1/[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly AppDbContext DBLOJA;
        public ImagemController(AppDbContext context)
        {
            DBLOJA = context;
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [SwaggerOperation(Summary = "Inserir Imagem",
            Description = "Inserir Imagem")]
        [HttpPost("InserirImagem")]
        public ActionResult InserirImagem(ImagemDTO imagem)
        {
            try
            {
                Produtos.Models.Imagens Model = new(DBLOJA);
                Model.InserirImagem(imagem);

                return StatusCode((int)HttpStatusCode.OK, "Inserido com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
          
    }
}
