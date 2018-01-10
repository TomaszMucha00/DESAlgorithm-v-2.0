using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class ConverterStringToByteTable
    {
        public static BitArray StringToByteTable(string plainTextString)
        {
            byte[] plainTextByteArray = Encoding.UTF8.GetBytes(plainTextString);
            BitArray PlainTextBitArray = new BitArray(plainTextByteArray);
            return PlainTextBitArray;
        }
    }
}
