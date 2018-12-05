using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson
{

    /// <summary>
    /// 皮尔森系数
    /// </summary>
    public class PearsonCorrelationCoefficient
    {

        private readonly double[] CompareTo;
        private readonly double[] CompareWith;
        private readonly List<double> listCompareTo;
        private readonly List<double> listCompareWith;


        public PearsonCorrelationCoefficient(List<PearsonEntity<string>> pearsonEntities)
        {
            listCompareTo = new List<double>();
            listCompareWith = new List<double>(); 

            foreach (var item in pearsonEntities)
            {
                listCompareTo.Add(Convert.ToDouble(item.Col1));
                listCompareWith.Add(Convert.ToDouble(item.Col2));
            }

            CompareTo = listCompareTo.ToArray();
            CompareWith = listCompareWith.ToArray();
        }

        public PearsonCorrelationCoefficient(List<PearsonEntity<double>> pearsonEntities)
        {
            listCompareTo = new List<double>();
            listCompareWith = new List<double>();

            foreach (var item in pearsonEntities)
            {
                listCompareTo.Add(Convert.ToDouble(item.Col1));
                listCompareWith.Add(Convert.ToDouble(item.Col2));
            }

            CompareTo = listCompareTo.ToArray();
            CompareWith = listCompareWith.ToArray();
        }

        public PearsonCorrelationCoefficient(string[] compareTo, string[] compareWith)
        {

            if (compareTo.Count() != compareWith.Count())
            {
                throw new Exception("two input param contain count is not same");
            }

            listCompareTo = new List<double>();
            listCompareWith = new List<double>();
            for (int i = 0; i < compareTo.Count(); i++)
            {
                if (double.TryParse(compareTo[i], out double tmpValue1) && double.TryParse(compareWith[i], out double tmpValue2))
                {
                    listCompareTo.Add(tmpValue1);
                    listCompareWith.Add(tmpValue2);
                }
            }

            CompareTo = listCompareTo.ToArray();
            CompareWith = listCompareWith.ToArray();
        }


        public PearsonCorrelationCoefficient(double[] compareTo, double[] compareWith)
        {
            CompareTo = compareTo;
            CompareWith = compareWith;
        }


        /// <summary>
        /// 皮尔森系数
        /// </summary>
        /// <returns>皮尔森系数</returns>
        public double Score()
        {
            if (CompareTo == null || CompareWith == null)
            {
                throw new Exception("param can not be null");
            }

            if (CompareTo.Count() != CompareWith.Count())
            {
                throw new Exception("two input param contain count is not same");
            }

            if (CompareTo.Count() == 0)
            {
                throw new Exception(" input param contain 0 element");
            }

            return CalculatePearsonCorrelationScore();
        }


        /// <summary>
        /// 计算皮尔森系数
        /// </summary>
        /// <returns>皮尔森系数</returns>
        private double CalculatePearsonCorrelationScore()
        {
            double n = CompareTo.Count();
            if (n == 0)
            {
                return 0;
            }

            var sum1 = SumScoresCompareTo();
            var sum2 = SumScoresCompareWith();

            var sum1Sq = SumSquaresCompareTo();
            var sum2Sq = SumSquaresCompareWith();

            var pSum = SumProductsOfBothInput();

            var num = pSum - (sum1 * sum2 / n);

            var den = Math.Sqrt((sum1Sq - Math.Pow(sum1, 2) / n) * (sum2Sq - Math.Pow(sum2, 2) / n));

            if (den == 0.0)
            {
                return 0.0;
            }

            var answer = num / den;
            return Math.Round(answer, 2);
        }

        public double SumProductsOfBothInput()
        {
            double sum = 0;
            for (int i = 0; i < CompareTo.Count(); i++)
            {
                sum += CompareTo[i] * CompareWith[i];
            }
            return sum;
        }

        public double SumSquaresCompareWith()
        {
            double sum = 0;
            for (int i = 0; i < CompareWith.Count(); i++)
            {
                sum += Math.Pow(CompareWith[i], 2);
            }
            return sum;
        }

        public double SumSquaresCompareTo()
        {
            double sum = 0;
            for (int i = 0; i < CompareTo.Count(); i++)
            {
                sum += Math.Pow(CompareTo[i], 2);
            }
            return sum;
        }

        public double SumScoresCompareTo()
        {
            double sum = 0;
            for (int i = 0; i < CompareTo.Count(); i++)
            {
                sum += CompareTo[i];
            }
            return sum;
        }

        public double SumScoresCompareWith()
        {
            double sum = 0;
            for (int i = 0; i < CompareWith.Count(); i++)
            {
                sum += CompareWith[i];
            }
            return sum;
        }




    }
}
