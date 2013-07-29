using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDR.GameSave.Utils
{
    public class HorseUtils
    {
        public static Enums.HorseType GetHorseTypeFromIndex(int index)
        {
            Array eVals = System.Enum.GetValues(typeof(Enums.HorseType));
            return (Enums.HorseType)eVals.GetValue(index);
        }
        public static int GetHorseIndexFromHorse(Enums.HorseType horseType)
        {
            Array eVals = System.Enum.GetValues(typeof(Enums.HorseType));
            for (int i = 0; i < eVals.Length; i++)
            {
                if ((int)eVals.GetValue(i) == (int)horseType)
                {
                    return i;
                }
            }
            return 0;
        }
    }
    public class LevelUtils
    {
        public static float GetXPFromLevel(int index)
        {
            Array eVals = System.Enum.GetValues(typeof(Enums.Level));
            return Convert.ToSingle(eVals.GetValue(index - 1));
        }
        public static int GetLevelFromXP(float xp)
        {
            Array eVals = System.Enum.GetValues(typeof(Enums.Level));
            for (int i = 0; i < eVals.Length; i++)
            {
                if ((i + 2) > eVals.Length)
                    return i + 1;
                if (Between((int)xp, (int)eVals.GetValue(i), (int)eVals.GetValue(i + 1) - 1))
                {
                    return i + 1;
                }
            }
            return 0;
        }
        private static bool Between(int value, int left, int right)
        {
            return value > (left - 1) && value < (right + 1);
        }
    }
    public class BlockUtils
    {
        public static bool BlockExists(Structs.Body Body, string Name)
        {
            for (int i = 0; i < Body.Blocks.Count; i++)
            {
                if (Body.Blocks[i].Name == Name)
                {
                    return true;
                }
            }
            return false;
        }
        public static Structs.Block GetBlockByName(Structs.Body Body, string Name)
        {
            for (int i = 0; i < Body.Blocks.Count; i++)
            {
                if (Body.Blocks[i].Name == Name)
                {
                    return Body.Blocks[i];
                }
            }
            return null;
        }
    }
}
