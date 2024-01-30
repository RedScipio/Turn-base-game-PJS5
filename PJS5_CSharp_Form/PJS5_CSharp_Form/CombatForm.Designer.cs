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
            this.guiPlayerFurnaceArmor = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guiPlayerLegsArmor = new System.Windows.Forms.ProgressBar();
            this.guiPlayerWeaponLArmor = new System.Windows.Forms.ProgressBar();
            this.guiPlayerWeaponRArmor = new System.Windows.Forms.ProgressBar();
            this.guiPlayerFuel = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guiEnnemiFuel = new System.Windows.Forms.ProgressBar();
            this.guiEnnemiWeaponRArmor = new System.Windows.Forms.ProgressBar();
            this.guiEnnemiWeaponLArmor = new System.Windows.Forms.ProgressBar();
            this.guiEnnemiLegsArmor = new System.Windows.Forms.ProgressBar();
            this.guiEnnemiFurnaceArmor = new System.Windows.Forms.ProgressBar();
            this.IntUpdater = new System.Windows.Forms.Timer(this.components);
            this.guiAttackButton = new System.Windows.Forms.Button();
            this.guiRepairsButton = new System.Windows.Forms.Button();
            this.guiFurnaceButton = new System.Windows.Forms.Button();
            this.guiBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guiPlayerFurnaceArmor
            // 
            this.guiPlayerFurnaceArmor.Location = new System.Drawing.Point(22, 347);
            this.guiPlayerFurnaceArmor.Maximum = 3;
            this.guiPlayerFurnaceArmor.Name = "guiPlayerFurnaceArmor";
            this.guiPlayerFurnaceArmor.Size = new System.Drawing.Size(287, 23);
            this.guiPlayerFurnaceArmor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(856, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ennemi";
            // 
            // guiPlayerLegsArmor
            // 
            this.guiPlayerLegsArmor.Location = new System.Drawing.Point(22, 376);
            this.guiPlayerLegsArmor.Maximum = 3;
            this.guiPlayerLegsArmor.Name = "guiPlayerLegsArmor";
            this.guiPlayerLegsArmor.Size = new System.Drawing.Size(287, 23);
            this.guiPlayerLegsArmor.TabIndex = 4;
            // 
            // guiPlayerWeaponLArmor
            // 
            this.guiPlayerWeaponLArmor.Location = new System.Drawing.Point(22, 405);
            this.guiPlayerWeaponLArmor.Maximum = 3;
            this.guiPlayerWeaponLArmor.Name = "guiPlayerWeaponLArmor";
            this.guiPlayerWeaponLArmor.Size = new System.Drawing.Size(143, 23);
            this.guiPlayerWeaponLArmor.TabIndex = 5;
            // 
            // guiPlayerWeaponRArmor
            // 
            this.guiPlayerWeaponRArmor.Location = new System.Drawing.Point(166, 405);
            this.guiPlayerWeaponRArmor.Maximum = 3;
            this.guiPlayerWeaponRArmor.Name = "guiPlayerWeaponRArmor";
            this.guiPlayerWeaponRArmor.Size = new System.Drawing.Size(143, 23);
            this.guiPlayerWeaponRArmor.TabIndex = 6;
            // 
            // guiPlayerFuel
            // 
            this.guiPlayerFuel.Location = new System.Drawing.Point(22, 493);
            this.guiPlayerFuel.Name = "guiPlayerFuel";
            this.guiPlayerFuel.Size = new System.Drawing.Size(287, 23);
            this.guiPlayerFuel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Furnace Armor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Legs Armor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "WeaponL armor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "WeaponR armor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fuel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(847, 519);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Fuel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(899, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "WeaponR armor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(764, 431);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "WeaponL armor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(648, 382);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Legs Armor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(649, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Furnace Armor";
            // 
            // guiEnnemiFuel
            // 
            this.guiEnnemiFuel.Location = new System.Drawing.Point(731, 493);
            this.guiEnnemiFuel.Name = "guiEnnemiFuel";
            this.guiEnnemiFuel.Size = new System.Drawing.Size(287, 23);
            this.guiEnnemiFuel.TabIndex = 17;
            // 
            // guiEnnemiWeaponRArmor
            // 
            this.guiEnnemiWeaponRArmor.Location = new System.Drawing.Point(875, 405);
            this.guiEnnemiWeaponRArmor.Maximum = 3;
            this.guiEnnemiWeaponRArmor.Name = "guiEnnemiWeaponRArmor";
            this.guiEnnemiWeaponRArmor.Size = new System.Drawing.Size(143, 23);
            this.guiEnnemiWeaponRArmor.TabIndex = 16;
            // 
            // guiEnnemiWeaponLArmor
            // 
            this.guiEnnemiWeaponLArmor.Location = new System.Drawing.Point(731, 405);
            this.guiEnnemiWeaponLArmor.Maximum = 3;
            this.guiEnnemiWeaponLArmor.Name = "guiEnnemiWeaponLArmor";
            this.guiEnnemiWeaponLArmor.Size = new System.Drawing.Size(143, 23);
            this.guiEnnemiWeaponLArmor.TabIndex = 15;
            // 
            // guiEnnemiLegsArmor
            // 
            this.guiEnnemiLegsArmor.Location = new System.Drawing.Point(731, 376);
            this.guiEnnemiLegsArmor.Maximum = 3;
            this.guiEnnemiLegsArmor.Name = "guiEnnemiLegsArmor";
            this.guiEnnemiLegsArmor.Size = new System.Drawing.Size(287, 23);
            this.guiEnnemiLegsArmor.TabIndex = 14;
            // 
            // guiEnnemiFurnaceArmor
            // 
            this.guiEnnemiFurnaceArmor.Location = new System.Drawing.Point(731, 347);
            this.guiEnnemiFurnaceArmor.Maximum = 3;
            this.guiEnnemiFurnaceArmor.Name = "guiEnnemiFurnaceArmor";
            this.guiEnnemiFurnaceArmor.Size = new System.Drawing.Size(287, 23);
            this.guiEnnemiFurnaceArmor.TabIndex = 13;
            // 
            // IntUpdater
            // 
            this.IntUpdater.Tick += new System.EventHandler(this.IntUpdater_Tick);
            // 
            // guiAttackButton
            // 
            this.guiAttackButton.Location = new System.Drawing.Point(374, 275);
            this.guiAttackButton.Name = "guiAttackButton";
            this.guiAttackButton.Size = new System.Drawing.Size(75, 23);
            this.guiAttackButton.TabIndex = 24;
            this.guiAttackButton.Text = "Attack";
            this.guiAttackButton.UseVisualStyleBackColor = true;
            this.guiAttackButton.Click += new System.EventHandler(this.guiAttackButton_Click);
            // 
            // guiRepairsButton
            // 
            this.guiRepairsButton.Location = new System.Drawing.Point(494, 275);
            this.guiRepairsButton.Name = "guiRepairsButton";
            this.guiRepairsButton.Size = new System.Drawing.Size(75, 23);
            this.guiRepairsButton.TabIndex = 25;
            this.guiRepairsButton.Text = "Repairs";
            this.guiRepairsButton.UseVisualStyleBackColor = true;
            this.guiRepairsButton.Click += new System.EventHandler(this.guiRepairsButton_Click);
            // 
            // guiFurnaceButton
            // 
            this.guiFurnaceButton.Location = new System.Drawing.Point(605, 275);
            this.guiFurnaceButton.Name = "guiFurnaceButton";
            this.guiFurnaceButton.Size = new System.Drawing.Size(75, 23);
            this.guiFurnaceButton.TabIndex = 26;
            this.guiFurnaceButton.Text = "Furnace";
            this.guiFurnaceButton.UseVisualStyleBackColor = true;
            // 
            // guiBackButton
            // 
            this.guiBackButton.Location = new System.Drawing.Point(494, 342);
            this.guiBackButton.Name = "guiBackButton";
            this.guiBackButton.Size = new System.Drawing.Size(75, 23);
            this.guiBackButton.TabIndex = 27;
            this.guiBackButton.Text = "Back";
            this.guiBackButton.UseVisualStyleBackColor = true;
            this.guiBackButton.Click += new System.EventHandler(this.guiBackButton_Click);
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 598);
            this.Controls.Add(this.guiBackButton);
            this.Controls.Add(this.guiFurnaceButton);
            this.Controls.Add(this.guiRepairsButton);
            this.Controls.Add(this.guiAttackButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.guiEnnemiFuel);
            this.Controls.Add(this.guiEnnemiWeaponRArmor);
            this.Controls.Add(this.guiEnnemiWeaponLArmor);
            this.Controls.Add(this.guiEnnemiLegsArmor);
            this.Controls.Add(this.guiEnnemiFurnaceArmor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guiPlayerFuel);
            this.Controls.Add(this.guiPlayerWeaponRArmor);
            this.Controls.Add(this.guiPlayerWeaponLArmor);
            this.Controls.Add(this.guiPlayerLegsArmor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guiPlayerFurnaceArmor);
            this.Name = "CombatForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar guiPlayerFurnaceArmor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar guiPlayerLegsArmor;
        private System.Windows.Forms.ProgressBar guiPlayerWeaponLArmor;
        private System.Windows.Forms.ProgressBar guiPlayerWeaponRArmor;
        private System.Windows.Forms.ProgressBar guiPlayerFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar guiEnnemiFuel;
        private System.Windows.Forms.ProgressBar guiEnnemiWeaponRArmor;
        private System.Windows.Forms.ProgressBar guiEnnemiWeaponLArmor;
        private System.Windows.Forms.ProgressBar guiEnnemiLegsArmor;
        private System.Windows.Forms.ProgressBar guiEnnemiFurnaceArmor;
        private System.Windows.Forms.Timer IntUpdater;
        private System.Windows.Forms.Button guiAttackButton;
        private System.Windows.Forms.Button guiRepairsButton;
        private System.Windows.Forms.Button guiFurnaceButton;
        private System.Windows.Forms.Button guiBackButton;
    }
}

