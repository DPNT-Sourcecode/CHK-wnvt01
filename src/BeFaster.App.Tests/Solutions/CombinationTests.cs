using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    internal class MockMultiDeal : IMultiDeal
    {
        public int CountNumberOfTimesCanBeApplied(char[] characters)
        {
            throw new NotImplementedException();
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    class CombinationTests
    {
        [Test]
        public void ComputeSimpleCombination()
        {
            var testCase = new List<Tuple<IMultiDeal, int>>();
            testCase.Add(new Tuple<IMultiDeal, int>(new MockMultiDeal(), 2));

            var combinations = MultiDealEngine.ComputeCombinations(testCase);

            Assert.AreEqual(1, combinations.Count);
        }

        [Test]
        public void ComputeCombinations()
        {
            var testCase = new List<Tuple<IMultiDeal, int>>();
            testCase.Add(new Tuple<IMultiDeal, int>(new MockMultiDeal(), 2));
            testCase.Add(new Tuple<IMultiDeal, int>(new MockMultiDeal(), 1));

            var combinations = MultiDealEngine.ComputeCombinations(testCase);

            //AAB BAA AB
        }

    }
}
