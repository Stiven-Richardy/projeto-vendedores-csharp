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

        public int Max { get => max; }
        public int Qtde { get => qtde; }
        public Vendedor[] OsVendedores { get => osVendedores; }

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }

        public bool addVendedor(Vendedor vendedor)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.OsVendedores[this.qtde++] = vendedor;
            return podeAdicionar;
        }

        public bool delVendedor(Vendedor vendedor)
        {
            int j;
            bool podeRemover = (searchVendedor(vendedor).Id != -1);
            if (podeRemover && vendedor.valorVendas() == 0)
            {
                int i = 0;
                while (i < this.max && this.OsVendedores[i].Id != vendedor.Id)
                {
                    ++i;
                }
                for (j = i; j < this.max - 1; ++j)
                {
                    this.OsVendedores[j] = this.OsVendedores[j+1];
                }
                this.OsVendedores[j] = new Vendedor();
                this.qtde--;
            }
            return podeRemover;
        }

        public Vendedor searchVendedor(Vendedor vendedor)
        {
            Vendedor vendedorAchado = new Vendedor();
            foreach (Vendedor v in this.OsVendedores)
            {
                if (v != null && v.Id == vendedor.Id)
                {
                    vendedorAchado = v;
                    break;
                }
            }
            return vendedorAchado;
        }

        public double valorVendas() {
            double total = 0;
            foreach (Vendedor v in this.OsVendedores)
            {
                if (v != null)
                    total += v.valorVendas();
            }
            return total;
        }

        public double valorComissao()
        {
            double total = 0;
            foreach (Vendedor v in this.OsVendedores)
            {
                if (v != null)
                    total += v.valorComissao();
            }
            return total;
        }
    }
}
