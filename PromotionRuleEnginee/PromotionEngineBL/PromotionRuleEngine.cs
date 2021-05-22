using System.Collections.Generic;

namespace PromotionEngineBL
{
    public class PromotionRuleEngine
    {
        List<IPromotionRule> _rules = new List<IPromotionRule>();

        public PromotionRuleEngine(IEnumerable<IPromotionRule> rules)
        {
            _rules.AddRange(rules);
        }

        public decimal CalculatePromotionPrice(Dictionary<char, int> orders) 
        {
            decimal totalPrice = 0;
            foreach (var rule in _rules)
            {
                totalPrice += rule.CalculatePrice(orders);
            }
            return totalPrice;
        }
    }

    public class PromotionCalculator
    {
        public decimal CalculatePromotionPrice(Dictionary<char, int> orders)
        {            
            var rules = new List<IPromotionRule>();
            rules.Add(new SKU_A_Rule());
            //rules.Add(new SKU_A_Rule(10)); //to enable percentage based 
            rules.Add(new SKU_B_Rule());
            rules.Add(new SKU_C_Rule());
            rules.Add(new SKU_D_Rule());

            var engine = new PromotionRuleEngine(rules);

            return engine.CalculatePromotionPrice(orders);
        }
    }
}
