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
    public partial class Lever : UserControl
    {
        private StringCollection _lLabelStringList = new StringCollection();
        private List<Label> _lLabelList = new List<Label>();
        public Lever()
        {
            InitializeComponent();
        }


        //Forces visual studio to use the correct editor
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(System.Drawing.Design.UITypeEditor))]
        public StringCollection LabelList
        {  get { return _lLabelStringList;  }

            set {
                _lLabelStringList = value;
                _lLabelStringList.Insert(0, " ");
                int iLabelCount = _lLabelStringList.Count;
                this.LabelLayout.RowCount = iLabelCount;
                this.LabelLayout.ColumnCount = 1;

                for (int iPosLabel = 0; iPosLabel < _lLabelStringList.Count; iPosLabel++)
                {
                    Label label = new System.Windows.Forms.Label();

                    this.LabelLayout.Controls.Add(label, 0, iPosLabel);
                    this.LabelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / iLabelCount));

                    label.AutoSize = true;
                    label.Dock = System.Windows.Forms.DockStyle.Bottom;
                    label.Location = new System.Drawing.Point(3, 136);
                    label.Name = "label" + iPosLabel;
                    label.Size = new System.Drawing.Size(164, 13);
                    label.TabIndex = iPosLabel;
                    label.Text = _lLabelStringList[iPosLabel];
                    
                    _lLabelList.Add(label);
                }

                if (_lLabelList.Count > 0)
                {
                    LeverPictureBox.Location = new Point(LeverPictureBox.Location.X, LabelLayout.Location.Y + 12);//12 = Y offset
                }

            }
        }

        private void LeverPictureBox_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
