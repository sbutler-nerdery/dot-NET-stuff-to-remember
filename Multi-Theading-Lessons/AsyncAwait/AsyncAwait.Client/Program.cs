using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.AsyncAwait.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Async task fired off");

            var p = new Progress<int>((i) => Console.Write("."));

            var info = Task.Run(() => GetUserTodoList(p));
            info.Wait();

            Console.Read();
        }

        private async static Task<List<string>> GetUserTodoList(IProgress<int> progress)
        {
            var userTodos = new List<string>();
            var results = GetSomething();

            while (!results.IsCompleted)
            {
                progress.Report(0);    
                await Task.Delay(1000);
            }

            Console.WriteLine(await results);
            return userTodos;
        }

        private async static Task<string> GetSomething()
        {
            await Task.Run(() => Thread.Sleep(5000));
            return "Done";
        }
    }
}
