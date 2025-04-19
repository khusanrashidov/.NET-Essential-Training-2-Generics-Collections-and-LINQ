using Essentials2.Library;

string personJson = @"{""Id"":8,""FirstName"":""Malika"",""LastName"":""Khusan"",""Age"":21}";

var jsonPerson = System.Text.Json.JsonSerializer.Deserialize<Person>(personJson);
Console.WriteLine($"{jsonPerson?.FirstName} {jsonPerson?.LastName} {jsonPerson?.Age} {jsonPerson?.Id}");

// nullable types are generic types albeit a little bit different and indirect in usage
double? mk = null;
Nullable<long> km = null;
Nullable<DateTime> dt = null;
Console.WriteLine(dt.GetValueOrDefault());

var K = new Person()
{
    FirstName = "Khusan",
    LastName = "Rashidov",
    Age = 21,
};

var M = new Person
{
    FirstName = "Malika",
    LastName = "Muhammadkosimova",
    Age = 20
};

Swap<Person>(ref K, ref M);

Console.WriteLine($"Khusan: {K.FirstName}");
Console.WriteLine($"Malika: {M.FirstName}");


double k = 8, m = 1;
Swap(ref m, ref k);
Console.WriteLine($"k: {k} and m: {m}");

static void Swap<T>(ref T first, ref T second)
{
    (first, second) = (second, first);
}