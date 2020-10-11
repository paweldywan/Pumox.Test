using Microsoft.Owin.Hosting;
using System;

namespace Pumox.Test.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = args;

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine();

                Console.WriteLine("Server started at: " + baseAddress);

                Console.WriteLine("Press ENTER to stop the server and close app...");

                Console.ReadLine();
            }
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());

            Console.WriteLine("Press Enter to continue");

            Console.ReadLine();

            Environment.Exit(1);
        }
    }
}
