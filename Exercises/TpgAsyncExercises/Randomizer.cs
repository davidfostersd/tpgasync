﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace TpgAsyncExercises
{
    // do not edit this file
    public class TimedInt
    {
        public DateTime RetrieveDate { get; }
        public int Value { get; }

        public TimedInt(DateTime retrieveDate, int value)
        {
            RetrieveDate = retrieveDate;
            Value = value;
        }
    }

    public class Randomizer
    {
        public static readonly Random Random = new Random();

        private bool _finished = false;

        public Task<TimedInt> Get(int input)
        {
            if (_finished)
                Debug.Assert(false, $"It took too much time to start the Get call for {input}");
            var delay = Random.Next(500, 3000);
            return Task.Delay(delay).ContinueWith(_ =>
            {
                _finished = true;
                return new TimedInt(DateTime.Now, input);
            });
        }

        public Task<int> GetAndAdd(int root, int addendum)
        {
            var delay = Random.Next(500, 3000);
            return Task.Delay(delay).ContinueWith(_ => root + addendum);
        }

        public WaitableItem GetWaitable(string input)
        {
            var item = new WaitableItem(input) ;
            var delay = Random.Next(2, 800);
            Task.Delay(delay).ContinueWith(_ => { item.Completed = true; });
            return item;
        }
    }

    public class TimedQueue
    {
        private readonly List<TimedInt> _list = new List<TimedInt>();
        public void Enqueue(TimedInt input)
        {
            var retrieveDate = input.RetrieveDate;
            if (_list.Any())
            {
                if (!IsValidSpan(retrieveDate) && !IsValidSpan(_list.Last().RetrieveDate))
                {
                    throw new ArgumentException($"You took too long to queue '{input.Value}'");
                }

                if (_list.Last().Value > input.Value)
                {
                    throw new ArgumentException($"'{input.Value}' is enqueued out of order");
                    
                }
            }
            _list.Add(input);
        }

        public int Count => _list.Count();

        private static bool IsValidSpan(DateTime retrieveDate)
        {
            return retrieveDate.AddMilliseconds(100) > DateTime.Now;
        }
    }
}