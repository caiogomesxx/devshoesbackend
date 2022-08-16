using System.ComponentModel.DataAnnotations;

namespace Produtos.Models
{
    public partial class TBCategoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public ICollection<TBProduto>? Produtos { get; set; }


    }
}
