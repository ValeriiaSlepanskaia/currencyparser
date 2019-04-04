using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using Newtonsoft.Json.Linq;

namespace CurrencyParser
{
    class ExchangerRuParser
    {
        public List<Rate> GetRates(JArray array)
        {
            return array.Select(x => new Rate(DateTimeOffset.FromUnixTimeMilliseconds(x[0].Value<long>()).DateTime, x[1].Value<double>())).ToList();
        }

    }
}
