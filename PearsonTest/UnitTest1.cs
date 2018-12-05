using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson;
using System;
using System.Collections.Generic;
using System.Linq;

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


            List<TestClass> list = new List<TestClass>() {
                new TestClass(){ col1="5",col2="8",col3="88",col4="98"},
                new TestClass(){ col1="45",col2="30",col3="88",col4="98"},
                new TestClass(){ col1="50",col2="25",col3="88",col4="98"},
                new TestClass(){ col1="70",col2="50",col3="88",col4="98"},
                new TestClass(){ col1="80",col2="85",col3="88",col4="98"}
            };

            var pearson = new PearsonCorrelationCoefficient(list.Select(a => new PearsonEntity<string>() { Col1 = a.col1, Col2 = a.col2 }).ToList()).Score();
            Assert.AreEqual(pearson == 0.89, true);




        }


    }


    public class TestClass
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }

    }

}
