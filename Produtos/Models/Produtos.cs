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
                    ProdutoId = 0,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Estoque = 1,
                    HoraCadastro = DateTime.Now,
                    ImagemUrl = produto.ImagemUrl

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
                produto.ImagemUrl = produto.ImagemUrl;
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
                                                
                                                 select new ProdutosDTO()
                                                 {
                                                     ProdutoId = p.ProdutoId,
                                                     Nome = p.Nome,
                                                     Descricao = p.Descricao,
                                                     Preco = p.Preco,
                                                     Estoque = p.Estoque,
                                                     ImagemUrl = p.ImagemUrl
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
                    ImagemUrl = tbProduto.ImagemUrl
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
