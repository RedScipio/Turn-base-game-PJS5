﻿using System;
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
            if (_activeLever == null)
            {
                _activeLever = this;
            }

            // Add event handlers for dragging the LeverPictureBox
            LeverPictureBox.MouseDown += LeverPictureBox_MouseDown;
            LeverPictureBox.MouseMove += LeverPictureBox_MouseMove;
            LeverPictureBox.MouseUp += LeverPictureBox_MouseUp;
        }

        public Lever(List<string> labelTexts, Lever previousLever = null) : this()
        {
            foreach (var text in labelTexts)
            {
                AddLabel(text);
            }

            _previousLever = previousLever;

            // Add a "Back" label if this is a new lever
            if (labelTexts.Count == 1)
            {
                AddBackLabel();
            }

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

                if (iLabelCount > 0)
                {
                    float rowHeightPercentage = 100f / iLabelCount;
                    for (int iPosLabel = 0; iPosLabel < _lLabelStringList.Count; iPosLabel++)
                    {
                        AddLabel(_lLabelStringList[iPosLabel], rowHeightPercentage);
                    }

                    LeverPictureBox.Location = new Point(LeverPictureBox.Location.X, _lLabelList.First().Top);

                    // Set limits for Y movement
                    _minY = _lLabelList.First().Top;
                    _maxY = _lLabelList.Last().Top;
                }
            }
        }

        private void AddLabel(string labelText, float rowHeightPercentage = 100f)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Dock = DockStyle.Bottom;
            label.Location = new Point(3, 136);
            label.Name = "label" + _lLabelList.Count;
            label.Size = new Size(164, 13);
            label.TabIndex = _lLabelList.Count;

            if (labelText != " ")
            {
                label.Text = "- " + labelText;
            }

            label.Click += Label_Click;

            this.LabelLayout.Controls.Add(label, 0, _lLabelList.Count);
            this.LabelLayout.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeightPercentage));

            _lLabelList.Add(label);
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

        private void Label_Click(object sender, EventArgs e)
        {
            if (this != _activeLever) return;

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                LeverPictureBox.Top = clickedLabel.Top;
                CreateNewLever(clickedLabel.Text);
            }
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

        private void LeverPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this == _activeLever)
            {
                _isDragging = true;
                _startPoint = e.Location;
                LeverPictureBox.Capture = true;
            }
        }

        private void LeverPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && this == _activeLever)
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

                // Update the LeverPictureBox position
                LeverPictureBox.Top = newY;
            }
        }

        private void LeverPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging && this == _activeLever)
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

                if (closestLabel != null)
                {
                    LeverPictureBox.Top = closestLabel.Top;
                    CreateNewLever(closestLabel.Text);
                }
            }
        }

        private void CreateNewLever(string labelText)
        {
            Lever newLever = new Lever(new List<string> { labelText }, this)
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
    }
}
