using Essentials2.Library;

var MalikaKhusan = new Customer { Id = 218, FirstName = "Malika", LastName = "Khusan", CreateDate = new DateOnly(2020, 8, 8) };
Console.WriteLine(string.Format("{0}, {1}, {2}.", MalikaKhusan.FirstName, MalikaKhusan.LastName, MalikaKhusan.Id));

var mapper = new CustomerToPersonMapper();

var KhusanMalika = mapper.Map(MalikaKhusan);
Console.WriteLine(string.Format("{0}, {1}, {2}.", KhusanMalika.FirstName, KhusanMalika.LastName, KhusanMalika.Id));

KhusanMalika = MalikaKhusan.Map(mapper);
Console.WriteLine(string.Format("{0}, {1}, {2}.", KhusanMalika.FirstName, KhusanMalika.LastName, KhusanMalika.Id));

Console.WriteLine();

var Malika = new Customer { Id = 1, FirstName = "Malika", LastName = "Muhammadkosimova", CreateDate = new DateOnly(2002, 8, 8) };
Console.WriteLine(string.Format("{0}, {1}, {2}.", Malika.FirstName, Malika.LastName, Malika.Id));

var Khusan = new Customer { Id = 8, FirstName = "Khusan", LastName = "Rashidov", CreateDate = new DateOnly(2002, 7, 21) };
Console.WriteLine(string.Format("{0}, {1}, {2}.", Khusan.FirstName, Khusan.LastName, Khusan.Id));

Console.WriteLine();
var sorter = new Sorter<Customer>();
var customers = new Customer[] { Khusan, Malika };

foreach (var customer in customers)
    Console.WriteLine($"{customer.FirstName} {customer.Id}");
Console.WriteLine();

sorter.Sort(customers);
foreach (var customer in customers)
    Console.WriteLine($"{customer.FirstName} {customer.Id}");