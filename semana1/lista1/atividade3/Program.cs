// Aluno: Welvis Silva Souza

double doubleValue = 3.14;
int intValue1 = Convert.ToInt32(doubleValue);
int intValue2 = (int)doubleValue;

Console.WriteLine("Converted value using Convert.ToInt32(): " + intValue1);
Console.WriteLine("Converted value using casting operator: " + intValue2);
