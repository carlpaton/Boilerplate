using System.Collections.Generic;
using System.Linq;

namespace EquilibriumIndex
{
    public class EquilibriumIndexService
    {
        private readonly int[] _array;

        public EquilibriumIndexService(int[] array)
        {
            _array = array;
        }

        public int ForLoop() 
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == 0 || i == _array.Length - 1)
                    continue;

                var lowerValues = 0;
                var upperValues = 0;

                for (int ii = 0; ii < i; ii++)
                {
                    lowerValues += _array[ii];
                }

                for (int iii = _array.Length-1; iii > i; iii--)
                {
                    upperValues += _array[iii];
                }

                if (lowerValues == upperValues)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// http://rosettacode.org/wiki/Equilibrium_index#C.23
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> ForeachLoop()
        {
            var left = 0;
            var right = _array.Sum();
            var index = 0;
            foreach (var element in _array)
            {
                right -= element;
                if (left == right)
                {
                    yield return index;
                }
                left += element;
                index++;
            }
        }
    }
}
