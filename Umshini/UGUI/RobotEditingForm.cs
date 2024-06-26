using Battle;
using Newtonsoft.Json.Linq;
using NoFormApp;
using Part;
using Robot;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UGUI
{
    public partial class RobotEditingForm : Form
    {
        
        public RobotEditingForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void RobotEditingForm_Load(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText("../../../NoFormApp/RobotComponents.json");
            JObject parts = JObject.Parse(jsonString);

            for(int i = 0; i < parts["Legs"].ToList().Count; i++) 
            {
                legs.Items.Add(parts["Legs"][i]["name"]);
                
            }

            for (int i = 0; i < parts["Weapons"].ToList().Count; i++)
            {
                weapon_1.Items.Add(parts["Weapons"][i]["name"]);
                weapon_2.Items.Add(parts["Weapons"][i]["name"]);
            }

            for (int i = 0; i < parts["Furnaces"].ToList().Count; i++)
            {
                furnace.Items.Add(parts["Furnaces"][i]["name"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public ROBOT GetRobot()
        {
            int iWeapon_1 = weapon_1.SelectedIndex;
            int iWeapon_2 = weapon_2.SelectedIndex;
            int iFurnace = furnace.SelectedIndex;
            int iLegs = legs.SelectedIndex;

            string sJsonString = File.ReadAllText("../../../NoFormApp/RobotComponents.json");

            JObject parts = JObject.Parse(sJsonString);

            IFURNACE furnaceRobot = parts["Furnaces"][iFurnace].ToObject<FURNACE>();
            ILEG legsRobot = parts["Legs"][iLegs].ToObject<LEG>();

            IWEAPON pWeapon_1 = Utils.GetWeapon(parts, iWeapon_1);
            IWEAPON pWeapon_2 = Utils.GetWeapon(parts, iWeapon_2);

            return new ROBOT(furnaceRobot, legsRobot, pWeapon_1, pWeapon_2);
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            StartingForm sf = new StartingForm(GetRobot());
            Visible = false;
            sf.Visible = true;
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            StartingForm sf = new StartingForm(null);
            Close();
            sf.Visible = true;
        }
    }
}
