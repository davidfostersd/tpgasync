using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class SimpleSimpleAsyncController
    {
        public async Task<string> Get()
        {
            return "hello";
        }
    }
}