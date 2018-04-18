using System;

namespace SimpleWebServer.cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            while (Console.ReadKey() != null)
            {
                var controller = new StringController();
                var task = controller.Get();
                task.ContinueWith(t => Console.WriteLine(t.Result));
                Console.WriteLine("after continue");
            }
        }
    }
}
