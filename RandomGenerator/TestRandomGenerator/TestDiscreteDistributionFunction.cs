using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RandomGenerator.Model;

namespace TestRandomGenerator
{
    [TestFixture]
    public class TestDiscreteDistributionFunction
    {
        [Test]
        public void Test1()
        {
            DiscreteDistributionFunction func = DiscreteDistributionFunction.Create();
            Assert.IsTrue(true);
        }
    }
}
