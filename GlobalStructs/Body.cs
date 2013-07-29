using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDR.GameSave.Structs
{
    public class Body
    {
        public List<Block> Blocks;
        public void Write(System.IO.Stream xOut, Header Header, byte[] key)
        {
            List<byte> ByteList = new List<byte>();

            if (Header.IsEnced)
            {

                for (int i = 0; i < Blocks.Count; i++)
                {
                    byte[] nameLengthBuff = BitConverter.GetBytes(Blocks[i].Name.Length);
                    byte[] nameBuff = System.Text.Encoding.GetEncoding(1252).GetBytes(Blocks[i].Name);
                    byte[] byteLengthbuff = BitConverter.GetBytes(Blocks[i].Buffer.Length);
                    Array.Reverse(nameLengthBuff);
                    Array.Reverse(byteLengthbuff);
                    ByteList.AddRange(nameLengthBuff);
                    ByteList.AddRange(nameBuff);

                    ByteList.Add(1);
                    ByteList.AddRange(byteLengthbuff);
                    ByteList.AddRange(Blocks[i].Buffer);
                }


                byte[] Enced = Methods.AES.encryptAES(ByteList.ToArray(), key);

                if (Enced.Length > 0)
                {
                    xOut.Write(Enced, 0, Enced.Length);
                }

            }
            else
            {
                for (int i = 0; i < Blocks.Count; i++)
                {
                    byte[] nameLengthBuff = BitConverter.GetBytes(Blocks[i].Name.Length);
                    byte[] nameBuff = System.Text.Encoding.GetEncoding(1252).GetBytes(Blocks[i].Name);
                    byte[] byteLengthbuff = BitConverter.GetBytes(Blocks[i].Buffer.Length);
                    Array.Reverse(nameLengthBuff);
                    Array.Reverse(byteLengthbuff);

                    ByteList.AddRange(nameLengthBuff);
                    ByteList.AddRange(nameBuff);

                    ByteList.Add(1);
                    ByteList.AddRange(byteLengthbuff);
                    ByteList.AddRange(Blocks[i].Buffer);
                }
                xOut.Write(ByteList.ToArray(), 0, ByteList.ToArray().Length);
            }
        }
        public Body(System.IO.Stream xIn, Header Header, byte[] key)
        {
            this.Blocks = new List<Block>();
            if (Header.IsEnced)
            {
                System.IO.MemoryStream xMem;
                byte[] xBuf = new byte[xIn.Length - 8];
                xIn.Position = 8;
                xIn.Read(xBuf, 0, xBuf.Length);

                byte[] xBufX = Methods.AES.decryptAES(xBuf, key);
                xMem = new System.IO.MemoryStream(Methods.AES.decryptAES(xBuf, key));
                xMem.Position = 0;
                for (int i = 0; i < Header.blockCount; i++)
                {
                    Int32 nameL = MemMethods.MemMethods.ReadInt32(xMem, true);
                    string name = MemMethods.MemMethods.Readstring(xMem, nameL);

                    int unkBool = xMem.ReadByte();
                    Int32 bufferSize = MemMethods.MemMethods.ReadInt32(xMem, true);
                    byte[] buffer = new byte[bufferSize];
                    xMem.Read(buffer, 0, buffer.Length);

                    if (unkBool > 0)
                    {
                        Structs.Block xBlock = new Structs.Block(name, buffer);
                        this.Blocks.Add(xBlock);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Header.blockCount; i++)
                {
                    Int32 nameL = MemMethods.MemMethods.ReadInt32(xIn, true);
                    string name = MemMethods.MemMethods.Readstring(xIn, nameL);
                    int unkBool = xIn.ReadByte();
                    Int32 bufferSize = MemMethods.MemMethods.ReadInt32(xIn, true);
                    byte[] buffer = new byte[bufferSize];
                    xIn.Read(buffer, 0, buffer.Length);
                    Structs.Block xBlock = new Structs.Block(name, buffer);
                    this.Blocks.Add(xBlock);
                }
            }
        }
    }
}
