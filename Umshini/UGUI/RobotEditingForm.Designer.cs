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
            this.furnace = new System.Windows.Forms.ListBox();
            this.weapon_1 = new System.Windows.Forms.ListBox();
            this.weapon_2 = new System.Windows.Forms.ListBox();
            this.legs = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Furnace select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
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
            this.label3.Location = new System.Drawing.Point(187, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Legs select";
            // 
            // furnace
            // 
            this.furnace.FormattingEnabled = true;
            this.furnace.Location = new System.Drawing.Point(154, 61);
            this.furnace.Name = "furnace";
            this.furnace.Size = new System.Drawing.Size(113, 17);
            this.furnace.TabIndex = 3;
            this.furnace.SelectedIndexChanged += new System.EventHandler(this.furnace_SelectedIndexChanged);
            // 
            // weapon_1
            // 
            this.weapon_1.FormattingEnabled = true;
            this.weapon_1.Location = new System.Drawing.Point(79, 156);
            this.weapon_1.Name = "weapon_1";
            this.weapon_1.Size = new System.Drawing.Size(113, 17);
            this.weapon_1.TabIndex = 4;
            this.weapon_1.SelectedIndexChanged += new System.EventHandler(this.weapon_1_SelectedIndexChanged);
            // 
            // weapon_2
            // 
            this.weapon_2.FormattingEnabled = true;
            this.weapon_2.Location = new System.Drawing.Point(235, 156);
            this.weapon_2.Name = "weapon_2";
            this.weapon_2.Size = new System.Drawing.Size(113, 17);
            this.weapon_2.TabIndex = 5;
            this.weapon_2.SelectedIndexChanged += new System.EventHandler(this.weapon_2_SelectedIndexChanged);
            // 
            // legs
            // 
            this.legs.FormattingEnabled = true;
            this.legs.Location = new System.Drawing.Point(163, 280);
            this.legs.Name = "legs";
            this.legs.Size = new System.Drawing.Size(113, 17);
            this.legs.TabIndex = 6;
            this.legs.SelectedIndexChanged += new System.EventHandler(this.legs_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save setup";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 44);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RobotEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 437);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.legs);
            this.Controls.Add(this.weapon_2);
            this.Controls.Add(this.weapon_1);
            this.Controls.Add(this.furnace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobotEditingForm";
            this.Text = "Robot editing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RobotEditingForm_FormClosing);
            this.Load += new System.EventHandler(this.RobotEditingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox furnace;
        private System.Windows.Forms.ListBox weapon_1;
        private System.Windows.Forms.ListBox weapon_2;
        private System.Windows.Forms.ListBox legs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}