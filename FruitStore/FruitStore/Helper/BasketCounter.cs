using FruitStore.Model;
using FruitStore.Repository;
using System.Collections.Generic;

namespace FruitStore.Helper
{
    class BasketCounter : IBasketCounter
    {
        private readonly IFruitRepository _fruitRepository;

        public BasketCounter(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public double BasketValue(Basket basket)
        {
            double basketTotalAmount = 0;

            foreach (KeyValuePair<string, int> basketFruit in basket.basket )
            {
                var fruit = _fruitRepository.GetFruit(basketFruit.Key);

                if (basketFruit.Value >= fruit.PromoAmount)
                {
                    var regularPriceAmount = basketFruit.Value % fruit.PromoAmount;
                    var divideAmount = fruit.PromoAmount != 0 ? fruit.PromoAmount : 1;
                    var promoPriceAmount = (basketFruit.Value - regularPriceAmount) / divideAmount;

                    basketTotalAmount += ((regularPriceAmount * fruit.Price) + (promoPriceAmount * fruit.PromoPrice));
                }
            }

            return basketTotalAmount;
        }
    }
}