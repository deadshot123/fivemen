using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms.SimpleLog;

namespace FT.Windows.Forms.NoUser
{
    public class NoUserHelper
    {
        /// <summary>
        /// 需要输入密码才能进行的操作
        /// </summary>
        /// <returns>是否解锁成功</returns>
        public static  bool Unlock()
        {
            Form form = new UnlockSystem();
            form.ShowInTaskbar = true;
            return DialogResult.OK == form.ShowDialog();
        }

        public static void ChangePwd()
        {
            Form form = new ModifyMockUserPwd();
            form.ShowInTaskbar = true;
            form.ShowDialog();
        }

        public static void ClearLogs()
        {
            if (MessageBoxHelper .Confirm("确定要清空全部日志吗？")&& Unlock())
            {
                string sql = "delete from table_custom_log";
                bool result=FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
                if(result)
                {
                    MessageBoxHelper.Show("清空全部日志成功！");
                }
            }
            

        }

        public static void ShowLogs()
        {
             Form form = new Form();
                form.Text = "系统全部日志";
                //form.WindowState = FormWindowState.Maximized;
                form.Size = new System.Drawing.Size(800, 500);
                form.ShowInTaskbar = true;
                CustomLogSearch ctr = new CustomLogSearch();

                ctr.Dock = DockStyle.Fill;
                form.Controls.Add(ctr);
                form.Show();
           
        }

        public static void About()
        {
            SimpleAbout form = new SimpleAbout();
            form.ShowInTaskbar = true;
            form.ShowDialog();
        }

        public static void CheckQuit()
        {
            if (Unlock())
            {
                Application.ExitThread();
            }
        }

        public static void Quit()
        {
            //if (Unlock())
            //{
                Application.ExitThread();
            //}
        }
    }
}
