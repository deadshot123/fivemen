using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// ʱ���������
    /// </summary>
    public class DateTimeHelper : BaseHelper
    {
        public static DateTime GetSeasonFirstDay()
        {
            return GetSeasonFirstDay(System.DateTime.Now);
        }

        public static DateTime GetSeasonFirstDay(DateTime now)
        {
            int month = now.Month;
            DateTime tmp = now;
            if (month <= 3)
            {
                tmp = new DateTime(now.Year, 1, 1);
            }
            else if (month >= 4 && month <= 6)
            {
                tmp = new DateTime(now.Year, 4, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                tmp = new DateTime(now.Year, 7, 1);
            }
            else if (month >= 10 && month <= 12)
            {
                tmp = new DateTime(now.Year , 10, 1);
            }
            return tmp;
        }

        public static DateTime GetSeasonLastDay()
        {
            return GetSeasonLastDay(System.DateTime.Now);
        }

        public static DateTime GetSeasonLastDay(DateTime now)
        {
            int month=now.Month;
            DateTime tmp = now;
            if (month <= 3)
            {
                tmp = new DateTime(now.Year, 4, 1);
            }
            else if (month >= 4 && month <= 6)
            {
                tmp = new DateTime(now.Year, 7, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                tmp = new DateTime(now.Year, 10, 1);
            }
            else if (month >= 10 && month <= 12)
            {
                tmp = new DateTime(now.Year+1, 1, 1);
            }
            return tmp.AddDays(-1);
        }

        public static DateTime GetMonthLastDay()
        {
            return GetMonthLastDay(System.DateTime.Now);
        }

        public static DateTime GetMonthLastDay(DateTime now)
        {
            DateTime tmp = new DateTime(now.Year, now.Month + 1, 1);
            return tmp.AddDays(-1);
        }


        public static DateTime GetMonthFirstDay()
        {
            return GetMonthFirstDay(System.DateTime.Now);
        }

        public static DateTime GetMonthFirstDay(DateTime now)
        {
            return new DateTime(now.Year, now.Month, 1);
        }

        public static DateTime GetMonday()
        {
            return GetMonday(System.DateTime.Now);
        }

        /// <summary>
        /// ��ȡĳ���ܵ�����һ
        /// </summary>
        /// <param name="now">��������</param>
        /// <returns>����һ</returns>
        public static DateTime GetMonday(DateTime now)
        {
            //���յ�����0-6
            Debug("��ʼ��ȡ"+now.ToShortDateString()+"������һ������");
            int i = (int)now.DayOfWeek;
            DateTime result = now;
            if (i == 0)
            {
                result= now.AddDays(-6);
            }
            else if (i != 1)
            {
                result= now.AddDays(0 - i + 1);
            }
            else
            {
                result= now;
            }
            Debug("��ȡ��һ������Ϊ->"+result.ToShortDateString());
            return result;

        }

        public static DateTime GetSunday()
        {
            return GetSunday(System.DateTime.Now);
        }

        /// <summary>
        /// ��ȡĳ���ܵ�������
        /// </summary>
        /// <param name="now">��������</param>
        /// <returns>������</returns>
        public static DateTime GetSunday(DateTime now)
        {
            //���յ�����0-6
            Debug("��ʼ��ȡ" + now.ToShortDateString() + "�������յ�����");
            int i = (int)now.DayOfWeek;
            DateTime result = now;
            if (i != 0)
            {
                result= now.AddDays(7 - i);
            }
            else
            {
                result= now;
            }
            Debug("��ȡ���� ������Ϊ->" + result.ToShortDateString());
            return result;
        }
    }
}