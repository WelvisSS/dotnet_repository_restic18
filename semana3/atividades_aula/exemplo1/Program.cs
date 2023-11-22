var tuple1 = (id: 1, name: "Welvis", sobrenome: "Silva Souza", born: new DateTime(2022, 1, 1));
var tuple2 = (id: 2, name: "Teste", sobrenome: "Teste Souza", born: new DateTime(2022, 1, 1));
var tuple3 = (id: 3, name: "Teste2", sobrenome: "Silva Teste2", born: new DateTime(2022, 1, 1));

Console.WriteLine($"{tuple1.id} {tuple1.name} {tuple1.sobrenome} {tuple1.born}");


List<(int id, string name, string sobrenome, DateTime born)> lista = new();

lista.Add(tuple1);
lista.Add(tuple2);
lista.Add(tuple3);


lista.ForEach(x => Console.WriteLine($"{x.id} {x.name} {x.sobrenome} {x.born}"));