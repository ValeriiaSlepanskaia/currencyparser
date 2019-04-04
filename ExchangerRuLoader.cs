using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyParser
{
    class ExchangerRuLoader
    {
        private readonly string url;
        private readonly WebProxy proxy;

        public ExchangerRuLoader(string url, WebProxy proxy)
        {
            this.url = url;
            this.proxy = proxy;
        }

        public JArray LoadJson()
        {
            using (WebClient client = new WebClient())
            {
                client.Proxy = proxy;
                client.Encoding = Encoding.UTF8;

                var data = client.DownloadString(url);

                return JArray.Parse(data);
            }
        }

    }
}
