using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ABC_Problem
{
    public class LoopyLoop
    {
        /// <summary>
        /// Using a normal `foreach` loop
        /// </summary>
        /// <param name="word"></param>
        /// <param name="blocks"></param>
        /// <returns></returns>
        public bool MakeWord(string word, List<string> blocks) 
        {
            var blocksLeft = new List<string>(blocks);
            var stringComparison = StringComparison.CurrentCultureIgnoreCase;

            foreach (var letter in word)
            {
                if (!blocksLeft.Any(b => b.Contains(letter, stringComparison)))
                    return false;

                blocksLeft.Remove(blocksLeft.First(b => b.Contains(letter, stringComparison)));
            }

            return true;
        }

        /// <summary>
        /// Trying to make things faster with an `Action`
        /// </summary>
        /// <param name="word"></param>
        /// <param name="blocks"></param>
        /// <returns></returns>
        public bool MakeWord2(string word, List<string> blocks)
        {
            var letters = word.ToList();
            var blocksLeft = new List<string>(blocks);
            var stringComparison = StringComparison.CurrentCultureIgnoreCase;

            letters.ForEach(letter => {

                if (!blocksLeft.Any(b => b.Contains(letter, stringComparison)))
                    return;

                blocksLeft.Remove(blocksLeft.First(b => b.Contains(letter, stringComparison)));

            });

            return blocksLeft.Count() + letters.Count() == blocks.Count();
        }

        /// <summary>
        /// Implementation from http://rosettacode.org/wiki/ABC_Problem#Regex
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool MakeWord3(string word, string blocks)
        {
            for (int i = 0; i < word.Length; ++i)
            {
                int length = blocks.Length;
                var rgx = new Regex("([a-z]" + word[i] + "|" + word[i] + "[a-z])", RegexOptions.IgnoreCase);
                blocks = rgx.Replace(blocks, "", 1);
                if (blocks.Length == length) return false;
            }
            return true;
        }

        /// <summary>
        /// yield result? - https://stackoverflow.com/questions/44798975/trouble-understanding-yield-in-c-sharp?noredirect=1&lq=1
        /// dunno if this is a good candidate for yield :D
        /// </summary>
        /// <returns></returns>
        public bool MakeWord4()
        {
            throw new NotImplementedException("hey go learn how to use yield :D");
        }
    }
}
