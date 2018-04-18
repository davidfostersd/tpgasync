using System;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class StringController
    {
        public Task<string> Get()
        {
            // return "http://www.google.com";
            return null;
        }
    }
}