using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDR.GameSave.Utils;
namespace RDR.GameSave.Structs.MultiPlayer
{
    public class GoldenWeapons
    {
        public Int32[] GoldWeaps;
        public bool UnlockAll = false;
        public System.IO.MemoryStream GoldWeapStream;
        public GoldenWeapons(Body body)
        {
            this.GoldWeaps = new Int32[40];
            this.GoldWeapStream = new System.IO.MemoryStream();
            BlockUtils.GetBlockByName(body, "gMP_GoldenWeapon").ExtractToStream(GoldWeapStream);
            Int32 boolCount = MemMethods.MemMethods.ReadInt32(GoldWeapStream, true);
            for (int i = 0; i < boolCount; i++)
            {
                GoldWeaps[i] = MemMethods.MemMethods.ReadInt32(GoldWeapStream, true);
            }
        }
        public void Write(Body body)
        {
            GoldWeapStream.SetLength(0);
            MemMethods.MemMethods.WriteInt32(GoldWeapStream, GoldWeaps.Length, true);
            for (int i = 0; i < GoldWeaps.Length; i++)
            {
                if (UnlockAll)
                {
                    MemMethods.MemMethods.WriteInt32(GoldWeapStream, 1, true);
                }
                else
                {
                    MemMethods.MemMethods.WriteInt32(GoldWeapStream, 0, true);
                }
            }
        }
    }
}
