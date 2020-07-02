using System;
using System.Collections.Generic;
using System.Linq;

namespace Random.Yield
{
    public class YieldDemo
    {
        public YieldDemo() 
        {
            var doTheYieldThing = new DoTheYieldThing();

            var infiniteOnes = doTheYieldThing.InfiniteOnes();

            var counter = 1;
            foreach (var one in infiniteOnes.Take(10))
            {
                Console.WriteLine("one={0}, counter={1}", one, counter);
                counter++;
            }

            Console.WriteLine("----------------------------");

            foreach (var one in infiniteOnes.Take(10))
            {
                Console.WriteLine("one={0}, counter={1}", one, counter);
                counter++;
            }
        }
    }

    public class DoTheYieldThing 
    {
        public IEnumerable<int> InfiniteOnes()
        {
            while (true)
                yield return 1;
        }
    }
}
