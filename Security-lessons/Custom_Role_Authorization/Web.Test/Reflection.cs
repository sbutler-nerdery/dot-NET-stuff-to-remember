using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;

namespace Web.Test
{
    [TestClass]
    public class Reflection
    {
        [TestMethod]
        public void GetControllerMethods()
        {
            var assembly = Assembly.LoadFrom("Web.dll");
            Type baseType = typeof (BaseController);
            var controllers = assembly.GetTypes().Where(x => baseType.IsAssignableFrom(x) && x.Name != "BaseController");
            var enumerable = controllers as Type[] ?? controllers.ToArray();
            Assert.AreNotEqual(enumerable.Count(), 0);

            foreach (var controller in enumerable)
            {
                var methods = controller.GetMethods().Where(x => x.ReturnType == typeof(ActionResult));
                Assert.AreNotEqual(methods.Count(), 3);   
            }
        }
    }
}
