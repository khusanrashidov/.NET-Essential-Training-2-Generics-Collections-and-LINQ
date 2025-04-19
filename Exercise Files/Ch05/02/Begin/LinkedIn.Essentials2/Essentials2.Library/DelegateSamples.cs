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
    public static class DelegateSamples
    {
        public static event Del NotifyEventTriggerHappened;
        public delegate void Del(string input); // the modifier 'static' is not valid for this delegate
        public static void PassMeWork(Del work)
        {
            work("delegates");
            //work(); // an error
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