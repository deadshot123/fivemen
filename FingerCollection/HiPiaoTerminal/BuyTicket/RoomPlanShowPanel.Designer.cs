﻿namespace HiPiaoTerminal.BuyTicket
{
    partial class RoomPlanShowPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTimes = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRoomName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // lbTimes
            // 
            this.lbTimes.AutoSize = true;
            this.lbTimes.BackColor = System.Drawing.Color.Transparent;
            this.lbTimes.Font = new System.Drawing.Font("方正兰亭纤黑简体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbTimes.Location = new System.Drawing.Point(15, 14);
            this.lbTimes.Name = "lbTimes";
            this.lbTimes.Size = new System.Drawing.Size(88, 27);
            this.lbTimes.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTimes.TabIndex = 0;
            this.lbTimes.Text = "label1";
            this.lbTimes.Click += new System.EventHandler(this.lbTimes_Click);
            // 
            // lbRoomName
            // 
            this.lbRoomName.AutoSize = true;
            this.lbRoomName.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbRoomName.Location = new System.Drawing.Point(103, 14);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(82, 27);
            this.lbRoomName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRoomName.TabIndex = 0;
            this.lbRoomName.Text = "label1";
            this.lbRoomName.Click += new System.EventHandler(this.lbTimes_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("方正兰亭纤黑简体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(15, 50);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(164, 27);
            this.lbPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Text = "会员价  {0}元";
            this.lbPrice.Click += new System.EventHandler(this.lbTimes_Click);
            // 
            // RoomPlanShowPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_RoomPlan;
            this.Controls.Add(this.lbRoomName);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbTimes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RoomPlanShowPanel";
            this.Size = new System.Drawing.Size(195, 88);
            this.Load += new System.EventHandler(this.RoomPlanShowPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbTimes;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRoomName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPrice;
    }
}
