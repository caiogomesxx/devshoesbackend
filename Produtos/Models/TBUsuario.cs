using System.ComponentModel.DataAnnotations;

namespace Produtos.Models
{
    public class TBUsuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public bool Admin { get; set; }


    }
}
