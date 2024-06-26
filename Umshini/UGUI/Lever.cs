using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UGUI
{
    public partial class Lever : UserControl
    {
        private StringCollection _lLabelStringList = new StringCollection();
        private List<Label> _lLabelList = new List<Label>();
        private bool _isDragging = false;
        private Point _startPoint = new Point();
        private int _minY;
        private int _maxY;
        private static Lever _activeLever;
        private Lever _previousLever;

        public Lever()
        {
            InitializeComponent();
            _activeLever = this;
        }

        public Lever(StringCollection labelTexts, Lever previousLever = null) : this()
        {
            LabelList = labelTexts;
            _previousLever = previousLever;
            _activeLever = this;

             AddBackLabel();

            if (_lLabelList.Count > 0)
            {
                LeverPictureBox.Location = new Point(LeverPictureBox.Location.X, _lLabelList.First().Top);

                // Set limits for Y movement
                _minY = _lLabelList.First().Top;
                _maxY = _lLabelList.Last().Top;
            }
        }

        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(System.Drawing.Design.UITypeEditor))]
        public StringCollection LabelList
        {
            get { return _lLabelStringList; }
            set
            {
                _lLabelStringList.Clear();
                _lLabelStringList = value;

                for (int i = _lLabelStringList.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(_lLabelStringList[i]))
                    {
                        _lLabelStringList.RemoveAt(i);
                    }
                }

                _lLabelStringList.Insert(0, " ");
                int iLabelCount = _lLabelStringList.Count;
                this.LabelLayout.RowCount = iLabelCount;
                this.LabelLayout.ColumnCount = 1;

                for (int iPosLabel = 0; iPosLabel < _lLabelStringList.Count; iPosLabel++)
                {
                    Label label = new System.Windows.Forms.Label();
                    label.AutoSize = true;
                    label.Dock = System.Windows.Forms.DockStyle.Bottom;
                    label.Location = new System.Drawing.Point(3, 136);
                    label.Name = "label" + iPosLabel;
                    label.Size = new System.Drawing.Size(164, 13);
                    label.TabIndex = iPosLabel;

                    if (_lLabelStringList[iPosLabel] != " ")
                    {
                        label.Text = "- " + _lLabelStringList[iPosLabel];
                    }

                    // Add click event handler for the label
                    label.Click += Label_Click;

                    this.LabelLayout.Controls.Add(label, 0, iPosLabel);
                    this.LabelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / iLabelCount));

                    _lLabelList.Add(label);
                }

                if (_lLabelList.Count > 0)
                {
                    LeverPictureBox.Location = new Point(LeverPictureBox.Location.X, _lLabelList.First().Top);

                    // Set limits for Y movement
                    _minY = _lLabelList.First().Top;
                    _maxY = _lLabelList.Last().Top;
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (_activeLever != this) return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                LeverPictureBox.Top = clickedLabel.Top;
                CreateNewLever(clickedLabel.Text);

            }
        }

        private void LeverPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _startPoint = e.Location;
                LeverPictureBox.Capture = true;
            }
        }

        private void LeverPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int newY = LeverPictureBox.Top + (e.Y - _startPoint.Y);

                // Ensure the new Y position is within the limits
                if (newY < _minY)
                {
                    newY = _minY;
                }
                else if (newY > _maxY)
                {
                    newY = _maxY;
                }

                LeverPictureBox.Top = newY;
            }
        }

        private void LeverPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                LeverPictureBox.Capture = false;

                // Snap to the closest label
                Label closestLabel = null;
                int minDistance = int.MaxValue;

                foreach (Label label in _lLabelList)
                {
                    int distance = Math.Abs(LeverPictureBox.Top - label.Top);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestLabel = label;
                    }
                }

                if (closestLabel != null && closestLabel != _lLabelList[0])
                {
                    if (closestLabel.Text.Contains("Back"))
                    {
                        if (_previousLever != null)
                        {
                            _previousLever.EnableLever();
                            _activeLever = _previousLever;
                        }
                        this.Parent.Controls.Remove(this);
                        return;
                    }

                    LeverPictureBox.Top = closestLabel.Top;
                    CreateNewLever(closestLabel.Text);
                }
            }
        }

        private void CreateNewLever(string labelText)
        {
            Lever newLever = new Lever(new StringCollection { labelText }, this)
            {
                Location = new Point(this.Location.X + this.Width + 10, this.Location.Y),
                Size = this.Size
            };

            if (this.Parent != null)
            {
                this.Parent.Controls.Add(newLever);
            }

            DisableLever();
            _activeLever = newLever;
        }

        private void DisableLever()
        {
            LeverPictureBox.Enabled = false;
            foreach (var label in _lLabelList)
            {
                label.Enabled = false;
            }
        }

        private void EnableLever()
        {
            LeverPictureBox.Enabled = true;
            foreach (var label in _lLabelList)
            {
                label.Enabled = true;
            }
        }

        private void AddBackLabel()
        {
            Label backLabel = new Label();
            backLabel.AutoSize = true;
            backLabel.Dock = DockStyle.Bottom;
            backLabel.Location = new Point(3, 136);
            backLabel.Name = "backLabel";
            backLabel.Size = new Size(164, 13);
            backLabel.TabIndex = _lLabelList.Count;
            backLabel.Text = "- Back";

            backLabel.Click += BackLabel_Click;

            this.LabelLayout.Controls.Add(backLabel, 0, _lLabelList.Count);
            this.LabelLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / (_lLabelStringList.Count + 1)));

            _lLabelList.Add(backLabel);
        }


        private void BackLabel_Click(object sender, EventArgs e)
        {
            if (_activeLever != this) return;

            if (_previousLever != null)
            {
                _previousLever.EnableLever();
                _activeLever = _previousLever;
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
