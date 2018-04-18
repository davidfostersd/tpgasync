using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TpgAsyncExercises
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // await Exercise1A();
            // Exercise2();
            // Exercise3("hello");
            Console.ReadKey();
        }


// rewrite this method to correctly use async/await
        public static Task<int> Exercise1(int input)
        {
            var r = new Randomizer();
            return r.GetAndAdd(input, 5)
                .ContinueWith(t => t.Result + 1)
                .ContinueWith(t => r.GetAndAdd(t.Result, 2)).Unwrap();
        }

        public static async Task Exercise1A()
        {
            var result = await Exercise1(3);
            Debug.Assert(result == 11, $"result should be 11");
            Console.WriteLine("Success");
        }


        // Call r.Get for each item in the input array.
        // Each call will take a random amount of time (imagine it's a web service call)
        // All r.Get calls must be started as quickly as possible
        //   DO NOT wait until one call returns before starting the next
        // The results from r.Get should be enqueued as quickly as 
        // possible but *must* be enqueued in input order 
        // IN other words, when "2" arrives, if "1" has not yet 
        // arrived then wait for it, otherwise enqueue "2" immediately.
        
        #if FALSE
        public static async Task Exercise2()
        {
            var input = new[] {1, 2, 3, 4};
            var r = new Randomizer();
            var queue = new TimedQueue();
            
            // call r.Get on all input items
            // enqueue them as quickly as possible, but in order

            Debug.Assert(queue.Count == 4, "not all values are enqueued");
            Console.WriteLine("success!");
        }
    
        #endif


        #if FALSE
        // Edit *only* the WaitableItem file to make this code compile 
        // and run correctly.  You should not need to edit
        // Exercise3 itself nor should you need to edit the Randomizer
        public static async Task Exercise3(string input)
        {
            var r = new Randomizer();
            var result = await r.GetWaitable(input);
            
            Debug.Assert(result == "hello", $"{result} is not 'Hello'");
            Console.WriteLine("Success");
        }
        #endif
    }
}