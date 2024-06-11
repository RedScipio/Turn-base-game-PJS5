namespace Battle
{
    partial class BasikBattle
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.scoreStatus1 = new Battle.ScoreStatus();
            this.scoreStatus2 = new Battle.ScoreStatus();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BackgroundImage = global::Battle.Properties.Resources.PanelMenu;
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMenu.Controls.Add(this.scoreStatus2);
            this.panelMenu.Controls.Add(this.scoreStatus1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Location = new System.Drawing.Point(-1, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(806, 451);
            this.panelMenu.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Battle.Properties.Resources.Scoreboard;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 451);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // scoreStatus1
            // 
            this.scoreStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(86)))), ((int)(((byte)(59)))));
            this.scoreStatus1.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus1.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus1.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus1.Location = new System.Drawing.Point(309, 86);
            this.scoreStatus1.Name = "scoreStatus1";
            this.scoreStatus1.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus1.Size = new System.Drawing.Size(66, 81);
            this.scoreStatus1.TabIndex = 1;
            // 
            // scoreStatus2
            // 
            this.scoreStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(86)))), ((int)(((byte)(59)))));
            this.scoreStatus2.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Location = new System.Drawing.Point(421, 86);
            this.scoreStatus2.Name = "scoreStatus2";
            this.scoreStatus2.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Size = new System.Drawing.Size(66, 81);
            this.scoreStatus2.TabIndex = 2;
            // 
            // BasikBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battle.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(804, 453);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.Name = "BasikBattle";
            this.Text = "BasikBattle";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ScoreStatus scoreStatus2;
        private ScoreStatus scoreStatus1;
    }
}