namespace UGUI
{
    partial class StartingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.customButton1 = new UGUI.CustomButton();
            this.customButton2 = new UGUI.CustomButton();
            this.customButton3 = new UGUI.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 50F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(422, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "Umshini";
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton1.LabelText = "Start game";
            this.customButton1.Location = new System.Drawing.Point(343, 143);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(389, 47);
            this.customButton1.TabIndex = 7;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.customButton2.LabelText = "Choosing equipment";
            this.customButton2.Location = new System.Drawing.Point(343, 196);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(389, 47);
            this.customButton2.TabIndex = 8;
            this.customButton2.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // customButton3
            // 
            this.customButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.customButton3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.customButton3.LabelText = "Quit game";
            this.customButton3.Location = new System.Drawing.Point(343, 249);
            this.customButton3.Name = "customButton3";
            this.customButton3.Size = new System.Drawing.Size(389, 47);
            this.customButton3.TabIndex = 9;
            this.customButton3.Click += new System.EventHandler(this.customButton3_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1090, 551);
            this.Controls.Add(this.customButton3);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.label1);
            this.Name = "StartingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Umshini";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartingForm_FormClosing);
            this.Load += new System.EventHandler(this.StartingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomButton customButton1;
        private CustomButton customButton2;
        private CustomButton customButton3;
    }
}