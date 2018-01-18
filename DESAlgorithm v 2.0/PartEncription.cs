using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal static class PartEncription
    {
        public static BitArray DES64BitsEncription(BitArray DES64BitsBitArray, BitArray[] keys)
        {
            byte[] InitialPermutation = new byte[] { 58, 50, 42, 34, 26, 18, 10, 2,
                                                             60, 52, 44, 36, 28, 20, 12, 4,
                                                             62, 54, 46, 38, 30, 22, 14, 6,
                                                             64, 56, 48, 40, 32, 24, 16, 8,
                                                             57, 49, 41, 33, 25, 17, 9,  1,
                                                             59, 51, 43, 35, 27, 19, 11, 3,
                                                             61, 53, 45, 37, 29, 21, 13, 5,
                                                             63, 55, 47, 39, 31, 23, 15, 7 };
            DES64BitsBitArray = MathUtil.BitArrayPermutate(DES64BitsBitArray, InitialPermutation);
            BitArray[] LeftSidePart = PartInit(new BitArray[17]);
            BitArray[] RightSidePart = PartInit(new BitArray[17]);
            LeftSidePart[0] = FirstLeftElementInit(LeftSidePart[0], DES64BitsBitArray);
            RightSidePart[0] = FirstRightElementInit(RightSidePart[0], DES64BitsBitArray);
            EncriptingCycle1To16(ref RightSidePart, ref LeftSidePart, keys);
            ReplaceLastElement(ref LeftSidePart, ref RightSidePart);
            DES64BitsBitArray = JoinLeftRightPart(LeftSidePart[16], RightSidePart[16]);
            byte[] FinalPermutation = new byte[] {40, 8, 48, 16, 56, 24, 64, 32,
                                                          39, 7, 47, 15, 55, 23, 63, 31,
                                                          38, 6, 46, 14, 54, 22, 62, 30,
                                                          37, 5, 45, 13, 53, 21, 61, 29,
                                                          36, 4, 44, 12, 52, 20, 60, 28,
                                                          35, 3, 43, 11, 51, 19, 59, 27,
                                                          34, 2, 42, 10, 50, 18, 58, 26,
                                                          33, 1, 41, 9 , 49, 17, 57, 25 };
            DES64BitsBitArray = MathUtil.BitArrayPermutate(DES64BitsBitArray, FinalPermutation);
            return DES64BitsBitArray;
        }

        static BitArray[] PartInit(BitArray[] Part)
        {
            for (int i = 0; i < 16; i++)
            {
                Part[i] = new BitArray(32);
            }
            return Part;
        }

        static BitArray FirstLeftElementInit(BitArray LeftSidePart, BitArray DES64BitsBitArray)
        {
            for (int i = 0; i < 32; i++)
            {
                LeftSidePart[i] = DES64BitsBitArray[i];
            }
            return LeftSidePart;
        }

        static BitArray FirstRightElementInit(BitArray RightSidePart, BitArray DES64BitsBitArray)
        {
            for (int i = 0; i < 32; i++)
            {
                RightSidePart[i] = DES64BitsBitArray[i + 32];
            }
            return RightSidePart;
        }

        static void EncriptingCycle1To16(ref BitArray[] RightSidePart, ref BitArray[] LeftSidePart, BitArray[] keys)
        {
            for (int i = 1; i < 17; i++)
            {
                LeftSidePart[i] = RightSidePart[i - 1];
                RightSidePart[i] = LeftSidePart[i - 1].Xor(MathUtil.FeistelFunction(RightSidePart[i-1],i,keys));
            }
        }

        static void ReplaceLastElement(ref BitArray[] RightSidePart, ref BitArray[] LeftSidePart)
        {
            BitArray temp = RightSidePart[16];
            RightSidePart[16] = LeftSidePart[16];
            LeftSidePart[16] = temp;
        }

        static BitArray JoinLeftRightPart(BitArray RightSidePart, BitArray LeftSidePart)
        {
            return new BitArray((RightSidePart.Cast<bool>().ToArray().Concat(LeftSidePart.Cast<bool>().ToArray())).ToArray());
        }

    }
}
