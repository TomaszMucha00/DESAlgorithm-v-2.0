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
            DES Des = new DES("TO JEST BARDZO TAJNY KOT", "KOD");
            Console.WriteLine("Encripted message: \n \n" + Des.Encript());
        }
    }
}
