namespace Essentials2.Library;

using System.Text.Json;

public static class ExceptionSamples
{
    public static void BasicExceptions()
    {
        string wrongPath = "matt.json";
        string rightPath = "..\\..\\..\\K8.json";

        // basic try catch
        string filePath = rightPath;
        //System.IO.Stream fileStream = null;
        Console.WriteLine($"Current Directory -> {Directory.GetCurrentDirectory()}");
        try
        {
            using (var fileStream = File.OpenRead(filePath)) // disposes automatically upon exit
            {
                // Record types have a compiler-generated ToString method that displays names and values of
                // public properties and fields. The ToString method returns a string of the following format:
                // <record type name> { <property name> = <value>, <property name> = <value>, ...}
                var matt = JsonSerializer.Deserialize<Employee>(fileStream);

                Console.WriteLine($"Employee read from file: {matt}");
            }
        }
        catch (IOException ioex)
        {
            Console.WriteLine($"IO Exception: {ioex.Message}");
        }
        catch (JsonException jsonex) when (jsonex.Message.Contains("converted", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"JSON exception convert: {jsonex.Message}");
        }
        catch (JsonException jsonex) when (jsonex.Message.Contains("is invalid after a value", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"JSON exception comma or full stop: {jsonex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Standard exception caught: {ex.Message}");
        }
        finally
        {
            //if (fileStream != null)
            //{
            //    fileStream.Dispose(); // from IDisposable interface
            //}
        }
    }

    public static void FundamentalExceptions()
    {
        string wrongPath = "matt.json";
        string rightPath = "..\\..\\..\\matt.json";

        // basic try catch
        string filePath = wrongPath;
        System.IO.Stream fileStream = null;
        Console.WriteLine($"Current Directory -> {Directory.GetCurrentDirectory()}");
        try
        {
            fileStream = File.OpenRead(filePath);

            // Record types have a compiler-generated ToString method that displays names and values of
            // public properties and fields. The ToString method returns a string of the following format:
            // <record type name> { <property name> = <value>, <property name> = <value>, ...}
            var matt = JsonSerializer.Deserialize<Employee>(fileStream);

            Console.WriteLine($"Employee read from file: {matt}");
        }
        // You typically include an argument in a catch block that indicates the
        // type of exception to catch. You can also omit the arguments on the
        // catch block entirely. In this case, the catch block will catch all
        // exceptions, regardless of their type.
        catch
        {
            Console.WriteLine("Can catch all exception, like catch (Exception)");
        }
        //catch (JsonException)
        //{
        //    Console.WriteLine($"IO Exception.");
        //}
        //// we can provide as many catch statement as we want by going from more specific to less specific exception types
        //catch (FileNotFoundException fnfex)
        //{
        //    Console.WriteLine($"FNF Exception: {fnfex.Message}");
        //}
        //catch (IOException)
        //{
        //    Console.WriteLine($"IO Exception.");
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine($"IO Exception.");
        //}
        finally
        {
            if (fileStream != null)
            {
                fileStream.Dispose(); // from IDisposable interface
            }
        }
    }

    public static void ThrowExceptions(bool? shouldThrow)
    {
        if (!shouldThrow.HasValue)
        {
            throw new ArgumentNullException("shouldThrow");
            //throw new ArgumentException("ArgumentNullException: ", nameof(shouldThrow));
        }

        if (shouldThrow.Value)
        {
            // BEST PRACTICE: do NOT throw System.Exception like this since it is too general and not descriptive!
            throw new Exception("I was told to throw this!");
        }
        else
        {
            Console.WriteLine("No exceptions being thrown here.");
        }
    }
}