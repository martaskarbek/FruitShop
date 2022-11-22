using FruitStore.Helper;
using FruitStore.Repository;
using FruitStore.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FruitStore.Data;

namespace FruitStore.Tests
{
    [TestFixture]
    public class BasketCounterTests
    {
        BasketCounter basketCounter;

        [SetUp]
        public void SetUp()
        {
            basketCounter = new BasketCounter(new FruitRepository(new FruitDB()));
        }
        
        [Test]
        public void ShouldThrowArgumentNullExceptionWhenProvidedNullBasket()
        {
            //GIVEN
            //WHEN
            //THEN
            Assert.Throws<ArgumentNullException>(() => basketCounter.BasketValue(null));
        }

        [Test]
        public void ShouldReturnZeroWhenProvidedBasketWithoutItems()
        {
            //GIVEN
            var basket = new Basket();
            const int expectedValue = 0;

            //WHEN
            var result = basketCounter.BasketValue(basket);

            //THEN
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void ShouldThrowKeyNotFoundExceptionWhenBasketFruitDoesNotExistInTheFruitRepository()
        {
            //GIVEN
            var basket = new Basket();
            basket.AddToBasket("Kiwi", 1);

            //WHEN
            //THEN
            Assert.Throws<KeyNotFoundException>(() => basketCounter.BasketValue(basket));
        }

        [TestCase("Apple", 1, 30)]
        [TestCase("Banana", 1, 50)]
        [TestCase("Banana", 2, 2*50)]
        public void ShouldMultiplyRegularPriceWhenAmountDoesNotExceedPromoAmount(string fruitName, int amount, double expectedValue)
        {
            //GIVEN
            var basket = new Basket();
            basket.AddToBasket(fruitName, amount);

            //WHEN
            var result = basketCounter.BasketValue(basket);

            //THEN
            Assert.AreEqual(expectedValue, result);
        }

        [TestCase("Apple", 2, 45)]
        [TestCase("Apple", 3, 45+30)]
        [TestCase("Apple", 5, 2*45+30)]
        public void ShouldMultiplyRegularPriceAndPromoPriceWhenAmountExceedsPromoAmount(string fruitName, int amount, double expectedValue)
        {
            //GIVEN
            var basket = new Basket();
            basket.AddToBasket(fruitName, amount);

            //WHEN
            var result = basketCounter.BasketValue(basket);

            //THEN
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void ShouldMultiplyRegularPriceWhenPromoAmountIsEqualToZero()
        {
            //GIVEN
            var basket = new Basket();
            basket.AddToBasket("Peach", 2);
            const double expectedValue = 60 * 2;

            //WHEN
            var result = basketCounter.BasketValue(basket);

            //THEN
            Assert.AreEqual(expectedValue, result);
        }
    }
}