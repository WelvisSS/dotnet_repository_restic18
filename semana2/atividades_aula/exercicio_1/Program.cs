string[] colecao = {"Item1", "Ite21", "Item3", "Item4"};

foreach (string item in colecao)
{   
    // item = item + " Alterado";
    colecao[0] = "item alterado";
    Console.WriteLine(item);
}


Console.WriteLine("Digite seu nome: ");
string? nome = Console.ReadLine();
Console.WriteLine("Seu nome é: " + nome);