using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson;
using System;

namespace PearsonTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(new PearsonCorrelationCoefficient(new double[] { 0, 1, 0, 0 }, new double[] { 0, 1, 0, 0 }).Score(), 1);

            Assert.AreEqual(new PearsonCorrelationCoefficient(new double[] { 0, 1, 0, 0 }, new double[] { 2, 4, 6, 0 }).Score(), 0.26);

            Assert.ThrowsException<Exception>(() => { new PearsonCorrelationCoefficient(null, new double[] { }).Score(); }, "param can not be null");

            Assert.ThrowsException<Exception>(() => { new PearsonCorrelationCoefficient(new double[] { 0, 1 }, new double[] { 0 }).Score(); }, "two input param contain count is not same");

            Assert.AreEqual(new PearsonCorrelationCoefficient(new double[] { 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0 }).Score(), 0);

            Assert.AreEqual(new PearsonCorrelationCoefficient(new double[] { 0, 1, 0, 0, 52, 48 }, new double[] { 2, 4, 6, 0, 85, 44 }).Score(), 0.94);
        }
    }
}
