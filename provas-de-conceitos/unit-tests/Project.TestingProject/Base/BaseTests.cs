using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Project.TestingProject.Base
{
    [TestClass]
    public class BaseTests
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine("AssemblyInit " + context.TestName);

            var automaticDropAndCreateDatabase = Convert.ToBoolean(ConfigurationManager.AppSettings["AutomaticDropAndCreateDatabase"]);

            if (automaticDropAndCreateDatabase)
            {
                var dbSetup = new DatabaseSetup();
                dbSetup.WipeAndCreateDatabase();
            }
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("AssemblyCleanup");
        }
    }
}
