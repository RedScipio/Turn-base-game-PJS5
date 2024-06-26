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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scoreStatus1 = new Battle.ScoreStatus();
            this.scoreStatus3 = new Battle.ScoreStatus();
            this.leverMainMenu = new UGUI.Lever();
            this.generalLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalLayout
            // 
            this.generalLayout.BackColor = System.Drawing.Color.Transparent;
            this.generalLayout.ColumnCount = 3;
            this.generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.generalLayout.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.generalLayout.Controls.Add(this.leverMainMenu, 0, 1);
            this.generalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLayout.Location = new System.Drawing.Point(0, 0);
            this.generalLayout.Name = "generalLayout";
            this.generalLayout.RowCount = 2;
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.generalLayout.Size = new System.Drawing.Size(1090, 551);
            this.generalLayout.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(366, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(357, 379);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41667F));
            this.tableLayoutPanel1.Controls.Add(this.scoreStatus1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.scoreStatus3, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 47);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 207);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // scoreStatus1
            // 
            this.scoreStatus1.BackColor = System.Drawing.Color.Transparent;
            this.scoreStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreStatus1.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus1.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus1.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus1.Location = new System.Drawing.Point(45, 30);
            this.scoreStatus1.Margin = new System.Windows.Forms.Padding(10);
            this.scoreStatus1.Name = "scoreStatus1";
            this.scoreStatus1.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus1.Size = new System.Drawing.Size(85, 83);
            this.scoreStatus1.TabIndex = 0;
            // 
            // scoreStatus3
            // 
            this.scoreStatus3.BackColor = System.Drawing.Color.Transparent;
            this.scoreStatus3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreStatus3.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus3.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus3.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus3.Location = new System.Drawing.Point(206, 30);
            this.scoreStatus3.Margin = new System.Windows.Forms.Padding(10);
            this.scoreStatus3.Name = "scoreStatus3";
            this.scoreStatus3.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus3.Size = new System.Drawing.Size(85, 83);
            this.scoreStatus3.TabIndex = 1;
            // 
            // leverMainMenu
            // 
            this.leverMainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leverMainMenu.BackgroundImage")));
            this.leverMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leverMainMenu.LabelList = ((System.Collections.Generic.List<string>)(resources.GetObject("leverMainMenu.LabelList")));
            this.leverMainMenu.Location = new System.Drawing.Point(3, 388);
            this.leverMainMenu.Name = "leverMainMenu";
            this.leverMainMenu.SelectedAction = null;
            this.leverMainMenu.Size = new System.Drawing.Size(356, 160);
            this.leverMainMenu.TabIndex = 2;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicBattleForm_FormClosing);
            this.Load += new System.EventHandler(this.BasicBattleForm_Load);
            this.generalLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel generalLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Battle.ScoreStatus scoreStatus1;
        private Battle.ScoreStatus scoreStatus3;
        private Lever leverMainMenu;
    }
}