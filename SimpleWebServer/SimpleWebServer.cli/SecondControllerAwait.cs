using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class SecondControllerAwait
    {
        public async Task<string> Get()
        {
            var client = new HttpClient();
            var s = await client.GetStringAsync("http://www.google.com");
            return s.Substring(0, 10);
        }
    }
}