﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Web.Tools;

public partial class DriverPreson_Hospital_BusCountByHos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.txtBeginDate.Value.Length == 0 || this.txtEndDate.Value.Length == 0)
        {
            WebTools.Alert(this, "必须选择时间段进行统计！");
            return;
        }
        string sql = "select ";
        if (this.DropDownList1.SelectedIndex == 0)
        {
            sql += "c_hospital as hospital,";
        }
        else
        {
            sql += " c_operator as hospital,";
        }
        sql += " sum(decode(i_state,0,1,0)) as desp1,sum(decode(i_state,1,1,0)) as desp2,0 as desp3,sum(decode(i_state,2,1,0)) as desp4 "
            +" from table_bus_all_info";
        sql+= " where regdate between to_date('" + this.txtBeginDate.Value.Trim() + " 00:00:00','yyyy-MM-dd HH24:mi:ss') and to_date('" + this.txtEndDate.Value.Trim() + " 23:59:59','yyyy-MM-dd HH24:mi:ss')";
        if (this.DropDownList1.SelectedIndex == 0)
        {
            sql += " group by c_hospital";
        }
        else
        {
            sql += " group by c_operator";
        }
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
        this.DataGrid1.DataSource = dt;
        this.DataGrid1.DataBind();
    }
}
