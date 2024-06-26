using Battle;
using Newtonsoft.Json.Linq;
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

        private void furnace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void weapon_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void weapon_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void legs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartingForm sf = new StartingForm();
            Close();
            sf.Visible = true;
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

        private void RobotEditingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
