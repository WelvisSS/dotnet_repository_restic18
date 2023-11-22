#region Culture Definition

using exemplo3.Pessoa;
using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");


#endregion



/* #region Linq Examples

List<int> list = new() { 1, 2, 3, 4, 5 };
var squaredList = list.Select(x => x * x);
Console.WriteLine($"Original List: {string.Join(", ", list)}");
Console.WriteLine($"Squared  List: {string.Join(", ", squaredList)}");
// Original List: 1, 2, 3, 4, 5
// Squared  List: 1, 4, 9, 16, 25
var summedList = list.Select((x, index) => x + squaredList.ElementAt(index));
Console.WriteLine($"Summed   List: {string.Join(", ", summedList)}");
// Summed   List: 2, 6, 12, 20, 30

var listMultipleOfThree = list.Where(x => x % 3 == 0).ToList();
listMultipleOfThree.AddRange(squaredList.Where(x => x % 3 == 0).ToList());
listMultipleOfThree.AddRange(summedList.Where(x => x % 3 == 0).ToList());
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree)}");
// List Multiple of Three: 3, 9, 6, 12, 30
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree.Order())}");

var students = new List<Student>{
   new Student(1, "Helder Almeida", "123456789", new DateTime(1987, 9, 24), new List<string>{"123456789", "73988342986"}),
   new Student(2, "Nicole Almeida", "987654321", new DateTime(2019, 1, 12), new List<string>{"123456789", "73987654321"}),
   new Student(3, "Gilvana Rocha", "123456789", new DateTime(1984, 11, 24), new List<string>{"123456789", "77988237086"})
};

var any = students.Any();
var anyHelder = students.Any(x => x.FullName.Contains("Helder"));
//var single = students.Single(x => x.Id == 10);
//throw exception
var singleOrDefault = students.SingleOrDefault(x => x.Id == 10);

var select = students.Select(x => x.PhoneNumbers);
var selectMany = students.SelectMany(x => x.PhoneNumbers);

var legalAge = students.Where(x => x.BirthDate <= DateTime.Today.AddYears(-18)).Select(x => x.FullName);
Console.WriteLine($"Legal age people: {string.Join(", ", legalAge)}");


Console.Read();
#endregion */

/* #region Question 1

Console.WriteLine($"{GetPerson("Helder", new DateTime(1987, 9, 24))}");


(string,int) GetPerson(string name, DateTime BirthDate){
   var yearsOld = DateTime.Today.Year - BirthDate.Year;
   if (BirthDate.Date.DayOfYear >= DateTime.Now.DayOfYear) yearsOld--;
   return (name, yearsOld);
}

#endregion */

/* #region Question 2

Func<int,int,int> sumSquares = (x,y) => (x * x)+(y * y);

Console.WriteLine($"2*2+3*3 = {sumSquares(2,3)}");

#endregion */

/* #region Exceptions Examples

try
{
    Console.WriteLine("Enter a number: ");
    var number1 = Console.ReadLine();
    isNumber(number1);

}
catch (InvalidNumberException ex)
{
    // Handle the specific exception
    Console.WriteLine("Error: Número inválido");
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    // Handle any other exceptions
    Console.WriteLine("An error occurred");
    Console.WriteLine(ex.Message);
}
finally
{
    // Code that will always execute, regardless of whether an exception occurred or not
    Console.WriteLine("Finally block executed");
}

int isNumber(string str)
{
    int number;
    if (!int.TryParse(str, out _))
    {
        // Throw a custom exception
        throw new InvalidNumberException("Número inválido");
    }

    number = int.TryParse(str, out number) ? number : 0;

    return number;
}

#endregion */

/* public class Student
{
    public Student(int id, string fullName, string document, DateTime birthDate, List<string> phoneNumbers)
    {
        Id = id;
        FullName = fullName;
        Document = document;
        BirthDate = birthDate;
        PhoneNumbers = new List<string>(phoneNumbers);
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Document { get; set; }
    public DateTime BirthDate { get; set; }
    public List<string> PhoneNumbers { get; set; }
} */


