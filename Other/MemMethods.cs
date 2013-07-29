using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemMethods
{
    public static class MemMethods
    {
        public static Int32 ReadInt32(System.IO.Stream xSTR, bool rev){
            byte[] xBuf = new byte[4];
            xSTR.Read(xBuf, 0, 4);
            if (rev) { Array.Reverse(xBuf); }
            return BitConverter.ToInt32(xBuf, 0);
        }
        public static UInt32 ReadUInt32(System.IO.Stream xSTR, bool rev){
            byte[] xBuf = new byte[4];
            xSTR.Read(xBuf, 0, 4);
            if (rev) { Array.Reverse(xBuf); }
            return BitConverter.ToUInt32(xBuf, 0);
        }
        public static UInt64 ReadUInt64(System.IO.Stream xSTR, bool rev){
            byte[] xBuf = new byte[8];
            xSTR.Read(xBuf, 0, 8);
            if (rev) { Array.Reverse(xBuf); }
            return BitConverter.ToUInt64(xBuf, 0);
        }
        public static short ReadInt16(System.IO.Stream xSTR, bool rev){
            byte[] buffer = new byte[2];
            xSTR.Read(buffer, 0, buffer.Length);
            if (rev) { Array.Reverse(buffer); }
            return BitConverter.ToInt16(buffer, 0);
        }
        public static Int64 ReadInt64(System.IO.Stream xSTR, bool rev){
            byte[] xBuf = new byte[8];
            xSTR.Read(xBuf, 0, 8);
            if (rev) { Array.Reverse(xBuf); }
            return BitConverter.ToInt64(xBuf, 0);
        }
        public static float ReadFloat(System.IO.Stream xSTR, bool rev){
            byte[] xBuf = new byte[4];
            xSTR.Read(xBuf, 0, 4);
            if (rev) { Array.Reverse(xBuf); }
            return BitConverter.ToSingle(xBuf, 0);
        }
        public static bool ReadBoolean(System.IO.Stream xSTR)
        {
            return Convert.ToBoolean(xSTR.ReadByte());
        }
        public static String Readstring(System.IO.Stream xSTR, int length){

            byte[] tBytes = new byte[length];
            xSTR.Read(tBytes, 0, tBytes.Length);
            return System.Text.Encoding.GetEncoding(1252).GetString(tBytes);
        }
        public static void WriteInt32(System.IO.Stream xSTR, Int32 val, bool rev)
        {
            byte[] xBuf = BitConverter.GetBytes(val);
            if (rev) { Array.Reverse(xBuf); }
            xSTR.Write(xBuf, 0, 4);
        }
        public static void WriteFloat(System.IO.Stream xSTR, Single Val, bool rev)
        {
            byte[] xBuf = BitConverter.GetBytes(Val);
            if (rev) { Array.Reverse(xBuf); }
            xSTR.Write(xBuf, 0, xBuf.Length);
        }
        public static void WriteInt16(System.IO.Stream xSTR, short val, bool rev)
        {
            byte[] xBuf = BitConverter.GetBytes(val);
            if (rev) { Array.Reverse(xBuf); }
            xSTR.Write(xBuf, 0, xBuf.Length);
        }
      

    }
}
