﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using System.Threading;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class ConfirmPayPwdPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        private List<TicketPrintObject> lists;
        private MovieObject movieInfo;
        private RoomPlanObject roomPlan;
        private MoviePlanObject moviePlan;
        private DateTime dt;

        public ConfirmPayPwdPanel(List<TicketPrintObject> tickets,MovieObject movie,MoviePlanObject moviePlan,RoomPlanObject roomPlan,DateTime dt)
        {
            InitializeComponent();
            this.lists = tickets;
           
            this.movieInfo = movie;
            this.roomPlan = roomPlan;
            this.moviePlan = moviePlan;
            this.dt = dt;
         
        }
        

        private bool allowPay = false;
        private void userInputPanel1_KeyUp(object sender, KeyEventArgs e)
        {
          
            
        }

        private void txtUserPwd_onSubTextChanged()
        {
            string pwd = this.txtUserPwd.Text.Trim();
            if (pwd.Length >= 6)
            {
                allowPay = true;
                this.btnConfirmPay.Image = Properties.Resources.BuyTicket_Btn_Active;
            }
            else
            {
                allowPay = false;
                this.btnConfirmPay.Image = Properties.Resources.BuyTicket_Btn_Not_Active;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            if (this.txtUserPwd.Text != GlobalTools.GetLoginUser().Pwd)
            {
                this.lbMsg.Text = "密码不正确！";
                this.txtUserPwd.Text = string.Empty;
                this.txtUserPwd.Focus();
            }
            else
            {
                this.FindForm().Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalTools.HideAllKeyBoard();
            this.FindForm().Close();
        }

        private void btnConfirmPay_Click_1(object sender, EventArgs e)
        {
            if (allowPay)
            {
#if DEBUG
                UserObject usertmp = GlobalTools.GetLoginUser();
                string pwdtmp = usertmp.Pwd;
#endif
                if (GlobalTools.GetLoginUser().Pwd.Length == 0)
                {
                   UserObject user= HiPiaoOperatorFactory.GetHiPiaoOperator().Login(GlobalTools.GetLoginUser().Name, this.txtUserPwd.Text);
                   if (user != null)
                   {
                       GlobalTools.loginUser = user;
                   }
                   else
                   {
                       this.lbMsg.Text = "密码输入错误！";
                       return;
                   }
                }
                if (this.txtUserPwd.Text != GlobalTools.GetLoginUser().Pwd)
                {
                    this.lbMsg.Text = "密码输入错误！";
                    return;
                }
                this.FindForm().Close();
                //string retCode="1";
                string retCode=HiPiaoCache.UserBuyTicket(GlobalTools.GetLoginUser(), this.lists);
                //<?xml version="1.0" encoding="utf-8"?><root><order res="0" stat="购票失败"  text="场次过期"  phone="4001-099-088" ></order></root>
                //订购成功
                if (retCode == "1")
                {
                    GlobalTools.GetLoginUser().NeedRefresh();
                    GlobalTools.ChangePanel(GlobalTools.MainForm, new WaitTicketPrintPanel(this.lists, this.movieInfo, this.moviePlan));
                    this.FindForm().Close();
                    
                }
                    //订购失败
                else if (retCode.StartsWith("0"))
                {
                    this.FindForm().Close();
                    GlobalTools.Pop(retCode.Substring(1));
                    //GlobalTools.PopNetError();
                }
                    //座位已售出，重新刷座位图
                else if (retCode.StartsWith( "2"))
                {
                    this.FindForm().Close();
                   this.lbMsg.Text="座位已售出，重新选择座位！";
                    GlobalTools.ChangePanel(GlobalTools.MainForm,new MovieSeatSelectorPanel(this.roomPlan,this.movieInfo,this.moviePlan,dt));
                }
                
                
                
            }
        }

        private void ConfirmPayPwdPanel_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(FocusText));
            thread.Start();
        }
        public void FocusText()
        {
            System.Threading.Thread.Sleep(500);
            this.txtUserPwd.Focus();
        }
    }
}
