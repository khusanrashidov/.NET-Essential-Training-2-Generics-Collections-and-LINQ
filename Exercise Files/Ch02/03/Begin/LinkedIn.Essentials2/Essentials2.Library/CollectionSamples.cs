using System.Linq;

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

        private static List<Customer> customers;
        private static List<CustomerRecordStruct> customersRecordStruct;
        private static List<CustomerRecordClass> customersRecordClass;

        static CollectionSamples()
        {
            // initialize new customers and add to list
            customers = new List<Customer>();

            for (int i = 1; i <= 10; i++)
            {
                customers.Add(
                    new Customer
                    {
                        Id = i,
                        FirstName = i.ToString(),
                        LastName = "Customer",
                        CreateDate = new DateOnly(2021, 10, i)
                    });
            }

            customersRecordStruct = new List<CustomerRecordStruct>();

            for (int i = 1; i <= 10; i++)
            {
                customersRecordStruct.Add(
                    new CustomerRecordStruct
                    {
                        Id = i,
                        FirstName = i.ToString(),
                        LastName = "Customer",
                        CreateDate = new DateOnly(2021, 10, i)
                    });
            }

            customersRecordClass = new List<CustomerRecordClass>();

            for (int i = 1; i <= 10; i++)
            {
                customersRecordClass.Add(
                    new CustomerRecordClass
                    {
                        Id = i,
                        FirstName = i.ToString(),
                        LastName = "Customer",
                        CreateDate = new DateOnly(2021, 10, i)
                    });
            }
        }

        public static void Indexing()
        {
            Console.WriteLine("CLASSES:");
            // get an item at a specific index
            var customerThree = customers[2];
            Console.WriteLine($"Found customer {customerThree.Id} at index 2.");

            // check if a collection contains an item
            string doesContain = customers.Contains(customerThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            // FOLLOW UP: What if you created a new customer object with the same property values?
            var anotherCustomerThree = new Customer
            {
                Id = 3,
                FirstName = 3.ToString(),
                LastName = "Customer",
                CreateDate = new DateOnly(2021, 10, 3)
            };
            doesContain = customers.Contains(anotherCustomerThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            Console.WriteLine();

            // FOLLOW UP: Same as before, but what if customer was a record type or value type instead of a class?
            Console.WriteLine("RECORD STRUCTS:");
            // get an item at a specific index
            var customerRecordStructThree = customersRecordStruct[2];
            Console.WriteLine($"Found customer {customerRecordStructThree.Id} at index 2.");

            // check if a collection contains an item
            doesContain = customersRecordStruct.Contains(customerRecordStructThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            // FOLLOW UP: What if you created a new customer object with the same property values?
            var anotherCustomerRecordStructThree = new CustomerRecordStruct
            {
                Id = 3,
                FirstName = 3.ToString(),
                LastName = "Customer",
                CreateDate = new DateOnly(2021, 10, 3)
            };
            doesContain = customersRecordStruct.Contains(anotherCustomerRecordStructThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            Console.WriteLine();

            Console.WriteLine("RECORD CLASSES:");
            // get an item at a specific index
            var customerRecordClassThree = customersRecordClass[2];
            Console.WriteLine($"Found customer {customerRecordClassThree.Id} at index 2.");

            // check if a collection contains an item
            doesContain = customersRecordClass.Contains(customerRecordClassThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            // FOLLOW UP: What if you created a new customer object with the same property values?
            var anotherCustomerRecordClassThree = new CustomerRecordClass
            {
                Id = 3,
                FirstName = 3.ToString(),
                LastName = "Customer",
                CreateDate = new DateOnly(2021, 10, 3)
            };
            doesContain = customersRecordClass.Contains(anotherCustomerRecordClassThree) ? "does" : "does not";
            Console.WriteLine($"Customers {doesContain} contain this customer.");

            Console.WriteLine();

            // use a predicate to find an item in the collection
            var customerSeven = customers.Find(CustomerIsMatch); // same as this line of code: var customerSeven = customers.Find(c => c.Id == 7);
            if (customerSeven != null)
            {
                Console.WriteLine($"Found customer {customerSeven.Id}.");
            }
            else
            {
                Console.WriteLine("No customer found with that ID.");
            }
            Console.WriteLine(customers?.IndexOf(customerSeven!));

            // FOLLOW UP: What happens if your expression matches more than one item?
            var customerLastName = customers?.Find(c => c.LastName == "Customer");
            Console.WriteLine(customerLastName!.LastName);
            Console.WriteLine(customers!.IndexOf(new Customer { Id = 8 }));
        }

        private static bool CustomerIsMatch(Customer c)
        {
            return c.Id == 7;
        }

        public static void Iterating()
        {
            // reverse the order of the list
            customers.Reverse();

            IEnumerator<Customer> custEnum = customers.GetEnumerator();
            while (custEnum.MoveNext())
            {
                Customer current = custEnum.Current;
                Console.WriteLine($"{current.FirstName} {current.LastName}");
            }

            // sort the customers
            customers.Sort();  // Or in our case, Reverse would do the same.

            // or using foreach
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }
        }
    }
}