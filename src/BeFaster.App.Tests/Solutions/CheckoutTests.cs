using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    class CheckoutTests
    {
        [TestCase("BBEEEE", ExpectedResult = 160)]
        public int TestCase_AllBAreFree(string s)
            => CheckoutSolution.Checkout(s);


        [TestCase("A", ExpectedResult = 50)]
        public int RookieMistake(string s)
            => CheckoutSolution.Checkout(s);

        [TestCase("FFF", ExpectedResult = 20)]
        public int BTGOFTest(string s)
            => CheckoutSolution.Checkout(s);


        [TestCase("FFFFFF", ExpectedResult = 40)]
        public int BTgofTwice(string s)
            => CheckoutSolution.Checkout(s);

        [TestCase("AAAAAAAAAAAAAAA", ExpectedResult = 600)]
        public int TestCase_ModuloConflict(string s)
            => CheckoutSolution.Checkout(s);
    }
}