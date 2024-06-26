namespace UGUI
{
    partial class RobotEditingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.weapon_1 = new System.Windows.Forms.ComboBox();
            this.weapon_2 = new System.Windows.Forms.ComboBox();
            this.legs = new System.Windows.Forms.ComboBox();
            this.furnace = new System.Windows.Forms.ComboBox();
            this.customButton2 = new UGUI.CustomButton();
            this.customButton1 = new UGUI.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(171, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Furnace select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(171, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weapons select";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(187, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Legs select";
            // 
            // weapon_1
            // 
            this.weapon_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.weapon_1.FormattingEnabled = true;
            this.weapon_1.Location = new System.Drawing.Point(69, 169);
            this.weapon_1.Name = "weapon_1";
            this.weapon_1.Size = new System.Drawing.Size(121, 21);
            this.weapon_1.TabIndex = 9;
            // 
            // weapon_2
            // 
            this.weapon_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.weapon_2.FormattingEnabled = true;
            this.weapon_2.Location = new System.Drawing.Point(229, 169);
            this.weapon_2.Name = "weapon_2";
            this.weapon_2.Size = new System.Drawing.Size(121, 21);
            this.weapon_2.TabIndex = 10;
            // 
            // legs
            // 
            this.legs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.legs.FormattingEnabled = true;
            this.legs.Location = new System.Drawing.Point(158, 299);
            this.legs.Name = "legs";
            this.legs.Size = new System.Drawing.Size(121, 21);
            this.legs.TabIndex = 11;
            // 
            // furnace
            // 
            this.furnace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.furnace.FormattingEnabled = true;
            this.furnace.Location = new System.Drawing.Point(158, 61);
            this.furnace.Name = "furnace";
            this.furnace.Size = new System.Drawing.Size(121, 21);
            this.furnace.TabIndex = 12;
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton2.LabelText = "Cancel";
            this.customButton2.Location = new System.Drawing.Point(252, 350);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(183, 52);
            this.customButton2.TabIndex = 14;
            this.customButton2.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton1.LabelText = "Save setup";
            this.customButton1.Location = new System.Drawing.Point(23, 350);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(183, 52);
            this.customButton1.TabIndex = 13;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // RobotEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(447, 437);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.furnace);
            this.Controls.Add(this.legs);
            this.Controls.Add(this.weapon_2);
            this.Controls.Add(this.weapon_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RobotEditingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot editing";
            this.Load += new System.EventHandler(this.RobotEditingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox weapon_1;
        private System.Windows.Forms.ComboBox weapon_2;
        private System.Windows.Forms.ComboBox legs;
        private System.Windows.Forms.ComboBox furnace;
        private CustomButton customButton1;
        private CustomButton customButton2;
    }
}