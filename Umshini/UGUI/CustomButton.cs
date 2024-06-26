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
    public partial class CustomButton : UserControl
    {
        Color mainColor = Color.White;
        public string LabelText
        {
            get { return ButtonLabel.Text; }
            set
            {
                ButtonLabel.Text = value;
            }
        }

        public Color Color
        {
            get { return this.BackColor; }
            set { this.BackColor = value;
                mainColor = value;
            }
        }

        public CustomButton()
        {
            InitializeComponent();
            int x = (this.Size.Width - ButtonLabel.Size.Width) / 2;
            int y = (this.Size.Height - ButtonLabel.Size.Height) / 2;
            ButtonLabel.Location = new Point(x, y);
        }

        private void CustomButton_SizeChanged(object sender, EventArgs e)
        {
            int x = (this.Size.Width - ButtonLabel.Size.Width) / 2;
            int y = (this.Size.Height - ButtonLabel.Size.Height) / 2;
            ButtonLabel.Location = new Point(x, y);
        }

        private void CustomButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = LightenColor(this.BackColor, 0.2f);
        }

        private Color LightenColor(Color color, float correctionFactor)
        {
            float red = (255 - color.R) * correctionFactor + color.R;
            float green = (255 - color.G) * correctionFactor + color.G;
            float blue = (255 - color.B) * correctionFactor + color.B;

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = mainColor;
        }
    }
}
