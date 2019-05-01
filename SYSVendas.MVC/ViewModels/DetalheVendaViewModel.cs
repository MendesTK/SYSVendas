using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class DetalheVendaViewModel
    {
        [Key]
        public int VendaProdutoId { get; set; }

        public int VendaId { get; set; }

        [Display(Name = "ID")]
        public int ProdutoId { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Preencha a quantidade do produto.")]
        public int Qtd { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        public decimal Valor { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        public decimal Total { get; set; }

        public virtual VendaViewModel Venda { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }
    }
}