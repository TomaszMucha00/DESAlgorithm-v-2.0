using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class PlainTextJoin
    {
        public static BitArray Join(BitArray plainTextBitArray, BitArray[] plainText64BitFragments)
        {
            plainTextBitArray = plainText64BitFragments[0];
            for (int i = 1; i < plainText64BitFragments.Length; i++)
            {
                plainTextBitArray = new BitArray((plainTextBitArray.Cast<bool>().ToArray().Concat(plainText64BitFragments[i].Cast<bool>().ToArray())).ToArray());
            }
            return plainTextBitArray;
        }
    }
}
