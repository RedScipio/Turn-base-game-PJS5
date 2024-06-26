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
            this.generalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BarMenuPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ScoreLayout = new System.Windows.Forms.TableLayoutPanel();
            this.scoreStatus2 = new Battle.ScoreStatus();
            this.generalLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarMenuPictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.ScoreLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalLayout
            // 
            this.generalLayout.BackColor = System.Drawing.Color.Transparent;
            this.generalLayout.ColumnCount = 1;
            this.generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.generalLayout.Controls.Add(this.BarMenuPictureBox, 0, 1);
            this.generalLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.generalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLayout.Location = new System.Drawing.Point(0, 0);
            this.generalLayout.Name = "generalLayout";
            this.generalLayout.RowCount = 2;
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.generalLayout.Size = new System.Drawing.Size(1090, 551);
            this.generalLayout.TabIndex = 0;
            // 
            // BarMenuPictureBox
            // 
            this.BarMenuPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BarMenuPictureBox.BackgroundImage")));
            this.BarMenuPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BarMenuPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarMenuPictureBox.Location = new System.Drawing.Point(3, 388);
            this.BarMenuPictureBox.Name = "BarMenuPictureBox";
            this.BarMenuPictureBox.Size = new System.Drawing.Size(1084, 160);
            this.BarMenuPictureBox.TabIndex = 0;
            this.BarMenuPictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.ScoreLayout, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1084, 379);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ScoreLayout
            // 
            this.ScoreLayout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScoreLayout.BackgroundImage")));
            this.ScoreLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ScoreLayout.ColumnCount = 5;
            this.ScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ScoreLayout.Controls.Add(this.scoreStatus2, 1, 0);
            this.ScoreLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoreLayout.Location = new System.Drawing.Point(371, 10);
            this.ScoreLayout.Margin = new System.Windows.Forms.Padding(10);
            this.ScoreLayout.Name = "ScoreLayout";
            this.ScoreLayout.RowCount = 2;
            this.ScoreLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ScoreLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ScoreLayout.Size = new System.Drawing.Size(341, 169);
            this.ScoreLayout.TabIndex = 0;
            // 
            // scoreStatus2
            // 
            this.scoreStatus2.BackColor = System.Drawing.Color.Transparent;
            this.scoreStatus2.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Location = new System.Drawing.Point(180, 10);
            this.scoreStatus2.Margin = new System.Windows.Forms.Padding(10);
            this.scoreStatus2.Name = "scoreStatus2";
            this.scoreStatus2.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Size = new System.Drawing.Size(63, 45);
            this.scoreStatus2.TabIndex = 1;
            // 
            // BasicBattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1090, 551);
            this.Controls.Add(this.generalLayout);
            this.DoubleBuffered = true;
            this.Name = "BasicBattleForm";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BasicBattleForm_Load);
            this.generalLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarMenuPictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ScoreLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel generalLayout;
        private System.Windows.Forms.PictureBox BarMenuPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel ScoreLayout;
        private Battle.ScoreStatus scoreStatus2;
    }
}