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
            this.informationPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.scoreStatus2 = new Battle.ScoreStatus();
            this.scoreStatus4 = new Battle.ScoreStatus();
            this.leverMainMenu = new UGUI.Lever();
            this.generalLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.informationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalLayout
            // 
            this.generalLayout.BackColor = System.Drawing.Color.Transparent;
            this.generalLayout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("generalLayout.BackgroundImage")));
            this.generalLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.tableLayoutPanel2.Controls.Add(this.informationPanel, 0, 2);
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
            this.tableLayoutPanel1.Controls.Add(this.scoreStatus2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.scoreStatus4, 3, 1);
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
            // informationPanel
            // 
            this.informationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.informationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.informationPanel.Controls.Add(this.infoLabel);
            this.informationPanel.Location = new System.Drawing.Point(3, 267);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(351, 84);
            this.informationPanel.TabIndex = 3;
            this.informationPanel.SizeChanged += new System.EventHandler(this.informationPanel_SizeChanged);
            this.informationPanel.Click += new System.EventHandler(this.informationPanel_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(124, 28);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(94, 17);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Sample Label";
            this.infoLabel.TextChanged += new System.EventHandler(this.infoLabel_TextChanged);
            // 
            // scoreStatus2
            // 
            this.scoreStatus2.BackColor = System.Drawing.Color.Transparent;
            this.scoreStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreStatus2.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Location = new System.Drawing.Point(38, 23);
            this.scoreStatus2.Name = "scoreStatus2";
            this.scoreStatus2.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus2.Size = new System.Drawing.Size(99, 97);
            this.scoreStatus2.TabIndex = 0;
            // 
            // scoreStatus4
            // 
            this.scoreStatus4.BackColor = System.Drawing.Color.Transparent;
            this.scoreStatus4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreStatus4.FurnaceColor = System.Drawing.Color.Gray;
            this.scoreStatus4.LeftArmColor = System.Drawing.Color.Gray;
            this.scoreStatus4.LegsColor = System.Drawing.Color.Gray;
            this.scoreStatus4.Location = new System.Drawing.Point(199, 23);
            this.scoreStatus4.Name = "scoreStatus4";
            this.scoreStatus4.RightArmColor = System.Drawing.Color.Gray;
            this.scoreStatus4.Size = new System.Drawing.Size(99, 97);
            this.scoreStatus4.TabIndex = 1;
            // 
            // leverMainMenu
            // 
            this.leverMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.leverMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leverMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leverMainMenu.LabelList = ((System.Collections.Generic.List<string>)(resources.GetObject("leverMainMenu.LabelList")));
            this.leverMainMenu.Location = new System.Drawing.Point(25, 385);
            this.leverMainMenu.Margin = new System.Windows.Forms.Padding(25, 0, 25, 20);
            this.leverMainMenu.Name = "leverMainMenu";
            this.leverMainMenu.SelectedAction = null;
            this.leverMainMenu.Size = new System.Drawing.Size(313, 146);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicBattleForm_FormClosing);
            this.Load += new System.EventHandler(this.BasicBattleForm_Load);
            this.generalLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.informationPanel.ResumeLayout(false);
            this.informationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel generalLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Battle.ScoreStatus scoreStatus1;
        private Battle.ScoreStatus scoreStatus3;
        private Lever leverMainMenu;
        private Battle.ScoreStatus scoreStatus2;
        private Battle.ScoreStatus scoreStatus4;
        private System.Windows.Forms.Panel informationPanel;
        private System.Windows.Forms.Label infoLabel;
    }
}