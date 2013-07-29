using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDR.GameSave.Structs
{
    public class Header
    {
        public Enums.SaveType SaveType { get; set; }
        public bool IsEnced;
        //public bool IsAllowed;
        //public bool IsRDR;
        public int blockCount;
        public Header(System.IO.Stream xSTR)
        {
            if (MemMethods.MemMethods.ReadInt16(xSTR, true) == 0x7777) { this.IsEnced = true; } else { this.IsEnced = false; }
            if (MemMethods.MemMethods.ReadInt16(xSTR, true) == 0xE) { this.SaveType = Enums.SaveType.Multiplayer; } else { this.SaveType = Enums.SaveType.SinglePlayer; }
            this.blockCount = MemMethods.MemMethods.ReadInt32(xSTR, true);
        }
        public void Write(System.IO.Stream xOut)
        {
            if (IsEnced)
            {
                MemMethods.MemMethods.WriteInt16(xOut, 0x7777, true);
            }
            else
            {
                MemMethods.MemMethods.WriteInt16(xOut, 0, true);
            }
            MemMethods.MemMethods.WriteInt16(xOut, (Int16)this.SaveType, true);
            MemMethods.MemMethods.WriteInt32(xOut, blockCount, true);
        }
    }
}
