using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2023.Models
{
    public class Consumo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatório Informar a descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a descrição")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a quilometragem")]
        public int Km { get; set; }

        [Display(Name ="Tipo do Combustível")]
        public TipoCombustivel Tipo {  get; set; }

        [Required(ErrorMessage ="Obrigatorio informar o veiculo!")]
        public int VeiculoId {  get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

    }
    public enum TipoCombustivel
    {
        Gasolina,
        Etanol
    }
}
