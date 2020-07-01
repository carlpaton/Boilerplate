using ABC_Problem;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "KELVIN";
            var blocks = new List<string>() { "B O", "X K", "D Q", "C P", "N A", "G T", "R E", "T G", "Q D", "F S", "J W", "H U", "V I", "A N", "O B", "E R", "F S", "L Y", "P C", "Z M" };
            var blocks2 = string.Join("|", blocks.ToArray()).Replace(" ", "").Replace("|", " ");
            var loopyLoop = new LoopyLoop();

            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("{0}={1}", word, loopyLoop.MakeWord(word, blocks));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("{0}={1}", word, loopyLoop.MakeWord2(word, blocks));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("{0}={1}", word, loopyLoop.MakeWord3(word, blocks2));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
