using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class PermutationOperation
    {
        public static BitArray Permutate(BitArray toPermutate, int[] permutatior)
        {
            BitArray permutated = new BitArray(permutatior.Length);

            for (int i = 0; i < permutatior.Length; i++)
            {
                permutated[i] = toPermutate[permutatior[i] - 1];
            }
            return permutated;
        }
    }
}
