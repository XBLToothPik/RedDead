using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDR.GameSave.Utils;
namespace RDR.GameSave.Structs.MultiPlayer
{
    public class Stats
    {

        public Single XP;
        public Int32 Prestige;

        public System.IO.MemoryStream StatStream;
        public System.IO.MemoryStream UnlockStream;

        public Stats(Body Body)
        {
            this.StatStream = new System.IO.MemoryStream();
            this.UnlockStream = new System.IO.MemoryStream();

            BlockUtils.GetBlockByName(Body, "gRDR2_Stats").ExtractToStream(StatStream);
            BlockUtils.GetBlockByName(Body, "MP_UNLOCKDATA").ExtractToStream(UnlockStream);


            //Reading XP
            StatStream.Position = 0x7A1;
            XP = MemMethods.MemMethods.ReadFloat(StatStream, false);

            //Reading Prestige
            UnlockStream.Position = 0x2C4;
            Prestige = MemMethods.MemMethods.ReadInt32(UnlockStream, true);


        }
        public void Write(Body Body, System.IO.Stream statStream)
        {
            //Writing XP
            statStream.Position = 0x7A1;
            MemMethods.MemMethods.WriteFloat(statStream, XP, false);

            //Writing Prestige
            UnlockStream.Position = 0x2C4;
            MemMethods.MemMethods.WriteInt32(UnlockStream, Prestige - 1, true);

            BlockUtils.GetBlockByName(Body, "gRDR2_Stats").ReplaceWithStream(StatStream);
            BlockUtils.GetBlockByName(Body, "MP_UNLOCKDATA").ReplaceWithStream(UnlockStream);

        }

    }
}
