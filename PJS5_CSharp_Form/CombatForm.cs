using PJS5_CSharp.Sources;
using PJS5_CSharp.Sources.Battle;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PJS5_CSharp_Form
{
    public partial class CombatForm : Form
    {
        private const int WAIT_CODE = 133;
        private const int CONTINUE_CODE = 134;
        NORMAL_WEAPON pBasicNormalWeaponPlayer;
        MELEE_WEAPON pBasicMeleeWeaponPlayer;
        FURNACE pBasicFurnacePlayer;
        LEGS pBasicLegsPlayer;

        NORMAL_WEAPON pBasicNormalWeaponBot;
        MELEE_WEAPON pBasicMeleeWeaponBot;
        FURNACE pBasicFurnaceBot;
        LEGS pBasicLegsBot;

        Robot pPlayer;
        Robot pBot;
        PILOT.IPILOT pPlayerPilot;
        PILOT.IPILOT pBotPilot;
        Battle pBattle;
        static int iResultValue = WAIT_CODE;
        public CombatForm()
        {
            InitializeComponent();
            pBasicNormalWeaponPlayer = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            pBasicMeleeWeaponPlayer = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);
            pBasicFurnacePlayer = new FURNACE(1, "Basic Furnace", 3, 1, 80);
            pBasicLegsPlayer = new LEGS(1, "Basic Legs", 3, 2);

            pBasicNormalWeaponBot = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            pBasicMeleeWeaponBot = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);
            pBasicFurnaceBot = new FURNACE(1, "Basic Furnace", 3, 1, 80);
            pBasicLegsBot = new LEGS(1, "Basic Legs", 3, 2);

            Robot pPlayer = new Robot(pBasicFurnacePlayer, pBasicLegsPlayer, pBasicNormalWeaponPlayer, pBasicMeleeWeaponPlayer);
            Robot pBot = new Robot(pBasicFurnaceBot, pBasicLegsBot, pBasicNormalWeaponBot, pBasicMeleeWeaponBot);
            pPlayerPilot = new PLAYER_PILOT(pPlayer, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            pBotPilot = new BOT_PILOT(pBot, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            pBattle = new Battle(pPlayerPilot, pBotPilot);
            BattleWithGui();
            IntUpdater.Start();
        }


        public void BattleWithGui()
        {
            ShowStatus(pBattle._tPilot[0].GetRobot(), pBattle._tPilot[1].GetRobot());

                for (int iPilot = 0; iPilot < 2; iPilot++)
                {

                pBattle._tPilot[iPilot].PlayTurn(pBattle._tPilot[1 - iPilot].GetRobot());
                    if (pBattle._tPilot[1 - iPilot].RobotIsDestroy())
                    {
                        // Handle robot destruction
                    }
                }
            
        }

        public void UpdateGuiStatus(Robot pPlayer, Robot pBot)
        {
            pLabelFuel.Text = "FUEL " + pPlayer.GetFuel().ToString();
            pLabelLeftArmor.Text = "ARMOR: " + pPlayer.GetLeftWeaponArmor() + "/" + pPlayer.GetLeftWeaponMaxArmor();
            pLabelLeftLife.Text = "LIFE: " + pPlayer.GetLeftWeaponLife() + "/" + pPlayer.GetLeftWeaponMaxLife();
            pLabelRightArmor.Text = "ARMOR: " + pPlayer.GetRightWeaponArmor() + "/" + pPlayer.GetRightWeaponMaxArmor();
            pLabelRightLife.Text = "LIFE: " + pPlayer.GetRightWeaponLife() + "/" + pPlayer.GetRightWeaponMaxLife();
            pLabelLegsArmor.Text = "ARMOR: " + pPlayer.GetLegsArmor() + "/" + pPlayer.GetLegsMaxArmor();
            pLabelLegsLife.Text = "LIFE: " + pPlayer.GetLegsLife() + "/" + pPlayer.GetLegsMaxLife();
            pLabelFurnaceArmor.Text = "ARMOR: " + pPlayer.GetFurnaceArmor() + "/" + pPlayer.GetFurnaceMaxArmor();
            pLabelFurnaceLife.Text = "LIFE: " + pPlayer.GetFurnaceLife() + "/" + pPlayer.GetFurnaceMaxLife();

            eLabelFuel.Text = "FUEL " + pBot.GetFuel().ToString();
            eLabelLeftArmor.Text = "ARMOR: " + pBot.GetLeftWeaponArmor() + "/" + pBot.GetLeftWeaponMaxArmor();
            eLabelLeftLife.Text = "LIFE: " + pBot.GetLeftWeaponLife() + "/" + pBot.GetLeftWeaponMaxLife();
            eLabelRightArmor.Text = "ARMOR: " + pBot.GetRightWeaponArmor() + "/" + pBot.GetRightWeaponMaxArmor();
            eLabelRightLife.Text = "LIFE: " + pBot.GetRightWeaponLife() + "/" + pBot.GetRightWeaponMaxLife();
            eLabelLegsArmor.Text = "ARMOR: " + pBot.GetLegsArmor() + "/" + pBot.GetLegsMaxArmor();
            eLabelLegsLife.Text = "LIFE: " + pBot.GetLegsLife() + "/" + pBot.GetLegsMaxLife();
            eLabelFurnaceArmor.Text = "ARMOR: " + pBot.GetFurnaceArmor() + "/" + pBot.GetFurnaceMaxArmor();
            eLabelFurnaceLife.Text = "LIFE: " + pBot.GetFurnaceLife() + "/" + pBot.GetFurnaceMaxLife();
        }

        public void ShowStatus(Robot pPlayer, Robot pBot)
        {
            UpdateGuiStatus(pPlayer, pBot);



            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                  Robots                  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|>-     Player     -<||>-     Ennemi     -<|");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("| Furnace armor: " + pPlayer.GetFurnaceArmor() + "/" + pPlayer.GetFurnaceMaxArmor() + " || Furnace armor: " + pBot.GetFurnaceArmor() + "/" + pBot.GetFurnaceMaxArmor() + " |");
            Console.WriteLine("| Furnace life: " + pPlayer.GetFurnaceLife() + "/" + pPlayer.GetFurnaceMaxLife() + "  || Furnace life: " + pBot.GetFurnaceLife() + "/" + pBot.GetFurnaceMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Legs armor: " + pPlayer.GetLegsArmor() + "/" + pPlayer.GetLegsMaxArmor() + "    || Legs armor: " + pBot.GetLegsArmor() + "/" + pBot.GetLegsMaxArmor() + "    |");
            Console.WriteLine("| Legs remains: " + pPlayer.GetLegsLife() + "/" + pPlayer.GetLegsMaxLife() + "  || Legs remains: " + pBot.GetLegsLife() + "/" + pBot.GetLegsMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponL armor: " + pPlayer.GetLeftWeaponArmor() + "/" + pPlayer.GetLeftWeaponMaxArmor() + " || WeaponL armor: " + pBot.GetLeftWeaponArmor() + "/" + pBot.GetLeftWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponL life: " + pPlayer.GetLeftWeaponLife() + "/" + pPlayer.GetLeftWeaponMaxLife() + "  || WeaponL life: " + pBot.GetLeftWeaponLife() + "/" + pBot.GetLeftWeaponMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponR armor: " + pPlayer.GetRightWeaponArmor() + "/" + pPlayer.GetRightWeaponMaxArmor() + " || WeaponR armor: " + pBot.GetRightWeaponArmor() + "/" + pBot.GetRightWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponR life: " + pPlayer.GetRightWeaponLife() + "/" + pPlayer.GetRightWeaponMaxLife() + "  || WeaponR life: " + pBot.GetRightWeaponLife() + "/" + pBot.GetRightWeaponMaxLife() + "  |");
            Console.WriteLine("|===================-<>-===================|");
            int iPlayerFuel = pPlayer.GetFuel();
            Console.Write("|    Fuel: " + iPlayerFuel + "/100");
            if (iPlayerFuel < 100)
            {
                Console.Write(" ");
            }
            int iBotFuel = pBot.GetFuel();
            Console.Write("   ||    Fuel: " + iBotFuel + "/100");
            if (iBotFuel < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("   |");
            Console.WriteLine("|====================--====================|");
        }
        public static int GetiResultValue()
        {
            return iResultValue;
        }
        public static int GetInt()
        {
            int iRes = iResultValue;           
            iResultValue = WAIT_CODE;
            return iRes;
        }

        public static void SetInt(int i)
        {
            iResultValue = i;
        }
        public static int MainMenu()
        {
            int iResult = 0;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Main  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|  1-Attack  ||  2-Repairs  ||  3-Furnace  |");
            Console.WriteLine("|===================-<>-===================|");
            iResult = GetInt();          
            Console.WriteLine(" |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int TargetMenu()
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Target  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|    1-Left Weapon   ||   2-Right Weapon   |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|       3-Legs       ||     4-Furnace      |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            iResult = GetInt();
            Console.WriteLine("               |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int RepairMenu(PILOT.IPILOT pPilot)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            int iLightArmor = vRepairKitsReserve[0];
            Console.Write("| 1-Light armor: x" + iLightArmor);
            if (iLightArmor < 10)
            {
                Console.Write(" ");
            }
            int iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || 2-Heavy armor: x" + iHeavyKits);
            if (iHeavyKits < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            int iRepairKits = vRepairKitsReserve[2];
            Console.Write("| 3-Repair kits: x" + iRepairKits);
            if (iRepairKits < 10)
            {
                Console.Write(" ");
            }
            int iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  4-Full kits: x" + iFullKits);
            if (iFullKits < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|   Life Points: 1   ||   Life Points: 3   |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your kit type : ");
            iResult = GetInt();
            Console.WriteLine("                 |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int FuelMenu(PILOT.IPILOT pPilot)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Fuel  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vFuelsReserve = pPilot.GetFuelsReserve();
            int iWood = vFuelsReserve[0];
            Console.Write("|     1-Wood: x" + iWood);
            if (iWood < 10)
            {
                Console.Write(" ");
            }
            int iCharcoal = vFuelsReserve[1];
            Console.Write("    ||   2-Charcoal: x" + iCharcoal);
            if (iCharcoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: 15     ||     Energy: 20     |");
            Console.WriteLine("|===================-<>-===================|");
            int iCoal = vFuelsReserve[2];
            Console.Write("|     3-Coal: x" + iCoal);
            if (iCoal < 10)
            {
                Console.Write(" ");
            }
            int iCompactCoal = vFuelsReserve[3];
            Console.Write("    || 4-Compact Coal: x" + iCompactCoal);
            if (iCompactCoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.WriteLine("|     Energy: 25     ||     Energy: 35     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your fuel type : ");
            iResult = GetInt();
            Console.WriteLine("                |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }
        
        public static int WeaponMenu(Robot pPlayer)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Weapon  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| 1-Left Weapon type: ");
            switch (pPlayer.GetLeftWeaponType())
            {
                case 1:
                    {
                        Console.WriteLine("Normal               |");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Melee                |");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Projectile           |");
                        int iAmmo = pPlayer.GetLeftWeaponSpecificity();
                        Console.Write("| Remaining ammo: x" + iAmmo);
                        if (iAmmo < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                      |");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thermal              |");
                        int iFuel = pPlayer.GetLeftWeaponSpecificity();
                        Console.Write("| Burning fuels: x" + iFuel);
                        if (iFuel < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                     |");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Undefined            |");
                        break;
                    }
            }
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Damage: " + pPlayer.GetLeftWeaponDamage() + "                                |");
            int iLeftAccuracy = pPlayer.GetLeftWeaponHitChance();
            Console.Write("| Accuracy: " + iLeftAccuracy + "%");
            if (iLeftAccuracy < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("                           |");
            Console.WriteLine("| Fuel Consumption: " + pPlayer.GetLeftWeaponPowerConsumption() + "                     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| 2-Right Weapon type: ");
            switch (pPlayer.GetRightWeaponType())
            {
                case 1:
                    {
                        Console.WriteLine("Normal              |");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Melee               |");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Projectile          |");
                        int iAmmo = pPlayer.GetRightWeaponSpecificity();
                        Console.Write("| Remaining ammo: x" + iAmmo);
                        if (iAmmo < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                      |");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thermal             |");
                        int iFuel = pPlayer.GetRightWeaponSpecificity();
                        Console.Write("| Burning fuels: x" + iFuel);
                        if (iFuel < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                     |");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Undefined           |");
                        break;
                    }
            }
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Damage: " + pPlayer.GetRightWeaponDamage() + "                                |");
            int iRightAccuracy = pPlayer.GetRightWeaponHitChance();
            Console.Write("| Accuracy: " + iRightAccuracy + "%");
            if (iRightAccuracy < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("                           |");
            Console.WriteLine("| Fuel Consumption: " + pPlayer.GetRightWeaponPowerConsumption() + "                     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your weapon : ");
            iResult = GetInt();
            Console.WriteLine("                   |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static void RobotRestart()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|      The robot need fuel to restart      |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WeaponIsUnusable()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|         This weapon  is unusable         |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void AlreadyDestroy()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|       This part is already destroy       |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void MissedFire()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|            It's a missed fire            |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockKit()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more kits of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void PerfectlyFine()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|              Perfectly Fine              |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockFuel()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more fuel of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WrongEntry()
        {
            Console.WriteLine("!!!-----------------!==!-----------------!!!");
            Console.WriteLine("|               Wrong  Entry               |");
            Console.WriteLine("!!!-----------------!==!-----------------!!!");
        }

        public void ContinueBattle(int i)
        {
            if (i == CONTINUE_CODE)
            {
                if (!pBattle.BattleIsOver())
                {
                    iResultValue = WAIT_CODE;
                    BattleWithGui();
                }
            }

        }

        private async void IntUpdater_Tick(object sender, EventArgs e)
        {
            if (iResultValue == CONTINUE_CODE)
            {
                
                ContinueBattle(iResultValue);
                
            }
            if (bShakeEnnemi == true)
            {
                var original = pictureBoxEnnemiBot.Location; //(pictureBoxEnnemiBot/pictureBoxPlayerBot)
                var rnd = new Random(1337);
                const int shake_amplitude = 4;
                for (int i = 0; i < 10; i++)
                {
                    pictureBoxEnnemiBot.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                    await Task.Delay(20);
                }
                pictureBoxEnnemiBot.Location = original;
                bShakeEnnemi = false;

                //PART HIT RED EFFECT
                switch (iTargetChoice)
                {
                    case 1:
                        {
                            labelLeftArm.ForeColor = Color.FromArgb(255, 128, 128);
                            await Task.Delay(200);
                            labelLeftArm.ForeColor = Color.Black;
                            break; 
                        }
                    case 2:
                        {
                            labelRightArm.ForeColor = Color.FromArgb(255, 128, 128);
                            await Task.Delay(200);
                            labelRightArm.ForeColor = Color.Black;
                            break;
                        }
                    case 3:
                        {
                            labelLegs.ForeColor = Color.FromArgb(255, 128, 128);
                            await Task.Delay(200);
                            labelLegs.ForeColor = Color.Black;
                            break;
                        }
                    case 4:
                        {
                            labelFurnace.ForeColor = Color.FromArgb(255, 128, 128);
                            await Task.Delay(200);
                            labelFurnace.ForeColor = Color.Black;
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }


            }

        }
        static bool bShakeEnnemi = false;
        static int iTargetChoice;

        public static void EnnemiHit(int iChoice)
        {
            bShakeEnnemi = true;
            iTargetChoice = iChoice;
        }


        private void guiBackButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("0");
            iResultValue = 0;
        }

        private void guiAttackButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            iResultValue = 1;
        }

        private void guiRepairsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("2");
            iResultValue = 2;
        }

        private void guiFurnaceButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("3");
            iResultValue = 3;
        }

        private void guiLeftWeaponButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            iResultValue = 1;
        }

        private void guiRightWeaponButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("2");
            iResultValue = 2;
        }

        private void guiBackButton_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("0");
            iResultValue = 0;
        }

        private void guiLeftWeaponButton2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            iResultValue = 1;
        }

        private void guiRightWeaponButton2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("2");
            iResultValue = 2;
        }

        private void guiLegsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("3");
            iResultValue = 3;
        }

        private void guiFurnaceButton_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("4");
            iResultValue = 4;
        }

        private void guiBackButton2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("0");
            iResultValue = 0;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void selectionSwitch1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void selectionSwitch1_MouseLeave(object sender, EventArgs e)
        {
            if (selectionSwitch1.Value != 0)
            {
                iResultValue = selectionSwitch1.Value;
                selectionSwitch21.Show();
                selectionSwitch1.Enabled = false;
            }

        }

        private void selectionSwitch21_MouseLeave(object sender, EventArgs e)
        {
            if (selectionSwitch21.Value != 0)
            {
                if (selectionSwitch21.Value == 3)
                {
                    //RETUN BACK
                    iResultValue = 0;
                    selectionSwitch1.Enabled = true;
                    selectionSwitch21.Hide();
                    selectionSwitch31.Hide();
                    selectionSwitch1.Value = 0;
                    selectionSwitch1.Refresh();

                    selectionSwitch21.Value = 0;
                    selectionSwitch21.Refresh();

                    selectionSwitch31.Value = 0;
                    selectionSwitch31.Refresh();
                }
                else
                {
                    iResultValue = selectionSwitch21.Value;
                    selectionSwitch31.Show();
                    selectionSwitch21.Enabled = false;
                }
            }


        }

        private void selectionSwitch31_MouseLeave(object sender, EventArgs e)
        {
            if (selectionSwitch31.Value != 0)
            {
                if (selectionSwitch31.Value == 5)
                {
                    iResultValue = 0;
                    selectionSwitch21.Enabled = true;
                    selectionSwitch31.Hide();

                    selectionSwitch21.Value = 0;
                    selectionSwitch21.Refresh();

                    selectionSwitch31.Value = 0;
                    selectionSwitch31.Refresh();
                }
                else
                {
                    iResultValue = selectionSwitch31.Value;
                    selectionSwitch1.Enabled = true;
                    selectionSwitch21.Enabled = true;
                    selectionSwitch21.Hide();
                    selectionSwitch31.Hide();
                    selectionSwitch1.Value = 0;
                    selectionSwitch1.Refresh();

                    selectionSwitch21.Value = 0;
                    selectionSwitch21.Refresh();

                    selectionSwitch31.Value = 0;
                    selectionSwitch31.Refresh();
                }
            }

        }

        private void selectionSwitch21_Load(object sender, EventArgs e)
        {

        }

        private void selectionSwitch1_Load(object sender, EventArgs e)
        {

        }

        private void selectionSwitch31_Load(object sender, EventArgs e)
        {

        }

        private void CombatForm_Load(object sender, EventArgs e)
        {

        }
    }
}
