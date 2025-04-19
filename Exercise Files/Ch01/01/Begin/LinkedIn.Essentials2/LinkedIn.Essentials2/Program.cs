using Essentials2.Library;

var K = new Person()
{
    FirstName = "Khusan",
    LastName = "Rashidov",
};
var M = new Person
{
    FirstName = "Malika",
    LastName = "Muhammadkosimova"
};

long k, m;
(m, k) = (1, 8);

Console.WriteLine($"Before long swap: m = {m} and k = {k}");
//Swap(m, k);
SwapGen<long>(ref m, ref k);
//SwapRef(ref m, ref k);
Console.WriteLine($"After long swap: m = {m} and k = {k}");

Console.WriteLine($"Before person swap: M = {M.FirstName} and K = {K.FirstName}");
//Swap(K, M);
SwapGen<Person>(ref K, ref M);
//SwapRef(ref K, ref M);
Console.WriteLine($"After person swap: M = {M.FirstName} and K = {K.FirstName}");

Console.WriteLine($"Before long swap: m = {m} and k = {k}");
//Swap(m, k);
SwapGen(ref m, ref k);
//SwapRef(ref m, ref k);
Console.WriteLine($"After long swap: m = {m} and k = {k}");

Console.WriteLine($"Before person swap: M = {M.FirstName} and K = {K.FirstName}");
//Swap(K, M);
SwapGen(ref K, ref M);
//SwapRef(ref K, ref M);
Console.WriteLine($"After person swap: M = {M.FirstName} and K = {K.FirstName}");

static void Swap(object first, object second)
{
    object temp = second;
    second = first;
    first = temp;
}

static void SwapRef(ref object first, ref object second)
{
    object temp = second;
    second = first;
    first = temp;
}

static void SwapGen<T>(ref T first, ref T second)
{
    T temp = second;
    second = first;
    first = temp;
}