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
    public partial class SelectionSwitch3 : UserControl
    {
        int iCurrentStep = 0;
        static int STEPS = 6;
        Point[] pStepCoordinate = new Point[STEPS];
        String[] sLabelList = new String[STEPS];

        public int Value
        {
            get { return iCurrentStep; }
            set
            {
                iCurrentStep = value;
                guiKnob.Location = pStepCoordinate[iCurrentStep];
            }
        }
        public SelectionSwitch3()
        {
            InitializeComponent();
            int iOffset = 40;           
            int iHeightStep = this.Height / STEPS;
            sLabelList[0] = "1 - Left-Weapon";
            sLabelList[1] = "2 - Right-Weapon";
            sLabelList[2] = "3 - Legs";
            sLabelList[3] = "4 - Furnace";
            sLabelList[4] = "0 - Back";
            for (int i = 0; i < STEPS; i++) {

                pStepCoordinate[i] = new Point(guiKnob.Location.X, (iHeightStep * (i + 1)) - iOffset);
                if (i!= 0)
                {
                    addLabel(pStepCoordinate[i], sLabelList[i - 1]);
                }
                
                Console.WriteLine(i);
            }

            guiKnob.Location = pStepCoordinate[0];
        }
        
        //Point[] steps = new Point[STEPS];

        private void addLabel(Point p, String text)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = text;
            label.Location = new Point(140, p.Y + 4); 
            label.AutoSize = true; 
            this.Controls.Add(label);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
/*
            if (e.Button == MouseButtons.Left)
            {
                Point clientCursorPos = this.PointToClient(Cursor.Position);

                // Calculate the new Y-coordinate based on the cursor position
                int newY = Math.Max(0, Math.Min(clientCursorPos.Y, this.Height - guiKnob.Height));

                // Switch the PictureBox location
                guiKnob.Location = new Point(guiKnob.Location.X, newY);
            }*/

        }

        private void SelectionSwitch3_MouseDown(object sender, MouseEventArgs e)
        {


            if (iCurrentStep == STEPS - 1)
            {
                iCurrentStep = 0;
            }
            else
            {
                iCurrentStep++;
            }
            guiKnob.Location = pStepCoordinate[iCurrentStep];
            Console.WriteLine(iCurrentStep);

        }
    }
}
