using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    class AnyOfTests
    {
        [Test]
        public void FindsAnyOFDeals()
        {
            var deal = new AnyOfMultiBuyDeal(3, 30, 'A', 'B', 'C');
            var possibleSavings = deal.CalculatePossibleSavings(new char[] {'A', 'B', 'C'});
            Assert.AreNotEqual(0, possibleSavings);
        }

        [Test]
        public void DoesntFindAnyOFDeals()
        {
            var deal = new AnyOfMultiBuyDeal(4, 30, 'A', 'B', 'C');
            var possibleSavings = deal.CalculatePossibleSavings(new char[] { 'A', 'A', 'A' });
            Assert.AreEqual(0, possibleSavings);
        }

    }
}
