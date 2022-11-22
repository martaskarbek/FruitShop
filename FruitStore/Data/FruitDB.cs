using System.Collections.Generic;

namespace FruitStore.Data
{
    public class FruitDB
    {
        public Dictionary<string, Dictionary<string, double>> fruitDataBase;

        public FruitDB()
        {
             fruitDataBase = new Dictionary<string, Dictionary<string, double>>()
            {
                { "Apple", new Dictionary<string, double> {{ "price", 30 }, { "promoPrice", 45.00 }, {"promoAmount", 2 }}},
                { "Banana", new Dictionary<string, double> {{ "price", 50 }, { "promoPrice", 130.00 }, {"promoAmount", 3 }}},
                { "Peach", new Dictionary<string, double> {{ "price", 60 }, { "promoPrice", 0 }, {"promoAmount", 0 }}}
            };
        }
    }
}