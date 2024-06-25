using Battle;
using Consumable;
using Part;
using Pilot;
using Robot;
using Weapon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTry
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<ICONSUMABLES> _vPlayerRepairKitsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotRepairKitsReserve = new List<ICONSUMABLES>();

            List<ICONSUMABLES> _vPlayerFuelsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotFuelsReserve = new List<ICONSUMABLES>();

            _vPlayerRepairKitsReserve.Add(new RepairKit(0, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(0, REPAIR.FULL_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(0, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(0, REPAIR.HEAVY_ARMOR));

            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_WOOD));
            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_CHARCOAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_COAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_COMPACT_COAL));

            IFURNACE playerFurn = new FURNACE("1", "Normal Furnace", 1, 2, "", 50);
            IFURNACE botFurn = new FURNACE("1", "Normal Furnace", 1, 1, "", 50);
            ILEG playerLegs = new LEG("1", "Basic Legs", 2, 2, "");
            ILEG botLegs = new LEG("1", "Basic Legs", 3, 2, "");

            IWEAPON botLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 3, 15, 100, 0);
            IWEAPON botRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);
            IWEAPON playerLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 3, 15, 100, 0);
            IWEAPON playerRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);

            ROBOT playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            ROBOT botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);

            IPILOT pPlayerPilot = new PLAYER_PILOT(playerRobot, _vPlayerFuelsReserve, _vPlayerRepairKitsReserve);
            IPILOT pBotPilot = new DumbBotPilot(botRobot, _vBotFuelsReserve, _vBotRepairKitsReserve);

            BASIC_BATTLE basicBattle = new BASIC_BATTLE(pPlayerPilot, pBotPilot);

            basicBattle.PlayBattle();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }
    }
}
