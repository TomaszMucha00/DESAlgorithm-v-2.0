using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class PlainTextStandardisation
    {
        // Standardisation to bit array divisible by 64
        public static BitArray BitArrayStandardisation(BitArray plainTextBitArray)
        {
            int AddictionalField = 64 - (plainTextBitArray.Count % 64);
            if (AddictionalField!=0)
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
    }
}
