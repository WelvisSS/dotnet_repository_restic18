string[] people = { "Welvis", "Andre", "Joao" };

char later = 'a';

Console.WriteLine($"Nomes com {later}: {string.Join(", ", people.Where(x => x.Contains(later)))}");