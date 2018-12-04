using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson;

namespace PearsonTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new double[] { 0, 1, 0, 0 };

            var pearson = new PearsonCorrelationCoefficient(a, a).Score();

            Assert.AreEqual(pearson, 1);


            var b= new double[] { 2, 4, 6, 0 };

             pearson = new PearsonCorrelationCoefficient(a, b).Score();

            Assert.AreEqual(pearson, 0.26);


        }
    }
}
