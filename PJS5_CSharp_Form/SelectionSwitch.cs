using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJS5_CSharp_Form
{
    public partial class SelectionSwitch : UserControl
    {

        public SelectionSwitch()
        {
            InitializeComponent();
        }
        int STEPS = 4;


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Point clientCursorPos = this.PointToClient(Cursor.Position);

                // Calculate the new Y-coordinate based on the cursor position
                int newY = Math.Max(0, Math.Min(clientCursorPos.Y, this.Height - pictureBox1.Height));

                // Switch the PictureBox location
                pictureBox1.Location = new Point(pictureBox1.Location.X, newY);
            }

        }
    }
}
