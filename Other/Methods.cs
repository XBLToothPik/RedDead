using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
namespace Methods
{
    public class Hashes
    {
        public static int ComputeHash(string STRData)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;
                byte[] data = System.Text.Encoding.GetEncoding(1252).GetBytes(STRData);
                for (int i = 0; i < data.Length; i++)
                    hash = (hash ^ data[i]) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }

    }
    public class AES
    {
        public static byte[] decryptAES(byte[] dataIn, byte[] key)
        {
            byte[] data = new byte[dataIn.Length];
            dataIn.CopyTo(data, 0);

            // Create our Rijndael class
            Rijndael rj = Rijndael.Create();
            rj.BlockSize = 128;
            rj.KeySize = 256;
            rj.Mode = CipherMode.ECB;
            rj.Key = key;
            rj.IV = new byte[16];
            rj.Padding = PaddingMode.None;

            ICryptoTransform transform = rj.CreateDecryptor();

            int dataLen = data.Length & ~0x0F;

            if (dataLen > 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    transform.TransformBlock(data, 0, dataLen, data, 0);
                }
            }

            return data;
        }
        public static byte[] encryptAES(byte[] dataIn, byte[] key)
        {
            byte[] data = new byte[dataIn.Length];
            dataIn.CopyTo(data, 0);

            // Create our Rijndael class
            Rijndael rj = Rijndael.Create();
            rj.BlockSize = 128;
            rj.KeySize = 256;
            rj.Mode = CipherMode.ECB;
            rj.Key = key;
            rj.IV = new byte[16];
            rj.Padding = PaddingMode.None;

            ICryptoTransform transform = rj.CreateEncryptor();

            int dataLen = data.Length & ~0x0F;

            if (dataLen > 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    transform.TransformBlock(data, 0, dataLen, data, 0);
                }
            }

            return data;
        }

    }
    public class Conversions
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern Int64 StrFormatByteSize(Int64 fileSize, [MarshalAs(UnmanagedType.LPTStr)]
StringBuilder buffer, Int32 bufferSize);
        public static string friendly_size(Int64 size)
        {
            StringBuilder builder = new StringBuilder(0x100);
            StrFormatByteSize(size, builder, 0x100);
            return builder.ToString();
        }

        public static byte[] ParseHexString(string text)
        {
            if ((text.Length % 2) != 0)
            {
                text += "0";

            }

            if (text.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
            {
                text = text.Substring(2);
            }

            int arrayLength = text.Length / 2;
            byte[] byteArray = new byte[arrayLength];



            for (int i = 0; i <= arrayLength - 1; i++)
            {
                byteArray[i] = byte.Parse(text.Substring(i * 2, 2), NumberStyles.HexNumber);


                if (i == arrayLength)
                {
                    return byteArray;

                }
            }

            return byteArray;
        }
    }
}
