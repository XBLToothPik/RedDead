using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDR.GameSave.Structs.SinglePlayer
{
    public class Character
    {

        public Stats Stats { get; set; }
        public Mount Mount { get; set; }
        public Character(Body body)
        {
            //Reading
            this.Stats = new Stats(body);
            this.Mount = new Mount(body);
        }
        public void Write(Body body)
        {
            //Writing 
            Stats.Write(body);
            Mount.Write(body);
        }
    }
}
