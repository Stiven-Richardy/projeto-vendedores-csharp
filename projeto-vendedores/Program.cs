/*
| Instituto Federal de São Paulo - Campus Cubatão
| Nome: Stiven Richardy Silva Rodrigues - CB3030202
| Turma: ADS 471
*/

namespace projeto_vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores meusVendedores = new Vendedores();
            int i = 0;
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("============================================");
                Console.WriteLine("            SISTEMA DE VENDAS");
                Console.WriteLine("============================================");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Cadastrar Vendedor");
                Console.WriteLine(" 2 - Consultar Vendedor");
                Console.WriteLine(" 3 - Excluir Vendedor");
                Console.WriteLine(" 4 - Registrar Venda");
                Console.WriteLine(" 5 - Listar Vendedores");
                Console.WriteLine("--------------------------------------------");
                Console.Write(" Escolha uma opção: ");
                string entrada = Console.ReadLine();
                int.TryParse(entrada, out opcao);

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        Console.ReadKey();
                        break;
                    case 1:
                        CadastrarVendedor(++i, meusVendedores);
                        break;
                    case 2:
                        ConsultarVendedor(meusVendedores);
                        break;
                    case 3:
                        ExcluirVendedor(meusVendedores);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine(" Digite um número de 0-5! (Aperte qualquer tecla...)");
                        Console.ReadKey();
                        break;
                } 
            } while (opcao != 0);
        }

        static void CadastrarVendedor(int i, Vendedores meusVendedores)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do Vendedor: ");
            string nome = Console.ReadLine();
            int perc;
            Console.WriteLine("Digite o percentual de venda do Vendedor: ");
            string entrada = Console.ReadLine();
            int.TryParse(entrada, out perc);
            Console.WriteLine(meusVendedores.addVendedor(new Vendedor(i, nome, perc)) ? $"Vendedor adicionado: {i}" : "Limite máximo de vendedores atingido");
            Console.WriteLine("[Aperte qualquer tecla...]");
            Console.ReadKey();
            Console.Clear();
        }


        static void ConsultarVendedor(Vendedores meusVendedores)
        {
            Console.Clear();
            int id;
            Console.Write("Informe o ID do vendedor: ");
            string entrada = Console.ReadLine();
            int.TryParse(entrada, out id);
            Vendedor vendedorPesquisado =  new Vendedor(id);
            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(vendedorPesquisado);
            if (vendedorEncontrado.Id == -1)
            {
                Console.WriteLine("Não encontrou");
            }
            else
            {
                Console.WriteLine("Vendedor: " + vendedorEncontrado.Name);
            }
            Console.WriteLine("[Aperte qualquer tecla...]");
            Console.ReadKey();
            Console.Clear();
        }

        static void ExcluirVendedor(Vendedores meusVendedores)
        {
            Console.Clear();
            int id;
            Console.Write("Informe o ID do vendedor: ");
            string entrada = Console.ReadLine();
            int.TryParse(entrada, out id);
            Console.WriteLine(meusVendedores.delVendedor(new Vendedor(id)) ? $"Vendedor removido: {id}" : "Vendedor não encontrado");
            Console.WriteLine("[Aperte qualquer tecla...]");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
