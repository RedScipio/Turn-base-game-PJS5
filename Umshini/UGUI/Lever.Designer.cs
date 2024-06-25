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
            ((System.ComponentModel.ISupportInitialize)(this.LeverPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LeverPictureBox
            // 
            this.LeverPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LeverPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeverPictureBox.BackgroundImage")));
            this.LeverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeverPictureBox.Location = new System.Drawing.Point(15, 14);
            this.LeverPictureBox.Name = "LeverPictureBox";
            this.LeverPictureBox.Size = new System.Drawing.Size(152, 35);
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
            this.LabelLayout.Location = new System.Drawing.Point(169, 0);
            this.LabelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.LabelLayout.Name = "LabelLayout";
            this.LabelLayout.Size = new System.Drawing.Size(170, 140);
            this.LabelLayout.TabIndex = 1;
            // 
            // Lever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.LeverPictureBox);
            this.Controls.Add(this.LabelLayout);
            this.DoubleBuffered = true;
            this.Name = "Lever";
            this.Size = new System.Drawing.Size(356, 182);
            ((System.ComponentModel.ISupportInitialize)(this.LeverPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LeverPictureBox;
        private System.Windows.Forms.TableLayoutPanel LabelLayout;
    }
}
