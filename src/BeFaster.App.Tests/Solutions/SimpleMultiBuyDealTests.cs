using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    class SimpleMultiBuyDealTests
    {
        [Test]
        public void TestCaseShouldFindOneDeal()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AAAA".ToCharArray();

            var count = testObj.CalculatePossibleSavings(testData);

            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestCaseShouldRemoveCharactersForOneDeal()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AAAA".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(1, result.Item1.Length);
        }


        [Test]
        public void TestCaseShouldReturnDealPrice()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AAAA".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(130, result.Item2);
        }


        [Test]
        public void TestCaseShouldReturnZeroAndUneditied()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AA".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual("AA", new string(result.Item1));
            Assert.AreEqual(0, result.Item2);
        }

        [Test]
        public void TestCaseShouldReturnNoDealFound()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AA".ToCharArray();

            var count = testObj.CalculatePossibleSavings(testData);

            Assert.AreEqual(0, count);
        }
    }

    [TestFixture]
    public class MultiDealRemovalTests
    {
        [Test]
        public void TestShouldRemoveAllObjects()
        {
            var testObj = new MultiBuyRemovalDeal(2,'A', 1,'B');

            var testData = "AAB".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(0, result.Item1.Length);
        }

        [Test]
        public void TestShouldStillPriceMultiBuyDeal()
        {
            var testObj = new MultiBuyRemovalDeal(2, 'A', 1, 'B');

            var testData = "AAB".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(100, result.Item2);
        }
    }


    [TestFixture]
    public class BuyXGetXTests
    {
        [Test]
        public void TestShouldRemoveAllObjects()
        {
            var testObj = new BuyXGetXFreeDeal('A', 2, 1);

            var testData = "AAA".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(0, result.Item1.Length);
        }

        [Test]
        public void TestShouldStillPriceMultiBuyDeal()
        {
            var testObj = new BuyXGetXFreeDeal('A', 2, 1);

            var testData = "AAA".ToCharArray();

            var result = testObj.Apply(testData);

            Assert.AreEqual(100, result.Item2);
        }

        [Test]
        public void TestShouldRemoveAllObjectsTwice()
        {
            var testObj = new BuyXGetXFreeDeal('A', 2, 1);

            var testData = "AAAAAA".ToCharArray();

            var result = testObj.Apply(testData);
            result = testObj.Apply(result.Item1);

            Assert.AreEqual(0, result.Item1.Length);
        }
    }
}
