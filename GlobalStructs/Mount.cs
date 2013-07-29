using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDR.GameSave.Utils;
namespace RDR.GameSave.Structs
{
    public class Mount
    {
        private System.IO.MemoryStream MountStream;
        public Enums.HorseType Horse;
        public string HorseName { get; set; }
        public Mount(Body body)
        {
            this.MountStream = new System.IO.MemoryStream();
            BlockUtils.GetBlockByName(body, "gMP_SavedHorseAEName").ExtractToStream(MountStream);
            MountStream.Position = 0;
            bool xTrue = true;
            string cBuilt = string.Empty;
            while (xTrue)
            {
                int xInt = MountStream.ReadByte();

                if (!(xInt == 0))
                {
                    cBuilt += Convert.ToChar(xInt);
                }
                else { xTrue = false; }
            }

            #region "Reading Horse"
            HorseName = cBuilt;
            switch (cBuilt)
            {

                case "RIDABLE_ANIMAL_HorseDead01":
                    this.Horse = Enums.HorseType.DeadHorse;
                    break;
                case "RIDEABLE_ANIMAL_HorseMangy01":
                    this.Horse = Enums.HorseType.LusitioNag;
                    break;
                case "RIDEABLE_ANIMAL_MEX_Mule01":
                    this.Horse = Enums.HorseType.ElSenor;
                    break;
                case "RIDEABLE_ANIMAL_Horse01":
                    this.Horse = Enums.HorseType.ClevelandBay;
                    break;
                case "RIDEABLE_ANIMAL_Horse02":
                    this.Horse = Enums.HorseType.PaintedQuarterHorse;
                    break;
                case "RIDEABLE_ANIMAL_Horse03":
                    this.Horse = Enums.HorseType.KentuckySaddler;
                    break;
                case "RIDEABLE_ANIMAL_Horse04":
                    this.Horse = Enums.HorseType.AmericanStandardBread;
                    break;
                case "RIDEABLE_ANIMAL_Horse05":
                    this.Horse = Enums.HorseType.StandardbredPinto;
                    break;
                case "RIDEABLE_ANIMAL_Horse06":
                    this.Horse = Enums.HorseType.PaintedStandardBred;
                    break;
                case "RIDEABLE_ANIMAL_Horse07":
                    this.Horse = Enums.HorseType.HungarianHalfBred;
                    break;
                case "RIDEABLE_ANIMAL_Horse08":
                    this.Horse = Enums.HorseType.HighlandChestnut;
                    break;
                case "RIDEABLE_ANIMAL_Horse09":
                    this.Horse = Enums.HorseType.QuarterHorse;
                    break;
                case "RIDEABLE_ANIMAL_Horse10":
                    this.Horse = Enums.HorseType.WelshMountain;
                    break;
                case "RIDEABLE_ANIMAL_Horse11":
                    this.Horse = Enums.HorseType.DutchWarmblood;
                    break;
                case "RIDEABLE_ANIMAL_Horse12":
                    this.Horse = Enums.HorseType.Turkmen;
                    break;
                case "RIDEABLE_ANIMAL_Horse13":
                    this.Horse = Enums.HorseType.TobianoPinto;
                    break;
                case "RIDEABLE_ANIMAL_Horse14":
                    this.Horse = Enums.HorseType.Lustiano;
                    break;
                case "RIDEABLE_ANIMAL_Horse15":
                    this.Horse = Enums.HorseType.Ardennais;
                    break;
                case "RIDEABLE_ANIMAL_Horse16":
                    this.Horse = Enums.HorseType.Tersk;
                    break;
                case "RIDEABLE_ANIMAL_Horse17":
                    this.Horse = Enums.HorseType.WarHorse;
                    break;
                case "RIDEABLE_ANIMAL_Horse18":
                    this.Horse = Enums.HorseType.DarkHorse;
                    break;
                case "RIDEABLE_ANIMAL_HorseMale01":
                    this.Horse = Enums.HorseType.MaleHorse;
                    break;
                case "RIDEABLE_ANIMAL_MEX_Mule02":
                    this.Horse = Enums.HorseType.ElHedor;
                    break;
                case "RIDEABLE_ANIMAL_MEX_Mule03":
                    this.Horse = Enums.HorseType.ElPicor;
                    break;
                case "RIDEABLE_ANIMAL_MEX_Mule04":
                    this.Horse = Enums.HorseType.ZebraDonkey;
                    break;
            }
            #endregion

        }
        public void Write(Body body)
        {
            System.IO.MemoryStream mountSTR = new System.IO.MemoryStream();
            #region "Writing Horse"
            switch (Horse)
            {
                //Writing horse name
                case Enums.HorseType.DeadHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDABLE_ANIMAL_HorseDead01"), 0, "RIDABLE_ANIMAL_HorseDead01".Length);
                    break;
                case Enums.HorseType.LusitioNag:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_HorseMangy01"), 0, "RIDEABLE_ANIMAL_HorseMangy01".Length);
                    break;
                case Enums.HorseType.DarkHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse18"), 0, "RIDEABLE_ANIMAL_Horse18".Length);
                    break;
                case Enums.HorseType.ElSenor:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_MEX_Mule01"), 0, "RIDEABLE_ANIMAL_MEX_Mule01".Length);
                    break;
                case Enums.HorseType.WarHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse17"), 0, "RIDEABLE_ANIMAL_Horse17".Length);
                    break;
                case Enums.HorseType.ClevelandBay:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse01"), 0, "RIDEABLE_ANIMAL_Horse01".Length);
                    break;
                case Enums.HorseType.PaintedQuarterHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse02"), 0, "RIDEABLE_ANIMAL_Horse02".Length);
                    break;
                case Enums.HorseType.KentuckySaddler:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse03"), 0, "RIDEABLE_ANIMAL_Horse03".Length);
                    break;
                case Enums.HorseType.AmericanStandardBread:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse04"), 0, "RIDEABLE_ANIMAL_Horse04".Length);
                    break;
                case Enums.HorseType.StandardbredPinto:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse05"), 0, "RIDEABLE_ANIMAL_Horse05".Length);
                    break;
                case Enums.HorseType.PaintedStandardBred:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse06"), 0, "RIDEABLE_ANIMAL_Horse06".Length);
                    break;
                case Enums.HorseType.HungarianHalfBred:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse07"), 0, "RIDEABLE_ANIMAL_Horse07".Length);
                    break;
                case Enums.HorseType.HighlandChestnut:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse08"), 0, "RIDEABLE_ANIMAL_Horse08".Length);
                    break;
                case Enums.HorseType.QuarterHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse09"), 0, "RIDEABLE_ANIMAL_Horse09".Length);
                    break;
                case Enums.HorseType.WelshMountain:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse10"), 0, "RIDEABLE_ANIMAL_Horse10".Length);
                    break;
                case Enums.HorseType.DutchWarmblood:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse11"), 0, "RIDEABLE_ANIMAL_Horse11".Length);
                    break;
                case Enums.HorseType.Turkmen:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse12"), 0, "RIDEABLE_ANIMAL_Horse12".Length);
                    break;
                case Enums.HorseType.TobianoPinto:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse13"), 0, "RIDEABLE_ANIMAL_Horse13".Length);
                    break;
                case Enums.HorseType.Lustiano:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse14"), 0, "RIDEABLE_ANIMAL_Horse14".Length);
                    break;
                case Enums.HorseType.Ardennais:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse15"), 0, "RIDEABLE_ANIMAL_Horse15".Length);
                    break;
                case Enums.HorseType.Tersk:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_Horse16"), 0, "RIDEABLE_ANIMAL_Horse16".Length);
                    break;
                case Enums.HorseType.MaleHorse:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_HorseMale01"), 0, "RIDEABLE_ANIMAL_HorseMale01".Length);
                    break;
                case Enums.HorseType.ElHedor:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_MEX_Mule01"), 0, "RIDEABLE_ANIMAL_MEX_Mule01".Length);
                    break;
                case Enums.HorseType.ElPicor:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_MEX_Mule03"), 0, "RIDEABLE_ANIMAL_MEX_Mule03".Length);
                    break;
                case Enums.HorseType.ZebraDonkey:
                    mountSTR.Write(System.Text.Encoding.GetEncoding(1252).GetBytes("RIDEABLE_ANIMAL_MEX_Mule04"), 0, "RIDEABLE_ANIMAL_MEX_Mule04".Length);
                    break;
            }

            #endregion
            while (mountSTR.Length < 64)
            {
                mountSTR.Write(new byte[] { (byte)0 }, 0, 1);
            }
            BlockUtils.GetBlockByName(body, "gMP_SavedHorseAEName").ReplaceWithStream(mountSTR);
        }
    }
}
