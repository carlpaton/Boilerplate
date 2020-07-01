using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Problem
{
    public class LoopyLoop
    {
        public bool MakeWord(string word, List<string> blocks) 
        {
            var blocksLeft = blocks;
            var stringComparison = StringComparison.CurrentCultureIgnoreCase;

            foreach (var letter in word)
            {
                if (!blocksLeft.Any(b => b.Contains(letter, stringComparison)))
                    return false;

                blocksLeft.Remove(blocksLeft.First(b => b.Contains(letter, stringComparison)));
            }

            return true;
        }
    }
}
