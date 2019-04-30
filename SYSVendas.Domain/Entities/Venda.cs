using System;
using System.Collections.Generic;

namespace SYSVendas.Domain.Entities
{
    public class Venda
    {
        public int VendaId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataVenda { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<DetalheVenda> VendasProdutos { get; set; }



    }
}
