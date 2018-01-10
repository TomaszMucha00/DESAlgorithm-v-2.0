using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal class BitArrayToStringConverter
    {
        public static string ConvertBitArrayToString(BitArray toConvert)
        {
            string toReturn = "";
            foreach (var BitArrayElement in toConvert)
            {
                toReturn += Convert.ToInt32(BitArrayElement).ToString();
            }
            return toReturn;
        }
    }
}
