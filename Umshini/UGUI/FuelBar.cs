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
    public partial class FuelBar : UserControl
    {
        private int percentage = 100;

        public FuelBar()
        {
            InitializeComponent();
        }


        public int Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Percentage", "Value must be between 0 and 100.");
                percentage = value;
                UpdatePictureBoxWidth();
            }
        }

        private void UpdatePictureBoxWidth()
        {
            if (pictureBox1 != null)
            {
                pictureBox1.Width = (int)(this.Width * (percentage / 100.0));
                pictureBox1.Height = this.Height;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdatePictureBoxWidth();
        }
    }
}