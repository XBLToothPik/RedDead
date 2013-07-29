using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RDR.GameSave.Utils;
namespace RDR.GameSave.Structs.MultiPlayer
{
    public class Character
    {
        public Stats Stats { get; set; }
        public GoldenWeapons GoldWeaps { get; set; }
        public Mount Mount { get; set; }
        public Character(Body Body)
        {
            this.Stats = new Stats(Body);
            this.GoldWeaps = new GoldenWeapons(Body);
            this.Mount = new Mount(Body);
        }
        public void Write(Body Body)
        {
            Stats.Write(Body, Stats.StatStream);
            GoldWeaps.Write(Body);
            Mount.Write(Body);
            BlockUtils.GetBlockByName(Body, "gMP_GoldenWeapon").ReplaceWithStream(GoldWeaps.GoldWeapStream);
        }
    }
}
