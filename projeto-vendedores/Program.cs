/*
| Instituto Federal de São Paulo - Campus Cubatão
| Nome: Stiven Richardy Silva Rodrigues - CB3030202
| Turma: ADS 471
*/

namespace projeto_vendedores
{
    internal class Program
    {
        static Vendedores meusVendedores = new Vendedores(10);

        static void Main(string[] args)
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Titulo("PAINEL PRINCIPAL");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Cadastrar Vendedor");
                Console.WriteLine(" 2 - Consultar Vendedor");
                Console.WriteLine(" 3 - Excluir Vendedor");
                Console.WriteLine(" 4 - Registrar Venda");
                Console.WriteLine(" 5 - Listar Vendedores");
                Console.WriteLine("--------------------------------------------");

                Console.Write(" Escolha uma opção: ");
                string e = Console.ReadLine();
                if (!int.TryParse(e, out opcao))
                {
                    MensagemErro("Opção inválida! Digite um número.");
                    opcao = -1;
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        CadastrarVendedor();
                        break;
                    case 2:
                        ConsultarVendedor();
                        break;
                    case 3:
                        ExcluirVendedor();
                        break;
                    case 4:
                        RegistrarVenda();
                        break;
                    case 5:
                        ListarVendedores();
                        break;
                    default:
                        MensagemErro(" Digite um número de 0-5!");
                        break;
                }
            } while (opcao != 0);
        }

        static void Titulo(string titulo)
        {
            Console.WriteLine("============================================");
            Console.WriteLine($" SISTEMA DE VENDAS - {titulo}");
            Console.WriteLine("============================================");
        }

        static void MensagemErro(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }

        static void MensagemSucesso(string texto) {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }

        static void CadastrarVendedor()
        {
            Console.Clear();
            Titulo("CADASTRAR VENDEDOR");

            if (meusVendedores.Qtde >= meusVendedores.Max)
            {
                MensagemErro("Limite atingido! Não é possível cadastrar mais vendedores.");
                return;
            }

            Console.Write(" Informe o ID do vendedor: ");
            string i = Console.ReadLine();
            if (!int.TryParse(i, out int id))
            {
                MensagemErro("ID Inválido.");
                return;
            }

            Vendedor vendedorPesquisado = meusVendedores.searchVendedor(new Vendedor(id));
            if (vendedorPesquisado.Id != -1)
            {
                MensagemErro("ID já cadastrado");
                return;
            }

            Console.Write(" Informe o Nome do vendedor: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MensagemErro("Nome inválido.");
                return;
            }

            Console.Write(" Informe o percentual(%) de comissão do Vendedor: ");
            string p = Console.ReadLine();
            if (!double.TryParse(p, out double percentual) || percentual < 0)
            {
                MensagemErro("Percentual inválido.");
                return;
            }

            if (meusVendedores.addVendedor(new Vendedor(id, nome, percentual)))
            {
                MensagemSucesso("Vendedor adicionado com sucesso!");
                return;
            }
            else 
            {
                MensagemErro("Vendedor não cadastrado!\n Verifique se o repositório está cheio ou ID duplicado.");
                return;
            }
        }

        static void ConsultarVendedor()
        {
            Console.Clear();
            Titulo("CONSULTAR VENDEDOR");

            Console.Write(" Informe o ID do vendedor: ");
            string ids = Console.ReadLine();
            if (!int.TryParse(ids, out int id))
            {
                MensagemErro("ID Inválido.");
                return;
            }

            Vendedor vendedorPesquisado =  new Vendedor(id);
            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(vendedorPesquisado);
            if (vendedorEncontrado.Id == -1)
            {
                MensagemErro("O vendedor não foi encontrado.");
            }
            else
            {
                bool semVendas = true;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($" ID: {vendedorEncontrado.Id}");
                Console.WriteLine($" Nome: {vendedorEncontrado.Name}");
                Console.WriteLine($" Valor total das vendas: R${vendedorEncontrado.valorVendas():F2}");
                Console.WriteLine($" Valor total da comissão: R${vendedorEncontrado.valorComissao():F2} ({vendedorEncontrado.PercComissao:F2}%)");
                Console.WriteLine($" Valor médio das vendas diárias: ");
                for (int i = 0; i < vendedorEncontrado.AsVendas.Length; i++)
                {
                    if (vendedorEncontrado.AsVendas[i] != null)
                    {
                        Console.WriteLine($" Dia {i+1}: R${vendedorEncontrado.AsVendas[i].valorMedio():F2}");
                        semVendas = false;
                    }
                }
                if (semVendas)
                {
                    Console.WriteLine(" Não houveram vendas");
                }
                Console.WriteLine("--------------------------------------------");
                MensagemSucesso("Consulta concluída!");
            }
        }

        static void ExcluirVendedor()
        {
            Console.Clear();
            Titulo("EXCLUIR VENDEDOR");

            Console.Write(" Informe o ID do vendedor: ");
            string i = Console.ReadLine();
            if (!int.TryParse(i, out int id))
            {
                MensagemErro("ID Inválido");
                return;
            }

            Vendedor vendedorPesquisado = new Vendedor(id);
            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(vendedorPesquisado);
            if (vendedorEncontrado.Id == -1)
            {
                MensagemErro("O vendedor não foi encontrado.");
            }
            else {
                if (vendedorEncontrado.valorVendas() == 0) {
                    meusVendedores.delVendedor(new Vendedor(id));
                    MensagemSucesso("Vendedor excluído com sucesso!");
                }
                else
                {
                    MensagemErro("Não é possível excluir este vendedor,\n pois ele possui vendas registradas");
                }
            }
        }

        static void RegistrarVenda()
        {
            Console.Clear();
            Titulo("REGISTRAR VENDA");

            Console.Write(" Informe o ID do vendedor: ");
            string i = Console.ReadLine();
            if (!int.TryParse(i, out int id))
            {
                MensagemErro("ID Inválido");
                return;
            }

            Vendedor vendedorPesquisado = new Vendedor(id);
            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(vendedorPesquisado);
            if (vendedorEncontrado.Id == -1)
            {
                MensagemErro("O vendedor não foi encontrado");
            }
            else
            {
                Console.Write(" Informe o dia (1-31): ");
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int dia) || dia < 1 || dia > 31)
                {
                    MensagemErro("Dia inválido. Deve ser entre 1 e 31.");
                    return;
                }

                Console.Write(" Informe a quantidade de vendas: ");
                string q = Console.ReadLine();
                if (!int.TryParse(q, out int qtde) || qtde <= 0)
                {
                    MensagemErro("Quantidade inválida. Deve ser maior que zero.");
                    return;
                }

                Console.Write(" Informe o valor total das vendas: R$");
                string sValor = Console.ReadLine();
                if (!double.TryParse(sValor, out double valor) || valor < 0)
                {
                    MensagemErro("Valor inválido.");
                    return;
                }

                vendedorEncontrado.registrarVenda(dia, new Venda(qtde, valor));
                MensagemSucesso("Venda registrada com sucesso!");
            }
        }

        static void ListarVendedores()
        {
            Console.Clear();
            Titulo("LISTA DE VENDEDORES");

            if (meusVendedores.Qtde == 0)
            {
                MensagemErro("Nenhum vendedor cadastrado.");
                return;
            }

            Vendedor vendedorAchado;
            for (int i = 0; i < meusVendedores.OsVendedores.Length; i++)
            {
                if (meusVendedores.searchVendedor(vendedorAchado = new Vendedor(i)).Id != -1)
                {
                    Console.WriteLine($" Id: {meusVendedores.searchVendedor(vendedorAchado = new Vendedor(i)).Id}\n" +
                            $" Nome: {meusVendedores.searchVendedor(vendedorAchado = new Vendedor(i)).Name}\n" +
                            $" Valor total de vendas: R${meusVendedores.searchVendedor(vendedorAchado = new Vendedor(i)).valorVendas():F2}\n" +
                            $" Valor da Comissão: R${meusVendedores.searchVendedor(vendedorAchado = new Vendedor(i)).valorComissao():F2}\n" +
                            "--------------------------------------------");
                }
            }
            Console.WriteLine($" TOTAL VENDAS: R${meusVendedores.valorVendas():F2}");
            Console.WriteLine($" TOTAL COMISSÕES: R${meusVendedores.valorComissao():F2}");
            Console.WriteLine("--------------------------------------------");
            MensagemSucesso("Listagem concluída!");
        }
    }
}
