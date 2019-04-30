﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class VendaViewModel
    {
        [Key]
        public int VendaId { get; set; }

        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataVenda { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "99999999999")]
        public decimal ValorTotal { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        public virtual ICollection<DetalheVendaViewModel> VendasProdutos { get; set; }
    }
}