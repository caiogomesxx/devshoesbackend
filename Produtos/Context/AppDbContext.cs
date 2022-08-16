using Microsoft.EntityFrameworkCore;
using Produtos.Models;

namespace Produtos.Context
{
    public partial class AppDbContext : DbContext
    {
        
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
      

        public DbSet<TBCategoria>? TB_CATEGORIAS { get; set; }
        public DbSet<TBProduto>? TB_PRODUTOS { get;set; }
        public DbSet<TBUsuario>? TB_USUARIOS { get; set; }
        public DbSet<TBImagem>? TB_IMAGEM { get; set; }
    }
}
