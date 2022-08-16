using Produtos.Models;

namespace Produtos.DTO
{
    public class ProdutosDTO
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime HoraCadastro { get; set; }
        public int CategoriaId { get; set; }
        public List<TBImagem> ImagemUrl { get; set; }
    }
}
