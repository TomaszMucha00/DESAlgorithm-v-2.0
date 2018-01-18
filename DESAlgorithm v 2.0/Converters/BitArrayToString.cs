using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    internal static class BitArrayToString
    {
        public static string Convert(BitArray toConvert)
        {
            string toReturn = "";
            int counter = 0;
            foreach (var BitArrayElement in toConvert)
            {
                if (counter % 64 == 0 && counter != 0)
                {
                    toReturn += "\n";
                }
                toReturn += System.Convert.ToInt32(BitArrayElement).ToString();
                counter++;
            }
            return toReturn;
        }

    }
}
