﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using FT.Commons.Tools;
using HiPiaoTerminal.UserRegister;

namespace HiPiaoTerminal
{
    public partial class QuickRegisterPanel : UserControl
    {
        public QuickRegisterPanel()
        {
            InitializeComponent();
            WinFormHelper.CenterHor(this.btnAgreeAndRegister);
            WinFormHelper.CenterHor(this.btnViewProtocol);
            this.txtUserName.Focus();
        }

        private void QuickRegisterPanel_Load(object sender, EventArgs e)
        {
            //GlobalTools.RegistUpdateUnOperationTime(null);
           // 
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private bool allowRegister;

        

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnReturnButton_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnViewProtocol_Click(object sender, EventArgs e)
        {
            GlobalTools.Pop(new UserNeedKnowInfoPanel());
        }
        /*
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Cursor.Current = Cursors.Default;
                // Cursor.Show();
                this.btnAgreeAndRegister_Click(null, null);
                //this.Close();
               // return true;
            }
            return false;
        }
*/
        // private 

        private void btnAgreeAndRegister_Click(object sender, EventArgs e)
        {
           // this.txtPassword.UnFocus();
          //  this.txtRepeatPwd.UnFocus();
          //  this.txtMobile.UnFocus();
          //  this.txtUserName.UnFocus();
           // GlobalTools.Pop(new UserRegister.UserRegisterSuccessPanel());
           // GlobalTools.PopNetError();
          //  return;
            if (allowRegister)
            {
#if DEBUG
                Console.WriteLine("点击注册按钮开始隐藏小键盘");
#endif
                GlobalTools.HideAllKeyBoard();
                string name = this.txtUserName.Text.Trim();
                string pwd = this.txtPassword.Text.Trim();
                string repeatPwd = this.txtRepeatPwd.Text.Trim();
                string mobile = this.txtMobile.Text.Trim();
                bool result = true;
                this.lbMobileHint.Text = this.lbPasswordHint.Text = this.lbRepeatPwdHint.Text = this.lbUserNameHint.Text = string.Empty;

                if (!ValidatorHelper.ValidateMobile(mobile, false))
                {
                    this.lbMobileHint.Text = "手机号输入错误";
                    this.picMobileHint.Visible = true;
                    this.picMobileHint.Image = Properties.Resources.Error;

                    this.txtPassword.UnFocus();
                    this.txtRepeatPwd.UnFocus();
                    this.txtUserName.UnFocus();
                    this.txtMobile.Focus();
                    result = false;
                    // return;

                }
                else
                {
                    this.lbMobileHint.Text = string.Empty;
                    this.picMobileHint.Image = Properties.Resources.Right;
                }
                /*
                if (!HiPiaoOperatorFactory.GetHiPiaoOperator().CheckUserName(name))
                {
                    this.lbUserNameHint.Text = "你输入的用户名已经存在，请重新输入";
                    this.picUserNameHint.Visible = true;
                    this.picUserNameHint.Image = Properties.Resources.Error;
                    this.txtUserName.Text = string.Empty;
                    result = false;

                }
                else
                {
                    this.lbUserNameHint.Text = string.Empty;
                    this.picUserNameHint.Image = Properties.Resources.Right;
                }
                 * */

                if (!ValidatorHelper.ValidatePostCode(pwd,false))
                {
                    this.lbPasswordHint.Text = "密码只允许6位数字";
                    this.picPasswordHint.Visible = true;
                    this.picPasswordHint.Image = Properties.Resources.Error;
                  
                    this.txtMobile.UnFocus();
                    this.txtRepeatPwd.UnFocus();
                    this.txtUserName.UnFocus();
                    this.txtPassword.Focus();
                    result = false;
                    return;

                }
                else
                {
                    this.lbPasswordHint.Text = string.Empty;
                    this.picPasswordHint.Image = Properties.Resources.Right;
                }

                if (pwd!=repeatPwd)
                {
                    this.lbRepeatPwdHint.Text = "两次输入的密码不一致，请重新输入";
                    this.picRepeatPwdHint.Visible = true;
                    this.picRepeatPwdHint.Image = Properties.Resources.Error;
                    this.txtPassword.Text = this.txtRepeatPwd.Text = string.Empty;
                    
                    this.txtMobile.UnFocus();
                    this.txtRepeatPwd.UnFocus();
                    this.txtUserName.UnFocus();
                    this.txtPassword.Focus();
                    result = false;
                    return;

                }
                else
                {
                    this.lbRepeatPwdHint.Text = string.Empty;
                    this.picRepeatPwdHint.Image = Properties.Resources.Right;
                }

               
                    /*
                else if (!HiPiaoOperatorFactory.GetHiPiaoOperator().CheckMobile(mobile))
                {
                    this.lbMobileHint.Text = "您输入的手机号已经被注册";
                    this.picMobileHint.Visible = true;
                    this.picMobileHint.Image = Properties.Resources.Error;
                    this.txtMobile.Text = string.Empty;
                    result = false;
                }
                else
                {
                    this.lbMobileHint.Text = string.Empty;
                    this.picMobileHint.Image = Properties.Resources.Right;
                }
                     * */
                if (result)
                {
                    string retcode = "0";
                    try
                    {
                        UserObject user = HiPiaoOperatorFactory.GetHiPiaoOperator().Register(name, pwd, mobile, ref retcode);
                        if (user != null)
                        {
                            GlobalTools.loginUser = user;
                            this.txtPassword.UnFocus();
                            this.txtRepeatPwd.UnFocus();
                            this.txtMobile.UnFocus();
                            this.txtUserName.UnFocus();
                            GlobalTools.Pop(new UserRegister.UserRegisterSuccessPanel());
                        }
                        else if (retcode == "2")
                        {
                            this.lbUserNameHint.Text = "你输入的用户名已经存在或者无效，请重新输入";
                            this.picUserNameHint.Visible = true;
                            this.picUserNameHint.Image = Properties.Resources.Error;
                            this.txtUserName.Text = string.Empty;
                            this.txtPassword.UnFocus();
                            this.txtRepeatPwd.UnFocus();
                            this.txtMobile.UnFocus();
                            this.txtUserName.Focus();

                        }
                        else
                        {
                            GlobalTools.PopNetError();
                        }
                    }
                    catch (Exception ex)
                    {
                        GlobalTools.PopNetError();
                    }
                }
            }
        }

        private void txtUserName_onSubTextChanged()
        {
            string name = this.txtUserName.Text.Trim();
            this.txtUserName.Text = this.txtUserName.Text.ToLower().Replace(" ","");
            string pwd = this.txtPassword.Text.Trim();
            string repeatPwd = this.txtRepeatPwd.Text.Trim();
            string mobile = this.txtMobile.Text.Trim();
            if (name.Length > 0 && pwd.Length > 0 && repeatPwd.Length > 0 && mobile.Length > 0)
            {
                allowRegister = true;
                this.btnAgreeAndRegister.BackgroundImage = Properties.Resources.Register_Agree_Ok;
            }
            else
            {
                allowRegister = false;
                this.btnAgreeAndRegister.BackgroundImage = Properties.Resources.Register_Agree_NotOk;
            }
        }

        
        //你输入的用户名已经存在，请重新输入
        //密码只允许6位数字
        //两次输入的密码不一致，请重新输入
        //手机号输入错误
        //您输入的手机号已经被注册

       
    }
}
