﻿namespace HiPiaoTerminal.TestForm
{
    partial class KeyBoardTestForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.userInputPanel1 = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(264, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // userInputPanel1
            // 
            this.userInputPanel1.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.userInputPanel1.BackColor = System.Drawing.Color.ForestGreen;
            this.userInputPanel1.Font = new System.Drawing.Font("宋体", 21F);
            this.userInputPanel1.Hint = null;
            this.userInputPanel1.IsActive = false;
            this.userInputPanel1.IsDeleted = false;
            this.userInputPanel1.KeyboardType = 1;
            this.userInputPanel1.Location = new System.Drawing.Point(250, 37);
            this.userInputPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.userInputPanel1.MaxInputLength = 32767;
            this.userInputPanel1.Name = "userInputPanel1";
            this.userInputPanel1.PasswordChar = '\0';
            this.userInputPanel1.RelativeLabel = null;
            this.userInputPanel1.Size = new System.Drawing.Size(249, 74);
            this.userInputPanel1.TabIndex = 0;
            // 
            // KeyBoardTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(804, 516);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.userInputPanel1);
            this.Name = "KeyBoardTestForm";
            this.Text = "KeyBoardTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HiPiaoTerminal.UserControlEx.UserInputPanel userInputPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}