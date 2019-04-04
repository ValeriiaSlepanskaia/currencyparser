using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyParser
{
    class Rate
    {
        public Rate()
        {
        }

        public Rate(DateTime created, double exchangeRate)
        {
            Created = created;
            ExchangeRate = exchangeRate;
        }

        public DateTime Created { get; set; }
        public double ExchangeRate { get; set; }

        public override string ToString()
        {
            return $"{Created}\t\t{ExchangeRate}";
        }

        public string FormatRow()
        {
            string[] cells = {
                Created.ToString(),
                ExchangeRate.ToString()
            };

            StringBuilder builder = new StringBuilder();

            foreach (string cell in cells)
            {
                builder.Append($"{cell};");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
