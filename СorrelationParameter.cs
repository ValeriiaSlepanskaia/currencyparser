using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyParser
{
    class CorrelationParameter
    {
        public static double Correlation(double[] data1, double[] data2)
        {
            if (data1.Length != data2.Length)
            {
                throw new Exception("The 2 datasets being tested are of different sizes");
            }

            double sum1 = 0.0d;
            double sum2 = 0.0d;

            for (int i = 0; i < data1.Length; i++)
            {
                sum1 += data1[i];
                sum2 += data2[i];
            }

            double mean1 = sum1 / data1.Length;
            double mean2 = sum2 / data2.Length;
            double total = 0.0d;

            for (int i = 0; i < data1.Length; i++)
            {
                total += ((data1[i] - mean1) * (data2[i] - mean2));
            }

            double covariance = total / data1.Length;

            sum1 = 0.0d;
            sum2 = 0.0d;

            for (int i = 0; i < data1.Length; i++)
            {
                sum1 += ((data1[i] - mean1) * (data1[i] - mean1));
                sum2 += ((data2[i] - mean2) * (data2[i] - mean2));
            }

            double stdev1 = Math.Sqrt(sum1 / data1.Length);
            double stdev2 = Math.Sqrt(sum2 / data2.Length);

            if ((stdev1 * stdev2) == 0)
            {
                throw new Exception("One of the standart deviations is zero");
            }

            return (covariance / (stdev1 * stdev2));
        }
    }
}
