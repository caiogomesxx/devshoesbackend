using Microsoft.EntityFrameworkCore;
using Produtos.Context;
using Produtos.DTO;

namespace Produtos.Models
{
    public class Produtos : AppDbContext
    {
        private readonly AppDbContext DBLOJA;
        public Produtos(AppDbContext _DBLOJA) : base()
        {
            DBLOJA = _DBLOJA;
        }
        public ProdutosDTO InserirProduto(ProdutosDTO produto)
        {
            try
            {
                TBProduto tbProdutos = new TBProduto()
                {
                    ProdutoId = produto.ProdutoId,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Estoque = produto.Estoque,
                    HoraCadastro = DateTime.Now,
                    CategoriaId = produto.CategoriaId,
                    ImagemId = produto.ProdutoId

                };
                DBLOJA.TB_PRODUTOS.Add(tbProdutos);
                DBLOJA.SaveChanges();
                return produto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void DeletarProduto(int Idproduto)
        {
            try
            {
                TBProduto produto = DBLOJA.TB_PRODUTOS.Find(Idproduto);
                DBLOJA.TB_PRODUTOS.Remove(produto);
                DBLOJA.SaveChanges();

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public void AtualizarProduto(ProdutosDTO produtoDTO)
        {
            try
            {
                TBProduto produto = DBLOJA.TB_PRODUTOS.Find(produtoDTO.ProdutoId);
                produto.Nome = produto.Nome;
                produto.Descricao = produto.Descricao;
                produto.Preco = produto.Preco;
                produto.Estoque = produto.Estoque;
                produto.CategoriaId = produto.CategoriaId;
                produto.ImagemId = produto.ProdutoId;
                DBLOJA.SaveChanges();

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public List<ProdutosDTO> ListarProdutos()
        {
            try
            {
                List<ProdutosDTO> lstProdutos = (from p in DBLOJA.TB_PRODUTOS
                                                 join
                                                 i in DBLOJA.TB_IMAGEM
                                                 on p.ProdutoId equals i.ProdutoId
                                                 select new ProdutosDTO()
                                                 {
                                                     ProdutoId = p.ProdutoId,
                                                     Nome = p.Nome,
                                                     Descricao = p.Descricao,
                                                     Preco = p.Preco,
                                                     Estoque = p.Estoque,
                                                     CategoriaId = p.CategoriaId,
                                                     ImagemUrl = p.Imagens
                                                 }
                                                ).ToList();

                return lstProdutos;

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public ProdutosDTO GetProduto(int idProduto)
        {
            try
            {

                TBProduto tbProduto = DBLOJA.TB_PRODUTOS.Find(idProduto);
                ProdutosDTO produto = new ProdutosDTO()
                {
                    ProdutoId = tbProduto.ProdutoId,
                    Nome = tbProduto.Nome,
                    Descricao = tbProduto.Descricao,
                    Preco = tbProduto.Preco,
                    Estoque = tbProduto.Estoque,
                    CategoriaId = tbProduto.CategoriaId,
                    ImagemUrl = tbProduto.Imagens
                };

                return produto;

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
