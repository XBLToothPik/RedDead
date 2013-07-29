using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDR.GameSave.Utils;
namespace RDR.GameSave.Structs.SinglePlayer
{
    public class Stats
    {
        private System.IO.MemoryStream StatStream { get; set; }
        public float AnimalsKilled { get; set; }
        public float Money { get; set; }

        public Stats(Body body)
        {
            this.StatStream = new System.IO.MemoryStream();
            BlockUtils.GetBlockByName(body, "gRDR2_Stats").ExtractToStream(StatStream);

            //Reading Money
            this.StatStream.Position = 0x4;
            this.Money = MemMethods.MemMethods.ReadFloat(StatStream, true);

            //Reading Animals Killed
            this.StatStream.Position = 0x6C;
            this.AnimalsKilled = MemMethods.MemMethods.ReadFloat(StatStream, true);

        }
        public void Write(Body body)
        {
            //Writing money
            this.StatStream.Position = 0x4;
            MemMethods.MemMethods.WriteFloat(StatStream, this.Money, true);

            //Writing animals killed
            this.StatStream.Position = 0x6C;
            MemMethods.MemMethods.WriteFloat(StatStream, this.AnimalsKilled, true);

            BlockUtils.GetBlockByName(body, "gRDR2_Stats").ReplaceWithStream(this.StatStream);
        }
    }
}
