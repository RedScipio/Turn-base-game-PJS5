using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle
{
    public partial class ScoreStatus : UserControl
    {
        public ScoreStatus()
        {
            InitializeComponent();
        }
        public Color LeftArmColor
        {
            get { return leftArmPictureBox.BackColor; }
            set
            {
                leftArmPictureBox.BackColor = value;
            }
        }

        public Color RightArmColor
        {
            get { return rightArmPictureBox.BackColor; }
            set
            {
                rightArmPictureBox.BackColor = value;
            }
        }
        public Color FurnaceColor
        {
            get { return furnacePictureBox.BackColor; }
            set
            {
                furnacePictureBox.BackColor = value;
            }
        }
        public Color LegsColor
        {
            get { return legsPictureBox1.BackColor; }
            set
            {
                legsPictureBox1.BackColor = value;
                legsPictureBox2.BackColor = value;
            }
        }

        private void ScoreStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
