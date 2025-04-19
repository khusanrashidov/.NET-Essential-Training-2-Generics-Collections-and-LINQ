using Essentials2.Library;

//ThreadSamples.SimpleThread();
//await ThreadSamples.SimpleThreadAsync();
//await ThreadSamples.SimpleThreadSync();

Console.CancelKeyPress += OnCancel;
Console.WriteLine("Hit CTRL+Z to cancel.");
// a delegate is a pointer to a function or a method

Delegate del = WriteHello;
//del.DynamicInvoke(); // an error
del.DynamicInvoke("K8");

DelegateSamples.PassMeWork(WriteHello);

static void WriteHello(string name)
{
    Console.WriteLine($"Hello {name}.");
    DelegateSamples.NotifyEventTriggerHappened -= WriteHello;
}

DelegateSamples.NotifyEventTriggerHappened += WriteHello;
DelegateSamples.DoSomething();

for (int i = 0; i <= 1000000; i++)
{
    Console.WriteLine("Writing {0}.", i);
}

static void OnCancel(object sender, ConsoleCancelEventArgs args)
{
    args.Cancel = true;
    Console.WriteLine("Unregistering from delegate event handler.");
    Console.CancelKeyPress -= OnCancel;
    Thread.Sleep(10000);
    args.Cancel = false;
}

// It's a very common pattern for events to have the delegate be an event handler, which is
// essentially a delegate, but it follows this signature where you have the object sender and
// then some kind of event ARGs class or derived class that provides information about the event.