﻿namespace HiPiaoTerminal.Maintain
{
    partial class ManagerLoginWithPwdPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnManagerLogin = new System.Windows.Forms.PictureBox();
            this.lbReturnMsg = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtManagePwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManagerLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_Login_Hint;
            this.pictureBox1.Location = new System.Drawing.Point(0, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 68);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_Login_Pwd;
            this.pictureBox2.Location = new System.Drawing.Point(156, 430);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 71);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btnManagerLogin
            // 
            this.btnManagerLogin.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Manager_Login;
            this.btnManagerLogin.Location = new System.Drawing.Point(839, 427);
            this.btnManagerLogin.Name = "btnManagerLogin";
            this.btnManagerLogin.Size = new System.Drawing.Size(171, 74);
            this.btnManagerLogin.TabIndex = 5;
            this.btnManagerLogin.TabStop = false;
            this.btnManagerLogin.Click += new System.EventHandler(this.btnManagerLogin_Click);
            // 
            // lbReturnMsg
            // 
            this.lbReturnMsg.AutoSize = true;
            this.lbReturnMsg.BackColor = System.Drawing.SystemColors.Window;
            this.lbReturnMsg.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReturnMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbReturnMsg.Location = new System.Drawing.Point(156, 276);
            this.lbReturnMsg.Name = "lbReturnMsg";
            this.lbReturnMsg.Size = new System.Drawing.Size(0, 32);
            this.lbReturnMsg.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbReturnMsg.TabIndex = 7;
            // 
            // txtManagePwd
            // 
            this.txtManagePwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.AllowAll;
            this.txtManagePwd.BackColor = System.Drawing.Color.Transparent;
            this.txtManagePwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtManagePwd.Hint = null;
            this.txtManagePwd.IsActive = true;
            this.txtManagePwd.IsDeleted = false;
            this.txtManagePwd.KeyboardType = 5;
            this.txtManagePwd.Location = new System.Drawing.Point(381, 428);
            this.txtManagePwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtManagePwd.MaxInputLength = 12;
            this.txtManagePwd.Name = "txtManagePwd";
            this.txtManagePwd.PasswordChar = '*';
            this.txtManagePwd.RelativeLabel = null;
            this.txtManagePwd.Size = new System.Drawing.Size(442, 74);
            this.txtManagePwd.TabIndex = 8;
            // 
            // ManagerLoginWithPwdPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtManagePwd);
            this.Controls.Add(this.lbReturnMsg);
            this.Controls.Add(this.btnManagerLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManagerLoginWithPwdPanel";
            this.Load += new System.EventHandler(this.ManagerLoginWithPwdPanel_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.btnManagerLogin, 0);
            this.Controls.SetChildIndex(this.lbReturnMsg, 0);
            this.Controls.SetChildIndex(this.txtManagePwd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManagerLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnManagerLogin;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbReturnMsg;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtManagePwd;

    }
}
