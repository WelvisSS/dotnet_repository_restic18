using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Definição da tupla para representar um produto
    private record Produto(int Codigo, string Nome, int Quantidade, double PrecoUnitario);

    static void Main()
    {
        List<Produto> estoque = new List<Produto>();

        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    // CadastrarProduto(estoque);
                    break;
                case "2":
                    // ConsultarProduto(estoque);
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
}
