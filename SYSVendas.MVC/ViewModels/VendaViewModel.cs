using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class VendaViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int VendaId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "99999999999")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Status")]
        public bool Cancelado { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        public virtual ICollection<DetalheVendaViewModel> VendasProdutos { get; set; }
    }
}