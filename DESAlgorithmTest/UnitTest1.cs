using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DESAlgorithmTest
{
    [TestClass]
    public class DESTest
    {
        [TestMethod]
        public void BitArrayPermutateTest()
        {
            BitArray toTest = new BitArray(new bool[] { true, true, true, true, false, false, false, false });
            byte[] permutator = new byte[] { 1, 5, 2, 6, 3, 7, 4, 8 };

            BitArray expected = new BitArray(new bool[] { true, false, true, false, true, false, true, false });
            BitArray actual = DESAlgorithm_v_2._0.MathUtil.BitArrayPermutate(toTest,permutator);

            for (int i = 0; i < toTest.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }           
        }

        [TestMethod]
        public void SBoxSubstitutionTest()
        {
            BitArray toTest = new BitArray(new bool[] { true, true, true, true, true, true,
                                                        true, true, true, true, true, true,
                                                        true, true, true, true, true, true,
                                                        false, false, true, true, false, false,
                                                        false, false, true, true, false, false,
                                                        false, false, true, true, false, false,
                                                        true, true, true, false, false, false,
                                                        true, true, true, false, false, false });

            BitArray actual = DESAlgorithm_v_2._0.Sbox.SBoxSubstitution(toTest);

            BitArray expected = new BitArray(new bool[] {true, true, false, true,
                                                         true, false, false, true,
                                                         true, true, false, false,
                                                         true, false, false, true,
                                                         true, false, true, true,
                                                         false, true, true, false,
                                                         false, false, false, false,
                                                         true, true, true, true});

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i],expected[i]);
            }
        }

        [TestMethod]
        public void ReverseBitArrayInitTest()
        {
            byte[] toTest = { 1, 2, 3, 4, 5 };

            BitArray expected = new BitArray(new bool[] {false,false,false,false,false,false,false,true,
                                                         false,false,false,false,false,false,true,false,
                                                         false,false,false,false,false,false,true,true,
                                                         false,false,false,false,false,true,false,false,
                                                         false,false,false,false,false,true,false,true,});

            BitArray actual = DESAlgorithm_v_2._0.BitArrayOperation.ReverseBitArrayInit(toTest);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}
