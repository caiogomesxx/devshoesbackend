using System.ComponentModel.DataAnnotations;

namespace Produtos.Models
{
    public class TBImagem
    {
        [Key]
        public int ImagemId { get; set; }
        public string ImagemUrl { get; set; }
        public int ProdutoId { get; set; }
        public TBProduto? Produto { get; set; }
        
    }
}
