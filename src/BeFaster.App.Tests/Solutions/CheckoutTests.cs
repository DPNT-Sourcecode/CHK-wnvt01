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
}
