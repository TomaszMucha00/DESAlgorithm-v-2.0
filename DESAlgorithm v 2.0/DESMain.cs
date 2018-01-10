using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm_v_2._0
{
    class DESMain
    {
        BitArray plainTextBitArray;
        BitArray keyBitArray;
        BitArray[] plainText64BitFragments;

        public DESMain(string plainText, string key)
        {
            plainTextBitArray = ConverterStringToByteTable.StringToByteTable(plainText);
            plainTextBitArray = PlainTextStandardisation.BitArrayStandardisation(plainTextBitArray);
            keyBitArray = ConverterStringToByteTable.StringToByteTable(key);
            keyBitArray = KeyStandardisation.BitArrayStandardisation(keyBitArray);
            plainText64BitFragments = new BitArray[keyBitArray.Length/64];
        }

        public string Encript()
        {
            Keys.CreateSubkeys(keyBitArray);
            plainText64BitFragments = PlainTextDivision.Divise(plainTextBitArray, plainText64BitFragments);
            plainText64BitFragments = EncriptPieceByPiece(plainText64BitFragments);
            plainTextBitArray = PlainTextJoin.Join(plainTextBitArray, plainText64BitFragments);
            return BitArrayToStringConverter.ConvertBitArrayToString(plainTextBitArray);
        }

        public static BitArray[] EncriptPieceByPiece(BitArray[] plainText64BitFragments)
        {
            for (int i = 0; i < plainText64BitFragments.Length; i++)
            {
                plainText64BitFragments[i] = _64BitsDesOperation.DES64BitsEncription(plainText64BitFragments[i], Keys.Subkeys);
            }
            return plainText64BitFragments;
        }

        
    }
}
