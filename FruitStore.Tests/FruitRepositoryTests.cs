using FruitStore.Data;
using FruitStore.Model;
using FruitStore.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FruitStore.Tests
{
    [TestFixture]
    class FruitRepositoryTests
    {
        [Test]
        public void ShouldReturnFruitWhenProvidedExistingInDBFruitName()
        {
            //GIVEN
            //We should never pass actual data base, but mock it, I did it just for demonstration purpose.
            FruitRepository fruitRepository = new FruitRepository(new FruitDB());

            //WHEN
            var result = fruitRepository.GetFruit("Apple");

            //THEN
            var expected = new Fruit();
            expected.Name = "Apple";
            expected.Price = 30;
            expected.PromoPrice = 45;
            expected.PromoAmount = 2;

            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Price, result.Price);
            Assert.AreEqual(expected.PromoPrice, result.PromoPrice);
            Assert.AreEqual(expected.PromoAmount, result.PromoAmount);
        }

        [Test]

        public void ShouldThrowKeynotFoundExceptionWhenProvidedNotExistingInDBFruitName()
        {
            //GIVEN
            FruitRepository fruitRepository = new FruitRepository(new FruitDB());

            //WHEN
            //THEN
            Assert.Throws<KeyNotFoundException>(() => fruitRepository.GetFruit("Kiwi"));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenProvidedNullValue()
        {
            //GIVEN
            FruitRepository fruitRepository = new FruitRepository(new FruitDB());

            //WHEN
            //THEN
            Assert.Throws<ArgumentNullException>(() => fruitRepository.GetFruit(null));
        }
    }
}