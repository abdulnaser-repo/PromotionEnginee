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
            List<UnitPrice> lstUnitPrice = new List<UnitPrice>();
            lstUnitPrice.Add(new UnitPrice { SKUId = 'A', price = 50 });
            lstUnitPrice.Add(new UnitPrice { SKUId = 'B', price = 30 });
            lstUnitPrice.Add(new UnitPrice { SKUId = 'C', price = 20 });
            lstUnitPrice.Add(new UnitPrice { SKUId = 'D', price = 15 });

            List<OrderDetails> lstOrder = new List<OrderDetails>();
            lstOrder.Add(new OrderDetails { SKUId = 'B', quantity = 1 });
            lstOrder.Add(new OrderDetails { SKUId = 'C', quantity = 1 });
            lstOrder.Add(new OrderDetails { SKUId = 'A', quantity = 1 });
        }
    }
}
