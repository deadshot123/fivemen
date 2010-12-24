﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
using FT.DAL;
using System.Collections;

/// <summary>
///YuyueLimitOperator 的摘要说明
/// </summary>
public class YuyueLimitOperator
{
    public YuyueLimitOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<YuyueLimit>(id);
    }

    public static void Update(YuyueLimit limit)
    {
        SimpleOrmOperator.Update(limit);
    }

    public static YuyueLimit Get(int id)
    {
       return SimpleOrmOperator.Query<YuyueLimit>(id);
    }

    public static void Save(WeekRecord week,int dayofweek,int km,string begindate,string desc)
    {
        if (desc == null || desc.Length == 0)
        {
            return;
        }
        int weeknum = week.WeekNum;
        DateTime begin = DateTime.Parse(begindate);
        ArrayList lists = new ArrayList();
        string[] array1 = desc.Trim("<br/>".ToCharArray()).Split(new string[]{"<br/>"},StringSplitOptions.RemoveEmptyEntries);
        string[] array2 = null;
        string[] array3 = null;
        YuyueLimit limit;
        for (int i = 0; i < array1.Length; i++)
        {
            limit = new YuyueLimit();
            limit.WeekNum = weeknum;
            limit.Operator = week.CheckOperator;
            limit.Ksrq = begin.AddDays(dayofweek-1).ToShortDateString();
            limit.DayOfWeek = dayofweek;
            array2 = array1[i].Split(';');
            array3 = array2[0].Split(':');
            limit.KsddCode = array3[0];
            limit.Ksdd = array3[1];

            array3 = array2[1].Split(':');
            limit.KsccCode = array3[0];
            limit.Kscc = array3[1];

            array3 = array2[2].Split(':');
            limit.SchoolCode = array3[0];
            limit.SchoolName = array3[1];

            limit.Km = km;

            limit.Total =Int32.Parse(array2[3]);
            SimpleOrmOperator.Create(limit);

        }
       // SimpleOrmOperator.Delete<YuyueLimit>(id);
    }


    public static DataTable Search()
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_yuyue_limit ", "tempdb");
    }
}