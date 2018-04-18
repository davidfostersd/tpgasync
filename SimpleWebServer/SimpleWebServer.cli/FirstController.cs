using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class FirstController
    {
        public Task<string> Get()
        {
            var client = new HttpClient();
            return client.GetStringAsync("http://www.google.com");
        }
    }
}