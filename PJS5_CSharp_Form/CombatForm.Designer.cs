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
            this.guiAttackButton = new System.Windows.Forms.Button();
            this.guiRepairsButton = new System.Windows.Forms.Button();
            this.guiFuelButton = new System.Windows.Forms.Button();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.eLabelLegsLife = new System.Windows.Forms.Label();
            this.eLabelLegsArmor = new System.Windows.Forms.Label();
            this.eLabelRightLife = new System.Windows.Forms.Label();
            this.eLabelRightArmor = new System.Windows.Forms.Label();
            this.eLabelLeftLife = new System.Windows.Forms.Label();
            this.eLabelLeftArmor = new System.Windows.Forms.Label();
            this.eLabelFuel = new System.Windows.Forms.Label();
            this.guiBackButton = new System.Windows.Forms.Button();
            this.guiRightWeaponButton = new System.Windows.Forms.Button();
            this.guiLeftWeaponButton = new System.Windows.Forms.Button();
            this.guiLegsButton = new System.Windows.Forms.Button();
            this.guiRightWeaponButton2 = new System.Windows.Forms.Button();
            this.guiLeftWeaponButton2 = new System.Windows.Forms.Button();
            this.guiFurnaceButton = new System.Windows.Forms.Button();
            this.guiBackButton2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selectionSwitch1 = new PJS5_CSharp_Form.SelectionSwitch();
            this.SuspendLayout();
            // 
            // IntUpdater
            // 
            this.IntUpdater.Tick += new System.EventHandler(this.IntUpdater_Tick);
            // 
            // guiAttackButton
            // 
            this.guiAttackButton.Location = new System.Drawing.Point(340, 486);
            this.guiAttackButton.Name = "guiAttackButton";
            this.guiAttackButton.Size = new System.Drawing.Size(174, 23);
            this.guiAttackButton.TabIndex = 24;
            this.guiAttackButton.Text = "1 - ATTACK";
            this.guiAttackButton.UseVisualStyleBackColor = true;
            this.guiAttackButton.Click += new System.EventHandler(this.guiAttackButton_Click);
            // 
            // guiRepairsButton
            // 
            this.guiRepairsButton.Location = new System.Drawing.Point(340, 515);
            this.guiRepairsButton.Name = "guiRepairsButton";
            this.guiRepairsButton.Size = new System.Drawing.Size(174, 23);
            this.guiRepairsButton.TabIndex = 25;
            this.guiRepairsButton.Text = "2 - REPAIR";
            this.guiRepairsButton.UseVisualStyleBackColor = true;
            this.guiRepairsButton.Click += new System.EventHandler(this.guiRepairsButton_Click);
            // 
            // guiFuelButton
            // 
            this.guiFuelButton.Location = new System.Drawing.Point(340, 544);
            this.guiFuelButton.Name = "guiFuelButton";
            this.guiFuelButton.Size = new System.Drawing.Size(174, 23);
            this.guiFuelButton.TabIndex = 26;
            this.guiFuelButton.Text = "3 - RE-FUEL";
            this.guiFuelButton.UseVisualStyleBackColor = true;
            this.guiFuelButton.Click += new System.EventHandler(this.guiFurnaceButton_Click);
            // 
            // pLabelFuel
            // 
            this.pLabelFuel.AutoSize = true;
            this.pLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelFuel.Location = new System.Drawing.Point(83, 630);
            this.pLabelFuel.Name = "pLabelFuel";
            this.pLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.pLabelFuel.TabIndex = 28;
            this.pLabelFuel.Text = "FUEL 0";
            // 
            // pLabelLeftArmor
            // 
            this.pLabelLeftArmor.AutoSize = true;
            this.pLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLeftArmor.Location = new System.Drawing.Point(14, 485);
            this.pLabelLeftArmor.Name = "pLabelLeftArmor";
            this.pLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLeftArmor.TabIndex = 29;
            this.pLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelLeftLife
            // 
            this.pLabelLeftLife.AutoSize = true;
            this.pLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelLeftLife.Location = new System.Drawing.Point(14, 503);
            this.pLabelLeftLife.Name = "pLabelLeftLife";
            this.pLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLeftLife.TabIndex = 30;
            this.pLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // pLabelRightArmor
            // 
            this.pLabelRightArmor.AutoSize = true;
            this.pLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightArmor.Location = new System.Drawing.Point(234, 485);
            this.pLabelRightArmor.Name = "pLabelRightArmor";
            this.pLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelRightArmor.TabIndex = 31;
            this.pLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelRightLife
            // 
            this.pLabelRightLife.AutoSize = true;
            this.pLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightLife.Location = new System.Drawing.Point(234, 503);
            this.pLabelRightLife.Name = "pLabelRightLife";
            this.pLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelRightLife.TabIndex = 32;
            this.pLabelRightLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsLife
            // 
            this.pLabelLegsLife.AutoSize = true;
            this.pLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsLife.Location = new System.Drawing.Point(234, 587);
            this.pLabelLegsLife.Name = "pLabelLegsLife";
            this.pLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLegsLife.TabIndex = 34;
            this.pLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsArmor
            // 
            this.pLabelLegsArmor.AutoSize = true;
            this.pLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsArmor.Location = new System.Drawing.Point(234, 569);
            this.pLabelLegsArmor.Name = "pLabelLegsArmor";
            this.pLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLegsArmor.TabIndex = 33;
            this.pLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 446);
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
            this.label2.Location = new System.Drawing.Point(12, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "LEFT ARM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(245, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "LEGS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "FURNACE";
            // 
            // pLabelFurnaceLife
            // 
            this.pLabelFurnaceLife.AutoSize = true;
            this.pLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceLife.Location = new System.Drawing.Point(128, 503);
            this.pLabelFurnaceLife.Name = "pLabelFurnaceLife";
            this.pLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelFurnaceLife.TabIndex = 40;
            this.pLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // pLabelFurnaceArmor
            // 
            this.pLabelFurnaceArmor.AutoSize = true;
            this.pLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceArmor.Location = new System.Drawing.Point(128, 485);
            this.pLabelFurnaceArmor.Name = "pLabelFurnaceArmor";
            this.pLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelFurnaceArmor.TabIndex = 39;
            this.pLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFurnaceLife
            // 
            this.eLabelFurnaceLife.AutoSize = true;
            this.eLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceLife.Location = new System.Drawing.Point(1051, 503);
            this.eLabelFurnaceLife.Name = "eLabelFurnaceLife";
            this.eLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelFurnaceLife.TabIndex = 53;
            this.eLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // eLabelFurnaceArmor
            // 
            this.eLabelFurnaceArmor.AutoSize = true;
            this.eLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceArmor.Location = new System.Drawing.Point(1051, 485);
            this.eLabelFurnaceArmor.Name = "eLabelFurnaceArmor";
            this.eLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelFurnaceArmor.TabIndex = 52;
            this.eLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1047, 446);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 51;
            this.label7.Text = "FURNACE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1168, 540);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "LEGS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(935, 446);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = "LEFT ARM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1149, 446);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "RIGHT ARM";
            // 
            // eLabelLegsLife
            // 
            this.eLabelLegsLife.AutoSize = true;
            this.eLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsLife.Location = new System.Drawing.Point(1157, 587);
            this.eLabelLegsLife.Name = "eLabelLegsLife";
            this.eLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLegsLife.TabIndex = 47;
            this.eLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // eLabelLegsArmor
            // 
            this.eLabelLegsArmor.AutoSize = true;
            this.eLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsArmor.Location = new System.Drawing.Point(1157, 569);
            this.eLabelLegsArmor.Name = "eLabelLegsArmor";
            this.eLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLegsArmor.TabIndex = 46;
            this.eLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelRightLife
            // 
            this.eLabelRightLife.AutoSize = true;
            this.eLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightLife.Location = new System.Drawing.Point(1157, 503);
            this.eLabelRightLife.Name = "eLabelRightLife";
            this.eLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelRightLife.TabIndex = 45;
            this.eLabelRightLife.Text = "LIFE: 0/0";
            // 
            // eLabelRightArmor
            // 
            this.eLabelRightArmor.AutoSize = true;
            this.eLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightArmor.Location = new System.Drawing.Point(1157, 485);
            this.eLabelRightArmor.Name = "eLabelRightArmor";
            this.eLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelRightArmor.TabIndex = 44;
            this.eLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelLeftLife
            // 
            this.eLabelLeftLife.AutoSize = true;
            this.eLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelLeftLife.Location = new System.Drawing.Point(937, 503);
            this.eLabelLeftLife.Name = "eLabelLeftLife";
            this.eLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLeftLife.TabIndex = 43;
            this.eLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // eLabelLeftArmor
            // 
            this.eLabelLeftArmor.AutoSize = true;
            this.eLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLeftArmor.Location = new System.Drawing.Point(937, 485);
            this.eLabelLeftArmor.Name = "eLabelLeftArmor";
            this.eLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLeftArmor.TabIndex = 42;
            this.eLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFuel
            // 
            this.eLabelFuel.AutoSize = true;
            this.eLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelFuel.Location = new System.Drawing.Point(1006, 630);
            this.eLabelFuel.Name = "eLabelFuel";
            this.eLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.eLabelFuel.TabIndex = 41;
            this.eLabelFuel.Text = "FUEL 0";
            // 
            // guiBackButton
            // 
            this.guiBackButton.Location = new System.Drawing.Point(534, 544);
            this.guiBackButton.Name = "guiBackButton";
            this.guiBackButton.Size = new System.Drawing.Size(174, 23);
            this.guiBackButton.TabIndex = 57;
            this.guiBackButton.Text = "0 - BACK";
            this.guiBackButton.UseVisualStyleBackColor = true;
            this.guiBackButton.Click += new System.EventHandler(this.guiBackButton_Click_1);
            // 
            // guiRightWeaponButton
            // 
            this.guiRightWeaponButton.Location = new System.Drawing.Point(534, 515);
            this.guiRightWeaponButton.Name = "guiRightWeaponButton";
            this.guiRightWeaponButton.Size = new System.Drawing.Size(174, 23);
            this.guiRightWeaponButton.TabIndex = 55;
            this.guiRightWeaponButton.Text = "2 - RIGHT WEAPON";
            this.guiRightWeaponButton.UseVisualStyleBackColor = true;
            this.guiRightWeaponButton.Click += new System.EventHandler(this.guiRightWeaponButton_Click);
            // 
            // guiLeftWeaponButton
            // 
            this.guiLeftWeaponButton.Location = new System.Drawing.Point(534, 486);
            this.guiLeftWeaponButton.Name = "guiLeftWeaponButton";
            this.guiLeftWeaponButton.Size = new System.Drawing.Size(174, 23);
            this.guiLeftWeaponButton.TabIndex = 54;
            this.guiLeftWeaponButton.Text = "1 - LEFT WEAPON";
            this.guiLeftWeaponButton.UseVisualStyleBackColor = true;
            this.guiLeftWeaponButton.Click += new System.EventHandler(this.guiLeftWeaponButton_Click);
            // 
            // guiLegsButton
            // 
            this.guiLegsButton.Location = new System.Drawing.Point(738, 516);
            this.guiLegsButton.Name = "guiLegsButton";
            this.guiLegsButton.Size = new System.Drawing.Size(174, 23);
            this.guiLegsButton.TabIndex = 60;
            this.guiLegsButton.Text = "3 - LEGS";
            this.guiLegsButton.UseVisualStyleBackColor = true;
            this.guiLegsButton.Click += new System.EventHandler(this.guiLegsButton_Click);
            // 
            // guiRightWeaponButton2
            // 
            this.guiRightWeaponButton2.Location = new System.Drawing.Point(738, 489);
            this.guiRightWeaponButton2.Name = "guiRightWeaponButton2";
            this.guiRightWeaponButton2.Size = new System.Drawing.Size(174, 23);
            this.guiRightWeaponButton2.TabIndex = 59;
            this.guiRightWeaponButton2.Text = "2 - RIGHT WEAPON";
            this.guiRightWeaponButton2.UseVisualStyleBackColor = true;
            this.guiRightWeaponButton2.Click += new System.EventHandler(this.guiRightWeaponButton2_Click);
            // 
            // guiLeftWeaponButton2
            // 
            this.guiLeftWeaponButton2.Location = new System.Drawing.Point(738, 460);
            this.guiLeftWeaponButton2.Name = "guiLeftWeaponButton2";
            this.guiLeftWeaponButton2.Size = new System.Drawing.Size(174, 23);
            this.guiLeftWeaponButton2.TabIndex = 58;
            this.guiLeftWeaponButton2.Text = "1 - LEFT WEAPON";
            this.guiLeftWeaponButton2.UseVisualStyleBackColor = true;
            this.guiLeftWeaponButton2.Click += new System.EventHandler(this.guiLeftWeaponButton2_Click);
            // 
            // guiFurnaceButton
            // 
            this.guiFurnaceButton.Location = new System.Drawing.Point(738, 542);
            this.guiFurnaceButton.Name = "guiFurnaceButton";
            this.guiFurnaceButton.Size = new System.Drawing.Size(174, 23);
            this.guiFurnaceButton.TabIndex = 61;
            this.guiFurnaceButton.Text = "4 - FURNACE";
            this.guiFurnaceButton.UseVisualStyleBackColor = true;
            this.guiFurnaceButton.Click += new System.EventHandler(this.guiFurnaceButton_Click_1);
            // 
            // guiBackButton2
            // 
            this.guiBackButton2.Location = new System.Drawing.Point(738, 571);
            this.guiBackButton2.Name = "guiBackButton2";
            this.guiBackButton2.Size = new System.Drawing.Size(174, 23);
            this.guiBackButton2.TabIndex = 62;
            this.guiBackButton2.Text = "0 - BACK";
            this.guiBackButton2.UseVisualStyleBackColor = true;
            this.guiBackButton2.Click += new System.EventHandler(this.guiBackButton2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1009, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 64;
            this.label5.Text = "SWITCH PROTOTYPE";
            // 
            // selectionSwitch1
            // 
            this.selectionSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.selectionSwitch1.Location = new System.Drawing.Point(938, 93);
            this.selectionSwitch1.Name = "selectionSwitch1";
            this.selectionSwitch1.Size = new System.Drawing.Size(251, 238);
            this.selectionSwitch1.TabIndex = 63;
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 676);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectionSwitch1);
            this.Controls.Add(this.guiBackButton2);
            this.Controls.Add(this.guiFurnaceButton);
            this.Controls.Add(this.guiLegsButton);
            this.Controls.Add(this.guiRightWeaponButton2);
            this.Controls.Add(this.guiLeftWeaponButton2);
            this.Controls.Add(this.guiBackButton);
            this.Controls.Add(this.guiRightWeaponButton);
            this.Controls.Add(this.guiLeftWeaponButton);
            this.Controls.Add(this.eLabelFurnaceLife);
            this.Controls.Add(this.eLabelFurnaceArmor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
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
            this.Controls.Add(this.guiFuelButton);
            this.Controls.Add(this.guiRepairsButton);
            this.Controls.Add(this.guiAttackButton);
            this.Name = "CombatForm";
            this.ShowIcon = false;
            this.Text = "Umshini";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer IntUpdater;
        private System.Windows.Forms.Button guiAttackButton;
        private System.Windows.Forms.Button guiRepairsButton;
        private System.Windows.Forms.Button guiFuelButton;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label eLabelLegsLife;
        private System.Windows.Forms.Label eLabelLegsArmor;
        private System.Windows.Forms.Label eLabelRightLife;
        private System.Windows.Forms.Label eLabelRightArmor;
        private System.Windows.Forms.Label eLabelLeftLife;
        private System.Windows.Forms.Label eLabelLeftArmor;
        private System.Windows.Forms.Label eLabelFuel;
        private System.Windows.Forms.Button guiBackButton;
        private System.Windows.Forms.Button guiRightWeaponButton;
        private System.Windows.Forms.Button guiLeftWeaponButton;
        private System.Windows.Forms.Button guiLegsButton;
        private System.Windows.Forms.Button guiRightWeaponButton2;
        private System.Windows.Forms.Button guiLeftWeaponButton2;
        private System.Windows.Forms.Button guiFurnaceButton;
        private System.Windows.Forms.Button guiBackButton2;
        private SelectionSwitch selectionSwitch1;
        private System.Windows.Forms.Label label5;
    }
}

