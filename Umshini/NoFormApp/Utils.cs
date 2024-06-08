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
        public static IPART GetEquipment(string sKeyName, int iEquipment)
        {
            string filePath = "../../RobotComponents.json";

            string jsonString = File.ReadAllText(filePath);

            JObject parts = JObject.Parse(jsonString);

            Console.WriteLine(parts);
            Console.ReadLine();

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
                    Console.WriteLine(iWeapon.GetLife());
                    Console.ReadLine();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.MELEE)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.MELEE_WEAPON>();
                    Console.WriteLine(iWeapon.GetLife());
                    Console.ReadLine();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.PROJECTILE)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.PROJECTILE_WEAPON>();
                    Console.WriteLine(iWeapon.GetLife());
                    Console.ReadLine();
                }
                else if(iEquipment == (int)WEAPONS_TYPES.THERMAL)
                {
                    iWeapon = parts[sKeyName][iEquipment].ToObject<Weapon.THERMAL_WEAPON>();
                    Console.WriteLine(iWeapon.GetLife());
                    Console.ReadLine();
                }
                return iWeapon;
            }
            else if (sKeyName.Equals("Furnace"))
            {
                FURNACE furnace = parts[sKeyName][iEquipment].ToObject<FURNACE>();
                Console.WriteLine(furnace.GetLife());
                Console.ReadLine();
                return furnace;
            }

            return null;
        }
    }
}
