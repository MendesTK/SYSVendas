using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSVendas.Domain.Entities
{
    public class DetalheVenda
    {
        public int VendaProdutoId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Qtd { get; set; }
        public decimal Valor { get; set; }
        public decimal Total { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }


    }
}
