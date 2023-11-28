using System;
using System.Collections.Generic;
using System.Linq;

class Storage
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
                    UpdateStock(stock);
                    break;
                case "4":
                    GenerateReports(stock);
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

    static void UpdateStock(List<Product> stock)
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Product product = stock.FirstOrDefault(p => p.Code == code);

            if (product != null)
            {
                Console.WriteLine($"Produto: {product.Name}, Quantidade atual: {product.Amount}");

                Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
                int update = Convert.ToInt32(Console.ReadLine());

                if (product.Amount + update < 0)
                {
                    throw new Exception("Quantidade insuficiente para esta remoção.");
                }

                product = product with { Amount = product.Amount + update };
                int index = stock.FindIndex(p => p.Code == code);
                stock[index] = product;

                Console.WriteLine("Estoque atualizado com sucesso!");
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


    static void GenerateReports(List<Product> stock)
    {
        Console.WriteLine("1. Lista de produtos com quantidade em estoque abaixo de um determinado limite");
        Console.WriteLine("2. Lista de produtos com valor entre um mínimo e um máximo");
        Console.WriteLine("3. Informar o valor total do estoque e o valor total de cada produto");

        Console.Write("Escolha uma opção de relatório: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Informe o limite de quantidade: ");
                int quantityLimit = Convert.ToInt32(Console.ReadLine());

                var productsBelowLimit = stock.Where(p => p.Amount < quantityLimit);
                foreach (var product in productsBelowLimit)
                {
                    Console.WriteLine($"Produto: {product.Name}, Quantidade: {product.Amount}");
                }
                break;
            case "2":
                Console.Write("Informe o valor mínimo: ");
                double minValue = Convert.ToDouble(Console.ReadLine());
                Console.Write("Informe o valor máximo: ");
                double maxValue = Convert.ToDouble(Console.ReadLine());

                var productsRangeValue = stock.Where(p => p.UnitPrice >= minValue && p.UnitPrice <= maxValue);
                foreach (var product in productsRangeValue)
                {
                    Console.WriteLine($"Produto: {product.Name}, Preço: {product.UnitPrice}");
                }
                break;
            case "3":
                double valueTotalStock = stock.Sum(p => p.Amount * p.UnitPrice);
                Console.WriteLine($"Valor total do estoque: {valueTotalStock}");

                foreach (var product in stock)
                {
                    double productValue = product.Amount * product.UnitPrice;
                    Console.WriteLine($"Produto: {product.Name}, Valor total: {productValue}");
                }
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}
