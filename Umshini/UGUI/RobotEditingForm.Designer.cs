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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.weapon_1 = new System.Windows.Forms.ComboBox();
            this.weapon_2 = new System.Windows.Forms.ComboBox();
            this.legs = new System.Windows.Forms.ComboBox();
            this.furnace = new System.Windows.Forms.ComboBox();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save setup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // weapon_1
            // 
            this.weapon_1.FormattingEnabled = true;
            this.weapon_1.Location = new System.Drawing.Point(69, 169);
            this.weapon_1.Name = "weapon_1";
            this.weapon_1.Size = new System.Drawing.Size(121, 21);
            this.weapon_1.TabIndex = 9;
            // 
            // weapon_2
            // 
            this.weapon_2.FormattingEnabled = true;
            this.weapon_2.Location = new System.Drawing.Point(229, 169);
            this.weapon_2.Name = "weapon_2";
            this.weapon_2.Size = new System.Drawing.Size(121, 21);
            this.weapon_2.TabIndex = 10;
            // 
            // legs
            // 
            this.legs.FormattingEnabled = true;
            this.legs.Location = new System.Drawing.Point(158, 299);
            this.legs.Name = "legs";
            this.legs.Size = new System.Drawing.Size(121, 21);
            this.legs.TabIndex = 11;
            // 
            // furnace
            // 
            this.furnace.FormattingEnabled = true;
            this.furnace.Location = new System.Drawing.Point(158, 61);
            this.furnace.Name = "furnace";
            this.furnace.Size = new System.Drawing.Size(121, 21);
            this.furnace.TabIndex = 12;
            // 
            // RobotEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 437);
            this.Controls.Add(this.furnace);
            this.Controls.Add(this.legs);
            this.Controls.Add(this.weapon_2);
            this.Controls.Add(this.weapon_1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobotEditingForm";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox weapon_1;
        private System.Windows.Forms.ComboBox weapon_2;
        private System.Windows.Forms.ComboBox legs;
        private System.Windows.Forms.ComboBox furnace;
    }
}