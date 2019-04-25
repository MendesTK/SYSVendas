﻿using System;

namespace SYSVendas.Domain.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

    }
}