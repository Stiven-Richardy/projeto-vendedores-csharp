using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        internal Vendedor[] OsVendedores { get => osVendedores; }
        public int Max { get => max; }
        public int Qtde { get => qtde; }

        public Vendedores()
        {
            this.max = 10;
            this.qtde = 0;
            this.osVendedores = new Vendedor[this.max];
        }

        public bool addVendedor(Vendedor vendedor)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.osVendedores[this.qtde++] = vendedor;
            return podeAdicionar;
        }

        public bool delVendedor(Vendedor vendedor)
        {
            int j;
            bool podeRemover = (searchVendedor(vendedor).Id != -1);
            if (podeRemover && vendedor.valorVendas() == 0)
            {
                int i = 0;
                while (i < this.max && this.osVendedores[i].Id != vendedor.Id)
                {
                    ++i;
                }
                for (j = i; j < this.max - 1; ++j)
                {
                    this.osVendedores[j] = this.osVendedores[j + 1];
                }
                this.osVendedores[j] = new Vendedor();
                this.qtde--;
            }
            return podeRemover;
        }

        public Vendedor searchVendedor(Vendedor vendedor)
        {
            Vendedor vendedorAchado = new Vendedor();
            foreach (Vendedor vend in this.osVendedores)
            {
                if (vend != null && vend.Id == vendedor.Id)
                {
                    vendedorAchado = vend;
                    break;
                }
            }
            return vendedorAchado;
        }

        public double valorVenda() {
            double total = 0;
            foreach (Vendedor vend in this.osVendedores)
            {
                if (vend != null)
                {
                    total += vend.valorVendas();
                }
            }
            return total;
        }

        public double valorComissao()
        {
            double total = 0;
            foreach (Vendedor vend in this.osVendedores)
            {
                if (vend != null)
                {
                    total += vend.valorComissao();
                }
            }
            return total;
        }
    }
}
