using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class ThirdController
    {
        public Task<string> Get()
        {
            return Db.QueryAsync("SELECT twitterId FROM ids where id = 42")
                .ContinueWith(t => Client.GetTweets(t.Result))
                .Unwrap()
                .ContinueWith(t => t.Result.First())
                .ContinueWith(e =>
                {
                    Console.WriteLine($"Error {e}");
                    return "";
                }, TaskContinuationOptions.OnlyOnFaulted);

        }


        internal class Db
        {
            public static Task<int> QueryAsync(string sql)
            {
                // return Task.Delay(0).ContinueWith(_ => 42);
                throw new Exception("foo");
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