using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoEstoque
{
    class Program
    {
        static List<(int, string, int, double)> estoque = new List<(int, string, int, double)>();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Buscar Produto");
                Console.WriteLine("3. Atualizar Estoque");
                Console.WriteLine("4. Gerar Relatórios");
                Console.WriteLine("5. Sair");
                Console.WriteLine("================");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarProduto();
                        break;
                    case "2":
                        BuscarProduto();
                        break;
                    case "3":
                        AtualizarEstoque();
                        break;
                    case "4":
                        GerarRelatorios();
                        break;
                    case "5":
                        sair = true;
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CadastrarProduto()
        {
            try
            {
                Console.Write("Digite o código do produto: ");
                int codigo = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();

                Console.Write("Digite a quantidade em estoque: ");
                int quantidade = int.Parse(Console.ReadLine());

                Console.Write("Digite o preço unitário: ");
                double preco = double.Parse(Console.ReadLine());

                estoque.Add((codigo, nome, quantidade, preco));

                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar produto: " + ex.Message);
            }
        }

        static void BuscarProduto()
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Item1 == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException();
            }

            Console.WriteLine($"Código: {produto.Item1}");
            Console.WriteLine($"Nome: {produto.Item2}");
            Console.WriteLine($"Quantidade em estoque: {produto.Item3}");
            Console.WriteLine($"Preço unitário: {produto.Item4}");
        }

        static void AtualizarEstoque()
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Item1 == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException();
            }

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidade = int.Parse(Console.ReadLine());

            if (produto.Item3 + quantidade < 0)
            {
                throw new EstoqueInsuficienteException();
            }

            produto.Item3 += quantidade;

            Console.WriteLine("Estoque atualizado com sucesso!");
        }

        static void GerarRelatorios()
        {
            Console.WriteLine("===== Relatórios =====");
            Console.WriteLine("1. Listar produtos com quantidade abaixo de um limite");
            Console.WriteLine("2. Listar produtos com valor entre um mínimo e um máximo");
            Console.WriteLine("3. Informar o valor total do estoque e o valor total de cada produto de acordo com seu estoque");
            Console.Write("Escolha uma opção de relatório: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o limite de quantidade: ");
                    int limite = int.Parse(Console.ReadLine());

                    var produtosAbaixoLimite = estoque.Where(p => p.Item3 < limite);

                    Console.WriteLine("===== Produtos abaixo do limite =====");
                    foreach (var produto in produtosAbaixoLimite)
                    {
                        Console.WriteLine($"Código: {produto.Item1}");
                        Console.WriteLine($"Nome: {produto.Item2}");
                        Console.WriteLine($"Quantidade em estoque: {produto.Item3}");
                        Console.WriteLine($"Preço unitário: {produto.Item4}");
                        Console.WriteLine("==========================");
                    }
                    break;
                case "2":
                    Console.Write("Digite o valor mínimo: ");
                    double minimo = double.Parse(Console.ReadLine());

                    Console.Write("Digite o valor máximo: ");
                    double maximo = double.Parse(Console.ReadLine());

                    var produtosEntreValores = estoque.Where(p => p.Item4 >= minimo && p.Item4 <= maximo);

                    Console.WriteLine("===== Produtos entre valores =====");
                    foreach (var produto in produtosEntreValores)
                    {
                        Console.WriteLine($"Código: {produto.Item1}");
                        Console.WriteLine($"Nome: {produto.Item2}");
                        Console.WriteLine($"Quantidade em estoque: {produto.Item3}");
                        Console.WriteLine($"Preço unitário: {produto.Item4}");
                        Console.WriteLine("==========================");
                    }
                    break;
                case "3":
                    double valorTotalEstoque = estoque.Sum(p => p.Item3 * p.Item4);

                    Console.WriteLine($"Valor total do estoque: {valorTotalEstoque}");

                    Console.WriteLine("===== Valor total de cada produto =====");
                    foreach (var produto in estoque)
                    {
                        double valorProduto = produto.Item3 * produto.Item4;
                        Console.WriteLine($"Código: {produto.Item1}");
                        Console.WriteLine($"Nome: {produto.Item2}");
                        Console.WriteLine($"Valor total do produto: {valorProduto}");
                        Console.WriteLine("==========================");
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException() : base("Produto não encontrado.") { }
    }

    public class EstoqueInsuficienteException : Exception
    {
        public EstoqueInsuficienteException() : base("Quantidade em estoque insuficiente.") { }
    }