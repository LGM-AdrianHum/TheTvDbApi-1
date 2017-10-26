using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTvDbApi.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Setup();
        }

        private static void Setup()
        {
            const string apikey = "8101D1A289918B8A";
            var client = new TheTvDbClient(apikey);
            var result = Task.Run(()=> client.SeriesClient.Get(121361)).GetAwaiter().GetResult();
            var result2 = Task.Run(() => client.SeriesClient.GetSeasonsAndEpisodes(121361)).GetAwaiter().GetResult();
        }
    }
}
