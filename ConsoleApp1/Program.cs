using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static  void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            string x =   DoWork();
            Console.WriteLine("I returned Here");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        static  string DoWork()
        {
            Console.WriteLine("Wait is comming");
            Console.WriteLine(await DoWait());  
            Console.Write("I still excute");
            return "DoWork is  Done";
        }

         static Task<string> DoWait()
        {
           return  Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done Waiting";

            });
        }
    }
}
