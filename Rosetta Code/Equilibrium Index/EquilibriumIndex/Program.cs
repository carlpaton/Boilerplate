using System;
using System.Collections.Generic;
using System.Linq;

namespace EquilibriumIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>
            {
                2,
                2,
                4,
                1,
                3
            };

            list = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            var equilibriumIndexService = new EquilibriumIndexService(list.ToArray());
            var result = equilibriumIndexService.ForLoop();

            Console.WriteLine($"Expect 2, Got {result}");
            Console.WriteLine("-------");


            var result2 = equilibriumIndexService
                .ForeachLoop()
                .FirstOrDefault();

            Console.WriteLine($"Expect 2, Got {result2}");
            Console.WriteLine("-------");
        }
    }
}
