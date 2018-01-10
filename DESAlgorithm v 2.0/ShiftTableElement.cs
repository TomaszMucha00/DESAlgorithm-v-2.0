using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class ShiftTableElement
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
    }
}
