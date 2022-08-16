using Produtos.Models;

namespace Produtos.DTO
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public ICollection<TBProduto>? Produtos { get; set; }
    }
}
