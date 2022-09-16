using Microsoft.EntityFrameworkCore;
using Produtos.Models;

namespace Produtos.Context
{
    public partial class AppDbContext : DbContext
    {
        
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
      

        public DbSet<TBProduto>? TB_PRODUTOS { get;set; }
    }
}
