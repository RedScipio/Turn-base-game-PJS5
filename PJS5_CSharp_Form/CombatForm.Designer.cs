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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnnemiBot = new System.Windows.Forms.PictureBox();
            this.selectionSwitch31 = new PJS5_CSharp_Form.SelectionSwitch3();
            this.selectionSwitch21 = new PJS5_CSharp_Form.SelectionSwitch2();
            this.selectionSwitch1 = new PJS5_CSharp_Form.SelectionSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnnemiBot)).BeginInit();
            this.SuspendLayout();
            // 
            // IntUpdater
            // 
            this.IntUpdater.Tick += new System.EventHandler(this.IntUpdater_Tick);
            // 
            // pLabelFuel
            // 
            this.pLabelFuel.AutoSize = true;
            this.pLabelFuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelFuel.ForeColor = System.Drawing.Color.White;
            this.pLabelFuel.Location = new System.Drawing.Point(110, 938);
            this.pLabelFuel.Name = "pLabelFuel";
            this.pLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.pLabelFuel.TabIndex = 28;
            this.pLabelFuel.Text = "FUEL 0";
            // 
            // pLabelLeftArmor
            // 
            this.pLabelLeftArmor.AutoSize = true;
            this.pLabelLeftArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLeftArmor.ForeColor = System.Drawing.Color.White;
            this.pLabelLeftArmor.Location = new System.Drawing.Point(41, 793);
            this.pLabelLeftArmor.Name = "pLabelLeftArmor";
            this.pLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLeftArmor.TabIndex = 29;
            this.pLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelLeftLife
            // 
            this.pLabelLeftLife.AutoSize = true;
            this.pLabelLeftLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabelLeftLife.ForeColor = System.Drawing.Color.White;
            this.pLabelLeftLife.Location = new System.Drawing.Point(41, 811);
            this.pLabelLeftLife.Name = "pLabelLeftLife";
            this.pLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLeftLife.TabIndex = 30;
            this.pLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // pLabelRightArmor
            // 
            this.pLabelRightArmor.AutoSize = true;
            this.pLabelRightArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightArmor.ForeColor = System.Drawing.Color.White;
            this.pLabelRightArmor.Location = new System.Drawing.Point(261, 793);
            this.pLabelRightArmor.Name = "pLabelRightArmor";
            this.pLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelRightArmor.TabIndex = 31;
            this.pLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // pLabelRightLife
            // 
            this.pLabelRightLife.AutoSize = true;
            this.pLabelRightLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelRightLife.ForeColor = System.Drawing.Color.White;
            this.pLabelRightLife.Location = new System.Drawing.Point(261, 811);
            this.pLabelRightLife.Name = "pLabelRightLife";
            this.pLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelRightLife.TabIndex = 32;
            this.pLabelRightLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsLife
            // 
            this.pLabelLegsLife.AutoSize = true;
            this.pLabelLegsLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsLife.ForeColor = System.Drawing.Color.White;
            this.pLabelLegsLife.Location = new System.Drawing.Point(261, 895);
            this.pLabelLegsLife.Name = "pLabelLegsLife";
            this.pLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelLegsLife.TabIndex = 34;
            this.pLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // pLabelLegsArmor
            // 
            this.pLabelLegsArmor.AutoSize = true;
            this.pLabelLegsArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelLegsArmor.ForeColor = System.Drawing.Color.White;
            this.pLabelLegsArmor.Location = new System.Drawing.Point(261, 877);
            this.pLabelLegsArmor.Name = "pLabelLegsArmor";
            this.pLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelLegsArmor.TabIndex = 33;
            this.pLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(253, 754);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "RIGHT ARM";
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 754);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "LEFT ARM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(272, 848);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "LEGS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(151, 754);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "FURNACE";
            // 
            // pLabelFurnaceLife
            // 
            this.pLabelFurnaceLife.AutoSize = true;
            this.pLabelFurnaceLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceLife.ForeColor = System.Drawing.Color.White;
            this.pLabelFurnaceLife.Location = new System.Drawing.Point(155, 811);
            this.pLabelFurnaceLife.Name = "pLabelFurnaceLife";
            this.pLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.pLabelFurnaceLife.TabIndex = 40;
            this.pLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // pLabelFurnaceArmor
            // 
            this.pLabelFurnaceArmor.AutoSize = true;
            this.pLabelFurnaceArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.pLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.pLabelFurnaceArmor.ForeColor = System.Drawing.Color.White;
            this.pLabelFurnaceArmor.Location = new System.Drawing.Point(155, 793);
            this.pLabelFurnaceArmor.Name = "pLabelFurnaceArmor";
            this.pLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.pLabelFurnaceArmor.TabIndex = 39;
            this.pLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFurnaceLife
            // 
            this.eLabelFurnaceLife.AutoSize = true;
            this.eLabelFurnaceLife.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelFurnaceLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceLife.ForeColor = System.Drawing.Color.White;
            this.eLabelFurnaceLife.Location = new System.Drawing.Point(1660, 811);
            this.eLabelFurnaceLife.Name = "eLabelFurnaceLife";
            this.eLabelFurnaceLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelFurnaceLife.TabIndex = 53;
            this.eLabelFurnaceLife.Text = "LIFE: 0/0";
            // 
            // eLabelFurnaceArmor
            // 
            this.eLabelFurnaceArmor.AutoSize = true;
            this.eLabelFurnaceArmor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelFurnaceArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelFurnaceArmor.ForeColor = System.Drawing.Color.White;
            this.eLabelFurnaceArmor.Location = new System.Drawing.Point(1660, 793);
            this.eLabelFurnaceArmor.Name = "eLabelFurnaceArmor";
            this.eLabelFurnaceArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelFurnaceArmor.TabIndex = 52;
            this.eLabelFurnaceArmor.Text = "ARMOR: 0/0";
            // 
            // labelFurnace
            // 
            this.labelFurnace.AutoSize = true;
            this.labelFurnace.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelFurnace.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFurnace.ForeColor = System.Drawing.Color.White;
            this.labelFurnace.Location = new System.Drawing.Point(1649, 744);
            this.labelFurnace.Name = "labelFurnace";
            this.labelFurnace.Size = new System.Drawing.Size(71, 17);
            this.labelFurnace.TabIndex = 51;
            this.labelFurnace.Text = "FURNACE";
            // 
            // labelLegs
            // 
            this.labelLegs.AutoSize = true;
            this.labelLegs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelLegs.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLegs.ForeColor = System.Drawing.Color.White;
            this.labelLegs.Location = new System.Drawing.Point(1777, 848);
            this.labelLegs.Name = "labelLegs";
            this.labelLegs.Size = new System.Drawing.Size(43, 17);
            this.labelLegs.TabIndex = 50;
            this.labelLegs.Text = "LEGS";
            // 
            // labelLeftArm
            // 
            this.labelLeftArm.AutoSize = true;
            this.labelLeftArm.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelLeftArm.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftArm.ForeColor = System.Drawing.Color.White;
            this.labelLeftArm.Location = new System.Drawing.Point(1537, 744);
            this.labelLeftArm.Name = "labelLeftArm";
            this.labelLeftArm.Size = new System.Drawing.Size(75, 17);
            this.labelLeftArm.TabIndex = 49;
            this.labelLeftArm.Text = "LEFT ARM";
            // 
            // labelRightArm
            // 
            this.labelRightArm.AutoSize = true;
            this.labelRightArm.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelRightArm.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightArm.ForeColor = System.Drawing.Color.White;
            this.labelRightArm.Location = new System.Drawing.Point(1751, 744);
            this.labelRightArm.Name = "labelRightArm";
            this.labelRightArm.Size = new System.Drawing.Size(84, 17);
            this.labelRightArm.TabIndex = 48;
            this.labelRightArm.Text = "RIGHT ARM";
            // 
            // eLabelLegsLife
            // 
            this.eLabelLegsLife.AutoSize = true;
            this.eLabelLegsLife.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelLegsLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsLife.ForeColor = System.Drawing.Color.White;
            this.eLabelLegsLife.Location = new System.Drawing.Point(1766, 895);
            this.eLabelLegsLife.Name = "eLabelLegsLife";
            this.eLabelLegsLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLegsLife.TabIndex = 47;
            this.eLabelLegsLife.Text = "LIFE: 0/0";
            // 
            // eLabelLegsArmor
            // 
            this.eLabelLegsArmor.AutoSize = true;
            this.eLabelLegsArmor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelLegsArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLegsArmor.ForeColor = System.Drawing.Color.White;
            this.eLabelLegsArmor.Location = new System.Drawing.Point(1766, 877);
            this.eLabelLegsArmor.Name = "eLabelLegsArmor";
            this.eLabelLegsArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLegsArmor.TabIndex = 46;
            this.eLabelLegsArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelRightLife
            // 
            this.eLabelRightLife.AutoSize = true;
            this.eLabelRightLife.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelRightLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightLife.ForeColor = System.Drawing.Color.White;
            this.eLabelRightLife.Location = new System.Drawing.Point(1766, 811);
            this.eLabelRightLife.Name = "eLabelRightLife";
            this.eLabelRightLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelRightLife.TabIndex = 45;
            this.eLabelRightLife.Text = "LIFE: 0/0";
            // 
            // eLabelRightArmor
            // 
            this.eLabelRightArmor.AutoSize = true;
            this.eLabelRightArmor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelRightArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelRightArmor.ForeColor = System.Drawing.Color.White;
            this.eLabelRightArmor.Location = new System.Drawing.Point(1766, 793);
            this.eLabelRightArmor.Name = "eLabelRightArmor";
            this.eLabelRightArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelRightArmor.TabIndex = 44;
            this.eLabelRightArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelLeftLife
            // 
            this.eLabelLeftLife.AutoSize = true;
            this.eLabelLeftLife.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelLeftLife.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelLeftLife.ForeColor = System.Drawing.Color.White;
            this.eLabelLeftLife.Location = new System.Drawing.Point(1546, 811);
            this.eLabelLeftLife.Name = "eLabelLeftLife";
            this.eLabelLeftLife.Size = new System.Drawing.Size(54, 14);
            this.eLabelLeftLife.TabIndex = 43;
            this.eLabelLeftLife.Text = "LIFE: 0/0";
            // 
            // eLabelLeftArmor
            // 
            this.eLabelLeftArmor.AutoSize = true;
            this.eLabelLeftArmor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelLeftArmor.Font = new System.Drawing.Font("Yu Gothic", 8.25F);
            this.eLabelLeftArmor.ForeColor = System.Drawing.Color.White;
            this.eLabelLeftArmor.Location = new System.Drawing.Point(1546, 793);
            this.eLabelLeftArmor.Name = "eLabelLeftArmor";
            this.eLabelLeftArmor.Size = new System.Drawing.Size(69, 14);
            this.eLabelLeftArmor.TabIndex = 42;
            this.eLabelLeftArmor.Text = "ARMOR: 0/0";
            // 
            // eLabelFuel
            // 
            this.eLabelFuel.AutoSize = true;
            this.eLabelFuel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.eLabelFuel.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabelFuel.ForeColor = System.Drawing.Color.White;
            this.eLabelFuel.Location = new System.Drawing.Point(1615, 938);
            this.eLabelFuel.Name = "eLabelFuel";
            this.eLabelFuel.Size = new System.Drawing.Size(107, 35);
            this.eLabelFuel.TabIndex = 41;
            this.eLabelFuel.Text = "FUEL 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PJS5_CSharp_Form.Properties.Resources.RobotPlayer;
            this.pictureBox1.Location = new System.Drawing.Point(56, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxEnnemiBot
            // 
            this.pictureBoxEnnemiBot.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEnnemiBot.Image = global::PJS5_CSharp_Form.Properties.Resources.RobotEnnemi2;
            this.pictureBoxEnnemiBot.Location = new System.Drawing.Point(1664, 437);
            this.pictureBoxEnnemiBot.Name = "pictureBoxEnnemiBot";
            this.pictureBoxEnnemiBot.Size = new System.Drawing.Size(194, 217);
            this.pictureBoxEnnemiBot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEnnemiBot.TabIndex = 69;
            this.pictureBoxEnnemiBot.TabStop = false;
            // 
            // selectionSwitch31
            // 
            this.selectionSwitch31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.selectionSwitch31.Location = new System.Drawing.Point(1085, 744);
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
            this.selectionSwitch21.Location = new System.Drawing.Point(853, 744);
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
            this.selectionSwitch1.Location = new System.Drawing.Point(621, 744);
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
            this.BackgroundImage = global::PJS5_CSharp_Form.Properties.Resources.All_Menu_texture_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pLabelFuel);
            this.Controls.Add(this.pLabelLeftArmor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pLabelLeftLife);
            this.Controls.Add(this.pictureBoxEnnemiBot);
            this.Controls.Add(this.pLabelRightArmor);
            this.Controls.Add(this.selectionSwitch31);
            this.Controls.Add(this.pLabelRightLife);
            this.Controls.Add(this.labelFurnace);
            this.Controls.Add(this.pLabelLegsArmor);
            this.Controls.Add(this.eLabelLeftLife);
            this.Controls.Add(this.pLabelLegsLife);
            this.Controls.Add(this.selectionSwitch21);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eLabelRightArmor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectionSwitch1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eLabelLeftArmor);
            this.Controls.Add(this.pLabelFurnaceArmor);
            this.Controls.Add(this.eLabelRightLife);
            this.Controls.Add(this.pLabelFurnaceLife);
            this.Controls.Add(this.eLabelFuel);
            this.Controls.Add(this.eLabelFurnaceLife);
            this.Controls.Add(this.eLabelLegsArmor);
            this.Controls.Add(this.eLabelLegsLife);
            this.Controls.Add(this.eLabelFurnaceArmor);
            this.Controls.Add(this.labelRightArm);
            this.Controls.Add(this.labelLeftArm);
            this.Controls.Add(this.labelLegs);
            this.DoubleBuffered = true;
            this.Name = "CombatForm";
            this.ShowIcon = false;
            this.Text = "Umshini";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CombatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnnemiBot)).EndInit();
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

