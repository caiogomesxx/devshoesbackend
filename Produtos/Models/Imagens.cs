using Produtos.Context;
using Produtos.DTO;

namespace Produtos.Models
{
    public class Imagens : AppDbContext
    {
        private readonly AppDbContext DBLOJA;
        public Imagens(AppDbContext _DBLOJA) : base()
        {
            DBLOJA = _DBLOJA;
        }
        public void InserirImagem(ImagemDTO imagem)
        {
            try 
            {
                TBImagem tbImagem = new TBImagem() 
                { 
                    ImagemId = imagem.ImagemId,
                    ImagemUrl = imagem.ImagemUrl,
                    ProdutoId = imagem.ProdutoId
                };
                DBLOJA.TB_IMAGEM.Add(tbImagem);
                DBLOJA.SaveChanges();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public void AtualizarImagem(ImagemDTO imagem) 
        {
            try 
            {
                TBImagem tbImagem = DBLOJA.TB_IMAGEM.Find(imagem.ImagemId);
                tbImagem.ImagemUrl = imagem.ImagemUrl;
                tbImagem.ProdutoId = imagem.ProdutoId;

                DBLOJA.SaveChanges();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public void RemoverImagem(int idImagem) 
        {
            try 
            {
                TBImagem tbImagem = DBLOJA.TB_IMAGEM.Find(idImagem);
                DBLOJA.TB_IMAGEM.Remove(tbImagem);
                DBLOJA.SaveChanges();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    
        
    }
}
