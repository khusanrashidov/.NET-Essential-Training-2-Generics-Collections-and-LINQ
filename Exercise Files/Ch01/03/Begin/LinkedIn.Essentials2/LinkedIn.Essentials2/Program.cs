using Essentials2.Library;

var MalikaKhusan = new Customer { Id = 218, FirstName = "Malika", LastName = "Khusan", CreateDate = new DateOnly(2020, 8, 8) };
Console.WriteLine(string.Format("{0}, {1}, {2}.", MalikaKhusan.FirstName, MalikaKhusan.LastName, MalikaKhusan.Id));

var mapper = new CustomerToPersonMapper();

var KhusanMalika = mapper.Map(MalikaKhusan);
Console.WriteLine(string.Format("{0}, {1}, {2}.", KhusanMalika.FirstName, KhusanMalika.LastName, KhusanMalika.Id));

KhusanMalika = MalikaKhusan.Map<Person>(mapper);
Console.WriteLine(string.Format("{0}, {1}, {2}.", KhusanMalika.FirstName, KhusanMalika.LastName, KhusanMalika.Id));