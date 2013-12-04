using System;
using System.Collections.Generic;
using Demo.Dynamic.ExpandoObject.App.Models;

namespace Demo.Dynamic.ExpandoObjectExample.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //dynamic item = new ExpandoObject();
            //item.SomeProperty = "I am a dynamic property";
            //item.GetProperty = (Func<string>)(() => item.SomeProperty + " in a Func.");

            //Console.WriteLine(item.SomeProperty);
            //Console.WriteLine(item.GetProperty());

            //item.GetProperty = "BOOOOOOM! Mind BLOWN!";

            //Console.WriteLine(item.GetProperty);

            dynamic profile = new Profile(); 
            profile.Address1 = "my address";
            profile.Telephone = "303232112";
            dynamic phone = new PhoneNumberOnly(); 
            phone.Telephone = "3032225555";

            UpdateModelInfo(profile);
            UpdateModelInfo(phone);

            Console.ReadKey();
        }

        static void UpdateModelInfo(dynamic model)
        {
            var modelType = model.GetType();
            var profile = new Profile(); 
            profile.Address1 = model.Address1;
            profile.Telephone = model.Telephone;
        }
    }
}
