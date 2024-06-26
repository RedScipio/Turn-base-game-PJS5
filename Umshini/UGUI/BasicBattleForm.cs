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
        private List<Lever> _lLever = new List<Lever>{ };

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
            leverMainMenu.LabelClick += new EventHandler(lever_LabelClick);

            _lLever.Add(leverMainMenu);

        }
        protected void lever_LabelClick(object sender, EventArgs eventLever)
        {
            CreateNewLever(new StringCollection{"Test"});
        }

        protected void lever_BackClick(object sender, EventArgs eventLever)
        {
            if (this.generalLayout != null)
            {
                _lLever.RemoveAt(_lLever.Count - 1);
                _lLever.Last().Enabled = true;
            }
        }

        private void CreateNewLever(StringCollection lLabelsText)
        {
            Lever newLever = new Lever(lLabelsText);

            if (this.generalLayout != null)
            {
                TableLayoutPanelCellPosition posLayoutLever = generalLayout.GetCellPosition(_lLever.Last());
                this.generalLayout.Controls.Add(newLever, posLayoutLever.Column+1, posLayoutLever.Row);
            }

            newLever.LabelClick += new EventHandler(lever_LabelClick);
            newLever.BackClick += new EventHandler(lever_BackClick);

            _lLever.Last().Enabled = false;
            _lLever.Add(newLever);
        }



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
