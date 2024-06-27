using Battle;
using UGUI;
using Consumable;
using Part;
using Pilot;
using Robot;
using Weapon;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoFormApp;

namespace UGUI
{
    public partial class StartingForm : Form
    {
        private bool isFirstTime = false;
        private IROBOT pPlayerRobot = null;
        public StartingForm(IROBOT robot)
        {
            InitializeComponent();
            if(robot != null) 
            {
                this.pPlayerRobot = robot;
            }
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                customButton1.Text = "Restart game";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }
        public void setIsFirstTime()
        {
            isFirstTime = true;
        }

        private void StartingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            string filePath = "../../../NoFormApp/RobotComponents.json";
            IROBOT playerRobot;

            List<ICONSUMABLES> _vPlayerRepairKitsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotRepairKitsReserve = new List<ICONSUMABLES>();

            List<ICONSUMABLES> _vPlayerFuelsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotFuelsReserve = new List<ICONSUMABLES>();

            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.FULL_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.HEAVY_ARMOR));

            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_WOOD));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_CHARCOAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_COAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_COMPACT_COAL));

            //IFURNACE botFurn = new FURNACE("1", "Normal Furnace", 1, 1, "", 50);
            //ILEG botLegs = new LEG("1", "Basic Legs", 3, 2, "");
            //IWEAPON botLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 3, 15, 100, 0);
            //IWEAPON botRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);

            if (pPlayerRobot != null)
            {
                playerRobot = pPlayerRobot;
                Console.WriteLine(playerRobot);
            }
            else
            {
                IFURNACE playerFurn = new FURNACE("1", "Normal Furnace", 1, 2, "", 50);
                ILEG playerLegs = new LEG("1", "Basic Legs", 2, 2, "");
                IWEAPON playerLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 1, 15, 100, 0);
                IWEAPON playerRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 1, 1, "", 1, 15, 80, 40);
                playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            }

            IROBOT botRobot = Utils.GetProceduralRobot(filePath);

            IPILOT pPlayerPilot = new PLAYER_PILOT(playerRobot, _vPlayerFuelsReserve, _vPlayerRepairKitsReserve);
            IPILOT pBotPilot = new SmartBotPilot(botRobot, _vBotFuelsReserve, _vBotRepairKitsReserve);

            BASIC_BATTLE basicBattle = new BASIC_BATTLE(pPlayerPilot, pBotPilot);

            BasicBattleForm bbf = new BasicBattleForm(basicBattle);
            bbf.Show();
            Visible = false;
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            RobotEditingForm ef = new RobotEditingForm();
            ef.Show();
            Visible = false;
        }

        private void customButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
