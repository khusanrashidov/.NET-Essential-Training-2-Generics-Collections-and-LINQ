using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public static class DelegateSamples
    {
        public delegate void Del(string input);
        public static void PassMeWork(Del work)
        {
            work("delegates");
            //work(); // an error
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