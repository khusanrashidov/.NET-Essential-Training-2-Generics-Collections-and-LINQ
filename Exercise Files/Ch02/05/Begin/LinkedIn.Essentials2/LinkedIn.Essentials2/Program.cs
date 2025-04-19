using Essentials2.Library;

CollectionSamples.Concurrent();
return;

CollectionSamples.Dictionary();
CollectionSamples.NameValue();
return;

CollectionSamples.Indexing();
CollectionSamples.Iterating();
return;

CollectionSamples.Queue();
CollectionSamples.Stack();
CollectionSamples.GenQueue();
CollectionSamples.GenStack();
return;

string[] name = new string[2];
name[0] = "Malika";
name[1] = "Khusan";
Console.WriteLine("{0} {1}", name);

var bitArray = new System.Collections.BitArray(8);
var arrayList = new System.Collections.ArrayList() { };

var al = new System.Collections.ArrayList(2);
Console.WriteLine("Collection size: " + al.Count);
Console.WriteLine("Collection capacity: " + al.Capacity);

//al[0] = 1;
al.Add(2);
al[0] = "First";
al.Add("Second");
al.AddRange(new string[] { "Third", "Fourth", "Fifth" });
Console.WriteLine("Collection size: " + al.Count);
Console.WriteLine("Collection capacity: " + al.Capacity);
Console.WriteLine("Indexed item from collection [2]: {0}", al[2]);
Console.WriteLine("IEnumerator:");
foreach (var item in al)
{
    Console.WriteLine(item);
}
Console.WriteLine($"{string.Join(", ", al.ToArray())}.");
// It's possible to use indexes in C# ArrayList. However, you can't use the indexing syntax ([]) directly as you would with arrays. Instead, you need to use the ArrayList's Get and Set methods to access elements at specific indexes.
// Elements are added to the ArrayList using the Add method.
// Elements are accessed using the [] syntax, but this is done through the getter and setter methods internally.
// You can modify elements at specific indexes using the [] syntax as well.