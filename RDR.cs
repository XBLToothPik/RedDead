using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
namespace RDR.GameSave
{
    public class RDR
    {
        //#FuckIt#Yolo#EncryptionKeyInPlainSight
        private readonly Byte[] Key = { 0xB7, 0x62, 0xDF, 0xB6, 0xE2, 0xB2, 0xC6, 0xDE, 0xAF, 0x72, 0x2A, 0x32, 0xD2, 0xFB, 0x6F, 0x0C, 0x98, 0xA3, 0x21, 0x74, 0x62, 0xC9, 0xC4, 0xED, 0xAD, 0xAA, 0x2E, 0xD0, 0xDD, 0xF9, 0x2F, 0x10 };
        public Structs.Header Header;
        public Structs.Body Body;
        public Structs.MultiPlayer.Character mpCharacter;
        public GameSave.Structs.SinglePlayer.Character spCharacter;
        public bool EditSave = true;
        public RDR(System.IO.Stream xIn)
        {
            this.Header = new Structs.Header(xIn);
            this.Body = new Structs.Body(xIn, this.Header, this.Key);

            if (Header.SaveType == Enums.SaveType.Multiplayer)
            {

                this.mpCharacter = new Structs.MultiPlayer.Character(this.Body);
            }
            else
            {
                this.spCharacter = new Structs.SinglePlayer.Character(this.Body);
            }
        }
        public void Write(System.IO.Stream xOut)
        {
            this.Header.blockCount = Body.Blocks.Count;
            this.Header.Write(xOut);

            if (this.Header.SaveType == Enums.SaveType.Multiplayer)
            {
                if (EditSave)
                {
                    this.mpCharacter.Write(this.Body);
                }
            }
            else
            {
                if (EditSave)
                {
                    this.spCharacter.Write(this.Body);
                }
            }
            this.Body.Write(xOut, this.Header, this.Key);
            xOut.Flush();
        }
    }

}
