using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 时间操作工具
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
        /// 获取某个周的星期一
        /// </summary>
        /// <param name="now">周内日期</param>
        /// <returns>星期一</returns>
        public static DateTime GetMonday(DateTime now)
        {
            //周日到周六0-6
            Debug("开始获取"+now.ToShortDateString()+"所在周一的日期");
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
            Debug("获取周一的日期为->"+result.ToShortDateString());
            return result;

        }

        public static DateTime GetSunday()
        {
            return GetSunday(System.DateTime.Now);
        }

        /// <summary>
        /// 获取某个周的星期天
        /// </summary>
        /// <param name="now">周内日期</param>
        /// <returns>星期天</returns>
        public static DateTime GetSunday(DateTime now)
        {
            //周日到周六0-6
            Debug("开始获取" + now.ToShortDateString() + "所在周日的日期");
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
            Debug("获取周日 的日期为->" + result.ToShortDateString());
            return result;
        }
    }
}
