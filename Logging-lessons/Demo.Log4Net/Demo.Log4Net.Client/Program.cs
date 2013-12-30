using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Log4Net.Core;

namespace Demo.Log4Net.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Logging now...");

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LoggingService.GetInstance().LogError(ex, typeof(Program));
            }

            Console.Read();
        }
    }
}
