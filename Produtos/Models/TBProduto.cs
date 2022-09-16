using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produtos.Models
{
    public class TBProduto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime HoraCadastro { get; set; }
        public string ImagemUrl { get; set; }

    }
}
