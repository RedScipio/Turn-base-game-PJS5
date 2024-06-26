using System;
using System.IO;
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
            string jsonString = File.ReadAllText("../../");
        }
    }
}
