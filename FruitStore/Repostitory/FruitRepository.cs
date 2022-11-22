using FruitStore.Data;
using FruitStore.Model;
using System;
using System.Collections.Generic;

namespace FruitStore.Repository
{
    public class FruitRepository : IFruitRepository
    {
        private FruitDB _fruitDB;

        public FruitRepository(FruitDB fruitDB)
        {
            _fruitDB = fruitDB;
        }

        public Fruit GetFruit(string fruitName)
        {
            if (fruitName == null)
            {
                throw new ArgumentNullException($"Argument '{nameof(fruitName)}' cannot be null");
            }
            Fruit basketFruit = null;
            
           if (!_fruitDB.fruitDataBase.ContainsKey(fruitName))
            {
                throw new KeyNotFoundException($"Fruit with name {fruitName} does not exist in data base");
            }

            var fruitData = _fruitDB.fruitDataBase[fruitName];

            if (fruitData != null)
            {
                basketFruit = new Fruit();
                basketFruit.Name = fruitName;
                basketFruit.Price = fruitData["price"];
                basketFruit.PromoAmount = Convert.ToInt32(fruitData["promoAmount"]);
                basketFruit.PromoPrice = fruitData["promoPrice"];
            }

            return basketFruit;
        }
    }
}