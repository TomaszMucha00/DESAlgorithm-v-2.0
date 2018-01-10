using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class Keys
    {
        public static BitArray[] Subkeys = new BitArray[16]; 
         
        static int[] PermutedChoice1Left = new int[] {57,  49,  41,  33,  25,  17,   9,
                                                              1 ,  58,  50,  42,  34,  26,  18,
                                                              10,  2 ,  59,  51,  43,  35,  27,
                                                              19,  11,  3 ,  60,  52,  44,  36 };

        static int[] PermutedChoice1Right = new int[] {63,  55,  47,  39,  31,  23,  15,
                                                               7 ,  62,  54,  46,  38,  30,  22,
                                                               14,  6,   61,  53,  45,  37,  29,
                                                               21,  13,  5,   28,  20,  12,  4};

        static int[] PermutedChoice2 = new int[] { 14,  17,  11,  24,  1 ,  5 ,
                                                            3,  28,  15,  6 ,  21,  10,
                                                           23,  19,  12,  4 ,  26,  8 ,
                                                           16,   7,  27,  20,  13,  2 ,
                                                           41,  52,  31,  37,  47,  55,
                                                           30,  40,  51,  45,  33,  48,
                                                           44,  49,  39,  56,  34,  53,
                                                           46,  42,  50,  36,  29,  32 };

        public static void CreateSubkeys(BitArray key)
        {
            BitArray[] LeftSideSubkeys = new BitArray[17];
            BitArray[] RightSideSubkeys = new BitArray[17];
            Subkeys = new BitArray[16];

            LeftSideSubkeys[0] = PermutationOperation.Permutate(key, PermutedChoice1Left);
            RightSideSubkeys[0] = PermutationOperation.Permutate(key, PermutedChoice1Right);

            for (int i = 1; i < 17; i++)
            {
                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    LeftSideSubkeys[i] =  ShiftTableElement.ShiftElement(LeftSideSubkeys[i - 1], 1);
                    RightSideSubkeys[i] = ShiftTableElement.ShiftElement(RightSideSubkeys[i - 1], 1);
                }
                else
                {
                    LeftSideSubkeys[i] = ShiftTableElement.ShiftElement(LeftSideSubkeys[i - 1], 2);
                    RightSideSubkeys[i] = ShiftTableElement.ShiftElement(RightSideSubkeys[i - 1], 2);
                }
            }
            for (int i = 0; i < 16; i++)
            {
                Subkeys[i] = new BitArray(LeftSideSubkeys[i+1].Cast<bool>().ToArray<bool>().Concat(RightSideSubkeys[i + 1].Cast<bool>().ToArray<bool>()).ToArray<bool>());
                Subkeys[i] = PermutationOperation.Permutate(Subkeys[i], PermutedChoice2);
            }
        }
    }
}
