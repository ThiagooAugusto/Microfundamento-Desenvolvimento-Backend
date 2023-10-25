
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2023.Models
{
    [Table ("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Placa Obrigatória!")]
        public string Placa {  get; set; }

        [Required(ErrorMessage = "Ano de Fabricação Obrigatório!")]
        [Display(Name = "Ano da Fabricação")]
        public int AnoFabricacao {  get; set; }

        [Required(ErrorMessage = "Ano do Modelo Obrigatório!")]
        [Display(Name = "Ano do Modelo")]

        public int AnoModelo { get; set; }


    }
}
