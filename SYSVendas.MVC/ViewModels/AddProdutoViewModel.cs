using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class AddProdutoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Valores maiores que 0")]
        [Display(Name = "Produto", Prompt = "[Selecione um Produto...]")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "Valores maiores que 0")]
        [Display(Name = "Quantidade")]
        public int Qtd { get; set; }
    }
}