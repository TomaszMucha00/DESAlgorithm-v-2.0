using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class BitArrayOperation
    {
        public static BitArray ShiftElement(BitArray toShift, int howMuch)
        {
            
            int counter = 0;
            bool temp = false;
            BitArray tempBitArray = new BitArray(toShift.Length);
            for (int i = 0; i < toShift.Length; i++)
            {
                tempBitArray[i] = toShift[i];
            }
            do
            {
                counter++;
                temp = tempBitArray[0];
                for (int i = 0; i < tempBitArray.Length - 1; i++)
                {
                    tempBitArray[i] = tempBitArray[i + 1];
                }
                tempBitArray[toShift.Length - 1] = temp;
            } while (counter != howMuch);
            return tempBitArray;
        }


        public static BitArray ReverseBitArrayInit(byte[] toReverse)
        {
            string[] toReverseStringTab = new string[toReverse.Length];
            for (int i = 0; i < toReverse.Length; i++)
            {
                toReverseStringTab[i] = Convert.ToString(toReverse[i], 2).PadLeft(8,'0');
            }
            for (int i = 0; i < toReverseStringTab.Length; i++)
            {
                toReverseStringTab[i] = new String(toReverseStringTab[i].Reverse().ToArray<char>());
            }
            byte[] toReverseByteTab = new byte[toReverseStringTab.Length];
            for (int i = 0; i < toReverseStringTab.Length; i++)
            {
                toReverseByteTab[i] = Convert.ToByte(toReverseStringTab[i], 2);
            }
            return new BitArray(toReverseByteTab);
        }

        public static BitArray ReverseBitArrayInitPadingToFor(byte[] toReverse)
        {
            string[] toReverseStringTab = new string[toReverse.Length/2];
            for (int i = 0; i < toReverse.Length; i+=2)
            {
                toReverseStringTab[i/2] = Convert.ToString(toReverse[i], 2).PadLeft(4, '0')+ Convert.ToString(toReverse[i+1], 2).PadLeft(4, '0');
            }
            for (int i = 0; i < toReverseStringTab.Length; i++)
            {
                toReverseStringTab[i] = new String(toReverseStringTab[i].Reverse().ToArray<char>());
            }
            byte[] toReverseByteTab = new byte[toReverseStringTab.Length];
            for (int i = 0; i < toReverseStringTab.Length; i++)
            {
                toReverseByteTab[i] = Convert.ToByte(toReverseStringTab[i], 2);
            }
            return new BitArray(toReverseByteTab);
        }
    }
}
