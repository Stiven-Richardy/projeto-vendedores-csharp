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
        private Venda[] asVendas = new Venda[31];

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; }

        public Vendedor(int id, string name, double percComissao)
        {
            this.id = id;
            this.name = name;
            this.percComissao = percComissao;
            for (int i = 0; i < asVendas.Length; i++)
            {
                asVendas[i] = null;
            }
        }

        public Vendedor(int id) : this(id, "", 0) { }

        public Vendedor(): this(-1, "", 0) { }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 31) 
                throw new ArgumentOutOfRangeException(nameof(dia), "Dia deve estar entre 1 e 31.");
            int d = dia - 1;
            if (asVendas[d] == null)
            {
                asVendas[d] = new Venda(venda.Qtde, venda.Valor);
                Console.WriteLine($" Total da venda no dia {dia}: R${venda.Valor}");
            } 
            else
            {
                asVendas[d].Qtde += venda.Qtde;
                asVendas[d].Valor += venda.Valor;
            }
        }

        public double valorVendas()
        {
            double total = 0;
            foreach(var v in asVendas)
            {
                if (v != null)
                    total += v.Valor;
            }
            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (this.percComissao / 100);
        }
    }
}
