using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheTvDbApi;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TheTvDbClient("F2A9C6DEED8BBCD8");
            var token1 = client.AuthenticationClient.Token;
            Thread.Sleep(200);
            client.AuthenticationClient.RefreshToken();
            var token2 = client.AuthenticationClient.Token;
        }
    }
}
