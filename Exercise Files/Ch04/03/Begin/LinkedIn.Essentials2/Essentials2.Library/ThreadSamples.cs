using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Essentials2.Library
{
    public static class ThreadSamples
    {
        public static void SimpleThread()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            Thread t = new Thread(DoFileWork);

            // await is similar to the case when we call for instance method of thread object Join() immediately directly after its Start() instance method
            t.Start();
            t.Join();
            Console.WriteLine("Work happening in main thread.");
        }

        public static void DoFileWork()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            string filePath = "..\\..\\..\\matt.json";
            // this could take a while
            var employeeJson = File.ReadAllText(filePath);

            var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }

        //File.BeginReadAllText(filePath, EndReadingFile, state);
        //public void EndReadingFile(object state, IAsyncResult iar)
        //{
        //  // handle the completion of file reading
        //}

        public static async Task SimpleThreadAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            //await DoFileWorkAsync("Matt");
            //await DoFileWorkAsync("Felicia");
            // above code runs synchronously because of await to make it run asynchronously you should assign it to tasks and then start them
            Task tMatt = DoFileWorkAsync("matt");
            Task tFelicia = DoFileWorkAsync("felicia");

            Console.WriteLine("Work happening in main thread.");

            await Task.WhenAll(tMatt, tFelicia);
            //Task.WaitAll();
            //await Task.Delay(-1); // to wait for tasks to complete before the program itself finishes first
        }

        public static async Task DoFileWorkAsync(string employeeName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();
            string filePath = $"..\\..\\..\\{employeeName}.json";
            var employeeJson = await File.ReadAllTextAsync(filePath);

            var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }

        // In order to use the await keyword, you have to be inside an asynchronous
        // operation. So that means your operation signature has to have that async
        // keyword. Also, in order to await an operation, it has to return Task.
    }
}