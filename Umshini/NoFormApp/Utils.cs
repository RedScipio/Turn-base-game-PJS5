using Battle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Part;
using Robot;
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

        /// <summary>
        /// Go through a JSON file, pick robot components 
        /// and procedurally generate a robot following the game's rules 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>A robot procedurally made</returns>
        public static IROBOT GetProceduralRobot(string filePath)
        {
            
            string sJsonString = File.ReadAllText(filePath);

            JObject parts = JObject.Parse(sJsonString);

            int iLengthWeapons = parts["Weapons"].ToList().Count();
            int iLengthLegs = parts["Legs"].ToList().Count();
            int iLengthFurnaces = parts["Furnaces"].ToList().Count();

            Random random = new Random();

            int iWeapon_1 = random.Next(0, iLengthWeapons);
            int iWeapon_2 = random.Next(0, iLengthWeapons);
            int iLegs = random.Next(0, iLengthLegs - 1);
            int iFurnaces = random.Next(0, iLengthFurnaces - 1);
            Console.WriteLine("2 : " + iWeapon_2 + " 1 : " + iWeapon_1 + " L : " + iLegs + " F : " + iFurnaces);
            

            IFURNACE furnaceRobot = parts["Furnaces"][iFurnaces].ToObject<FURNACE>();
            ILEG legsRobot = parts["Legs"][iLegs].ToObject<LEG>();

            IWEAPON pWeapon_1 = GetWeapon(parts, iWeapon_1);
            IWEAPON pWeapon_2 = GetWeapon(parts, iWeapon_2);
            return new ROBOT(furnaceRobot, legsRobot, pWeapon_1, pWeapon_2);
        }

        /// <summary>
        /// Pick a weapon from a JSON file ()
        /// </summary>
        /// <param name="jObject">la liste d'objets</param>
        /// <param name="iWeaponChoice">Le choix de l'arme</param>
        /// <returns>A normal / melee / 
        /// projectile / thermal weapon</returns>
        /// <exception cref="Exception"></exception>
        private static IWEAPON GetWeapon(JObject jWeaponsList, int iWeaponChoice)
        {
            int iWeaponTypeChoice = jWeaponsList["Weapons"][iWeaponChoice]["weapon_type"].Value<int>();

            IWEAPON pWeap = null;

            if (iWeaponTypeChoice == 0)
            {
                pWeap = jWeaponsList["Weapons"][iWeaponChoice].ToObject<NORMAL_WEAPON>();
            }
            else if (iWeaponTypeChoice == 1)
            {
                pWeap = jWeaponsList["Weapons"][iWeaponChoice].ToObject<MELEE_WEAPON>();
            }
            else if (iWeaponTypeChoice == 2)
            {
                pWeap = jWeaponsList["Weapons"][iWeaponChoice].ToObject<PROJECTILE_WEAPON>();
            }
            else if(iWeaponTypeChoice == 3)
            {
                pWeap = jWeaponsList["Weapons"][iWeaponChoice].ToObject<THERMAL_WEAPON>();
            }
            else
            {
                throw new Exception("Arme inexistante");
            }

            return pWeap;
        }
    }

    
}
