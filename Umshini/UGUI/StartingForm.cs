using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UGUI
{
    public partial class StartingForm : Form
    {
        private bool isFirstTime = false;
        public StartingForm()
        {
            InitializeComponent();
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                button1.Text = "Restart game";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicBattleForm bbf = new BasicBattleForm();
            bbf.Show();
            Visible = false;
        }
        public void setIsFirstTime()
        {
            isFirstTime = true;
        }

        private void StartingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
