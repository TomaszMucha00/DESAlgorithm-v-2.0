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
            int counter = 0;
            foreach (var BitArrayElement in toConvert)
            {
                if (counter%64==0&&counter!=0)
                {
                    toReturn += "\n";
                }
                toReturn += Convert.ToInt32(BitArrayElement).ToString();
                counter++;
            }
            return toReturn;
        }
    }
}
