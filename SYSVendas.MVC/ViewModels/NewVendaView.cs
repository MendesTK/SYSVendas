using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYSVendas.MVC.ViewModels
{
    public class NewVendaView
    {
        [Display(Name = "Detalhes")]
        public List<DetalheVendaViewModel> Detalhes { get; set; }

        public double TotalQtd { get { return Detalhes == null ? 0 : Detalhes.Sum(d => d.Qtd); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ValorTotal { get { return Detalhes == null ? 0 : Detalhes.Sum(d => d.Valor); } }

    }
}