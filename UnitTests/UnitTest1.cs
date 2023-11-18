using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MainProject;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetArmorsTest()
        {
            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(10);
            Assert.AreEqual(10, warehouse.armors.Count);
        }
    }
}
