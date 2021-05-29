using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ABCProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "CONFUSE";
            var blocks = new List<string>() { "B O", "X K", "D Q", "C P", "N A", "G T", "R E", "T G", "Q D", "F S", "J W", "H U", "V I", "A N", "O B", "E R", "F S", "L Y", "P C", "Z M" };
            var blocks2 = string.Join("|", blocks.ToArray()).Replace(" ", "").Replace("|", " ");
            var makeWord = new MakeWord();

            var sw = new Stopwatch();
            sw.Start();
            makeWord.ForeachLoop(word, blocks);
            sw.Stop();
            Console.WriteLine("ForeachLoop: {0}", sw.Elapsed);

            var sw1 = new Stopwatch();
            sw1.Start();
            makeWord.ActionDelegate(word, blocks);
            sw1.Stop();
            Console.WriteLine("ActionDelegate: {0}", sw1.Elapsed);

            var sw2 = new Stopwatch();
            sw2.Start();
            makeWord.Regex(word, blocks2);
            sw2.Stop();
            Console.WriteLine("Regex: {0}", sw2.Elapsed);
        }
    }
}
