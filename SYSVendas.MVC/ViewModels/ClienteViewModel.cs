using System;
using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        [MaxLength(30, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Sobrenome { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [ScaffoldColumn(false)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o cpf.")]
        [MaxLength(11, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(11, ErrorMessage = "Mínimo de {0} caracteres")]
        public string cpf { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}