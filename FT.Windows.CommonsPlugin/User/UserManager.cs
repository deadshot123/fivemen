using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FT.Windows.CommonsPlugin
{
    public class UserManager
    {
        private static User loginUser = null;

        /// <summary>
        /// ��ȡ��½���û�
        /// </summary>
        /// <value>��½���û���Ϣ</value>
        public static User LoginUser
        {
            get { return UserManager.loginUser; }
        }

        public static bool HasLogin()
        {
            return loginUser != null;
        }

        /// <summary>
        /// �û���½
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="pwd">δ���ܵ�����</param>
        /// <returns>�Ƿ��½�ɹ�,0 �����ɹ���1�����������2�����û��������� 3�����˻�������</returns>
        public static int Login(string name, string pwd)
        {

            ArrayList users = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList(typeof(User), " where c_name='"+name+"'");
            if(users.Count>0)
            {
                loginUser = users[0] as User;
                pwd = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(pwd);
                if (loginUser.Valid == "��Ч")
                    return 3;
                else if (pwd == loginUser.Password)
                    return 0;

                else
                    return 1;
            }
            return 2;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public static bool ResetPwd(string newpwd)
        {
            string tmp = loginUser.Password;
            loginUser.Password = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(newpwd);
            bool result= FT.DAL.Orm.SimpleOrmOperator.Update(loginUser);
            if (result)
            {
               
            }
            else
            {
                loginUser.Password = tmp;
                
            }
            return result;
        }

    }
}