namespace UGUI
{
    partial class CustomButton
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
            this.ButtonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonLabel
            // 
            this.ButtonLabel.AutoSize = true;
            this.ButtonLabel.Enabled = false;
            this.ButtonLabel.Location = new System.Drawing.Point(78, 15);
            this.ButtonLabel.Name = "ButtonLabel";
            this.ButtonLabel.Size = new System.Drawing.Size(60, 13);
            this.ButtonLabel.TabIndex = 0;
            this.ButtonLabel.Text = "Buttonlabel";
            // 
            // CustomButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonLabel);
            this.Name = "CustomButton";
            this.Size = new System.Drawing.Size(183, 52);
            this.SizeChanged += new System.EventHandler(this.CustomButton_SizeChanged);
            this.MouseEnter += new System.EventHandler(this.CustomButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CustomButton_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ButtonLabel;
    }
}
