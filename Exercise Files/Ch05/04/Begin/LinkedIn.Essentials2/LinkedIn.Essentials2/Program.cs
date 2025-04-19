using Essentials2.Library;

static void WriteHello(string name)
{
    Console.WriteLine("Hello {0}.", name);
}

static double RaiseToPowerOf8(long input)
{
    return Math.Pow(8, 8);
}

DelegateSamples.PassMeWork((DelegateSamples.Del)WriteHello);
DelegateSamples.PassMeWork((Action<string>)WriteHello); // cast is needed since ambiguous
DelegateSamples.PassMeWork((Func<long, double>)RaiseToPowerOf8); // cast is redundant though

Console.WriteLine();

var t3 = (double s) => { };
var t1 = (string s) => Console.WriteLine(s);
var t2 = (string s) => s.Length;
var t4 = (string s) =>
{
    Console.WriteLine(s);
    return s.Length;
};
t3(8);
t1("Kate");
long @double = t2("KateKane");
Console.WriteLine(@double);
Console.WriteLine(t4("KaneKate"));