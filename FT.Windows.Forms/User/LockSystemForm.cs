using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class LockSystemForm : DevExpress.XtraEditors.XtraForm
    {
        public LockSystemForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string pwd = this.txtPassword.Text.Trim();
            if (pwd.Length == 0)
            {
                MessageBoxHelper.Show("��������δ���룡");
                return;
            }
            User user = UserManager.LoginUser;
            pwd = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(pwd);
            if (user != null && pwd == user.Password)
            {
                this.Close();
            }
            else
            {
                MessageBoxHelper.Show("��������������������룡");
                this.txtPassword.Text = string.Empty;
                this.txtPassword.Focus();
                return;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}