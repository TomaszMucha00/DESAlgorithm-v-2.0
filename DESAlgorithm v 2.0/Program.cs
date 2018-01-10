using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            DESMain Des = new DESMain("KOT", "0001001100110100010101110111100110011011101111001101111111110001");
            Console.WriteLine(Des.Encript());
        }
    }
}
