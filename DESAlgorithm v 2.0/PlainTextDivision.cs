using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class PlainTextDivision
    {
        public static BitArray[] Divise(BitArray plainTextBitArray, BitArray[] plainText64BitFragments)
        {
            plainText64BitFragments[0] = new BitArray(plainTextBitArray.Cast<bool>().ToArray().Take(64).ToArray());
            for (int i = 1; i < plainTextBitArray.Length/64; i++)
            {
                plainText64BitFragments[i]=new BitArray(plainTextBitArray.Cast<bool>().ToArray().Take((i+1)*64).Skip(i*64).ToArray());
            }
            return plainText64BitFragments;
        }
    }
}
