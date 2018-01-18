using System.Collections;

namespace DESAlgorithm_v_2._0
{
    class DES
    {
        BitArray plainTextBitArray;
        BitArray keyBitArray;
        BitArray[] plainText64BitFragments;
        BitArray[] subkeys;

        public DES(string plainText, string key)
        {

            plainTextBitArray = StringToBitArray.Convert(plainText);
            plainTextBitArray = PlainTextOperation.Standardisation(plainTextBitArray);
            keyBitArray = StringToBitArray.Convert(key);
            keyBitArray = KeysOperations.Standardisation(keyBitArray);
            plainText64BitFragments = new BitArray[plainTextBitArray.Length/64];
            subkeys = KeysOperations.CreateSubkeys(keyBitArray);
        }

        public string Encript()
        {
            plainText64BitFragments = PlainTextOperation.Divise(plainTextBitArray, plainText64BitFragments);
            plainText64BitFragments = EncriptBitArray(plainText64BitFragments, subkeys);
            plainTextBitArray = PlainTextOperation.Join(plainTextBitArray, plainText64BitFragments);
            return BitArrayToString.Convert(plainTextBitArray);
        }

        private static BitArray[] EncriptBitArray(BitArray[] plainText64BitFragments, BitArray[] subkeys)
        {
            for (int i = 0; i < plainText64BitFragments.Length; i++)
            {
                plainText64BitFragments[i] = _64BitsDesOperation.DES64BitsEncription(plainText64BitFragments[i], subkeys);
            }
            return plainText64BitFragments;
        }

        
    }
}
