using FruitStore.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void ShouldAddNewFruitToBasketWhenItWasNotInItYet()
        {
            //GIVEN
            Basket basket = new Basket();
            const string fruitName = "Apple";
            const int expectedAmount = 2;
            const int expectedBasketCount = 1;

            //WHEN
            basket.AddToBasket("Apple", 2);

            //THEN
            Assert.IsTrue(basket.basket.ContainsKey(fruitName));
            Assert.AreEqual(expectedAmount, basket.basket[fruitName]);
            Assert.AreEqual(expectedBasketCount, basket.basket.Count);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenAddingToBasketWithAmountAsNegativeValue()
        {
            //GIVEN
            Basket basket = new Basket();

            //WHEN
            //THEN
            Assert.Throws<ArgumentException>(() => basket.AddToBasket("Apple", -4));
        }

        [Test]
        public void ShouldDoNothingWhenAddingFruitWitsZeroAmount()
        {
            //GIVEN
            Basket basket = new Basket();
            const int expectedBasketCount = 0;

            //WHEN
            basket.AddToBasket("Apple", 0);

            //THEN
            Assert.AreEqual(expectedBasketCount, basket.basket.Count);
        }

        [Test]
        public void ShouldIncrementFruitAmountInBasketWhenAddingFruitAlreadyPresentInBasket()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 2);
            const string fruitName = "Apple";
            const int expectedAmount = 4;
            const int expectedBasketCount = 1;

            //WHEN
            basket.AddToBasket("Apple", 2);

            //THEN
            Assert.IsTrue(basket.basket.ContainsKey(fruitName));
            Assert.AreEqual(expectedAmount, basket.basket[fruitName]);
            Assert.AreEqual(expectedBasketCount, basket.basket.Count);
        }

        [Test]
        public void ShouldThrowKeyNotFoundExceptionWhenRemovingNonExistingFruitFromTheBasket()
        {
            //GIVEN
            Basket basket = new Basket();

            //WHEN        
            //THEN
            Assert.Throws<KeyNotFoundException>(() => basket.RemoveFromBasket("Apple", 1));
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenRemovingNegativeAmount()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 1);

            //WHEN
            //THEN
            Assert.Throws<ArgumentException>(() => basket.RemoveFromBasket("Apple", -1));
        }

        [Test]
        public void ShouldDoNothingWhenRemovingZeroAmount()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 1);
            const int expectedAmount = 1;

            //WHEN
            basket.RemoveFromBasket("Apple", 0);

            //THEN
            Assert.AreEqual(expectedAmount, basket.basket["Apple"]);

        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenRemovingNullFruitName()
        {
            //GIVEN
            Basket basket = new Basket();

            //WHEN
            //THEN
            Assert.Throws<ArgumentNullException>(() => basket.RemoveFromBasket(null, 1));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenRemovingEmptyFruitName()
        {
            //GIVEN
            Basket basket = new Basket();

            //WHEN
            //THEN
            Assert.Throws<ArgumentNullException>(() => basket.RemoveFromBasket(string.Empty, 1));
        }


        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenRemovingMoreAmountThanItExistsInTheBasket()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 1);

            //WHEN
            //THEN
            Assert.Throws<InvalidOperationException>(() => basket.RemoveFromBasket("Apple", 2));
        }

        [Test]
        public void ShouldDecrementAmountWhenRemovingAmountLowerThanExistingAmountInTheBasket()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 3);
            const int expectedValue = 2;

            //WHEN
            basket.RemoveFromBasket("Apple", 1);

            //THEN
            Assert.AreEqual(expectedValue, basket.basket["Apple"]);
        }

        [Test]
        public void ShouldRemoveFruitEntryWhenRemovingAmountEqualToExistingAmountInTheBasket()
        {
            //GIVEN
            Basket basket = new Basket();
            basket.AddToBasket("Apple", 3);
            const int expectedCount = 0;

            //WHEN
            basket.RemoveFromBasket("Apple", 3);

            //THEN
            Assert.AreEqual(expectedCount, basket.basket.Count);
        }
    }
}
