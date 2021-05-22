using System.Collections.Generic;

namespace PromotionEngineBL
{
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
}
