namespace UGUI
{
    partial class BasicBattleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicBattleForm));
            this.lever1 = new UGUI.Lever();
            this.SuspendLayout();
            // 
            // lever1
            // 
            this.lever1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lever1.BackgroundImage")));
            this.lever1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lever1.LabelList = ((System.Collections.Specialized.StringCollection)(resources.GetObject("lever1.LabelList")));
            this.lever1.Location = new System.Drawing.Point(247, 210);
            this.lever1.Name = "lever1";
            this.lever1.Size = new System.Drawing.Size(356, 182);
            this.lever1.TabIndex = 0;
            // 
            // BasicBattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lever1);
            this.DoubleBuffered = true;
            this.Name = "BasicBattleForm";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BasicBattleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lever lever1;
    }
}