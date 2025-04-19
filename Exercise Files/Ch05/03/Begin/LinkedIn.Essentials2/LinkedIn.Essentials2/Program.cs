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