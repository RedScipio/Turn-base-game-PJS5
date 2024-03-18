namespace PJS5_CSharp_Form
{
    partial class CombatForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.IntUpdater = new System.Windows.Forms.Timer(this.components);
            this.pLabelFuel = new System.Windows.Forms.Label();
            this.pLabelLeftArmor = new System.Windows.Forms.Label();
            this.pLabelLeftLife = new System.Windows.Forms.Label();
            this.pLabelRightArmor = new System.Windows.Forms.Label();
            this.pLabelRightLife = new System.Windows.Forms.Label();
            this.pLabelLegsLife = new System.Windows.Forms.Label();
            this.pLabelLegsArmor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pLabelFurnaceLife = new System.Windows.Forms.Label();
            this.pLabelFurnaceArmor = new System.Windows.Forms.Label();
            this.eLabelFurnaceLife = new System.Windows.Forms.Label();
            this.eLabelFurnaceArmor = new System.Windows.Forms.Label();
            this.labelFurnace = new System.Windows.Forms.Label();
            this.labelLegs = new System.Windows.Forms.Label();
            this.labelLeftArm = new System.Windows.Forms.Label();
            this.labelRightArm = new System.Windows.Forms.Label();
            this.eLabelLegsLife = new System.Windows.Forms.Label();
            this.eLabelLegsArmor = new System.Windows.Forms.Label();
            this.eLabelRightLife = new System.Windows.Forms.Label();
            this.eLabelRightArmor = new System.Windows.Forms.Label();
            this.eLabelLeftLife = new System.Windows.Forms.Label();
            this.eLabelLeftArmor = new System.Windows.Forms.Label();
            this.eLabelFuel = new System.Windows.Forms.Label();
            this.pictureBoxEnnemiBot = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectionSwitch31 = new PJS5_CSharp_Form.SelectionSwitch3();
            this.selectionSwitch21 = new PJS5_CSharp_Form.SelectionSwitch2();
            this.selectionSwitch1 = new PJS5_CSharp_Form.SelectionSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnnemiBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IntUpdater
            // 
            this.IntUpdater.Tick += new System.EventHandler(this.IntUpdater_Tick);
            // 
            // pLabelFuel
            // 
            this.pLabelFuel.AutoSize = true;
            this.pLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelFuel.Location = new System.Drawing.Point(107, 602);
            this.pLabelFuel.Name = "pLabelFuel";
            this.pLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.pLabelFuel.TabIndex = 28;
            this.pLabelFuel.Text = "FUEL 0";
            // 
            // pLabelLeftArmor
            // 
            this.pLabelLeftArmor.AutoSize = true;
            this.pLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLeftArmor.Location = new System.Drawing.Point(38, 457);
            this.pLabelLeftArmor.Name = "pLabelLeftArmor";
            this.pLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLeftArmor.TabIndex = 29;
            this.pLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelLeftLife
            // 
            this.pLabelLeftLife.AutoSize = true;
            this.pLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelLeftLife.Location = new System.Drawing.Point(38, 475);
            this.pLabelLeftLife.Name = "pLabelLeftLife";
            this.pLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLeftLife.TabIndex = 30;
            this.pLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // pLabelRightArmor
            // 
            this.pLabelRightArmor.AutoSize = true;
            this.pLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightArmor.Location = new System.Drawing.Point(258, 457);
            this.pLabelRightArmor.Name = "pLabelRightArmor";
            this.pLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelRightArmor.TabIndex = 31;
            this.pLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelRightLife
            // 
            this.pLabelRightLife.AutoSize = true;
            this.pLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightLife.Location = new System.Drawing.Point(258, 475);
            this.pLabelRightLife.Name = "pLabelRightLife";
            this.pLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelRightLife.TabIndex = 32;
            this.pLabelRightLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsLife
            // 
            this.pLabelLegsLife.AutoSize = true;
            this.pLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsLife.Location = new System.Drawing.Point(258, 559);
            this.pLabelLegsLife.Name = "pLabelLegsLife";
            this.pLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLegsLife.TabIndex = 34;
            this.pLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsArmor
            // 
            this.pLabelLegsArmor.AutoSize = true;
            this.pLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsArmor.Location = new System.Drawing.Point(258, 541);
            this.pLabelLegsArmor.Name = "pLabelLegsArmor";
            this.pLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLegsArmor.TabIndex = 33;
            this.pLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "RIGHT ARM";
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "LEFT ARM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "LEGS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "FURNACE";
            // 
            // pLabelFurnaceLife
            // 
            this.pLabelFurnaceLife.AutoSize = true;
            this.pLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceLife.Location = new System.Drawing.Point(152, 475);
            this.pLabelFurnaceLife.Name = "pLabelFurnaceLife";
            this.pLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelFurnaceLife.TabIndex = 40;
            this.pLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // pLabelFurnaceArmor
            // 
            this.pLabelFurnaceArmor.AutoSize = true;
            this.pLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceArmor.Location = new System.Drawing.Point(152, 457);
            this.pLabelFurnaceArmor.Name = "pLabelFurnaceArmor";
            this.pLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelFurnaceArmor.TabIndex = 39;
            this.pLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFurnaceLife
            // 
            this.eLabelFurnaceLife.AutoSize = true;
            this.eLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceLife.Location = new System.Drawing.Point(1713, 475);
            this.eLabelFurnaceLife.Name = "eLabelFurnaceLife";
            this.eLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelFurnaceLife.TabIndex = 53;
            this.eLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // eLabelFurnaceArmor
            // 
            this.eLabelFurnaceArmor.AutoSize = true;
            this.eLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceArmor.Location = new System.Drawing.Point(1713, 457);
            this.eLabelFurnaceArmor.Name = "eLabelFurnaceArmor";
            this.eLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelFurnaceArmor.TabIndex = 52;
            this.eLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // labelFurnace
            // 
            this.labelFurnace.AutoSize = true;
            this.labelFurnace.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFurnace.Location = new System.Drawing.Point(1709, 418);
            this.labelFurnace.Name = "labelFurnace";
            this.labelFurnace.Size = new System.Drawing.Size(71, 17);
            this.labelFurnace.TabIndex = 51;
            this.labelFurnace.Text = "FURNACE";
            // 
            // labelLegs
            // 
            this.labelLegs.AutoSize = true;
            this.labelLegs.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLegs.Location = new System.Drawing.Point(1830, 512);
            this.labelLegs.Name = "labelLegs";
            this.labelLegs.Size = new System.Drawing.Size(43, 17);
            this.labelLegs.TabIndex = 50;
            this.labelLegs.Text = "LEGS";
            // 
            // labelLeftArm
            // 
            this.labelLeftArm.AutoSize = true;
            this.labelLeftArm.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftArm.ForeColor = System.Drawing.Color.Black;
            this.labelLeftArm.Location = new System.Drawing.Point(1597, 418);
            this.labelLeftArm.Name = "labelLeftArm";
            this.labelLeftArm.Size = new System.Drawing.Size(75, 17);
            this.labelLeftArm.TabIndex = 49;
            this.labelLeftArm.Text = "LEFT ARM";
            // 
            // labelRightArm
            // 
            this.labelRightArm.AutoSize = true;
            this.labelRightArm.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightArm.Location = new System.Drawing.Point(1811, 418);
            this.labelRightArm.Name = "labelRightArm";
            this.labelRightArm.Size = new System.Drawing.Size(84, 17);
            this.labelRightArm.TabIndex = 48;
            this.labelRightArm.Text = "RIGHT ARM";
            // 
            // eLabelLegsLife
            // 
            this.eLabelLegsLife.AutoSize = true;
            this.eLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsLife.Location = new System.Drawing.Point(1819, 559);
            this.eLabelLegsLife.Name = "eLabelLegsLife";
            this.eLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLegsLife.TabIndex = 47;
            this.eLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // eLabelLegsArmor
            // 
            this.eLabelLegsArmor.AutoSize = true;
            this.eLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsArmor.Location = new System.Drawing.Point(1819, 541);
            this.eLabelLegsArmor.Name = "eLabelLegsArmor";
            this.eLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLegsArmor.TabIndex = 46;
            this.eLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelRightLife
            // 
            this.eLabelRightLife.AutoSize = true;
            this.eLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightLife.Location = new System.Drawing.Point(1819, 475);
            this.eLabelRightLife.Name = "eLabelRightLife";
            this.eLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelRightLife.TabIndex = 45;
            this.eLabelRightLife.Text = "LIFE: 0/0";
            // 
            // eLabelRightArmor
            // 
            this.eLabelRightArmor.AutoSize = true;
            this.eLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightArmor.Location = new System.Drawing.Point(1819, 457);
            this.eLabelRightArmor.Name = "eLabelRightArmor";
            this.eLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelRightArmor.TabIndex = 44;
            this.eLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelLeftLife
            // 
            this.eLabelLeftLife.AutoSize = true;
            this.eLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelLeftLife.Location = new System.Drawing.Point(1599, 475);
            this.eLabelLeftLife.Name = "eLabelLeftLife";
            this.eLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLeftLife.TabIndex = 43;
            this.eLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // eLabelLeftArmor
            // 
            this.eLabelLeftArmor.AutoSize = true;
            this.eLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLeftArmor.Location = new System.Drawing.Point(1599, 457);
            this.eLabelLeftArmor.Name = "eLabelLeftArmor";
            this.eLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLeftArmor.TabIndex = 42;
            this.eLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFuel
            // 
            this.eLabelFuel.AutoSize = true;
            this.eLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelFuel.Location = new System.Drawing.Point(1668, 602);
            this.eLabelFuel.Name = "eLabelFuel";
            this.eLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.eLabelFuel.TabIndex = 41;
            this.eLabelFuel.Text = "FUEL 0";
            // 
            // pictureBoxEnnemiBot
            // 
            this.pictureBoxEnnemiBot.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxEnnemiBot.Image = global::PJS5_CSharp_Form.Properties.Resources.RobotEnnemi2;
            this.pictureBoxEnnemiBot.Location = new System.Drawing.Point(1644, 138);
            this.pictureBoxEnnemiBot.Name = "pictureBoxEnnemiBot";
            this.pictureBoxEnnemiBot.Size = new System.Drawing.Size(194, 217);
            this.pictureBoxEnnemiBot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEnnemiBot.TabIndex = 69;
            this.pictureBoxEnnemiBot.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::PJS5_CSharp_Form.Properties.Resources.RobotPlayer;
            this.pictureBox1.Location = new System.Drawing.Point(94, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // selectionSwitch31
            // 
            this.selectionSwitch31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.selectionSwitch31.Location = new System.Drawing.Point(1060, 394);
            this.selectionSwitch31.Name = "selectionSwitch31";
            this.selectionSwitch31.Size = new System.Drawing.Size(226, 231);
            this.selectionSwitch31.TabIndex = 67;
            this.selectionSwitch31.Value = 0;
            this.selectionSwitch31.Visible = false;
            this.selectionSwitch31.Load += new System.EventHandler(this.selectionSwitch31_Load);
            this.selectionSwitch31.MouseLeave += new System.EventHandler(this.selectionSwitch31_MouseLeave);
            // 
            // selectionSwitch21
            // 
            this.selectionSwitch21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.selectionSwitch21.Location = new System.Drawing.Point(828, 394);
            this.selectionSwitch21.Name = "selectionSwitch21";
            this.selectionSwitch21.Size = new System.Drawing.Size(226, 231);
            this.selectionSwitch21.TabIndex = 66;
            this.selectionSwitch21.Value = 0;
            this.selectionSwitch21.Visible = false;
            this.selectionSwitch21.Load += new System.EventHandler(this.selectionSwitch21_Load);
            this.selectionSwitch21.MouseLeave += new System.EventHandler(this.selectionSwitch21_MouseLeave);
            // 
            // selectionSwitch1
            // 
            this.selectionSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.selectionSwitch1.Location = new System.Drawing.Point(596, 394);
            this.selectionSwitch1.Name = "selectionSwitch1";
            this.selectionSwitch1.Size = new System.Drawing.Size(226, 231);
            this.selectionSwitch1.TabIndex = 65;
            this.selectionSwitch1.Value = 0;
            this.selectionSwitch1.Load += new System.EventHandler(this.selectionSwitch1_Load);
            this.selectionSwitch1.MouseLeave += new System.EventHandler(this.selectionSwitch1_MouseLeave);
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 670);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxEnnemiBot);
            this.Controls.Add(this.selectionSwitch31);
            this.Controls.Add(this.selectionSwitch21);
            this.Controls.Add(this.selectionSwitch1);
            this.Controls.Add(this.eLabelFurnaceLife);
            this.Controls.Add(this.eLabelFurnaceArmor);
            this.Controls.Add(this.labelFurnace);
            this.Controls.Add(this.labelLegs);
            this.Controls.Add(this.labelLeftArm);
            this.Controls.Add(this.labelRightArm);
            this.Controls.Add(this.eLabelLegsLife);
            this.Controls.Add(this.eLabelLegsArmor);
            this.Controls.Add(this.eLabelRightLife);
            this.Controls.Add(this.eLabelRightArmor);
            this.Controls.Add(this.eLabelLeftLife);
            this.Controls.Add(this.eLabelLeftArmor);
            this.Controls.Add(this.eLabelFuel);
            this.Controls.Add(this.pLabelFurnaceLife);
            this.Controls.Add(this.pLabelFurnaceArmor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pLabelLegsLife);
            this.Controls.Add(this.pLabelLegsArmor);
            this.Controls.Add(this.pLabelRightLife);
            this.Controls.Add(this.pLabelRightArmor);
            this.Controls.Add(this.pLabelLeftLife);
            this.Controls.Add(this.pLabelLeftArmor);
            this.Controls.Add(this.pLabelFuel);
            this.Name = "CombatForm";
            this.ShowIcon = false;
            this.Text = "Umshini";
            this.Load += new System.EventHandler(this.CombatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnnemiBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer IntUpdater;
        private System.Windows.Forms.Label pLabelFuel;
        private System.Windows.Forms.Label pLabelLeftArmor;
        private System.Windows.Forms.Label pLabelLeftLife;
        private System.Windows.Forms.Label pLabelRightArmor;
        private System.Windows.Forms.Label pLabelRightLife;
        private System.Windows.Forms.Label pLabelLegsLife;
        private System.Windows.Forms.Label pLabelLegsArmor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label pLabelFurnaceLife;
        private System.Windows.Forms.Label pLabelFurnaceArmor;
        private System.Windows.Forms.Label eLabelFurnaceLife;
        private System.Windows.Forms.Label eLabelFurnaceArmor;
        private System.Windows.Forms.Label labelFurnace;
        private System.Windows.Forms.Label labelLegs;
        private System.Windows.Forms.Label labelLeftArm;
        private System.Windows.Forms.Label labelRightArm;
        private System.Windows.Forms.Label eLabelLegsLife;
        private System.Windows.Forms.Label eLabelLegsArmor;
        private System.Windows.Forms.Label eLabelRightLife;
        private System.Windows.Forms.Label eLabelRightArmor;
        private System.Windows.Forms.Label eLabelLeftLife;
        private System.Windows.Forms.Label eLabelLeftArmor;
        private System.Windows.Forms.Label eLabelFuel;
        private SelectionSwitch selectionSwitch1;
        private SelectionSwitch2 selectionSwitch21;
        private SelectionSwitch3 selectionSwitch31;
        private System.Windows.Forms.PictureBox pictureBoxEnnemiBot;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

