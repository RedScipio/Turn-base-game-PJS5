namespace UGUI
{
    partial class Lever
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lever));
            this.LeverPictureBox = new System.Windows.Forms.PictureBox();
            this.LabelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LeverPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeverPictureBox
            // 
            this.LeverPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeverPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LeverPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeverPictureBox.BackgroundImage")));
            this.LeverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeverPictureBox.Location = new System.Drawing.Point(16, 10);
            this.LeverPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.LeverPictureBox.Name = "LeverPictureBox";
            this.LeverPictureBox.Size = new System.Drawing.Size(150, 35);
            this.LeverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeverPictureBox.TabIndex = 0;
            this.LeverPictureBox.TabStop = false;
            this.LeverPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeverPictureBox_MouseDown);
            this.LeverPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LeverPictureBox_MouseMove);
            this.LeverPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeverPictureBox_MouseUp);
            // 
            // LabelLayout
            // 
            this.LabelLayout.BackColor = System.Drawing.Color.Transparent;
            this.LabelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LabelLayout.Location = new System.Drawing.Point(178, 0);
            this.LabelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.LabelLayout.Name = "LabelLayout";
            this.LabelLayout.Size = new System.Drawing.Size(170, 140);
            this.LabelLayout.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelLayout, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 182);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LeverPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 182);
            this.panel1.TabIndex = 0;
            // 
            // Lever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "Lever";
            this.Size = new System.Drawing.Size(356, 182);
            this.SizeChanged += new System.EventHandler(this.Lever_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.LeverPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LeverPictureBox;
        private System.Windows.Forms.TableLayoutPanel LabelLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
