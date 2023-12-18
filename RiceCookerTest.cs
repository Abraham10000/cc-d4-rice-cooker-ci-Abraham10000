using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RiceCookerTests
{
    [TestClass]
    public class RiceCookerTests
    {
        [TestMethod]
        public void AddItems_WhenCapacityExceeded_ThrowsArgumentException()
        {
            double maxCapacity = 10;
            var riceCooker = new RiceCooker(maxCapacity);
            var items = new List<Tuple<string, double, string>>
            {
                Tuple.Create("Riz", 8, "kg"), 
                Tuple.Create("Quinoa", 2, "l") 
            };

            Assert.ThrowsException<ArgumentException>(() => riceCooker.AddItems(items));
        }

        [TestMethod]
        public void Cook_WhenNotWorking_ThrowsInvalidOperationException()
        {
            double maxCapacity = 15;
            var riceCooker = new RiceCooker(maxCapacity);

            riceCooker.CheckStatus();

            Assert.ThrowsException<InvalidOperationException>(() => riceCooker.Cook(10));
        }

        [TestMethod]
        public void ConvertToLiters_WithValidUnit_ConvertsCorrectly()
        {
            double maxCapacity = 15;
            var riceCooker = new RiceCooker(maxCapacity);

            var liters = riceCooker.ConvertToLiters(5, "kg");

            Assert.AreEqual(6, liters); 
        }

        [TestMethod]
        public void ConvertToLiters_WithInvalidUnit_ThrowsArgumentException()
        {
            double maxCapacity = 15;
            var riceCooker = new RiceCooker(maxCapacity);

            Assert.ThrowsException<ArgumentException>(() => riceCooker.ConvertToLiters(5, "pcs"));
        }
    }
}
