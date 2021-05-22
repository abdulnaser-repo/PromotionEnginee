using System.Collections.Generic;

namespace PromotionEngineBL
{
    public interface IPromotionRule
    {
        decimal CalculatePrice(Dictionary<char, int> orders);         
    }
}
