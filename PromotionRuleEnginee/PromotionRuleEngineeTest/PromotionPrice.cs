using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineBL;
using System.Collections.Generic;

namespace PromotionRuleEngineeTest
{
    [TestClass]
    public class PromotionPrice
    {        
        private PromotionCalculator _calculator = new PromotionCalculator();

        [TestMethod]
        public void TestScenario_A()
        {
            //Arrange
            Dictionary<char, int> orders = new Dictionary<char, int>();
            orders.Add('A', 1);
            orders.Add('B', 1);
            orders.Add('C', 1);

            decimal expectedTotal = 100;
            //Act
            decimal actualTotal = _calculator.CalculatePromotionPrice(orders);

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void TestScenario_B()
        {
            //Arrange
            Dictionary<char, int> orders = new Dictionary<char, int>();
            orders.Add('A', 5);
            orders.Add('B', 5);
            orders.Add('C', 1);

            decimal expectedTotal = 370;
            //Act
            decimal actualTotal = _calculator.CalculatePromotionPrice(orders);

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void TestScenario_C()
        {
            //Arrange
            Dictionary<char, int> orders = new Dictionary<char, int>();
            orders.Add('A', 3);
            orders.Add('B', 5);
            orders.Add('C', 1);
            orders.Add('D', 1);

            decimal expectedTotal = 280;
            //Act
            decimal actualTotal = _calculator.CalculatePromotionPrice(orders);

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        //[TestMethod]
        public void TestScenario_A_With_Percentage()
        {
            //Arrange
            Dictionary<char, int> orders = new Dictionary<char, int>();
            orders.Add('A', 1);
            orders.Add('B', 1);
            orders.Add('C', 1);

            decimal expectedTotal = 95;
            //Act
            decimal actualTotal = _calculator.CalculatePromotionPrice(orders);

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
