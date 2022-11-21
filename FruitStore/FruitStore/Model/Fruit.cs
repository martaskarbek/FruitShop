namespace FruitStore.Model
{
    public class Fruit
    {
        private string name;
        private double price;
        private double promoPrice;
        private int promoAmount;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public double PromoPrice
        {
            get => promoPrice;
            set => promoPrice = value;
        }

        public int PromoAmount
        {
            get => promoAmount;
            set => promoAmount = value;
        }
    }
}