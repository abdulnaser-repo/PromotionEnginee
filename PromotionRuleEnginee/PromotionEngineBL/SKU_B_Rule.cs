using System.Collections.Generic;

namespace PromotionEngineBL
{
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
}
