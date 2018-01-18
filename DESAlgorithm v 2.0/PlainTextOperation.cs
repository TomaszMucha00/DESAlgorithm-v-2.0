using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    class PlainTextOperation
    {
        public static BitArray Standardisation(BitArray plainTextBitArray)
        {
            int AddictionalField = (64 - (plainTextBitArray.Count % 64)!=0)? 64 - (plainTextBitArray.Count % 64):0;
            if (AddictionalField != 0)
            {
                BitArray temp = new BitArray(plainTextBitArray.Count + AddictionalField);
                for (int i = 0; i < plainTextBitArray.Count; i++)
                {
                    temp[i] = plainTextBitArray[i];
                }
                plainTextBitArray = temp;
            }
            return plainTextBitArray;
        }

        public static BitArray Join(BitArray plainTextBitArray, BitArray[] plainText64BitFragments)
        {
            plainTextBitArray = plainText64BitFragments[0];
            for (int i = 1; i < plainText64BitFragments.Length; i++)
            {
                plainTextBitArray = new BitArray((plainTextBitArray.Cast<bool>().ToArray().Concat(plainText64BitFragments[i].Cast<bool>().ToArray())).ToArray());
            }
            return plainTextBitArray;
        }

        public static BitArray[] Divise(BitArray plainTextBitArray, BitArray[] plainText64BitFragments)
        {
            plainText64BitFragments[0] = new BitArray(plainTextBitArray.Cast<bool>().ToArray().Take(64).ToArray());
            for (int i = 1; i < plainTextBitArray.Length / 64; i++)
            {
                plainText64BitFragments[i] = new BitArray(plainTextBitArray.Cast<bool>().ToArray().Take((i + 1) * 64).Skip(i * 64).ToArray());
            }
            return plainText64BitFragments;
        }
    }
}
