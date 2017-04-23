using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Project.TestingProject.Base
{
    [TestClass]
    public class BaseDatabaseTests
    {
        [TestInitialize()]
        public void Initialize()
        {
            Console.WriteLine("TestMethodInit");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Console.WriteLine("TestMethodCleanup");
        }
    }
}
