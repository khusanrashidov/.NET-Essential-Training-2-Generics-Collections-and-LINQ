namespace Essentials2.Library;

using System.Text.Json;

public static class ExceptionSamples
{
    public static void BasicExceptions()
    {
        string wrongPath = "matt.json";
        string rightPath = "..\\..\\..\\matt.json";

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
        catch (Exception ex)
        {
            Console.WriteLine($"Standard exception caught: {ex.Message}");
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Dispose(); // from IDisposable interface
            }
        }
    }
}