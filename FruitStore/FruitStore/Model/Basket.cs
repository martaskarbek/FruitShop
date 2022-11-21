using System.Collections.Generic;

namespace FruitStore.Model
{
    class Basket
    {
        public Dictionary<string, int> basket;

        public Basket() => basket = new Dictionary<string, int>();
    }
}