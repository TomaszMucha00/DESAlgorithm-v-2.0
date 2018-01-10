using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class KeyStandardisation
    {
        //Standardisation to 64 length bit array
        public static BitArray BitArrayStandardisation(BitArray keyBitArray)
        {
            BitArray temp = new BitArray(64);
            if (keyBitArray.Count<64)
            {
                for (int i = 0; i < keyBitArray.Count; i++)
                {
                    temp[i] = keyBitArray[i];
                }
                keyBitArray = temp;
            }
            if (keyBitArray.Count>64)
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
