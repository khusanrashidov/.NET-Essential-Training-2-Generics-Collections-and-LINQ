using Essentials2.Library;
using Essentials2.Library.Extensions; // That static class that has our extension method in it has to be in scope, has to
                                      // be in namespace scope. And sometimes when people write libraries or even in the
                                      // framework, those extension methods are in a slightly different namespace or they
                                      // may just be in a namespace that you haven't put in scope with the using statement
using System.Xml.Linq;

//static void WriteHello(string name)
//{
//    Console.WriteLine("Hello {0}.", name);
//}

//static double RaiseToPowerOf8(long input)
//{
//    return Math.Pow(8, 8);
//}

//DelegateSamples.PassMeWork((DelegateSamples.Del)WriteHello);
//DelegateSamples.PassMeWork((Action<string>)WriteHello); // cast is needed since ambiguous
//DelegateSamples.PassMeWork((Func<long, double>)RaiseToPowerOf8); // cast is redundant though

//Console.WriteLine();

//var t3 = (double s) => { };
//var t1 = (string s) => Console.WriteLine(s);
//var t2 = (string s) => s.Length;
//var t4 = (string s) =>
//{
//    Console.WriteLine(s);
//    return s.Length;
//};
//t3(8);
//t1("Kate");
//long @double = t2("KateKane");
//Console.WriteLine(@double);
//Console.WriteLine(t4("KaneKate"));

//// Lambda expressions are anonymous methods.

//DelegateSamples.PassMeAction(m => Console.WriteLine("Expression for action: " + m));
//DelegateSamples.PassMeAction((m) => Console.WriteLine("Expression for action: " + m));
//DelegateSamples.PassMeAction((string m) => Console.WriteLine("Expression for action: " + m));
//DelegateSamples.PassMeAction((string m) => { Console.WriteLine("Expression for action: " + m); });

//DelegateSamples.PassMeFunction(k => 8 * k);
//DelegateSamples.PassMeFunction((k) => 8 * k);
//DelegateSamples.PassMeFunction((long k) => (double)(8 * k));
//DelegateSamples.PassMeFunction((long k) => { return (double)(8 * k); });
//DelegateSamples.PassMeFunction((long k) => { Console.WriteLine("Expression for function: "); return (double)(8 * k); });

//var theMostRight = Essentials2.Library.Extensions.StringExtensions.Right("KateKane", 9);
//Console.WriteLine(theMostRight);
//theMostRight = Essentials2.Library.Extensions.StringExtensions.Right("KateKane", 8);
//Console.WriteLine(theMostRight);
//var rightMost = Essentials2.Library.Extensions.StringExtensions.Right("KateKane", 4);
//Console.WriteLine(rightMost);
//
//string s = "KaneKate";
//var right = s.Right(4);
//Console.WriteLine(right);
//
//var names = new List<string>() { "Khusan", "Malika", "Kane", "Kate" };
//var shortest = names.MinBy((s) => s.Length);
//Console.WriteLine($"The shortest name is {shortest}.");
//var orderedNames = names.OrderBy(s => s.Length);
//Console.WriteLine($"{string.Join(", ", names)}.");
//Console.WriteLine($"{string.Join(", ", orderedNames)}.");

// LINQ = language integrated query.
// JSON = JavaScript Object notation.

var employees = new List<Employee>()
{
    new Employee("Malika") { Id = 1 },
    new Employee("Khusan") { Id = 2 },
    new Employee("Kate") { Id = 8 },
    new Employee("Kane") { Id = 20 }
};

var fileteredEmployees = employees.Where(e => e.Id < 8);
foreach (var employee in fileteredEmployees)
    Console.Write(employee + " ");

Console.WriteLine();

foreach (var employee in fileteredEmployees)
{
    Console.WriteLine(employee.FirstName);
}

Console.WriteLine();
var selectFileteredEmployees = employees.Where(e => e.Id < 8).Select(es => es.FirstName);
foreach (var employee in selectFileteredEmployees)
{
    Console.WriteLine(employee);
}

Console.WriteLine();
var selectAnonymousType = employees.Where(e => e.Id < 8).Select(es => new { Firstname = es.FirstName });
foreach (var employee in selectAnonymousType)
{
    Console.WriteLine(employee);
}

foreach (var employee in selectAnonymousType)
{
    Console.WriteLine(employee.Firstname);
}

Console.WriteLine();

var queryEmployees = from employee in employees
                     where employee.Id < 8
                     select employee.FirstName;
Console.WriteLine(string.Format($"{string.Join(", ", queryEmployees)}."));

var queryAnonymousType = from e in employees
                         where e.Id < 8
                         select new { FirstName = e.FirstName };
foreach (var employee in queryAnonymousType)
{
    Console.WriteLine(employee);
}
Console.WriteLine(string.Format($"{string.Join(", ", queryAnonymousType.Select(a => a.FirstName))}."));

Console.WriteLine();
var queryNotProjectionYetTypeObject = from e in employees
                                      where e.Id > 1 & e.Id <= 8
                                      select e;
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee);
}
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee.FirstName);
}
Console.WriteLine();
queryNotProjectionYetTypeObject = from e in employees
                                  where e.Id > 1 & e.Id <= 8
                                  orderby e.Id descending
                                  select e;
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee);
}
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee.FirstName);
}

Console.WriteLine();
queryNotProjectionYetTypeObject = from e in employees
                                  where e.Id > 1 & e.Id <= 8
                                  orderby e.FirstName ascending
                                  select e;
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee);
}
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee.FirstName);
}

Console.WriteLine();
queryNotProjectionYetTypeObject = (from e in employees
                                       //where e.Id > 1 & e.Id <= 8
                                   orderby e.FirstName ascending
                                   select e).Skip(1).Take(3);
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee);
}
foreach (var employee in queryNotProjectionYetTypeObject)
{
    Console.WriteLine(employee.FirstName);
}

Console.WriteLine();
Console.WriteLine("LINQ XML");
var xmlEmployee = XElement.Load("..\\..\\..\\Employees.xml"); // Nullable XElement? type.
var xmlLinq = from xml in xmlEmployee.Descendants("Employee")
              where (int)xml?.Element("Id")! > 2
              select new
              {
                  FirstName = xml.Element("FirstName"),
                  LastName = xml.Element("LastName")
              };
foreach (var xml in xmlLinq)
{
    Console.WriteLine($"{xml.FirstName} {xml.LastName}");
}
foreach (var xml in xmlLinq)
{
    Console.WriteLine($"{xml.FirstName.Value} {xml.LastName.Value}");
}

Console.WriteLine();
var linqXml = (from xml in xmlEmployee.Descendants("Employee")
               where (int)xml?.Element("Id")! > 2
               select new
               {
                   FirstName = xml?.Element("FirstName")!.Value,
                   LastName = xml?.Element("LastName")!.Value
               });
foreach (var xml in linqXml)
{
    Console.WriteLine($"{xml.FirstName} {xml.LastName}");
}