using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class SecondController
    {
        public Task<string> Get()
        {
            var client = new HttpClient();
            return client.GetStringAsync("http://www.google.com")
                .ContinueWith(t => t.Result.Substring(0, 10));
        }
        
    }
}