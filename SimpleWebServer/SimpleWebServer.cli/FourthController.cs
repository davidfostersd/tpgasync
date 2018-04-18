using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class FourthController
    {
        public async Task<string> Get()
        {
            var twitterId = await Db.QueryAsync("SELECT twitterId FROM ids where id = 42");
            var tweets = await Client.GetTweets(twitterId);
            return tweets.First();
        }
        

        internal class Db
        {
            public static Task<int> QueryAsync(string sql)
            {
                return Task.Delay(0).ContinueWith(_ => 42);
            }
        }
        
        internal class Client
        {
            public static Task<string[]> GetTweets(int id)
            {
                return Task.Delay(0).ContinueWith(_ => new [] { "one", "two", "three"});
            }
        }
    }
}