using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2023.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatorio preencher o nome!")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio preencher a Senha!")]
        [DataType(DataType.Password)]
        public string Senha {  get; set; }

        public Perfil Perfil { get; set; }
    }

    //AUTORIZAÇÃO no sistema
    public enum Perfil
    {
        Admin,
        User
    }
}
