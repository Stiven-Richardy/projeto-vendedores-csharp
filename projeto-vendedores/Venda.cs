using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public Venda(): this(0, 0) { }

        public double valorMedio()
        {
            return (this.qtde == 0) ? 0 : this.valor / this.qtde;
        }
    }
}
