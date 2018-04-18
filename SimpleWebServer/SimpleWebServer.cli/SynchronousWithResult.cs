using System;
using System.Net.Http;

namespace SimpleWebServer.cli
{
    public class SynchronousWithResult
    {
        public string Get()
        {
            // BAD BAD BAD 
            var client = new HttpClient();
            var html = client.GetStringAsync("http://www.google.com").Result;
            Console.WriteLine("This will run *after* the google call");
            return html;
        }
    }
}