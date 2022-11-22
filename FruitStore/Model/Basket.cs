using System;
using System.Collections.Generic;

namespace FruitStore.Model
{
    public class Basket
    {
        public Dictionary<string, int> basket;

        public Basket() => basket = new Dictionary<string, int>();

        public void AddToBasket(string fruitName, int amount)
        {
            if (amount == 0)
            {
                return;
            }
            else if (amount < 0)
            {
                throw new ArgumentException("Amount can not be a negative value");
            }

            if (!basket.ContainsKey(fruitName))
            {
                basket.Add(fruitName, 0);
            }

            basket[fruitName] += amount;
        }

        public void RemoveFromBasket(string fruitName, int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"'{nameof(amount)}' must be a positive number");
            }
            else if (amount == 0)
            {
                return;
            }
            else if (string.IsNullOrEmpty(fruitName))
            {
                throw new ArgumentNullException($"'{nameof(fruitName)}' cannot be null or empty");
            }
            else if (!basket.ContainsKey(fruitName))
            {
                throw new KeyNotFoundException($"Couldn't find fruit '{fruitName}' in the basket");
            }
            else
            {
                if (basket[fruitName] < amount)
                {
                    throw new InvalidOperationException($"Attempted to remove {amount} of {fruitName} when only {basket[fruitName]} is available");
                }

                basket[fruitName] -= amount;
                if (basket[fruitName] == 0)
                {
                    basket.Remove(fruitName);
                }
            }
        }
    }
}