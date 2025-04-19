namespace Essentials2.Library
{
    public static class CollectionSamples
    {
        public static void Queue()
        {
            //System.Collections.Specialized.NameValueCollection
            var q = new System.Collections.Queue();
            q.Enqueue("Malika");
            q.Enqueue("Khusan");

            string? item = null;

            Console.WriteLine("Using a queue.");
            while ((item = (string?)q.Dequeue()) != null)
            {
                Console.WriteLine(item);
                if (q.Count <= 0)
                    break;
            }
            Console.WriteLine();
        }

        public static void GenQueue()
        {
            //System.Collections.Specialized.NameValueCollection
            var q = new System.Collections.Generic.Queue<string>();
            q.Enqueue("Malika");
            q.Enqueue("Khusan");

            string? item = null;

            Console.WriteLine("Using a generic queue.");
            while ((item = q.Dequeue()) != null)
            {
                Console.WriteLine(item);
                if (q.Count <= 0)
                    break;
            }
            Console.WriteLine();
        }

        public static void Stack()
        {
            var stk = new System.Collections.Stack();
            stk.Push("Malika");
            stk.Push("Khusan");

            string? item = null;
            Console.WriteLine("Using a stack.");

            while ((item = (string?)stk.Pop()) != null)
            {
                Console.WriteLine(item);
                if (stk.Count <= 0)
                    break;
            }
            Console.WriteLine();
        }

        public static void GenStack()
        {
            var stk = new System.Collections.Generic.Stack<string>();
            stk.Push("Malika");
            stk.Push("Khusan");

            string? item = null;
            Console.WriteLine("Using a generic stack.");

            while ((item = stk.Pop()) != null)
            {
                Console.WriteLine(item);
                if (stk.Count <= 0)
                    break;
            }
            Console.WriteLine();
        }
    }
}