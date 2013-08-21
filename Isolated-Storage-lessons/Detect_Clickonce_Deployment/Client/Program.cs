using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is version 2!");
            var storageScope = IsolatedStorageFile.GetUserStoreForDomain();

            //Determine if the applciation was clickonce deployed
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                storageScope = IsolatedStorageFile.GetUserStoreForApplication();
                Console.WriteLine("This app was click once deployed...");
            }

            using (var fs = new IsolatedStorageFileStream("data.dat", FileMode.OpenOrCreate, storageScope))
            {
                //Get previous data...
                using (var reader = new StreamReader(fs))
                {
                    Console.WriteLine("Reading data...");
                    var contents = reader.ReadToEnd();
                    Console.WriteLine(contents);
                }
            }

            using (var fs = new IsolatedStorageFileStream("data.dat", FileMode.Append, storageScope))
            {
                //Update data...
                using (var writer = new StreamWriter(fs))
                {
                    Console.WriteLine("Writing data...");
                    writer.WriteLine(DateTime.Now.ToString());
                }
            }

            Console.Read();
        }
    }
}
