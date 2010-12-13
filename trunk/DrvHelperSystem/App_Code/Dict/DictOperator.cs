﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL;
using FT.DAL.Orm;

/// <summary>
///DictOperator 的摘要说明
/// </summary>
public class DictOperator
{
    public DictOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<Dict>(id);
    }


    public static DataTable Search(string typename,string key)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_dicts where c_typename like '%" + typename + "%' and c_dict_text like '%"+key+"%'", "tempdb");
    }

    public static void BindDropDownList(string typename,DropDownList ddl)

    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_dicts where c_typename ='" + typename + "'", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_dict_text";
        ddl.DataValueField = "c_dict_value";
        ddl.DataBind();


    }
}
