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

            await DoFileWorkAsync(); // cannot await void
            // THIS IS where the callback code happens!

            Console.WriteLine("Work happening in main thread.");
        }

        public static async Task DoFileWorkAsync()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();
            string filePath = "..\\..\\..\\matt.json";
            var employeeJson = await File.ReadAllTextAsync(filePath);

            // If you look down on line 62, that's where, in our DoFileWorkAsync, we're writing out the thread ID, notice that this is different from our first example. In our first example, we created a new thread and started it. That's why we got a new thread ID in that operation. We haven't done that here. We've just invoked an asynchronous operation, and while it was starting these first four lines of code, everything was synchronous. We set the foreground color, we did a write line, we reset the color, we set a string variable. Then, only on line 65, did we actually start some asynchronous work. So at no point did we start up a new thread as we began this work, that's why we have the same thread ID, but there may be a thread that gets fired up in our ReadAllTextAsync behind the scenes for us, and we're awaiting that asynchronous work.

            var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }

        // In order to use the await keyword, you have to be inside an asynchronous
        // operation. So that means your operation signature has to have that async
        // keyword. Also, in order to await an operation, it has to return Task.
    }
}