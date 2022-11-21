using FruitStore.Data;
using FruitStore.Model;
using System;

namespace FruitStore.Repository
{
    class FruitRepository : IFruitRepository
    {
        private FruitDB _fruitDB;

        public FruitRepository(FruitDB fruitDB)
        {
            _fruitDB = fruitDB;
        }

        public Fruit GetFruit(string fruitName)
        {
            Fruit basketFruit = null;
            var fruitData = _fruitDB._fruitDataBase[fruitName];

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