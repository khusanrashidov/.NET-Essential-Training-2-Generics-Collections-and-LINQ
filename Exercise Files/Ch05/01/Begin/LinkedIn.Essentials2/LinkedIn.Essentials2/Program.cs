using Essentials2.Library;

//ThreadSamples.SimpleThread();
//await ThreadSamples.SimpleThreadAsync();
//await ThreadSamples.SimpleThreadSync();

// a delegate is a pointer to a function or a method

Delegate del = WriteHello;
//del.DynamicInvoke(); // an error
del.DynamicInvoke("K8");

DelegateSamples.PassMeWork(WriteHello);

static void WriteHello(string name)
{
    Console.WriteLine($"Hello {name}.");
}