using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Problem
{
    public class LoopyLoop
    {
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
    }
}
