using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private record Product(int Code, string Name, int Amount, double UnitPrice);

    static void Main()
    {
        List<Product> stock = new List<Product>();

        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterProduct(stock);
                    break;
                case "2":
                    SearchProduct(stock);
                    break;
                case "3":
                    // AtualizarEstoque(estoque);
                    break;
                case "4":
                    // GerarRelatorios(estoque);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void RegisterProduct(List<Product> stock)
    {
        try
        {
            Console.WriteLine("Cadastro de Produto:");

            Console.Write("Código: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Preço unitário: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product newProduct = new Product(code, name, quantidade, price);
            stock.Add(newProduct);

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida.");
        }
    }

    static void SearchProduct(List<Product> stock)
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Product product = stock.FirstOrDefault(p => p.Code == code);

            if (product != null)
            {
                Console.WriteLine($"Produto encontrado: {product.Name}, Quantidade: {product.Amount}, Preço: {product.UnitPrice}");
            }
            else
            {
                throw new Exception("Produto não encontrado.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
