using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Vendedor
    {
        private int id;
        private string name;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; }

        public Vendedor(int id, string name, double percComissao)
        {
            this.id = id;
            this.name = name;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
        }

        public Vendedor(int id) : this(id, "", 0) { }

        public Vendedor(): this(-1, "", 0) { }

        public void registrarVenda(int dia, Venda venda)
        {
            int d = dia - 1;
            if (asVendas[d] == null)
            {
                asVendas[d] = new Venda(venda.Qtde, venda.Valor);
                Console.WriteLine($" Total da venda registrada no dia {dia}: R${venda.Qtde * venda.Valor}");
            } else
            {
                asVendas[d].Qtde += venda.Qtde;
                asVendas[d].Valor += venda.Valor;
            }
        }

        public double valorVendas()
        {
            double total = 0;

            for(int i = 0; i < asVendas.Length; ++i)
            {
                if (asVendas[i] != null)
                {
                    total += asVendas[i].Valor;
                }
            }

            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100);
        }
    }
}
