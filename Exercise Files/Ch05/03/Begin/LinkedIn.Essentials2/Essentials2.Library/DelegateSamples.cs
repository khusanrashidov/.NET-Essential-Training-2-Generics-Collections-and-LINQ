using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    // Another case where we want to use delegates is when we want to raise events. And this is
    // what's often referred to as a multicast delegate, meaning I'm going to be able to invoke
    // a method once in my code, but it may then trigger or invoke many different delegates.
    
    // Action and Func help us not have to write the delegate declarations.
    // By the same token, Lambda expressions are going to help us not have
    // to write methods. So for those cases where, really, the implementation
    // of that delegate is very focused, we don't need a standalone method
    // for it, we want to be able to have a way to write a method
    // having to fully declare it or write that logic.

    public static class DelegateSamples
    {
        public static event Action<string> NotifyEventTriggerHappened;
        public static event Del NotifyEventTriggerHappened2;

        public delegate void Del(string input); // the modifier 'static' is not valid for this delegate

        public static void PassMeWork(Del work)
        {
            //work(); // an error
            work("delegates");
        }
        public static void PassMeWork(Action<string> work) // Action<T1, T2, ... , T16> has from 0 up to 16 generic parameters and returns void.
        {
            //work(); // an error
            work("actions");
        }
        public static void PassMeWork(Func<long, double> work) // Func<in, out>  can accept in parameters and can return out parameters.
        {
            //work(); // an error
            double count = work(8);
            Console.WriteLine($"funcs returned: {count}");
        }
        public static void DoSomething()
        {
            Console.WriteLine("I'm about to do something.");
            if (NotifyEventTriggerHappened != null)
            {
                NotifyEventTriggerHappened("I did something");
            }
        }
    }

    public class SystemDelegate
    {
        public static void Function()
        {
            Delegate del = WriteHello;
            //del("K8"); // an error
            del.DynamicInvoke("K8");
            static void WriteHello(string name)
            {
                Console.WriteLine($"Hello {name}.");
            }
        }

    }
    public class CustomDelegate
    {
        delegate void Delegate(string input);
        public static void Method()
        {
            Delegate del = WriteHello;
            del("K8"); // no error
            del.DynamicInvoke("K8");
            static void WriteHello(string name)
            {
                Console.WriteLine($"Hello {name}.");
            }
        }
    }
}