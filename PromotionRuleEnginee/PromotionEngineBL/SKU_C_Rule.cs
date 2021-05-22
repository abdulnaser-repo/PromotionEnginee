using System.Collections.Generic;

namespace PromotionEngineBL
{
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
}
