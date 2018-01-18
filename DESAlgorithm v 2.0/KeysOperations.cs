using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal static class KeysOperations
    {
        public static BitArray[] CreateSubkeys(BitArray key)
        {
            byte[] PermutedChoice1Left = new byte[] {57,  49,  41,  33,  25,  17,   9,
                                                              1 ,  58,  50,  42,  34,  26,  18,
                                                              10,  2 ,  59,  51,  43,  35,  27,
                                                              19,  11,  3 ,  60,  52,  44,  36 };

            byte[] PermutedChoice1Right = new byte[] {63,  55,  47,  39,  31,  23,  15,
                                                               7 ,  62,  54,  46,  38,  30,  22,
                                                               14,  6,   61,  53,  45,  37,  29,
                                                               21,  13,  5,   28,  20,  12,  4};

            byte[] PermutedChoice2 = new byte[] { 14,  17,  11,  24,  1 ,  5 ,
                                                            3,  28,  15,  6 ,  21,  10,
                                                           23,  19,  12,  4 ,  26,  8 ,
                                                           16,   7,  27,  20,  13,  2 ,
                                                           41,  52,  31,  37,  47,  55,
                                                           30,  40,  51,  45,  33,  48,
                                                           44,  49,  39,  56,  34,  53,
                                                           46,  42,  50,  36,  29,  32 };

            BitArray[] Subkeys = new BitArray[16];
            BitArray[] LeftSideSubkeys = new BitArray[17];
            BitArray[] RightSideSubkeys = new BitArray[17];

            LeftSideSubkeys[0] = MathUtil.BitArrayPermutate(key, PermutedChoice1Left);
            RightSideSubkeys[0] = MathUtil.BitArrayPermutate(key, PermutedChoice1Right);
            BitArray temp1 = new BitArray(RightSideSubkeys[0]);
            BitArray temp2 = new BitArray(LeftSideSubkeys[0]);
            for (int i = 1; i < 17; i++)
            {
                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    LeftSideSubkeys[i] =  BitArrayOperation.ShiftElement(LeftSideSubkeys[i - 1], 1);
                    RightSideSubkeys[i] = BitArrayOperation.ShiftElement(RightSideSubkeys[i - 1], 1);
                }
                else
                {
                    LeftSideSubkeys[i] = BitArrayOperation.ShiftElement(LeftSideSubkeys[i - 1], 2);
                    RightSideSubkeys[i] = BitArrayOperation.ShiftElement(RightSideSubkeys[i - 1], 2);
                }
                BitArray temp3 = new BitArray(RightSideSubkeys[i]);
                BitArray temp4 = new BitArray(LeftSideSubkeys[i]);
            }
            for (int i = 0; i < 16; i++)
            {
                Subkeys[i] = new BitArray(LeftSideSubkeys[i+1].Cast<bool>().ToArray<bool>().Concat(RightSideSubkeys[i + 1].Cast<bool>().ToArray<bool>()).ToArray<bool>());
                BitArray temp5 = new BitArray(Subkeys[i]);
                Subkeys[i] = MathUtil.BitArrayPermutate(Subkeys[i], PermutedChoice2);
                BitArray temp6 = new BitArray(Subkeys[i]);
            }
            return Subkeys;
        }

        public static BitArray Standardisation(BitArray keyBitArray)
        {
            BitArray temp = new BitArray(64);
            if (keyBitArray.Count < 64)
            {
                for (int i = 0; i < keyBitArray.Count; i++)
                {
                    temp[i] = keyBitArray[i];
                }
                keyBitArray = temp;
            }
            if (keyBitArray.Count > 64)
            {
                for (int i = 0; i < 64; i++)
                {
                    temp[i] = keyBitArray[i];
                }
                keyBitArray = temp;
            }
            return keyBitArray;
        }
    }
}
