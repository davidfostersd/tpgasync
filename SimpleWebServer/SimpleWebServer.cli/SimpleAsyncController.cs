using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class SimpleAsyncController
    {
        public Task<string> Get()
        {
            return Task.FromResult("hello");
        }
        
    }
}