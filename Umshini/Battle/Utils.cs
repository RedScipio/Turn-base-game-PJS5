using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    public class Utils
    {
        public static IPART GetEquipment(string sKeyName, int iEquipment)
        {
            string filePath = "../../RobotComponents.json";

            string jsonString = File.ReadAllText(filePath);

            Dictionary<string, List<IPART>> parts = JsonConvert.DeserializeObject<Dictionary<string, List<IPART>>>(jsonString);

            List<IPART> equipments = parts[sKeyName];

            return equipments[iEquipment];

        }
    }
}
