using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    class CheckoutTests
    {
        [TestCase("BBEEEE", ExpectedResult = 80)]
        public int TestCase_AllBAreFree(string s)
            => CheckoutSolution.Checkout(s);


        [TestCase("AAAAAAAAAAAAAAA", ExpectedResult = 600)]
        public int TestCase_ModuloConflict(string s)
            => CheckoutSolution.Checkout(s);
    }

    [TestFixture]
    class SimpleMultiBuyDealTests
    {
        [Test]
        public void TestCaseShouldFindOneDeal()
        {
            var testObj = new SimpleMultiBuyDeal(3, 130, 'A');

            var testData = "AAAA".ToCharArray();

            var count = testObj.FindDealFunc(testData);

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
    }
}