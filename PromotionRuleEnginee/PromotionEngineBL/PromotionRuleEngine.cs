using System.Collections.Generic;

namespace PromotionEngineBL
{
    public interface IPromotionRule
    {
        decimal CalculatePrice(Dictionary<char, int> orders);         
    }

    public class SKU_A_Rule : IPromotionRule
    {
        private decimal _percentage;
        public SKU_A_Rule()
        {
            _percentage = 0;
        }

        public SKU_A_Rule(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculatePrice(Dictionary<char, int> orders)
        {
            int total_A = 0;
            int noAs = 3;
            decimal totalPrice_A = 0;

            if (orders.ContainsKey('A'))
            {
                total_A = orders['A'];
            }
            if (_percentage == 0 && total_A != 0)
            {               
                int Offer_A = total_A / noAs;
                int fullPrice_A = total_A - (Offer_A * noAs);
                totalPrice_A = (Offer_A * 130) + (fullPrice_A * 50);                
            }            
            else if (_percentage != 0 && total_A != 0)
            {
                decimal totalprice = total_A * 50;
                totalPrice_A = totalprice - ((totalprice * _percentage) / 100);
            }
            return totalPrice_A;
        }
    }  

    public class SKU_B_Rule : IPromotionRule
    {
        private decimal _percentage;
        public SKU_B_Rule()
        {
            _percentage = 0;
        }

        public SKU_B_Rule(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculatePrice(Dictionary<char, int> orders)
        {
            int total_B = 0;
            int noBs = 2;
            decimal totalPrice_B = 0;

            if (orders.ContainsKey('B'))
            {
                total_B = orders['B'];
            }
            if (_percentage == 0 && total_B != 0)
            {
                int Offer_B = total_B / noBs;
                int fullPrice_B = total_B - (Offer_B * noBs);
                totalPrice_B = (Offer_B * 45) + (fullPrice_B * 30);
            }
            else if (_percentage != 0 && total_B != 0)
            {                
                decimal totalprice = total_B * 30;
                totalPrice_B = totalprice - ((totalprice * _percentage) / 100);
            }
            return totalPrice_B;
        }
    }

    public class SKU_C_Rule : IPromotionRule
    {
        private decimal _percentage;
        public SKU_C_Rule()
        {
            _percentage = 0;
        }

        public SKU_C_Rule(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculatePrice(Dictionary<char, int> orders)
        {
            int total_C = 0;
            int total_D = 0;
            int only_C = 0;
            decimal totalPrice_C = 0;

            if (orders.ContainsKey('C'))
            {
                total_C = orders['C'];
            }
            if (orders.ContainsKey('D'))
            {
                total_D = orders['D'];
            }
            if (_percentage == 0)
            {
                if (total_C > total_D)
                {
                    only_C = total_C - total_D;
                    totalPrice_C = (only_C * 20);
                }                
            }
            else if (_percentage != 0 && total_C != 0)
            {                
                decimal totalprice = only_C * 20;
                totalPrice_C = totalprice - ((totalprice * _percentage) / 100);
            }
            return totalPrice_C;
        }
    }

    public class SKU_D_Rule : IPromotionRule
    {
        private decimal _percentage;
        public SKU_D_Rule()
        {
            _percentage = 0;
        }

        public SKU_D_Rule(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculatePrice(Dictionary<char, int> orders)
        {
            int total_C = 0;
            int total_D = 0;
            int offer_count = 0;
            int only_D = 0;            
            decimal totalPrice_D = 0;

            if (orders.ContainsKey('C'))
            {
                total_C = orders['C'];
            }
            if (orders.ContainsKey('D'))
            {
                total_D = orders['D'];
            }
            if (_percentage == 0)
            {
                if (total_D >= total_C)
                {
                    offer_count = total_C;
                    only_D = total_C - total_D;
                    totalPrice_D = (offer_count * 30) + (only_D * 15);
                }                   
            }
            else if (_percentage != 0 && total_D != 0)
            {
                decimal totalprice = only_D * 15;
                totalPrice_D = totalprice - ((totalprice * _percentage) / 100);
            }
            return totalPrice_D;
        }
    }

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
