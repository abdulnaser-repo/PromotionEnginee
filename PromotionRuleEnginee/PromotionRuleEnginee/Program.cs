using PromotionEngineBL;
using System;
using System.Collections.Generic;

namespace PromotionRuleEnginee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set SKU unit price");
            Dictionary<char, int> orders = new Dictionary<char, int>();
            orders.Add('A', 1);
            orders.Add('B', 1);
            orders.Add('C', 1);

            Console.WriteLine("Calculate Promotion price");
            PromotionCalculator _calculator = new PromotionCalculator();       
            
            decimal totalPrice = _calculator.CalculatePromotionPrice(orders);
            Console.WriteLine(string.Format("The total price is: {0}", totalPrice));
        }
    }
}
