using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyParser
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            const string url = "https://wm.exchanger.ru/asp/XMLQuerysStatsJSON.asp?exchtype=6&grouptype=4";
            var proxy = new WebProxy("175.100.18.45", 41924);

            Console.WriteLine("Загрузка данных...");
            Console.WriteLine();

            ExchangerRuLoader loader = new ExchangerRuLoader(url, proxy);
            JArray array = loader.LoadJson();

            ExchangerRuParser parser = new ExchangerRuParser();
            List<Rate> trades = parser.GetRates(array);

            double[] rates = trades.Select(trade => (double)trade.ExchangeRate).ToArray();
            double[] dates = trades.Select(x => (double)new DateTimeOffset(x.Created).ToUnixTimeMilliseconds()).ToArray(); 

            double parameter = CorrelationParameter.Correlation(rates, dates);

            Application.EnableVisualStyles();
            Application.Run(new PlotForm(dates.Zip(rates, (date, rate) => (date, rate)).ToArray()));

           using (StreamWriter csv = new StreamWriter("correlation.csv", true, Encoding.UTF8))
       {
              foreach (Rate trate in trades)
                {
                    csv.WriteLine(value:trate.FormatRow());
                }
            
            }
        }

    }
}
