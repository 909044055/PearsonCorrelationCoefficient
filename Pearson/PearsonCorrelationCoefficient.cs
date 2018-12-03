using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson
{
    public class PearsonCorrelationCoefficient
    {

        private readonly double[] CompareTo;
        private readonly double[] CompareWith;
        private List<string> similarTitles;

        public PearsonCorrelationCoefficient(double[] compareTo, double[] compareWith)
        {
            CompareTo = compareTo;
            CompareWith = compareWith;
        }

        public double Score()
        {
            if (CompareTo.Count() != CompareWith.Count())
            {
                throw new Exception("two input param contain count is not same");
            }

            return CalculatePearsonCorrelationScore();
        }

        private double CalculatePearsonCorrelationScore()
        {
            var n = similarTitles.Count;
            if (n == 0)
            {
                return 0.0;
            }

            var sum1 = SumScoresCompareTo();
            var sum2 = SumScoresCompareWith();

            var sum1Sq = SumSquaresCompareTo();
            var sum2Sq = SumSquaresCompareWith();

            var pSum = SumProductsOfBothReviewers();

            var num = pSum - (sum1 * sum2 / n);

            var den = Math.Sqrt((sum1Sq - Math.Pow(sum1, 2) / n) * (sum2Sq - Math.Pow(sum2, 2) / n));

            if (den == 0.0)
            {
                return 0.0;
            }

            var answer = num / den;
            return Math.Round(answer, 3);
        }

        public double SumProductsOfBothReviewers()
        {
            double sum = 0;
            for (int i = 0; i < CompareTo.Count(); i++)
            {
                sum += CompareTo[i] * CompareTo[i];
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
                sum += Math.Pow(CompareWith[i], 2);
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
