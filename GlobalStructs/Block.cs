using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDR.GameSave.Structs
{
    public class Block
    {
        public string Name;
        public byte[] Buffer;
        public Block(string Name, byte[] Buffer)
        {
            this.Name = Name;
            this.Buffer = Buffer;
        }
        public void ExtractToStream(System.IO.Stream xOut)
        {
            xOut.Write(this.Buffer, 0, this.Buffer.Length);
            xOut.Position = 0;
        }
        public void ReplaceWithStream(System.IO.Stream xIn)
        {
            xIn.Position = 0;
            byte[] replaceBuf = new byte[xIn.Length];
            xIn.Read(replaceBuf, 0, replaceBuf.Length);
            this.Buffer = replaceBuf;
            replaceBuf = null;
        }
    }
}
