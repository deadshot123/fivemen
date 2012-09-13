﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.Account
{
    public partial class NotifyBindMobilePanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public NotifyBindMobilePanel()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form frm = this.FindForm();
            if (frm != null)
            {
                frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
                frm.Close();
                
            }
           // GlobalTools.ReturnMain();
        }

        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            GlobalTools.ChangePanel(this.FindForm(), new BindMobilePanel());
        }
    }
}
