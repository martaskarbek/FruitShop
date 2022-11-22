using FruitStore.Model;
using FruitStore.Repository;
using System;
using System.Collections.Generic;

namespace FruitStore.Helper
{
    public class BasketCounter : IBasketCounter
    {
        private readonly IFruitRepository _fruitRepository;

        public BasketCounter(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public double BasketValue(Basket basket)
        {
            if (basket == null)
            {
                throw new ArgumentNullException($"{nameof(basket)} cannot be null");
            }

            double basketTotalAmount = 0;

            foreach (KeyValuePair<string, int> basketFruit in basket.basket )
            {
                Fruit fruit = null;
                try
                {
                    fruit = _fruitRepository.GetFruit(basketFruit.Key);
                }
                catch (KeyNotFoundException)
                {
                    throw;
                }
                catch (Exception)
                {
                    //Normally we should implement logging this exceptions to for example data base or other file.
                    throw;
                }
                
                if (basketFruit.Value >= fruit.PromoAmount)
                {
                    var regularPriceAmount = fruit.PromoAmount != 0 ? basketFruit.Value % fruit.PromoAmount : basketFruit.Value;
                    var divideAmount = fruit.PromoAmount != 0 ? fruit.PromoAmount : 1;
                    var promoPriceAmount = (basketFruit.Value - regularPriceAmount) / divideAmount;

                    basketTotalAmount += ((regularPriceAmount * fruit.Price) + (promoPriceAmount * fruit.PromoPrice));
                }
                else
                {
                    basketTotalAmount += basketFruit.Value * fruit.Price;
                }
            }

            return basketTotalAmount;
        }
    }
}