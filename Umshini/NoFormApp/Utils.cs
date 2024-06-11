using Battle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Part;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapon;

namespace NoFormApp
{
    public class Utils
    {
        /// <summary>
        /// Retrieve an equipment part from a JSON file (Legs / Weapons / Furnace).
        /// Return null if the key name is not equal to Legs, Weapons or Furnace
        /// </summary>
        /// <param name="sKeyName">The key name that access to equipment part</param>
        /// <param name="iEquipment">the index for equipment</param>
        /// <returns>A leg / weapon / furnace part</returns>
        public static IPART GetEquipment(string filePath, string sKeyName, int iEquipment)
        {
            //string filePath = "../../RobotComponents.json";

            string jsonString = File.ReadAllText(filePath);

            JObject parts = JObject.Parse(jsonString);

            if (sKeyName.Equals("Legs"))
            {
                List<Part.LEG> legs = parts[sKeyName].ToObject<List<Part.LEG>>();
                return legs[iEquipment];
            }
            else if (sKeyName.Equals("Weapons"))
            {
                IWEAPON iWeapon = null;
                if(iEquipment == (int)WEAPONS_TYPES.NORMAL)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.NORMAL_WEAPON>();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.MELEE)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.MELEE_WEAPON>();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.PROJECTILE)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.PROJECTILE_WEAPON>();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.THERMAL)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.THERMAL_WEAPON>();
                }
                return iWeapon;
            }
            else if (sKeyName.Equals("Furnace"))
            {
                FURNACE furnace = parts[sKeyName][iEquipment].ToObject<FURNACE>();
                return furnace;
            }

            return null;
        }
    }
}
