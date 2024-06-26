using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UGUI
{

    /// <summary>
    /// Form use to show a Basic Battle to the user
    /// </summary>
    /// <authors> MBL, DTR</authors>
    /// <date> 25-06-2024 </date>
    /// 

    public partial class BasicBattleForm : Form
    {
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        #endregion

        #region .. code for Flucuring ..
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion

        public BasicBattleForm()
        {
            InitializeComponent();
            SetDoubleBuffered(generalLayout);
            SetDoubleBuffered(tableLayoutPanel1);
            SetDoubleBuffered(tableLayoutPanel2);
            lever1.LabelClick += new EventHandler(lever1_LabelClick);

        }
        protected void lever1_LabelClick(object sender, EventArgs e)
        {
            MessageBox.Show("eez");
        }

/*        private void CreateNewLever(string labelText, Lever lever)
        {
            Lever newLever = new Lever(new StringCollection { labelText }, Lever)
            {
                Location = new Point(lever.Location.X + lever.Width + 10, lever.Location.Y),
                Size = lever.Size
            };

            if (this.Parent != null)
            {
                this.Parent.Controls.Add(newLever);
            }

            lever.Enabled = false;
            _activeLever = newLever;
        }
*/


        private void BasicBattleForm_Load(object sender, EventArgs e)
        {

        }


        private void BasicBattleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartingForm sf = new StartingForm();
            sf.setIsFirstTime();
            sf.Visible = true;
        }
    }
}
