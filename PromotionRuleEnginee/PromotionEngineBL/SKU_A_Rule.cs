using System.Collections.Generic;

namespace PromotionEngineBL
{
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
}
